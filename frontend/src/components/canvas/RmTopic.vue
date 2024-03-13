<script setup lang="ts">
import { ref, watch, nextTick } from 'vue';

withDefaults(
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

const isEditing = ref(false);
const textArea = ref<HTMLTextAreaElement>();

watch(isEditing, (editing) => {
  if (editing && textArea.value) {
    textArea.value.focus();
    nextTick(() => textArea.value?.select());
  }
}, { flush: 'post' });
</script>
<template>
  <g
    :transform="`translate(${x},${y})`"
    @dblclick="isEditing = true"
  >
    <rect
      :width="width"
      :height="height"
      fill="#FF8811"
    />
    <foreignObject
      v-if="isEditing"
      :width="width"
      :height="height"
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
      font-family="Fredoka"
      font-size="18px"
      fill="white"
      font-weight="500"
      :x="width / 2"
      :y="height / 2"
    >
      {{ text }}
    </text>
  </g>
</template>