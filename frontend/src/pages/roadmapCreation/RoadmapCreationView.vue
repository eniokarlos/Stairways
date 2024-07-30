<script setup lang="ts">
import UiIcon from '@/ui/icon/UiIcon.vue';
import UiDropDown from '@/ui/dropDown/UiDropDown.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import PublishMenu from './PublishMenuView.vue';
import RmCanvas, { GridMoveEvent } from '@/components/canvas/RmCanvas.vue';
import { ref } from 'vue';
import { ItemType, RoadmapItem } from '@/components/canvas/RmItem.vue';
import { alignToGrid } from '@/components/canvas/Util/alignToGrid';
import { useRoadmapStore } from '@/stores/roadmap.store';
import { useAuthStore } from '@/stores/auth.store';
import rmService, { RoadmapPost } from '@/services/roadmap.services';
import router from '@/modules/router/router';

const levelColors: string[] = [
  'brand-blue',
  'brand-orange',
  'brand-magenta',
]; 

const privacyIcons: string[] = [
  'lock',
  'earth',
];

const canvas = ref();
const authStore = useAuthStore();
const rmStore = useRoadmapStore();
const scale = ref<number>(1);
const showPublishMenu = ref<boolean>(false);
const newItem = ref<Required<RoadmapItem>>();

const roadmapItemsDefaults: Record<ItemType, 
  Partial<RoadmapItem>> = {
    topic: {
      label: 'Tópico',
      width: 256,
      height: 64,
      labelSize: 24,
    }, 
    subTopic: {
      label: 'Sub-Tópico',
      width: 192,
      height: 48,
      labelSize: 18,
    },
    link: {
      label: 'Link para outro roadmap',
      width: 288,
      height: 48,
      labelSize: 18,
    },
    text: {
      label: 'Título',
      width: 120,
      height: 64,
      labelSize: 32,
    },
  };

let isGrabbing: boolean = false;
let lastItemType: ItemType;
let lastMoveEvent: GridMoveEvent;

function onGrab(itemType: ItemType) {
  lastItemType = itemType;
  isGrabbing = true;
}

function onEnter(e: GridMoveEvent) {
  if (isGrabbing) {
    lastMoveEvent = e;
    newItem.value = {
      id: crypto.randomUUID(),
      content: {
        title: '',
        description: '',
        links: [],
      },
      width: roadmapItemsDefaults[lastItemType].width!,
      height: roadmapItemsDefaults[lastItemType].height!,
      labelSize: roadmapItemsDefaults[lastItemType].labelSize!,
      labelWidth: 400,
      x: (e.event.offsetX - lastMoveEvent.grid.x) / scale.value,
      y: (e.event.offsetY - lastMoveEvent.grid.y) / scale.value,
      type: lastItemType,
      label: roadmapItemsDefaults[lastItemType].label!,
      linkTo: '',
    };
    rmStore.roadmap.items.push(newItem.value);
  }
}

function onMove(e: GridMoveEvent) {
  if (newItem.value && isGrabbing) {

    const dx = e.event.x - lastMoveEvent.event.x;
    const dy = e.event.y - lastMoveEvent.event.y;

    newItem.value.x += dx / scale.value;
    newItem.value.y += dy / scale.value;    

    lastMoveEvent.event = e.event;
  }
}

function onLeave() {
  if (newItem.value && isGrabbing) {
    rmStore.roadmap.items.pop();
  }
}

function stopAddElement() {
  if (newItem.value) {
    isGrabbing = false;
    newItem.value.x = alignToGrid(newItem.value.x);
    newItem.value.y = alignToGrid(newItem.value.y);
    newItem.value = undefined;
  }
}

async function publish() {
  if (!authStore.user || !canvas.value) {
    return;
  }
  const requestBody: RoadmapPost = {
    userId: authStore.user.id,
    title: rmStore.roadmap.meta.title,
    description: rmStore.roadmap.meta.description,
    level: rmStore.roadmap.meta.level,
    privacy: rmStore.roadmap.meta.privacy,
    imageURL: rmStore.roadmap.meta.imageURL,
    categoryId: rmStore.roadmap.meta.categoryId,
    jsonContent: rmStore.toBePublished,
  };
  console.log(requestBody);
  const res = await rmService.post(requestBody);
  if (res?.status !== 200) {
    return;
  }

  router.push('/');
}
</script>

