<script setup lang="ts">
import { onBeforeUnmount, ref, reactive, provide, watchEffect } from 'vue';
import RmGrid from './RmGrid.vue';
import RmItem, { RoadmapItem } from './RmItem.vue';
import RmEdge, { RoadmapEdge } from './RmEdge.vue';
import RmSelectedBox from './RmSelectedBox.vue';
import RmItemMenu from './RmItemMenu.vue';
import RmEdgeMenu from './RmEdgeMenu.vue';
import { Anchor, AnchorClickEvent } from './RmAnchors.vue';
import { useRoadmapStore } from '@/stores/roadmap.store';
import getItemContentHash from './Util/getItemContentHash';
import { RoadmapContent } from '@/services/roadmap.services';

export type RoadmapLevel = 0 | 1 | 2;

export interface Roadmap {
  meta: {
    title: string,
    description: string,
    categoryId: string,
    privacy: 0 | 1,
    imageURL: string,
    level: RoadmapLevel,
  },
  items: RoadmapItem[],
  edges: RoadmapEdge[]
}

export interface Point {
  x: number,
  y: number,
}

export interface AddEdgeEvent{
  lastEvent?: PointerEvent
  sketchLineStart: Point,
  sketchLineEnd: Point,
  startItem: RoadmapItem,
  endItem?: RoadmapItem,
  startItemAnchor: Anchor
  endItemAnchor?: Anchor
}

export interface GridMoveEvent{
  event: PointerEvent,
  grid: Point
}

const props = defineProps({
  isOnPublish: {
    type: Boolean,
    default: false,
  },
});

const svg = ref<SVGSVGElement>();
const rmStore = useRoadmapStore();
const selectedItem = ref<RoadmapItem>();
const hoveredItem = ref<RoadmapItem>();
const selectedEdge = ref<RoadmapEdge>();
const lastEvent = ref<PointerEvent>();
const selectionEvent = ref<PointerEvent>();
const addEdgeEvent = ref<AddEdgeEvent | undefined>();

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

function onWheel(event: WheelEvent) {   
  if (!svg.value) {
    return;
  }
  
  const delta = 0.2 * Math.sign(event.deltaY);
  const point = svg.value.createSVGPoint();
  point.x = event.clientX;
  point.y = event.clientY;
  
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
    sketchLineStart: {
      x: e.anchor.cx / scale.value,
      y: e.anchor.cy / scale.value,
    },
    sketchLineEnd: {
      x: e.anchor.cx / scale.value,
      y: e.anchor.cy / scale.value,
    },
    startItem: selectedItem.value,
    startItemAnchor: e.anchor.id,
  };
  
  addEdgeEvent.value.lastEvent = e.event;
}

function stopAddEdge() {
  if (addEdgeEvent.value?.endItem && 
  addEdgeEvent.value?.endItemAnchor) {
    
    const newEdge: RoadmapEdge = {
      id: crypto.randomUUID(),
      startItemId: addEdgeEvent.value.startItem.id,
      endItemId: addEdgeEvent.value.endItem.id,
      startItemAnchor: addEdgeEvent.value.startItemAnchor,
      endItemAnchor: addEdgeEvent.value.endItemAnchor,
      format: 'curve',
      style: 'solid',
      selected: false,
    };
    
    rmStore.roadmap.edges.push(newEdge); 
  }
  
  addEdgeEvent.value = undefined;
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
    
    addEdgeEvent.value.sketchLineEnd.x += dx / scale.value;
    addEdgeEvent.value.sketchLineEnd.y += dy / scale.value;
    
    addEdgeEvent.value.lastEvent = e;
  }
}

function stopGridMove() {
  if (lastEvent.value) {
    lastEvent.value = undefined;
  }
}

function deleteItem(e: KeyboardEvent) {
  if (e.key !== 'Delete' && e.key !== 'Backspace') {
    return;
  }

  if (document.activeElement?.tagName === 'INPUT' ||
    document.activeElement?.tagName === 'TEXTAREA'
  ) {
    return;
  }

  if (selectedItem.value) {
    const edges = rmStore.roadmap.edges.filter(
      edge => edge.startItemId !== selectedItem.value?.id &&
      edge.endItemId !== selectedItem.value?.id,
    );
    
    const items = rmStore.roadmap.items.filter(
      (item) => item.id !== selectedItem.value?.id,
    );

    rmStore.roadmap.items = items;
    rmStore.roadmap.edges = edges;

    selectedItem.value = undefined;
  }
  else if (selectedEdge.value) {
    const edges = rmStore.roadmap.edges.filter(
      edge => edge.id !== selectedEdge.value!.id,
    );

    rmStore.roadmap.edges = edges;
  }
}

