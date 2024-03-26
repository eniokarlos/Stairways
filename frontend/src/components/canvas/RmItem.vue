<script setup lang="ts">
import { computed } from 'vue';
import { alignToGrid } from './Util/alignToGrid';
import { ItemType, RoadmapItem } from './Util/roadmap.interfaces';
import { RoadmapDefaults } from './Util/roadmap.defaults';

const props = withDefaults(
  defineProps<RoadmapItem>(),
  {
    x: 0,
    y: 0,
    type: 'topic',
    width: RoadmapDefaults.topic.width,
    height: RoadmapDefaults.topic.height,
  },
);

const text = defineModel<string>('text');
const widthAligned = computed(() => alignToGrid(props.width));
const heightAligned = computed(() => alignToGrid(props.height));
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

const fontSizes: Record<ItemType, string> = {
  topic: '26',
  subTopic: '18',
  link: '26',
};


</script>
<template>
  <g
    :transform="`translate(${alignToGrid(x)},${alignToGrid(y)})`"
  >
    <rect
      :x="-paddingOffset / 2"
      :y="-paddingOffset/2"
      :width="widthAligned + paddingOffset"
      :height="heightAligned + paddingOffset"
      fill="transparent"
    />
    <rect
      :width="widthAligned"
      :height="heightAligned"
      :fill="typeColors[type].bg"
      stroke="black"
      rx="5"
    />
    <text
      style="font-family: 'Fredoka'"
      alignment-baseline="middle"
      dominant-baseline="middle"
      text-anchor="middle"
      :font-size="fontSizes[type]"
      font-weight="400"
      :fill="typeColors[type].fg"
      :x="widthAligned / 2"
      :y="heightAligned / 2"
    >
      {{ text }}
    </text>
  </g>
</template>