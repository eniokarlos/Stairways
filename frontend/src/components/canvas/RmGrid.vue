<script setup lang="ts">
withDefaults(
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
    size: ({ scale = 1 }) =>  64 * scale,
    subGridSize: ({ scale = 1 }) => 8 * scale,
  },
);
</script>
<template>
  <defs>
    <pattern
      :id="subGridId"
      :width="subGridSize"
      :height="subGridSize"
      patternUnits="userSpaceOnUse"
    >
      <path
        :d="`M0,0 v${subGridSize} h${subGridSize}`"
        stroke-width="1"
        :stroke="color"
        fill="none"
      />
    </pattern>

    <pattern
      :id="gridId"
      :x="x % size"
      :y="y % size"
      :width="size"
      :height="size"
      patternUnits="userSpaceOnUse"
    >
      <rect
        :width="width"
        :height="height"
        :fill="`url(#${subGridId})`"
      />
      <path
        :d="`M0,0 v${size} h${size}`"
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