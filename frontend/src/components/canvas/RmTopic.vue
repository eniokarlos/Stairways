<script setup lang="ts">
import { ref, watch, nextTick, computed } from 'vue';
import { alignToGrid } from './util';

const props = withDefaults(
  defineProps<{
    x: number,
    y: number,
    width?: number
    height?: number,
  }>(),
  {
    x: 0,
    y: 0,
    width: 256,
    height: 64,
  },
);

const text = defineModel<string>('text');

const isEditing = defineModel<boolean>('editing');
const textArea = ref<HTMLTextAreaElement>();
const widthAligned = computed(() => alignToGrid(props.width));
const heightAligned = computed(() => alignToGrid(props.height));

watch(isEditing, (editing) => {
  if (editing && textArea.value) {
    textArea.value.focus();
    nextTick(() => textArea.value?.select());
  }
}, { flush: 'post' });
</script>
<template>
  <g
    :transform="`translate(${alignToGrid(x)},${alignToGrid(y)})`"
  >
    <rect
      :width="widthAligned"
      :height="heightAligned"
      fill="#FF8811"
      stroke="black"
      rx="5"
    />
    <foreignObject
      v-if="isEditing"
      :width="widthAligned"
      :height="heightAligned"
      x="0"
      y="0"
    >
      <textarea
        ref="textArea"
        v-model="text"
        placeholder="Digite..."
        class="bg-transparent text-white w-full h-full text-center font-sans text-5 resize-none"
        @blur="isEditing = false"
      />
    </foreignObject>
    <text
      v-else
      alignment-baseline="middle"
      dominant-baseline="middle"
      text-anchor="middle"
      font-size="20px"
      fill="white"
      font-weight="500"
      :x="widthAligned / 2"
      :y="heightAligned / 2"
    >
      {{ text }}
    </text>
  </g>
</template>