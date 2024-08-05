<script setup lang="ts">
import { onMounted, onUpdated, ref } from 'vue';
import { useResizeObserver } from '@vueuse/core';

const props = defineProps({
  progress: {
    type: Number,
    required: true,
    default: 0,
    validator: (value: number) => {
      if (value > 100) {
        console.warn('progress should not be greater than 100');
        return false;
      }
      return true;
    },
  },
});

const barLabel = ref<HTMLElement>();
const progressBar = ref<HTMLElement>();
const bar = ref<HTMLElement>();

function init() {
  let width;
  if (progressBar.value) {
    progressBar.value.style.width = `${props.progress}%`;
  }
  if (bar.value) {
    width = bar.value.getBoundingClientRect().width;
  }
  if (barLabel.value) {
    const barLabelWidth = barLabel.value.getBoundingClientRect().width;
    barLabel.value.style.transform = `translateX(${width!/2 - barLabelWidth!/2 - 1}px)`;
  }
}

onMounted(init);
onUpdated(init);
useResizeObserver(bar, init);

</script>

<template>
  <div
    ref="bar"
    class="relative b-1px-solid-gray
  rd-5px py-4px flex justify-center overflow-hidden"
  >
    <div
      ref="progressBar"
      class="bg-green overflow-hidden absolute flex items-center
      left-0 top-0 h-full z-1"
    >
      &nbsp;
      <span
        ref="barLabel"
        class="absolute left-0 fg-white font-500"
      >Progress: {{ progress }}%</span>
    </div>
    <span class="fg-gray z-0 font-500">Progress: {{ progress }}%</span>
  </div>
</template>


<style lang="css" scoped>
</style>