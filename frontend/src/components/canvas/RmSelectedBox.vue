<script setup lang="ts">
import { alignToGrid } from './Util/alignToGrid';
import { Ref, computed, inject, onBeforeUnmount, watchEffect } from 'vue';
import { RoadmapItem } from './Util/roadmap.interfaces';
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

const alignedBox = computed(() => ({
  id: item.value.id,
  x: alignToGrid(item.value.x),
  y: alignToGrid(item.value.y),
  width: alignToGrid(item.value.width),
  height: alignToGrid(item.value.height),
}));

const scaledBox = computed(() => ({
  x: alignedBox.value.x * scale.value,
  y: alignedBox.value.y * scale.value,
  width: alignedBox.value.width * scale.value,
  height: alignedBox.value.height * scale.value,
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

watchEffect(() => {
  lastMoveEvent = props.event;
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

function resize(dx: number, dy: number) {
  
  if (resizeCorner === 'a' || resizeCorner === 'b') {
    item.value.y += dy;
    item.value.height -= dy;
  }
  
  if (resizeCorner === 'a' || resizeCorner === 'c') {
    item.value.x += dx;
    item.value.width -= dx;
  }
  
  if (resizeCorner === 'b' || resizeCorner === 'd') {
    item.value.width += dx;
  }
  
  if (resizeCorner === 'c' || resizeCorner === 'd') {
    item.value.height += dy;
  }

}

function onKeyDown(e: KeyboardEvent) {

  const setEditingToFalse = () => item.value.editing = false;

  
  const actions = {
    Escape: () => setEditingToFalse(),
    Enter: () => setEditingToFalse(),
    Delete: () => emit('delete'),
  };
  
  const arrowActions = {
    ArrowUp: () => item.value.y -= 8 / scale.value,
    ArrowDown: () => item.value.y += 8 / scale.value,
    ArrowLeft: () => item.value.x -= 8 / scale.value,
    ArrowRight: () => item.value.x += 8 / scale.value,
  };

  try {    
    actions[e.key as keyof typeof actions]();

    if (!item.value.editing){
      arrowActions[e.key as keyof typeof arrowActions]();
    }
  }
  catch {
    return;
  }
}

function startResize(event: PointerEvent, corner: string) {
  lastMoveEvent = event;
  resizeCorner = corner;
}

document.addEventListener('pointermove', onMove);
document.addEventListener('pointerup', stopMove);
document.addEventListener('keydown', onKeyDown);

onBeforeUnmount(() => {
  document.removeEventListener('pointermove', onMove);
  document.removeEventListener('pointerup', stopMove);
  document.removeEventListener('keydown', onKeyDown);
});

</script>

<template>
  <g v-if="anchorsOnly">
    <RmAnchors
      v-model:item="alignedBox"
      @anchor-hover="emit('anchor-hover', $event)"
      @anchor-leave="emit('anchor-leave')"
    />
  </g>
  <g
    v-else
    style="pointer-events: bounding-box"
    @pointerdown.left.stop="startMove"
    @dblclick="item.editing = true"
  >
    <rect
      :width="alignedBox.width * scale"
      :height="alignedBox.height * scale"
      :x="alignedBox.x * scale"
      :y="alignedBox.y * scale"
      fill="none"
      stroke="#009FB7"
      stroke-width="3"
    />
    <RmAnchors
      v-model:item="alignedBox"
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