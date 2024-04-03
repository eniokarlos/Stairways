<script setup lang="ts">
import { computed, ref, watchEffect } from 'vue';
import { Anchor } from './RmAnchors.vue';
import { RoadmapItem } from './RmItem.vue';
import { Point } from './RmCanvas.vue';

export type EdgeStyle = 'solid' | 'dashed' | 'dotted';
export type EdgeFormat = 'line' | 'curve' | 'straight';
export interface RoadmapEdge {
  id: string;
  startItem: RoadmapItem;
  endItem: RoadmapItem;
  startItemAnchor: Anchor;
  endItemAnchor: Anchor;
  format?: EdgeFormat;
  style?: EdgeStyle;
  selected?: boolean;
}

const props = defineProps<{edge: RoadmapEdge}>();

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
  const cords = anchorsCords[props.edge.startItemAnchor](props.edge.startItem);
  return cords;
});

const end = computed(() => {
  return anchorsCords[props.edge.endItemAnchor](props.edge.endItem);
});
const shadow = ref<string>();

watchEffect(() => {
  shadow.value = props.edge.selected ?
    'drop-shadow(3px 3px 2px rgb(0 0 0 / 0.7))' : '';
});

function getLinePath(start: Point, end: Point) {
  
  let format = props.edge.format === 'curve' ? 'C' : 'L';
  const halfX = (start.x + end.x)/2;
  const halfY = (start.y + end.y)/2;

  function isOnVerticalAxis(anchor: Anchor) {
    return anchor === 'top' || anchor === 'bottom';
  }

  function isOnHorizontalAxis(anchor: Anchor) {
    return anchor === 'left' || anchor === 'right';
  }

  if (props.edge.format === 'straight') {
    return `M${start.x},${start.y} L${end.x},${end.y}`;
  }

  if (
    isOnHorizontalAxis(props.edge.startItemAnchor) &&
    isOnHorizontalAxis(props.edge.endItemAnchor)
  ){
    return `M${start.x},${start.y} ${format}${halfX},${start.y} 
    ${halfX},${end.y} ${end.x},${end.y}`;
  }

  if (
    isOnVerticalAxis(props.edge.startItemAnchor) &&
    isOnVerticalAxis(props.edge.endItemAnchor)
  ) {
    return `M${start.x},${start.y} ${format}${start.x},${halfY} 
    ${end.x},${halfY} ${end.x},${end.y}`;
  }

  if (format !== 'L') {
    format = 'Q';
  }

  if (
    isOnHorizontalAxis(props.edge.startItemAnchor) &&
    isOnVerticalAxis(props.edge.endItemAnchor)
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
  <g v-if="edge">
    <path
      :d="getLinePath(start,end)"
      fill="none"
      stroke-linecap="round"
      stroke-linejoin="round"
      stroke="transparent"
      stroke-width="40"
    />
    <path
      :d="getLinePath(start,end)"
      v-bind="styleProps[edge.style ?? 'solid']"
      fill="none"
      stroke-linecap="round"
      stroke-linejoin="round"
      stroke="#009FB7"
      :filter="shadow"
    />
  </g>
</template>