<script setup lang="ts">
import { Ref, computed, inject, onBeforeUnmount, watchEffect } from 'vue';
import { alignToGrid } from './util';

const props = withDefaults(
  defineProps<{
    cornerBoxSize?: number,
    cornerCircleSize?: number
    event?: PointerEvent
  }>(),
  {
    cornerBoxSize: 10,
    cornerCircleSize: 12,
  }, 
);

const x = defineModel<number>('x', { default: 0 });
const y = defineModel<number>('y', { default: 0 });
const width = defineModel<number>('width', { default: 64 });
const height = defineModel<number>('height', { default: 64 });
const isEditing = defineModel<boolean>('editing');
// const isAddingEdge = defineModel<boolean>('adding-edge');

const emit = defineEmits<{
  (name: 'delete'): void
}>();

const { scale } = inject('canvas') as {
  scale: Ref<number>
};
  
const widthToGrid = computed(() => alignToGrid(width.value * scale.value));
const heightToGrid = computed(() => alignToGrid(height.value * scale.value));

const halfCornerBoxSize = computed(() => props.cornerBoxSize / 2);
const halfCircleSize = computed(() => props.cornerCircleSize / 2);
const cornerA = computed(() => ({
  x: -halfCornerBoxSize.value,
  y: -halfCornerBoxSize.value,
}));
const cornerB = computed(() => ({
  x: (widthToGrid.value - halfCornerBoxSize.value) / 2,
  y: -halfCornerBoxSize.value,
}));
const cornerC = computed(() => ({
  x: widthToGrid.value - halfCornerBoxSize.value,
  y: -halfCornerBoxSize.value,
}));
const cornerD = computed(() => ({
  x: -halfCornerBoxSize.value,
  y: ((heightToGrid.value - props.cornerBoxSize) / 2),
}));
const cornerE = computed(() => ({
  x: widthToGrid.value - halfCircleSize.value,
  y: ((heightToGrid.value - props.cornerCircleSize) / 2),
}));
const cornerF = computed(() => ({
  x: -halfCornerBoxSize.value,
  y: heightToGrid.value - halfCornerBoxSize.value,
}));

const cornerG = computed(() => ({
  x: (widthToGrid.value - halfCornerBoxSize.value) / 2,
  y: heightToGrid.value - halfCornerBoxSize.value,
}));

const cornerH = computed(() => ({
  x: widthToGrid.value - halfCornerBoxSize.value,
  y: heightToGrid.value - halfCornerBoxSize.value,
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
    x.value += dx;
    y.value += dy;
  }

  lastMoveEvent = event;
}

function resize(dx: number, dy: number) {
  
  if (resizeCorner === 'a' || resizeCorner === 'c') {
    y.value += dy;
    height.value -= dy;
  }
  
  if (resizeCorner === 'a' || resizeCorner === 'f') {
    x.value += dx;
    width.value -= dx;
  }
  
  if (resizeCorner === 'c' || resizeCorner === 'h') {
    width.value += dx;
  }
  
  if (resizeCorner === 'f' || resizeCorner === 'h') {
    height.value += dy;
  }

}

document.addEventListener('pointermove', onMove);
document.addEventListener('pointerup', stopMove);
document.addEventListener('keydown', (e) => {
  if (e.key === 'Escape') {
    isEditing.value = false;
  }

  else if (e.key === 'Enter') {
    isEditing.value = false;
  }

  else if (e.key === 'Delete' && !isEditing.value) {
    emit('delete');
  }

  else if (e.key === 'ArrowUp') {
    y.value -= 8 / scale.value;
  }

  else if (e.key === 'ArrowDown') {
    y.value += 8 / scale.value;
  }

  else if (e.key === 'ArrowLeft') {
    x.value -= 8 / scale.value;
  }

  else if (e.key === 'ArrowRight') {
    x.value += 8 / scale.value;
  }
});

onBeforeUnmount(() => {
  document.removeEventListener('pointermove', onMove);
  document.removeEventListener('pointerup', stopMove);
});

function startResize(event: PointerEvent, corner: string) {
  lastMoveEvent = event;
  resizeCorner = corner;
}
</script>

<template>
  <g
    :transform="`translate(${alignToGrid(x) * scale},${alignToGrid(y) * scale})`"
    style="pointer-events: bounding-box"
    @pointerdown.left.stop="startMove"
    @dblclick="isEditing = true"
  >
    <rect
      :width="widthToGrid"
      :height="heightToGrid"
      fill="none"
      stroke="#009FB7"
      stroke-width="2"
    />

    <rect
      v-bind="cornerA"
      :width="cornerBoxSize"
      :height="cornerBoxSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1"
      cursor="nwse-resize"
      @pointerdown.stop="startResize($event, 'a')"
    />

    <rect
      v-bind="cornerB"
      :width="cornerCircleSize"
      :height="cornerCircleSize"
      :rx="cornerCircleSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1"
      cursor="pointer"
      @pointerdown.stop="startResize($event, 'e')"
    />

    <rect
      v-bind="cornerC"
      :width="cornerBoxSize"
      :height="cornerBoxSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1"
      cursor="nesw-resize"
      @pointerdown.stop="startResize($event, 'c')"
    />

    <rect
      v-bind="cornerD"
      :width="cornerCircleSize"
      :height="cornerCircleSize"
      :rx="cornerCircleSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1"
      cursor="pointer"
      @pointerdown.stop="startResize($event, 'e')"
    />

    <rect
      v-bind="cornerE"
      :width="cornerCircleSize"
      :height="cornerCircleSize"
      :rx="cornerCircleSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1"
      cursor="pointer"
      @pointerdown.stop="startResize($event, 'e')"
    />

    <rect
      v-bind="cornerF"
      :width="cornerBoxSize"
      :height="cornerBoxSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1"
      cursor="nesw-resize"
      @pointerdown.stop="startResize($event, 'f')"
    />

    <rect
      v-bind="cornerG"
      :width="cornerCircleSize"
      :height="cornerCircleSize"
      :rx="cornerCircleSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1"
      cursor="pointer"
      @pointerdown.stop="startResize($event, 'e')"
    />

    <rect
      v-bind="cornerH"
      :width="cornerBoxSize"
      :height="cornerBoxSize"
      fill="white"
      stroke="#009FB7"
      stroke-width="1"
      cursor="nwse-resize"
      @pointerdown.stop="startResize($event, 'h')"
    />
  </g>
</template>