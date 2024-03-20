<script setup lang="ts">
import { Ref, computed, inject } from 'vue';
import { RoadmapEdge, RoadmapItem } from './Util/roadmap.interfaces';
import { alignToGrid } from './Util/alignToGrid';


const props = withDefaults(
  defineProps<RoadmapEdge>(),
  {
    format: 'curve',
    style: 'solid',
  },
);

const { roadmap } = inject('roadmap') as {
  roadmap: Ref<{
    items: RoadmapItem[],
    edges: RoadmapEdge[]
  }>
};

const anchorOffset = 4;
const anchorsCords = {
  top: (item: RoadmapItem) => ({
    x: item.x + item.width/2,
    y: item.y + anchorOffset,
  }),
  right: (item: RoadmapItem) => ({
    x: item.x + item.width - anchorOffset,
    y: item.y + item.height/2,
  }),
  bottom: (item: RoadmapItem) => ({
    x: item.x + item.width/2,
    y: item.y + item.height - anchorOffset,
  }),
  left: (item: RoadmapItem) => ({
    x: item.x + anchorOffset,
    y: item.y + item.height/2,  
  }),
};

const start = computed(() => {
  const res = roadmap.value.items.find(item => item.id === props.startItemId);

  if (res) {
    const cords = anchorsCords[props.startItemAnchor](res);
    cords.x = alignToGrid(cords.x);
    cords.y = alignToGrid(cords.y);
    return cords;
  }

  return undefined;
});

const end = computed(() => {
  const res =  roadmap.value.items.find(item => item.id === props.endItemId);

  if (res) {
    const cords = anchorsCords[props.endItemAnchor](res);
    cords.x = alignToGrid(cords.x);
    cords.y = alignToGrid(cords.y);
    return cords;
  }

  return undefined;
});

</script>
<template>
  <g v-if="start && end">
    <path
      v-if="direction === 'lineY'"
      :d="`M${start.x},${start.y} C${start.x},${(start.y + end.y) / 2} ${end.x},${(start.y + end.y) / 2} ${end.x},${end.y}`"
      fill="none"
      stroke="#009FB7"
      stroke-width="4"
    />
    <path 
      v-else
      :d="`M${start.x},${start.y} C${(start.x + end.x) / 2},${start.y} ${(start.x + end.x) / 2},${end.y} ${end.x},${end.y}`"
      fill="none"
      stroke="#009FB7"
      stroke-width="4"
    />
  </g>
</template>