import { Roadmap } from '@/components/canvas/RmCanvas.vue';
import { RoadmapContent } from '@/services/roadmap.services';
import { useStorage } from '@vueuse/core';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useRoadmapStore = defineStore('roadmaps', () => {
  const gridAlignment = ref<boolean>(true);
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const roadmap = useStorage<Roadmap>('roadmap',{
    meta: {
      title: '',
      description: '',
      level: 0,
      privacy: 1,
      categoryId: '',
      imageURL: '',
    },
    items: [],
    edges: [], 
  });

  const toBePublished = ref<RoadmapContent>({
    edges: [],
    items: [],
  });

  function clear() {
    roadmap.value.items = [];
    roadmap.value.edges = [];
  }

  function toggleGridAlignment() {
    gridAlignment.value = !gridAlignment.value;
  }

  return {
    roadmap,
    gridAlignment,
    toBePublished,
    clear,
    toggleGridAlignment,
  };
});