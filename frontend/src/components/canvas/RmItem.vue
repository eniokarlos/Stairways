<script setup lang="ts">
import { computed } from 'vue';
import { alignToGrid } from './Util/alignToGrid';

export type ItemType = 'topic' | 'subTopic' | 'link';
export type ItemContent = {
  title: string,
  description: string,
  links: Array<
  {text: string,
    url: string}
  >
}

export interface BoundingBox {
  x: number,
  y: number,
  width: number,
  height: number
}

export interface RoadmapItem extends BoundingBox{
  id: string;
  content: ItemContent;
  type?: ItemType;
  linkTo?: string;
  label?: string;
  labelWidth?: number;
  labelSize?: number;
}

const props = defineProps<{item: RoadmapItem}>();
const widthAligned = computed(() => alignToGrid(props.item.width));
const heightAligned = computed(() => alignToGrid(props.item.height));
const paddingOffset = 40;
const typeColors: Record<ItemType, {bg:string, fg:string}> = {
  topic: {
    bg: '#FF8811',
    fg: '#fff',
  },
  subTopic: {
    bg: '#FFE599',
    fg: '#000',
  },
  link: {
    bg: '#DB2763',
    fg: '#FFF',
  },
};
</script>
<template>
  <g
    :transform="`translate(${alignToGrid(item.x)},${alignToGrid(item.y)})`"
  >
    <rect
      :x="-paddingOffset/2"
      :y="-paddingOffset/2"
      :width="widthAligned + paddingOffset"
      :height="heightAligned + paddingOffset"
      fill="transparent"
    />
    <rect
      :width="widthAligned"
      :height="heightAligned"
      :fill="typeColors[item.type ?? 'topic'].bg"
      stroke="black"
      rx="5"
    />
    <text
      style="font-family: 'Fredoka'"
      alignment-baseline="middle"
      dominant-baseline="middle"
      text-anchor="middle"
      :font-size="item.labelSize"
      :font-weight="item.labelWidth"
      :fill="typeColors[item.type ?? 'topic'].fg"
      :x="widthAligned / 2"
      :y="heightAligned / 2"
    >
      {{ item.label }}
    </text>
  </g>
</template>