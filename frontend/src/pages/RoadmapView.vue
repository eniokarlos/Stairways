<script setup lang="ts">
import rmService, { RoadmapApi } from '@/services/roadmap.services';
import RoadmapRender from '@/components/RoadmapRender/RoadmapRender.vue';
import UiIcon from '@/ui/icon/UiIcon.vue';
import UiProgressBar from '@/ui/progressBar/UiProgressBar.vue';
import { onMounted, ref } from 'vue';

const props = defineProps<{
  id:string
}>();

const roadmap = ref<RoadmapApi>();

const levels = [
  'Iniciante',
  'Intermediário',
  'Avançado',
];

const levelColors = [
  'brand-blue',
  'brand-orange',
  'brand-magenta',
];


async function getRoadmap() {
  const res = await rmService.getById(props.id);
  if (!res) {
    return;
  }
  roadmap.value = res;
  roadmap.value!.jsonContent.edges = res.jsonContent.edges.map(
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    (e: any) => ({
      path: e.path,
      edgeStyle: e.style,
    }));
}

onMounted(getRoadmap);
</script>
<template>
  <header
    v-if="roadmap"
    class="relative flex items-center h-200px fg-gray justify-center pt-20px"
  >
    <UiIcon 
      class="absolute left-50px cursor-pointer top-40% font-size-40px"
      name="arrow-left"
      @pointerdown="$router.back()"
    />
    <div class="w-60%">
      <h1 
        v-color="levelColors[roadmap.level]"
        class="title relative block w-fit fg-foreground mb-12px"
      >
        {{ roadmap.title }}
      </h1>
      <p class="mb-20px w-80%">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. 
        Alias ut quaerat, quidem, nostrum culpa omnis nam similique obcaecati 
        officia maxime commodi id sit expedita ipsa autem odio 
        aspernatur laborum delectus.
      </p>
      <span class="">
        Criador por: <b>Lorem Ipsum</b>
      </span>
      <div>
        <UiProgressBar
          class="w-60%"
          :progress="50"
        />
      </div>
    </div>
    <div class="flex h-70% flex-self-end relative flex-col items-end w-15%">
      <div>Nível: {{ levels[roadmap.level] }}</div>
      <div>Avaliações: 90%</div>
      <div class="flex absolute bottom-0 gap-10px">
        <div class="flex items-center cursor-pointer">
          Curtir <UiIcon
            class="ml-4px font-size-20px"
            name="heart-outline"
            color="brand-magenta"
          />
        </div>
        <div class="flex items-center cursor-pointer">
          Salvar <UiIcon
            class="ml-4px font-size-22px"
            name="bookmark-outline"
            color="brand-blue"
          />
        </div>
      </div>
    </div>
  </header>
  <main v-if="roadmap">
    <RoadmapRender 
      :edges="roadmap.jsonContent.edges"
      :items="roadmap.jsonContent.items"
    />
  </main>
</template>


<style lang="css" scoped>
  .title::before
  {
    content: '';
    display: block;
    position: absolute;
    width: 100%;
    height: 3px;
    background-color: var(--current-color);
    bottom: -6px;
    border-radius: 5px;
  }
</style>