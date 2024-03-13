<script setup lang="tsx">
import { onBeforeUnmount, ref, reactive, provide } from 'vue';
import RmGrid from './RmGrid.vue';
import RmTopic from './RmTopic.vue';
import RmSelectedBox from './RmSelectedBox.vue';

interface Point {
  x: number;
  y: number;
}

interface BoundingBox extends Point {
  width: number;
  height: number;
}

interface RoadmapItem extends BoundingBox {
  id: string;
  type: string;
  editing?: boolean;
}


const lastEvent = ref<PointerEvent>();
const selectedItem = ref<RoadmapItem>();
const selectionEvent = ref<PointerEvent>();

const scale = ref(1);

const grid = reactive({
  id: '9',
  type: 'grid',
  x: 0,
  y: 0,
});

const roadmap = ref<Record<string, RoadmapItem[]>>({
  items: [
    {
      id: '0',
      type: 'topic',
      x: 510,
      y: 63,
      width: 256,
      height: 64,
    },
    {
      id: '1',
      type: 'topic',
      x: 702,
      y: 314,
      width: 256,
      height: 64,
    },
  ],
});

function onWheel(e: WheelEvent) {
  e.preventDefault();
  const scaleFactor = 0.2;

  if (e.deltaY < 0 && scale.value + scaleFactor < 2) {
    scale.value += scaleFactor;
  }
  else if (e.deltaY > 0 && scale.value - scaleFactor > 0.4) {
    scale.value -= scaleFactor;
  }
}

function startGridMove(e: PointerEvent) {
  lastEvent.value = e;
}

function moveGrid(e: PointerEvent) {
  if (lastEvent.value) {
    const dx = e.clientX - lastEvent.value.clientX;
    const dy = e.clientY - lastEvent.value.clientY;

    grid.x += dx / scale.value;
    grid.y += dy / scale.value;
    lastEvent.value = e;
  }
}

function stopGridMove() {
  if (lastEvent.value) {
    lastEvent.value = undefined;
  }
}

document.addEventListener('pointermove', moveGrid);
document.addEventListener('pointerup', stopGridMove);

onBeforeUnmount(() => {
  document.removeEventListener('pointermove', moveGrid);
  document.removeEventListener('pointerup', stopGridMove);
});

const mouse = ref({
  x: 0,
  y: 0,
});

provide('canvas', { scale });
</script>

<template>
  <svg
    class="block select-none"
    width="100%"
    height="100%"
    xmlns="http://www.w3.org/2000/svg"
    @pointerdown.middle="startGridMove"
    @pointerdown.left="startGridMove"
    @wheel="onWheel"
    @pointermove="mouse = { x: $event.x, y: $event.y }"
    @pointerdown="selectedItem = undefined"
  >
  
    <RmGrid
      grid-id="grid"
      :x="grid.x"
      :y="grid.y"
      :scale="scale"
    />
    <g :transform="`translate(${grid.x}, ${grid.y}) scale(${scale})`">
      <template v-for="item in roadmap.items">
        <RmTopic
          v-if="item.type === 'topic'"
          :key="item.id"
          v-model:editing="item.editing"
          :x="item.x"
          :y="item.y"
          :width="item.width"
          :height="item.height"
          @pointerdown.stop="selectedItem = item, selectionEvent = $event"
        />
      </template>
      <RmSelectedBox
        v-if="selectedItem"
        v-model:x="selectedItem.x"
        v-model:y="selectedItem.y"
        v-model:width="selectedItem.width"
        v-model:height="selectedItem.height"
        v-model:editing="selectedItem.editing"
        :event="selectionEvent"
        @delete="roadmap.items = roadmap.items.filter((item) => item.id !== selectedItem?.id), selectedItem = undefined"
      />
    </g>
  </svg>
  <div
    class="canvas-scale absolute bottom-20px right-20px fg-foreground font-500 text-right"
  >
    Zoom: {{ scale.toFixed(2) }}X
  </div>
</template>