function setRenderFormat(){
  if (!svg.value) {
    return;
  }
  const res: RoadmapContent = {
    items: [],
    edges: [], 
  };

  res.items = rmStore.roadmap.items.map(i => ({
    id: crypto.randomUUID(),
    signature: getItemContentHash(i.content),
    x: i.x,
    y: i.y,
    content: i.content,
    height: i.height,
    width: i.width,
    label: i.label,
    labelSize: i.labelSize,
    labelWidth: i.labelWidth,
    type: i.type,
    linkTo: i.linkTo,
  }));
  const edges = svg.value.getElementsByClassName('edge');
  res.edges = Array.from(edges).map(
    (e) => { 
      return {
        path: e.getAttribute('d')!.replace(/(\s+|\r\n|\n|\r)/gm, ' '),
        style: e.classList[1],
      };
    },
  );
  rmStore.toBePublished.edges = res.edges;
  rmStore.toBePublished.items = res.items;
}

function clear() {
  selectedItem.value = undefined;
  if (selectedEdge.value) {
    selectedEdge.value.selected = false;
    selectedEdge.value = undefined;
  }
}

document.addEventListener('pointermove', onMove);
document.addEventListener('pointerup', stopGridMove);
document.addEventListener('pointerup', stopAddEdge);
document.addEventListener('keydown', deleteItem);

onBeforeUnmount(() => {
  document.removeEventListener('pointermove', onMove);
  document.removeEventListener('pointerup', stopGridMove);
  document.removeEventListener('pointerup', stopAddEdge);
  document.removeEventListener('keydown', deleteItem);
});

watchEffect(() => {
  if (props.isOnPublish) {
    setRenderFormat();
  }
});

provide('scale', { scale });
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
      @pointerenter="emit('on-enter', {event: $event, grid: {x: grid.x, y: grid.y}});"
      @pointerdown="clear"
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
            :d="`M${addEdgeEvent.sketchLineStart.x},${addEdgeEvent.sketchLineStart.y} 
          C${addEdgeEvent.sketchLineStart.x},${(addEdgeEvent.sketchLineStart.y + addEdgeEvent.sketchLineEnd.y) / 2} 
          ${addEdgeEvent.sketchLineEnd.x},${(addEdgeEvent.sketchLineEnd.y + addEdgeEvent.sketchLineEnd.y) / 2} 
          ${addEdgeEvent.sketchLineEnd.x},${addEdgeEvent.sketchLineEnd.y}`"
            fill="none"
            stroke="#009FB780"
            stroke-width="4"
          />
        </g>

        <RmEdge
          v-for="edge in rmStore.roadmap.edges"
          :key="edge.id"
          :edge="edge"
          @pointerdown.left.stop="
            selectedItem = undefined; 
            selectedEdge = edge;
          "
        />
        
        <RmItem
          v-for="item in rmStore.roadmap.items"
          :key="item.id"
          :item="item"
          @pointerdown.left.stop="
            selectedItem = item; 
            selectionEvent = $event;
            if (selectedEdge) {
              selectedEdge.selected = false;
              selectedEdge = undefined;
            };"
          @mouseenter="hoveredItem = item"
        />

      </g>
      <g
        v-if="selectedItem"
        :transform="`translate(${grid.x}, ${grid.y})`"
      >
        <RmSelectedBox
          v-model:item="selectedItem"
          :event="selectionEvent"
          @anchor-click="startAddEdge"
        />

        <RmSelectedBox 
          v-if="hoveredItem && hoveredItem.id !== selectedItem.id
            && addEdgeEvent"
          v-model:item="hoveredItem"
          anchors-only
          @anchor-leave="if (addEdgeEvent) {
            addEdgeEvent.endItem = undefined;
            addEdgeEvent.endItemAnchor = undefined;
          };"

          @anchor-hover="if (addEdgeEvent) {
            addEdgeEvent.endItem = hoveredItem;
            addEdgeEvent.endItemAnchor = $event.anchorId
          };"
        />
      </g>
    </svg>
    <div 
      class="canvas-scale absolute bottom-20px left-20px fg-foreground font-500 text-right"
    >
      Zoom: {{ scale.toFixed(2) }}X 
    </div>
    <RmItemMenu
      v-if="selectedItem" 
      v-model="selectedItem"
    />
    <RmEdgeMenu 
      v-if="selectedEdge"
      v-model="selectedEdge"
    />
  </div>
</template>