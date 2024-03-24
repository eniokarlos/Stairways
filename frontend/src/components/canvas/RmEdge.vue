<script setup lang="ts">
import { Ref, computed, inject } from 'vue';
import { EdgeStyle, Point, Anchor, RoadmapEdge, RoadmapItem } from './Util/roadmap.interfaces';
import { alignToGrid } from './Util/alignToGrid';

const props = withDefaults(
  defineProps<RoadmapEdge>(),
  {
    format: 'curve',
    style: 'dotted',
  },
);


const { roadmap } = inject('roadmap') as {
  roadmap: Ref<{
    items: RoadmapItem[],
    edges: RoadmapEdge[]
  }>
};

const styleProps: Record<EdgeStyle, object> = {
  solid: { 'stroke-width': '4' },
  dashed: {
    'stroke-width': '4',
    'stroke-dasharray': '10',
  },
  dotted: {
    'stroke-width': '6',
    'stroke-dasharray': '0.1 10',
    'stroke-linecap': 'round',
  },
};

const anchorOffset = 6;
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

function getLinePath(start: Point, end: Point) {
  
  let format = props.format === 'curve' ? 'C' : 'L';
  const halfX = (start.x + end.x)/2;
  const halfY = (start.y + end.y)/2;

  function isOnVerticalAxis(anchor: Anchor) {
    return anchor === 'top' || anchor === 'bottom';
  }

  function isOnHorizontalAxis(anchor: Anchor) {
    return anchor === 'left' || anchor === 'right';
  }

  if (props.format === 'diagonal') {
    return `M${start.x},${start.y} L${end.x},${end.y}`;
  }

  if (
    isOnHorizontalAxis(props.startItemAnchor) &&
    isOnHorizontalAxis(props.endItemAnchor)
  ){
    return `M${start.x},${start.y} ${format}${halfX},${start.y} 
    ${halfX},${end.y} ${end.x},${end.y}`;
  }

  if (
    isOnVerticalAxis(props.startItemAnchor) &&
    isOnVerticalAxis(props.endItemAnchor)
  ) {
    return `M${start.x},${start.y} ${format}${start.x},${halfY} 
    ${end.x},${halfY} ${end.x},${end.y}`;
  }

  if (format !== 'L') {
    format = 'Q';
  }

  if (
    isOnHorizontalAxis(props.startItemAnchor) &&
    isOnVerticalAxis(props.endItemAnchor)
  ){
    return `M${start.x},${start.y} ${format}${end.x},${start.y} 
    ${end.x},${end.y}`;
  }
  else {
    return `M${start.x},${start.y} ${format}${start.x},${end.y} 
    ${end.x},${end.y}`;
  }
}

</script>

<template>
  <g v-if="start && end">
    <path
      :d="getLinePath(start,end)"
      v-bind="styleProps[style]"
      fill="none"
      stroke="#009FB7"
    />
  </g>
</template>