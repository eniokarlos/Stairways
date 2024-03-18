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
    size: 64,
    subGridSize: 8,
  },
);
</script>

<template>
  <defs>
    <pattern
      v-if="scale > 0.2"
      :id="subGridId"
      :width="subGridSize * scale"
      :height="subGridSize * scale"
      patternUnits="userSpaceOnUse"
    >
      <path
        :d="`M0,0 v${subGridSize * scale} h${subGridSize * scale}`"
        stroke-width="1"
        :stroke="color"
        fill="none"
      />
    </pattern>

    <pattern
      :id="gridId"
      :x="x % (size * scale)"
      :y="y % (size * scale)"
      :width="(size * scale)"
      :height="(size * scale)"
      patternUnits="userSpaceOnUse"
    >
      <rect
        :width="width"
        :height="height"
        :fill="`url(#${subGridId})`"
      />
      <path
        :d="`M0,0 v${size * scale} h${size * scale}`"
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