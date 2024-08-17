<script setup lang="ts">
import rmService, { RoadmapGet } from '@/services/roadmap.services';
import RoadmapRender from '@/components/RoadmapRender/RoadmapRender.vue';
import UiIcon from '@/ui/icon/UiIcon.vue';
import UiToggleButton from '@/ui/toggleButton/ToggleButton.vue';
import UiProgressBar from '@/ui/progressBar/UiProgressBar.vue';
import { computed, onMounted, ref } from 'vue';
import userService from '@/services/user.services';
import { ItemRenderProps } from '@/components/RoadmapRender/RenderItem.vue';
import { useAuthStore } from '@/stores/auth.store';

const props = defineProps<{
  id:string
}>();
const userStore = useAuthStore();
const roadmap = ref<RoadmapGet>();
const activeItem = ref<ItemRenderProps | undefined>();
const progress = computed(() => {
  const totalItems = roadmap.value?.jsonContent.items.filter(i => 
    i.type !== 'link' && i.type !== 'text').length ?? 1;
  const doneItems =  roadmap.value?.jsonContent.items.filter(i => i.isDone).length ?? 0;
  return Math.round((doneItems/totalItems) * 100);
});

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

function addOrRemoveItem(add: boolean) {
  if (!(userStore.user && activeItem.value)) {
    return;
  }
  if (add) {
    userStore.user.doneItemsHashs.push(activeItem.value.signature);
    userService.setDoneItem(userStore.user.id, userStore.user.doneItemsHashs)
      .then(res => userStore.setUser(res));

    activeItem.value.isDone = true;
  }
  else {
    userStore.user.doneItemsHashs.splice(
      userStore.user.doneItemsHashs.indexOf(activeItem.value.signature),
      1,
    );
    userService.setDoneItem(userStore.user.id, userStore.user.doneItemsHashs)
      .then(res => userStore.setUser(res));

    activeItem.value.isDone = false;
  }
}

async function getRoadmap() {
  const res = await rmService.getById(props.id);
  if (!res) {
    return;
  }
  roadmap.value = res;
  roadmap.value.jsonContent.items.forEach(i => {
    if (i.type !== 'text') {
      i.isDone = userStore.user?.doneItemsHashs.includes(i.signature);
    }
  });
  roadmap.value!.jsonContent.edges = res.jsonContent.edges.map(
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    (e: any) => ({
      path: e.path,
      edgeStyle: e.style,
    }));
}

function hasContent() {
  if (!activeItem.value) {
    return;
  }
  return activeItem.value.content?.title || 
    activeItem.value.content?.description ||
    activeItem.value.content?.links.length;
}

onMounted(async () => {
  await getRoadmap();
});
</script>
<template>
  <div
    v-if="roadmap"
    @pointerdown="activeItem = undefined"
  >
    <header 
      class="relative flex items-stretch fg-gray justify-center pt-20px pb-10px"
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
          {{ roadmap.description }}
        </p>
        <span class="">
          Criador por: <b>{{ roadmap.authorName }}</b>
        </span>
        <div v-if="userStore.isAuth">
          <UiProgressBar
            class="w-60%"
            :progress="progress"
          />
        </div>
      </div>
      <div class="flex relative flex-col items-end justify-center">
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
    <main>
      <RoadmapRender 
        v-model:active-item="activeItem"
        :edges="roadmap.jsonContent.edges"
        :items="roadmap.jsonContent.items"
      />
    </main>
    <div
      v-if="activeItem && hasContent()"
      class="modal fixed top-0px right-0 h-full w-100vw z-100"
      @pointerdown="activeItem = undefined"
    >
      <div
        class="absolute top-0 z-102 right-0 bg-white w-35% h-full pa-24px" 
        @pointerdown.stop
      >
        <UiToggleButton
          v-if="userStore.isAuth"
          :initial-value="activeItem.isDone"
          @change="addOrRemoveItem($event)"
        />
        <h1 class="font-size-36px font-800 mt-28px mb-10px">
          {{ activeItem.content?.title }}
        </h1>
        <p class="font-size-16px line-height-28px fg-modal-fg mb-25px">
          {{ activeItem.content?.description }}
        </p>
        <a
          v-for="link,i in activeItem.content?.links"
          :key="i"
          target="_blank"
          :href="link.url"
          class="fg-foreground font-600 mb-10px block"
        >{{ link.text }}</a>
      </div>
    </div>
  </div>
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
  .modal {
    background-color: rgba(17, 24, 39, .8);
  }

</style>