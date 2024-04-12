import { Roadmap } from '@/components/canvas/RmCanvas.vue';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useRoadmapStore = defineStore('roadmaps', () => {

  const roadmap = ref<Roadmap>({
    items: [],
    edges: [], 
  });

  return { roadmap };
});