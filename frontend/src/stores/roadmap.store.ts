import { Roadmap } from '@/components/canvas/RmCanvas.vue';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useRoadmapStore = defineStore('roadmaps', () => {
  const gridAlignment = ref<boolean>(true);
  const roadmap = ref<Roadmap>({
    meta: {
      title: '',
      description: '',
      level: 'beginner',
      privacity: 'public',
      tags: [],
    },
    items: [],
    edges: [], 
  });

  function toggleGridAlignment() {
    gridAlignment.value = !gridAlignment.value;
  }

  return {
    roadmap,
    gridAlignment, 
    toggleGridAlignment,
  };
});