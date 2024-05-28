import { RenderFormat } from '@/components/canvas/RmCanvas.vue';
import { RoadmapEdge } from '@/components/canvas/RmEdge.vue';
import { RoadmapItem } from '@/components/canvas/RmItem.vue';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useRoadmapStore = defineStore('roadmaps', () => {
  const gridAlignment = ref<boolean>(true);
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const roadmap = ref<{meta: any, items: RoadmapItem[], edges: RoadmapEdge[]}>({
    meta: {
      title: '',
      description: '',
      level: 0,
      privacity: 1,
      imageURL: '',
      tags: [],
    },
    items: [],
    edges: [], 
  });


  const toBePublished = ref<RenderFormat>({
    edges: [],
    items: [],
  });

  function toggleGridAlignment() {
    gridAlignment.value = !gridAlignment.value;
  }

  return {
    roadmap,
    gridAlignment,
    toBePublished,
    toggleGridAlignment,
  };
});