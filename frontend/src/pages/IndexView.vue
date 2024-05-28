<script setup lang="ts">
import UiList from '@/ui/uiList/UiList.vue';
import Card from '@/components/card/Card.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import UiIcon from '@/ui/icon/UiIcon.vue';
import { useAuthStore } from '@/stores/auth.store';
import rmService from '@/services/roadmap.services';
import { ref, onMounted } from 'vue';
import { RoadmapLevel } from '@/components/canvas/RmCanvas.vue';
import router from '@/modules/router/router';

const auth = useAuthStore();
const roadmaps = ref();
const levels: RoadmapLevel[] = [
  'beginner',
  'intermediate',
  'advanced',
];

async function getRoadmaps() {
  const res = await rmService.get();

  roadmaps.value = res;
}

function openRoadmap(id: string) {
  router.push({
    name: 'roadmap',
    params: { id },
  });
}

onMounted(getRoadmaps);
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
      v-if="roadmaps"
      :title="roadmaps[0].tags[0]"
    >
      <Card
        v-for="rm in roadmaps"
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