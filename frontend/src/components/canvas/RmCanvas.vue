<script setup lang="tsx">
import { RoadmapItem, RoadmapEdge, Point, Anchor, EdgeDirection } from './Util/roadmap.interfaces';
import { onBeforeUnmount, ref, reactive, provide, PropType } from 'vue';
import RmGrid from './RmGrid.vue';
import RmTopic from './RmTopic.vue';
import RmEdge from './RmEdge.vue';
import RmSelectedBox from './RmSelectedBox.vue';
import RmEditingMenu from './RmEditingMenu.vue';
import { AnchorClickEvent } from './RmAnchors.vue';

export interface AddEdgeEvent{
  lastEvent?: PointerEvent
  start: Point,
  end: Point,
  direction?: EdgeDirection
  startItemId: string,
  endItemId?: string,
  startItemAnchor: Anchor
  endItemAnchor?: Anchor
}

export interface GridMoveEvent{
  event: PointerEvent,
  grid: Point
}

const props = defineProps({
  items: {
    type: Array as PropType<RoadmapItem[]>,
    required: true, 
  },
});

const svg = ref<SVGSVGElement>();
const selectedItem = ref<RoadmapItem>();
const hoveredItem = ref<RoadmapItem>();
const lastEvent = ref<PointerEvent>();
const selectionEvent = ref<PointerEvent>();
const addEdgeEvent = ref<AddEdgeEvent| undefined>();

const emit = defineEmits<{
  (name: 'on-move', data: GridMoveEvent): void,
  (name: 'on-enter', data: GridMoveEvent): void
}>();

const scale = defineModel('scale', { 
  type: Number,
  required: true,
});

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
  items: props.items,
  edges: [],
});


