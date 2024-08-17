<script setup lang="ts">
import { computed } from 'vue';


const props = withDefaults(
  defineProps<{
    gridId: string;
    subGridId?: string;
    scale?: number;
    x: number;
    y: number;
    width?: string;
    height?: string;
    size?: number;
    subGridSize?: number;
    color?: string;
  }>(), {
    subGridId: ({ gridId }) => gridId + '_small',
    scale: 1,
    width: '100%',
    height: '100%',
    color: '#0000003F',
    size: 64,
    subGridSize: 8,
  },
);

const scaledSize = computed(() => props.size * props.scale);
const scaledSubSize = computed(() => props.subGridSize * props.scale);
</script>

<template>
  <defs>
    <pattern
      v-if="scale > 0.21"
      :id="subGridId"
      :width="scaledSubSize"
      :height="scaledSubSize"
      patternUnits="userSpaceOnUse"
    >
      <path
        :d="`M0,0 v${scaledSubSize} h${scaledSubSize}`"
        stroke-width="1"
        :stroke="color"
        fill="none"
      />
    </pattern>

    <pattern
      :id="gridId"
      :x="x % scaledSize"
      :y="y % scaledSize"
      :width="scaledSize"
      :height="scaledSize"
      patternUnits="userSpaceOnUse"
    >
      <rect
        :width="scaledSize"
        :height="scaledSize"
        :fill="`url(#${subGridId})`"
      />
      <path
        :d="`M0,0 v${scaledSize} h${scaledSize}`"
        stroke-width="1"
        :stroke="color"
        fill="none"
      />
    </pattern>
  </defs>
  <rect
    :width="width"
    :height="height"
    :fill="`url(#${gridId})`"
  />
</template>