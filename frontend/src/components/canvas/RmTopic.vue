<script setup lang="ts">
import { computed } from 'vue';
import { alignToGrid } from './Util/alignToGrid';
import { RoadmapItem } from './Util/roadmap.interfaces';

const props = withDefaults(
  defineProps<RoadmapItem>(),
  {
    x: 0,
    y: 0,
    width: 256,
    height: 64,
  },
);

const text = defineModel<string>('text');
const widthAligned = computed(() => alignToGrid(props.width));
const heightAligned = computed(() => alignToGrid(props.height));
const paddingOffset = 70;

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
      fill="#FF8811"
      stroke="black"
      rx="5"
    />
    <text
      style="font-family: 'Fredoka'"
      alignment-baseline="middle"
      dominant-baseline="middle"
      text-anchor="middle"
      font-size="28px"
      font-weight="400"
      fill="white"
      :x="widthAligned / 2"
      :y="heightAligned / 2"
    >
      {{ text }}
    </text>
  </g>
</template>