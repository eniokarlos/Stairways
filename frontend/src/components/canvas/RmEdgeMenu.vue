<script setup lang="ts">
import { EdgeFormat, EdgeStyle, RoadmapEdge } from './RmEdge.vue';
import { watch, ref } from 'vue';
import UiIcon from '@/ui/icon/UiIcon.vue';

const edge = defineModel<RoadmapEdge>({ required: true });
const formatButtons = ref<{value: EdgeFormat, icon: string}[]>([
  {
    value: 'line',
    icon: 'chart-timeline-variant', 
  },
  {
    value: 'straight',
    icon: 'vector-line', 
  },
  {
    value: 'curve',
    icon: 'vector-radius', 
  },
]);
const styleButtons = ref<{value: EdgeStyle, icon: string}[]>([
  {
    value: 'solid',
    icon: 'solid-line', 
  },
  {
    value: 'dashed',
    icon: 'dashed-line',
  },
  {
    value: 'dotted',
    icon: 'dotted-line',
  },
]);


watch(edge, (newValue, oldValue) => {
  if (oldValue) {
    oldValue.selected = false;
  }
  newValue.selected = true;
}, { immediate: true });
</script>

<template>
  <aside
    class="side-menu absolute top-0 right-0 bg-white 
    w-300px h-full flex flex-col"
  >
    <main class="pl-15px">
      <span
        class="fg-gray block w-full font-size-18px
        pt-10px my-10px"
      >
        Design da linha
      </span>
      <div class="flex items-center gap-5px pr-20px mb-5px">
        <span class="grow font-500">Formato</span>
        <label
          v-for="button,i in formatButtons"
          :key="i"
          :class="{'selected': edge.format === button.value}"
          class="cursor-pointer w-28px h-28px bg-light-gray-alfa 
        b-0 pa-5px rd-5px"
        >
          <input
            v-model="edge.format"
            class="hidden"
            :value="button.value"
            type="radio"
            name="stroke-format"
          >
          <UiIcon 
            class="font-size-18px"
            :name="button.icon"
          />
        </label>
      </div>
      <div class="flex items-center gap-5px pr-20px">
        <span class="grow font-500">Estilo</span>
        <label
          v-for="button,i in styleButtons"
          :key="i"
          :class="{'selected': edge.style === button.value}"
          class="cursor-pointer bg-light-gray-alfa 
        b-0 rd-5px w-0px w-28px h-28px"
        >
          <input
            v-model="edge.style"
            :value="button.value"
            class="hidden"
            type="radio"
            name="stroke-style"
          >
          <i
            :class="[
              button.icon, 
            ]"
          />
        </label>
      </div>
    </main> 
  </aside>
</template>

<style scoped>
  .selected {
    filter: opacity(30%);
    cursor: not-allowed;
  }
  .solid-line::before {
    content: url('../../assets/solid-line.svg');
  }
  .dashed-line::before {
    content: url('../../assets/dashed-line.svg');
  }
  .dotted-line::before {
    content: url('../../assets/dotted-line.svg');
  }
</style>