<script setup lang="tsx">
import { onBeforeUnmount, ref, reactive } from 'vue';
import RmGrid from './RmGrid.vue';
import RmTopic from './RmTopic.vue';
import CanvasSelectedBox from './selectedBox';

type RoadmapItem = {
  id: string;
  type: string;
  x: number;
  y: number;
  width?: number;
  height?: number;
};

interface RoadmapEvent {
  item: RoadmapItem;
  event: PointerEvent;
}

const lastEvent = ref<RoadmapEvent | undefined>(undefined);
const selectedItem = ref<RoadmapItem | undefined>(undefined);

const scale = ref(1);

const grid = reactive<RoadmapItem>({
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
    },
    {
      id: '1',
      type: 'topic',
      x: 702,
      y: 314,
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

function onPointerDown(e: RoadmapEvent) {
  lastEvent.value = e;
}

function onPointerMove(e: PointerEvent) {
  if (lastEvent.value) {
    const dx = e.clientX - lastEvent.value.event.clientX;
    const dy = e.clientY - lastEvent.value.event.clientY;

    lastEvent.value.item.x += dx / scale.value;
    lastEvent.value.item.y += dy / scale.value;
    lastEvent.value.event = e;
  }
}

function onPointerUp() {
  if (lastEvent.value) {
    lastEvent.value = undefined;
  }
}

document.addEventListener('pointermove', onPointerMove);
document.addEventListener('pointerup', onPointerUp);

onBeforeUnmount(() => {
  document.removeEventListener('pointermove', onPointerMove);
  document.removeEventListener('pointerup', onPointerUp);
});

const mouse = ref({
  x: 0,
  y: 0,
});

function startMove(event: PointerEvent, item: RoadmapItem) {
  onPointerDown({
    item,
    event, 
  });
  selectedItem.value = item;
}
</script>

<template>
  <svg
    class="block"
    width="100%"
    height="100%"
    xmlns="http://www.w3.org/2000/svg"
    @pointerdown.middle="(e) => onPointerDown({ event: e, item: grid })"
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
          :x="item.x"
          :y="item.y"
          @pointerdown.stop="startMove($event, item)"
        />
      </template>
      <CanvasSelectedBox
        v-if="selectedItem"
        :x="selectedItem.x"
        :y="selectedItem.y"
        :width="256"
        :height="64"
        @corner-click="(e) => console.log(e.offsetX)"
      />
    </g>
  </svg>
  <div
    class="canvas-scale absolute bottom-20px right-20px fg-foreground font-500 text-right"
  >
    Zoom: {{ scale.toFixed(2) }}X
  </div>
</template>
