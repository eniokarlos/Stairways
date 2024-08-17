import { RoadmapCategory } from '@/services/category.services';
import { useStorage } from '@vueuse/core';
import { defineStore } from 'pinia';

export const useCategoryStore = defineStore('categories', () => {
  const list = useStorage<RoadmapCategory[]>('categories',[]);
  function set(values: RoadmapCategory[]) {
    list.value = values;
  }

  return {
    list,
    set,
  };
});
