<script setup lang="ts">
export type ItemType = 'topic' | 'subTopic' | 'link' | 'text';
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

defineProps<{item: RoadmapItem}>();
const paddingOffset = 30;
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
  text: {
    bg: 'transparent',
    fg: '#2E2E2E',
  },
};

</script>
<template>
  <g
    :transform="`translate(${item.x},${item.y})`"
  >
    <rect
      :x="-paddingOffset/2"
      :y="-paddingOffset/2"
      :width="item.width + paddingOffset"
      :height="item.height + paddingOffset"
      fill="transparent"
    />
    <rect
      :width="item.width"
      :height="item.height"
      :fill="typeColors[item.type ?? 'topic'].bg"
      :stroke="item.type === 'text' ? 'none' : 'black'"
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
      :x="item.width / 2"
      :y="item.height / 2"
    >
      {{ item.label }}
    </text>
  </g>
</template>