function onWheel(evt: WheelEvent) {   
  if (!svg.value) {
    return;
  }
  
  const delta = 0.5 * Math.sign(evt.deltaY);
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

function startAddEdge(e: AnchorClickEvent) {
  if (!selectedItem.value) {
    return;
  }
  
  addEdgeEvent.value = {
    start: {
      x: e.anchor.cx / scale.value,
      y: e.anchor.cy / scale.value,
    },
    end: {
      x: e.anchor.cx / scale.value,
      y: e.anchor.cy / scale.value,
    },
    startItemId: selectedItem.value.id,
    startItemAnchor: e.anchor.id,
  };
  
  addEdgeEvent.value.lastEvent = e.event;
  
}

function onMove(e: PointerEvent) {
  emit('on-move', {
    event: e,
    grid, 
  });
  
  if (lastEvent.value) {
    const dx = e.clientX - lastEvent.value.clientX;
    const dy = e.clientY - lastEvent.value.clientY;
    
    grid.x += dx;
    grid.y += dy;
    lastEvent.value = e;
  }
  
  else if (addEdgeEvent.value && addEdgeEvent.value.lastEvent) {
    const dx = e.clientX - addEdgeEvent.value.lastEvent.clientX;
    const dy = e.clientY - addEdgeEvent.value.lastEvent.clientY;
    
    addEdgeEvent.value.end.x += dx / scale.value;
    addEdgeEvent.value.end.y += dy / scale.value;
    
    addEdgeEvent.value.lastEvent = e;
  }
}

function stopGridMove() {
  if (lastEvent.value) {
    lastEvent.value = undefined;
  }
}

function stopAddEdge() {
  if (addEdgeEvent.value?.endItemId && 
  addEdgeEvent.value?.endItemAnchor) {
    
    roadmap.value.edges.push({
      id: crypto.randomUUID(),
      startItemId: addEdgeEvent.value.startItemId,
      endItemId: addEdgeEvent.value.endItemId,
      startItemAnchor: addEdgeEvent.value.startItemAnchor,
      endItemAnchor: addEdgeEvent.value.endItemAnchor,
      direction: addEdgeEvent.value.direction,
    });
  }
  
  addEdgeEvent.value = undefined;
}

document.addEventListener('pointermove', onMove);
document.addEventListener('pointerup', stopGridMove);
document.addEventListener('pointerup', stopAddEdge);

onBeforeUnmount(() => {
  document.removeEventListener('pointermove', onMove);
  document.removeEventListener('pointerup', stopGridMove);
});

provide('scale', { scale });
provide('roadmap', { roadmap });
</script>

<template>
  <div class="relative h-full w-full">
    <svg
      ref="svg"
      class="block select-none"
      width="100%"
      height="100%"
      xmlns="http://www.w3.org/2000/svg"
      @pointerdown.middle="startGridMove"
      @wheel.prevent="onWheel"
      @pointerenter="emit('on-enter', {event: $event, grid: {x: grid.x, y: grid.y}})"
      @pointerdown="selectedItem = undefined"
    >
    
      <RmGrid
        grid-id="grid"
        :x="grid.x"
        :y="grid.y"
        :scale="scale"
      />

      <g :transform="`translate(${grid.x}, ${grid.y}) scale(${scale})`">

        <g v-if="addEdgeEvent">
          <path
            v-if="addEdgeEvent.direction === 'lineY'"
            :d="`M${addEdgeEvent.start.x},${addEdgeEvent.start.y} 
          C${addEdgeEvent.start.x},${(addEdgeEvent.start.y + addEdgeEvent.end.y) / 2} 
          ${addEdgeEvent.end.x},${(addEdgeEvent.end.y + addEdgeEvent.end.y) / 2} 
          ${addEdgeEvent.end.x},${addEdgeEvent.end.y}`"
            fill="none"
            stroke="#009FB780"
            stroke-width="4"
          />
          <path 
            v-else
            :d="`M${addEdgeEvent.start.x},${addEdgeEvent.start.y} 
          C${(addEdgeEvent.start.x + addEdgeEvent.end.x) / 2},${addEdgeEvent.start.y} 
          ${(addEdgeEvent.start.x + addEdgeEvent.end.x) / 2},${addEdgeEvent.end.y} 
          ${addEdgeEvent.end.x},${addEdgeEvent.end.y}`"
            fill="none"
            stroke="#009FB780"
            stroke-width="4"
          />
        </g>

        <template
          v-for="edge in roadmap.edges"
          :key="edge.id"
        >
          <RmEdge
            :id="edge.id"
            :start-item-id="edge.startItemId"
            :end-item-id="edge.endItemId" 
            :start-item-anchor="edge.startItemAnchor"
            :end-item-anchor="edge.endItemAnchor"
            :direction="edge.direction"
            :style="edge.style"
          />
        </template>
        <template
          v-for="item in roadmap.items"
          :key="item.id"
        >
          <RmTopic
            v-if="item.type === 'topic'"
            :id="item.id"
            :x="item.x"
            :y="item.y"
            :width="item.width"
            :height="item.height"
            @pointerdown.left.stop="selectedItem = item, selectionEvent = $event"
            @mouseenter="hoveredItem = item"
          />
        </template>
      </g>
      <g
        v-if="selectedItem"
        :transform="`translate(${grid.x}, ${grid.y})`"
      >
        <RmSelectedBox
          v-model:item="selectedItem"
          :event="selectionEvent"
          @delete="roadmap.items = roadmap.items.filter((item) => item.id !== selectedItem?.id), selectedItem = undefined"
          @anchor-click="startAddEdge"
        />

        <RmSelectedBox 
          v-if="hoveredItem && hoveredItem.id !== selectedItem.id
            && addEdgeEvent"
          v-model:item="hoveredItem"
          anchors-only

          @anchor-leave="if (addEdgeEvent) {
            addEdgeEvent.endItemId = undefined;
            addEdgeEvent.endItemAnchor = undefined;
          };"

          @anchor-hover="if (addEdgeEvent) {
            addEdgeEvent.endItemId = hoveredItem.id;
            addEdgeEvent.endItemAnchor = $event.anchorId
          };"
        />
      </g>
    </svg>
    <div 
      class="canvas-scale absolute bottom-20px right-20px fg-foreground font-500 text-right"
    >
      Zoom: {{ scale.toFixed(2) }}X 
    </div>
    <RmEditingMenu />
  </div>
</template>