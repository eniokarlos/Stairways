<script setup lang="ts">
import { alignToGrid } from './Util/alignToGrid';
import { Ref, computed, inject, onBeforeUnmount, watch, watchEffect } from 'vue';
import { BoundingBox, RoadmapItem } from './RmItem.vue';
import RmAnchors, { AnchorClickEvent, AnchorDropEvent } from './RmAnchors.vue';

const props = withDefaults(
  defineProps<{
    anchorsOnly?: boolean
    cornerBoxSize?: number,
    event?: PointerEvent
  }>(),
  { cornerBoxSize: 12 }, 
);

const item = defineModel<RoadmapItem>('item', { required: true });

const emit = defineEmits<{
  (name: 'delete'): void,
  (name: 'anchor-click', value: AnchorClickEvent): void,
  (name: 'anchor-hover', value: AnchorDropEvent): void,
  (name: 'anchor-leave'): void
}>();

const { scale } = inject('scale') as {
  scale: Ref<number>
};
  
const scaledCornerBoxSize = computed(() => props.cornerBoxSize);
const halfCornerBoxSize = computed(() => scaledCornerBoxSize.value/2);

const alignedBox = computed<BoundingBox>(() => ({
  x: alignToGrid(item.value.x) * scale.value,
  y: alignToGrid(item.value.y) * scale.value,
  width: alignToGrid(item.value.width) * scale.value,
  height: alignToGrid(item.value.height) * scale.value,
}));

const cornerA = computed(() => ({
  x: alignedBox.value.x - halfCornerBoxSize.value,
  y: alignedBox.value.y - halfCornerBoxSize.value,
}));

const cornerB = computed(() => ({
  x: alignedBox.value.x + alignedBox.value.width - halfCornerBoxSize.value,
  y: alignedBox.value.y - halfCornerBoxSize.value,
}));

const cornerC = computed(() => ({
  x: alignedBox.value.x - halfCornerBoxSize.value,
  y: alignedBox.value.y + alignedBox.value.height - halfCornerBoxSize.value,
}));

const cornerD = computed(() => ({
  x: alignedBox.value.x + alignedBox.value.width - halfCornerBoxSize.value,
  y: alignedBox.value.y + alignedBox.value.height - halfCornerBoxSize.value,
}));

let lastMoveEvent: PointerEvent | undefined;
let resizeCorner: string | undefined;

watchEffect(() => {
  lastMoveEvent = props.event;
});

watch(() => ({
  height: alignedBox.value.height,
  width: alignedBox.value.width,
}),
(newValue, oldValue) => {
  if (resizeCorner === 'a') {
    item.value.y -= newValue.height - oldValue.height;
    item.value.x -= newValue.width - oldValue.width;
  }
  else if (resizeCorner === 'b') {
    item.value.y -= newValue.height - oldValue.height;
  }
  else if (resizeCorner === 'c') {
    item.value.x -= newValue.width - oldValue.width;
  }
});

function startMove(event: PointerEvent) {
  lastMoveEvent = event;
}

function stopMove() {
  lastMoveEvent = undefined;
  resizeCorner = undefined;
}

function onMove(event: PointerEvent) {
  if (!lastMoveEvent) {
    return;
  }

  const dx = (event.x - lastMoveEvent.x) / scale.value;
  const dy = (event.y - lastMoveEvent.y) / scale.value;

  if (resizeCorner) {
    resize(dx, dy);
  }

  else {
    item.value.x += dx;
    item.value.y += dy;
  }

  lastMoveEvent = event;
}

function startResize(event: PointerEvent, corner: string) {
  lastMoveEvent = event;
  resizeCorner = corner;
}

function resize(dx: number, dy: number) {
  
  if (resizeCorner === 'a' || resizeCorner === 'b') {
    item.value.height -= dy;
  }
  
  if (resizeCorner === 'a' || resizeCorner === 'c') {
    item.value.width -= dx;
  }
  
  if (resizeCorner === 'b' || resizeCorner === 'd') {
    item.value.width += dx;
  }
  
  if (resizeCorner === 'c' || resizeCorner === 'd') {
    item.value.height += dy;
  }

}

document.addEventListener('pointermove', onMove);
document.addEventListener('pointerup', stopMove);

onBeforeUnmount(() => {
  document.removeEventListener('pointermove', onMove);
  document.removeEventListener('pointerup', stopMove);
});

</script>

<template>
  <g v-if="anchorsOnly">
    <RmAnchors
      v-model:box="alignedBox"
      @anchor-hover="emit('anchor-hover', $event)"
      @anchor-leave="emit('anchor-leave')"
    />
  </g>
  <g
    v-else
    style="pointer-events: bounding-box"
    @pointerdown.left.stop="startMove"
  >
    <rect
      :width="alignedBox.width"
      :height="alignedBox.height"
      :x="alignedBox.x"
      :y="alignedBox.y"
      fill="none"
      stroke="#009FB7"
      stroke-width="3"
    />
    <RmAnchors
      v-model:box="alignedBox"
      @anchor-click="emit('anchor-click', $event)"
      @anchor-hover="emit('anchor-hover', $event)"
    />
    <rect
      v-bind="cornerA"
      :width="cornerBoxSize"
      :height="cornerBoxSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1.5"
      cursor="nwse-resize"
      @pointerdown.stop="startResize($event, 'a')"
    />

    <rect
      v-bind="cornerB"
      :width="cornerBoxSize"
      :height="cornerBoxSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1.5"
      cursor="nesw-resize"
      @pointerdown.stop="startResize($event, 'b')"
    />

    <rect
      v-bind="cornerC"
      :width="cornerBoxSize"
      :height="cornerBoxSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1 / scale"
      cursor="nesw-resize"
      @pointerdown.stop="startResize($event, 'c')"
    />

    <rect
      v-bind="cornerD"
      :width="cornerBoxSize"
      :height="cornerBoxSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1.5"
      cursor="nwse-resize"
      @pointerdown.stop="startResize($event, 'd')"
    />
  </g>
</template>