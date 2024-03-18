<script setup lang="ts">

defineProps<{
  start: {x:number,y:number},
  end: {x:number,y:number},
  format?: 'line' | 'curve',
  style?: 'solid' | 'dashed' | 'dotted',
  direction: 'lineX' | 'lineY'
}>();



</script>
<template>
  <path
    v-if="direction === 'lineY'"
    :d="`M${start.x},${start.y} C${start.x},${(start.y + end.y) / 2} ${end.x},${(start.y + end.y) / 2} ${end.x},${end.y}`"
    fill="none"
    stroke="#009FB7"
    stroke-width="4"
  />
  <path 
    v-else
    :d="`M${start.x},${start.y} C${(start.x + end.x) / 2},${start.y} ${(start.x + end.x) / 2},${end.y} ${end.x},${end.y}`"
    fill="none"
    stroke="#009FB7"
    stroke-width="4"
  />
</template>