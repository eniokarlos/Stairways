<script setup lang="ts">
import { onBeforeUnmount, ref, reactive, provide } from 'vue';
import RmGrid from './RmGrid.vue';
import RmItem, { RoadmapItem } from './RmItem.vue';
import RmEdge, { RoadmapEdge } from './RmEdge.vue';
import RmSelectedBox from './RmSelectedBox.vue';
import RmItemMenu from './RmItemMenu.vue';
import RmEdgeMenu from './RmEdgeMenu.vue';
import { Anchor, AnchorClickEvent } from './RmAnchors.vue';

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

const svg = ref<SVGSVGElement>();
const selectedItem = ref<RoadmapItem>();
const hoveredItem = ref<RoadmapItem>();
const selectedEdge = ref<RoadmapEdge>();
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

const roadmapItems = defineModel<RoadmapItem[]>('items', { required: true });
const roadmapEdges = ref<RoadmapEdge[]>([]);

function onWheel(evt: WheelEvent) {   
  if (!svg.value) {
    return;
  }
  
  const delta = 0.2 * Math.sign(evt.deltaY);
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

function stopAddEdge() {
  if (addEdgeEvent.value?.endItem && 
  addEdgeEvent.value?.endItemAnchor) {
    
    const newEdge: RoadmapEdge = {
      id: crypto.randomUUID(),
      startItem: addEdgeEvent.value.startItem,
      endItem: addEdgeEvent.value.endItem,
      startItemAnchor: addEdgeEvent.value.startItemAnchor,
      endItemAnchor: addEdgeEvent.value.endItemAnchor,
      format: 'curve',
      style: 'solid',
      selected: false,
    };
    
    roadmapEdges.value.push(newEdge); 
  }
  
  addEdgeEvent.value = undefined;
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
    roadmapEdges.value = roadmapEdges.value.filter(
      edge => edge.startItem.id !== selectedItem.value?.id &&
      edge.endItem.id !== selectedItem.value?.id,
    );
  
    roadmapItems.value = roadmapItems.value.filter(
      (item) => item.id !== selectedItem.value?.id,
    );
    selectedItem.value = undefined;
  }
  else if (selectedEdge.value) {
    roadmapEdges.value = roadmapEdges.value.filter(
      edge => edge.id !== selectedEdge.value!.id,
    );
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

provide('scale', { scale });
provide('roadmapItems', { roadmapItems });
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
      @pointerdown="
        selectedItem = undefined;
        if (selectedEdge) {
          selectedEdge.selected = false;
          selectedEdge = undefined;
        }
      "
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

        <template
          v-for="edge in roadmapEdges"
          :key="edge.id"
        >
          <RmEdge
            :edge="edge"
            @pointerdown.left.stop="
              selectedItem = undefined; 
              selectedEdge = edge;
            "
          />
          
        </template>
        <template
          v-for="item in roadmapItems"
          :key="item.id"
        >
          <RmItem
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

        </template>
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