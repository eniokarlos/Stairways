<script setup lang="ts">
import { computed } from 'vue';
import { EdgeStyle, RoadmapEdge } from '../canvas/RmEdge.vue';
import { Point } from '../canvas/RmCanvas.vue';
import { Anchor } from '../canvas/RmAnchors.vue';
import { ItemRenderProps } from './RenderItem.vue';

export interface RenderEdgeProps {
  items: ItemRenderProps[],
  edge: RoadmapEdge
}

const props = defineProps<RenderEdgeProps>();
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

const startItem = findItem(props.edge.startItemId);
const endItem = findItem(props.edge.endItemId);
const anchorOffset = 6;
const anchorsCords = {
  top: (item: ItemRenderProps) => ({
    x: item.x + item.width/2,
    y: item.y + anchorOffset,
  }),
  right: (item: ItemRenderProps) => ({
    x: item.x + item.width - anchorOffset,
    y: item.y + item.height/2,
  }),
  bottom: (item: ItemRenderProps) => ({
    x: item.x + item.width/2,
    y: item.y + item.height - anchorOffset,
  }),
  left: (item: ItemRenderProps) => ({
    x: item.x + anchorOffset,
    y: item.y + item.height/2,  
  }),
};

const start = computed(() => {
  return anchorsCords[props.edge.startItemAnchor](startItem);
});

const end = computed(() => {
  return anchorsCords[props.edge.endItemAnchor](endItem);
});

function findItem(id: string): ItemRenderProps{
  const res = props.items.find(i => i.id == id) ?? {
    content: {
      description: '',
      links: [],
      title: '', 
    },
    signature: '',
    height: 0,
    id: '',
    label: '',
    labelSize: 0,
    labelWidth: 0,
    type: 'topic',
    width: 0,
    x: 0,
    y: 0,
  } as ItemRenderProps; 
  return res;
}

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
  <g
    v-if="props"
  >
    <path
      class="edge"
      :class="edge.style"
      :d="getLinePath(start,end)"
      v-bind="styleProps[edge.style ?? 'solid']"
      fill="none"
      stroke-linecap="round"
      stroke-linejoin="round"
      stroke="#009FB7"
    />
  </g>
</template>