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
  (name: 'anchor-click', value: AnchorClickEvent): void,
  (name: 'anchor-hover', value: AnchorDropEvent): void,
  (name: 'anchor-leave'): void
}>();

const { scale } = inject('scale') as {
  scale: Ref<number>
};
  
const scaledCornerBoxSize = computed(() => props.cornerBoxSize);
const halfCornerBoxSize = computed(() => scaledCornerBoxSize.value/2);

const scaledBox = computed<BoundingBox>(() => ({
  x: item.value.x * scale.value,
  y: item.value.y * scale.value,
  width: item.value.width * scale.value,
  height: item.value.height * scale.value,
}));

const cornerA = computed(() => ({
  x: scaledBox.value.x - halfCornerBoxSize.value,
  y: scaledBox.value.y - halfCornerBoxSize.value,
}));

const cornerB = computed(() => ({
  x: scaledBox.value.x + scaledBox.value.width - halfCornerBoxSize.value,
  y: scaledBox.value.y - halfCornerBoxSize.value,
}));

const cornerC = computed(() => ({
  x: scaledBox.value.x - halfCornerBoxSize.value,
  y: scaledBox.value.y + scaledBox.value.height - halfCornerBoxSize.value,
}));

const cornerD = computed(() => ({
  x: scaledBox.value.x + scaledBox.value.width - halfCornerBoxSize.value,
  y: scaledBox.value.y + scaledBox.value.height - halfCornerBoxSize.value,
}));

let lastMoveEvent: PointerEvent | undefined;
let resizeCorner: string | undefined;

const alignedMoveEvent = () => {
  if (lastMoveEvent) {
    return {
      x: alignToGrid(lastMoveEvent.x / scale.value),
      y: alignToGrid(lastMoveEvent.y / scale.value),
    };
  }
};

watchEffect(() => {
  lastMoveEvent = props.event;
});

watch(() => ({
  height: scaledBox.value.height,
  width: scaledBox.value.width,
}),
(newValue, oldValue) => {
  const dx = (newValue.width - oldValue.width) / scale.value;
  const dy = (newValue.height - oldValue.height) / scale.value;

  if (resizeCorner === 'a') {
    item.value.y -= dy;
    item.value.x -= dx;
  }
  else if (resizeCorner === 'b') {
    item.value.y -= dy;
  }
  else if (resizeCorner === 'c') {
    item.value.x -= dx;
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
  const alignedMove = alignedMoveEvent();
  const dx = (alignToGrid(event.x / scale.value) - alignedMove!.x);
  const dy = (alignToGrid(event.y / scale.value) - alignedMove!.y); 

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
      v-model:box="scaledBox"
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
      :width="scaledBox.width"
      :height="scaledBox.height"
      :x="scaledBox.x"
      :y="scaledBox.y"
      fill="none"
      stroke="#009FB7"
      stroke-width="3"
    />
    <RmAnchors
      v-model:box="scaledBox"
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