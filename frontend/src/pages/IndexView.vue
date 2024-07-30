<script setup lang="ts">
import UiList from '@/ui/uiList/UiList.vue';
import Card from '@/components/card/Card.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import UiIcon from '@/ui/icon/UiIcon.vue';
import { useAuthStore } from '@/stores/auth.store';
import categoryService from '@/services/category.services';
import rmService, { RoadmapGet } from '@/services/roadmap.services';
import { ref, onMounted } from 'vue';
import router from '@/modules/router/router';
import { useCategoryStore } from '@/stores/category.store';

export type RoadmapByCategory = Record<string, Array<RoadmapGet>>

const auth = useAuthStore();
const categoryStore = useCategoryStore();
const groupedRoadmaps = ref<RoadmapByCategory>();
const levels: ('beginner' | 'intermediate' | 'advanced')[] = [
  'beginner',
  'intermediate',
  'advanced',
];

async function loadData() {
  const roadmaps = await rmService.get();
  const allCategories = await categoryService.get();

  categoryStore.set(allCategories);

  const groupedRes = roadmaps.reduce((res: RoadmapByCategory, current) => {
    (res[current.category.name] = res[current.category.name] || []).push(current);
    return res;
  }, {});

  groupedRoadmaps.value = groupedRes;
}

function openRoadmap(id: string) {
  router.push({
    name: 'roadmap',
    params: { id },
  });
}

onMounted(loadData);

</script>

<template>
  <section>
    <RouterLink 
      v-if="auth.isAuth"
      to="roadmap-creation"
    >
      <UiBtn
        class="w-60px h-60px fixed 
      bottom-40px right-20px z-10 bg-brand-orange"
        variant="rounded"
      >
        <UiIcon
          color="white"
          name="plus"
          class="font-500 font-size-38px"
        />
      </UiBtn>
    </RouterLink>
    <UiList 
      v-for="(category, i) in groupedRoadmaps"
      :key="i"
      :title="i.toString()"
    >
      <Card
        v-for="rm in category"
        :key="rm.id"
        class="cursor-pointer"
        :title="rm.title"
        :user-name="rm.authorName"
        :user-picture="rm.authorProfileImage"
        :description="rm.description"
        :rating="80"
        :level="levels[rm.level]"
        :card-picture="rm.imageURL"
        @clicked="openRoadmap(rm.id)"
      />
    </UiList>
  </section>
</template>

<style scoped>

</style>