<template>
  <section class="h-screen flex flex-col">
    <nav
      class="rm-creation__nav flex w-full h-62px relative justify-between
    items-center b-1px-solid-light-gray"
    >
      <RouterLink
        to="/"
        class="z-2 fg-foreground decoration-none"
      >
        <UiIcon
          name="arrow-left"
          class="font-size-30px pl-40px"
        />
      </RouterLink>

      <div class="rm-creation__title absolute z-1 w-full flex flex-col items-center">
        <input
          v-model="rmStore.roadmap.meta.title"
          type="text"
          class="block bg-transparent b-0 font-size-20px w-460px
        text-center mb-4px fg-foreground font-500"
          maxlength="35"
          placeholder="Título do projeto"
        >

        <div
          v-color="levelColors[rmStore.roadmap.meta.level]"
          class="rm-creation__level
        font-400 font-size-16px"
        >
          <span>Nível: </span>
          <UiDropDown
            v-model="rmStore.roadmap.meta.level"
            :items="[
              {title: 'Iniciante', value: 0}, 
              {title: 'Intermediário', value: 1}, 
              {title: 'Avançado', value: 2}]"
            class="mb-4px"
          />
        </div>
      </div>

      <div class="rm-creation__config pr-40px flex items-center z-1">
        <UiIcon
          :name="privacyIcons[rmStore.roadmap.meta.privacy]"
          color="light-gray"
          class="font-size-20px mr-8px"
        />
        <UiDropDown
          v-model="rmStore.roadmap.meta.privacy" 
          class="font-size-16px font-500 mr-20px"
          :items="[
            {title: 'Somente eu', value: 0},
            {title: 'Todos podem ver', value: 1}
          ]"
        />
        <UiBtn
          class="font-size-16px"
          @pointerdown="showPublishMenu = true"
        >
          Publicar
        </UiBtn>
      </div>
    </nav>  

    <div 
      class="rm-creation__body flex flex-grow-1"
      :class="{grabbing: isGrabbing}"
      @pointerup="stopAddElement"
    >
      <div
        class="rm-creation__side-menu select-none w-250px h-full
      b-1px-solid-light-gray flex flex-col items-center gap-15px" 
      >
        <span class="w-68% block mt-15px text-center fg-gray font-500">
          Componentes (arrastar e soltar)
        </span>
        <UiBtn
          draggable
          color="brand-orange"
          @pointerdown.left="onGrab('topic')"
        >
          Tópico
        </UiBtn>

        <UiBtn
          draggable
          color="sub-topic"
          @pointerdown.left="onGrab('subTopic')"
        >
          SubTópico
        </UiBtn>

        <UiBtn
          draggable
          color="brand-magenta"
          @pointerdown.left="onGrab('link')"
        >
          Link
        </UiBtn>
        <UiBtn
          draggable
          color="foreground"
          @pointerdown.left="onGrab('text')"
        >
          Texto
        </UiBtn>
      </div>
      <div 
        class="rm-creation__canvas w-full h-full"
        @pointerleave="onLeave"
      >
        <RmCanvas
          ref="canvas"
          v-model:scale="scale"
          v-model:roadmap="rmStore.roadmap"
          :is-on-publish="showPublishMenu"
          @on-move="onMove"
          @on-enter="onEnter"
        />
      </div>
    </div>

    <PublishMenu 
      v-model="showPublishMenu"
      @published="publish"
    />
  </section>
</template>


<style scoped>
  .grabbing {
    cursor: grabbing;
  }

  .rm-creation__title::placeholder {
    color: var(--foreground);
    opacity: 1;
  }

  .rm-creation__level:after {
    content: '';
    display: block;
    background-color: var(--current-color);
    width: 100%;
    border-radius: 5px;
    height: 5px;
    margin: auto;
  }
</style>