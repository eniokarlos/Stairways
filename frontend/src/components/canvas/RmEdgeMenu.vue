<script setup lang="ts">
import UiDropDown from '@/ui/dropDown/UiDropDown.vue';
import { RoadmapEdge } from './RmEdge.vue';
import { watch } from 'vue';

const edge = defineModel<RoadmapEdge>({ required: true });

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
        class="fg-gray block w-full
        pt-10px"
      >
        Design da linha
      </span>
      <div class="w-full pa-8px">
        <span>Estilo: </span>
        <UiDropDown
          v-model="edge.style"
          class=""
          :items="[
            {title: 'solid', value: 'solid'},
            {title: 'dashed', value: 'dashed'},
            {title: 'dotted', value: 'dotted'},
          ]"
        />
      </div>
      <div class="w-full pa-8px">
        <span>Formato: </span>
        <UiDropDown
          v-model="edge.format"
          :items="[
            {title: 'line', value: 'line'},
            {title: 'curve', value: 'curve'},
            {title: 'straight', value: 'straight'},
          ]"
        />
      </div>
    </main>  
  </aside>
</template>

<style scoped>
  
</style>