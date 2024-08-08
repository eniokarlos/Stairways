import { RoadmapCategory } from '@/services/category.services';
import { defineStore } from 'pinia';
import { ref } from 'vue';


export const useCategoryStore = defineStore('categories', () => {
  const list = ref<RoadmapCategory[]>([]);
  function set(values: RoadmapCategory[]) {
    list.value = values;
  }

  return {
    list,
    set,
  };
});
