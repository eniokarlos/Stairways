<script setup lang="tsx">
import { onBeforeUnmount, ref, reactive, provide } from 'vue';
import RmGrid from './RmGrid.vue';
import RmTopic from './RmTopic.vue';
import RmEdge from './RmEdge.vue';
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

interface RoadmapEdge{
  start: {x:number,y:number},
  end: {x:number,y:number},
  format?: 'line' | 'curve',
  style?: 'solid' | 'dashed' | 'dotted',
  direction: 'lineX' | 'lineY'
}

const svg = ref<SVGSVGElement>();
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

const roadmap = ref<{
  items: RoadmapItem[],
  edges: RoadmapEdge[]
}>({
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
  edges: [],
});

function onWheel(evt: WheelEvent) {   
  if (!svg.value) {
    return;
  }

  const delta = 0.4 * Math.sign(evt.deltaY);
  const point = svg.value.createSVGPoint();
  point.x = evt.clientX;
  point.y = evt.clientY;

  const scaleBefore = scale.value;
  const scaleAfter = Math.max(0.2, Math.min(5, scale.value - delta));

  scale.value = scaleAfter;

  const scalePoint = point.matrixTransform(svg.value.getScreenCTM()?.inverse());
  const scaleDelta = (scaleAfter / scaleBefore) - 1;

  grid.x -= (scalePoint.x - grid.x) * scaleDelta;
  grid.y -= (scalePoint.y - grid.y) * scaleDelta;
}

function startGridMove(e: PointerEvent) {
  lastEvent.value = e;
}

function moveGrid(e: PointerEvent) {
  if (lastEvent.value) {
    const dx = e.clientX - lastEvent.value.clientX;
    const dy = e.clientY - lastEvent.value.clientY;

    grid.x += dx;
    grid.y += dy;
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

provide('canvas', { scale });
</script>

<template>
  <svg
    ref="svg"
    class="block select-none"
    width="100%"
    height="100%"
    xmlns="http://www.w3.org/2000/svg"
    @pointerdown.middle="startGridMove"
    @wheel.prevent="onWheel"
    @pointerdown="selectedItem = undefined"
  >
    
    <RmGrid
      grid-id="grid"
      :x="grid.x"
      :y="grid.y"
      :scale="scale"
    />

    <g :transform="`translate(${grid.x}, ${grid.y}) scale(${scale})`">
      <template v-for="edge in roadmap.edges">
        <RmEdge />
      </template>

      <template v-for="item in roadmap.items">
        <RmTopic
          v-if="item.type === 'topic'"
          :key="item.id"
          v-model:editing="item.editing"
          :x="item.x"
          :y="item.y"
          :width="item.width"
          :height="item.height"
          @pointerdown.left.stop="selectedItem = item, selectionEvent = $event"
        />
      </template>
    </g>
    <g
      v-if="selectedItem"
      :transform="`translate(${grid.x}, ${grid.y})`"
    >
      <RmSelectedBox
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
