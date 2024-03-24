<script setup lang="ts">
import UiIcon from '@/ui/icon/UiIcon.vue';
import UiDropDown from '@/ui/dropDown/UiDropDown.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import RmCanvas, { GridMoveEvent } from '@/components/canvas/RmCanvas.vue';
import { reactive, ref } from 'vue';
import { RoadmapItem } from '@/components/canvas/Util/roadmap.interfaces';

const levelColors = [
  'brand-blue',
  'brand-orange',
  'brand-magenta',
];

const privacity = [
  {
    value: 'public',
    icon: 'earth', 
  },
  {
    value: 'private',
    icon: 'lock', 
  },
];

const selectedPrivacity = ref(0);
const selectedLevel = ref(0);

const roadmapItems = reactive<RoadmapItem[]>([]);
const scale = ref<number>(1);
const newItem = ref<RoadmapItem>();
const defaultItemSize = {
  w: 256,
  h: 64, 
};

let isGrabbing: boolean = false;
let lastItemType: string;
let lastMoveEvent: GridMoveEvent;

function onGrab(itemType: string) {
  lastItemType = itemType;
  isGrabbing = true;
}

function onEnter(e: GridMoveEvent) {
  if (isGrabbing) {
    lastMoveEvent = e;
    newItem.value = {
      id: crypto.randomUUID(),
      width: defaultItemSize.w,
      height: defaultItemSize.h,
      x: (e.event.offsetX - lastMoveEvent.grid.x) / scale.value,
      y: (e.event.offsetY - lastMoveEvent.grid.y) / scale.value,
      type: lastItemType,
    };
    roadmapItems.push(newItem.value);
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
    roadmapItems.pop();
  }
}

function stopAddElement() {
  isGrabbing = false;
  newItem.value = undefined;
}


</script>

<template>
  <section class="h-screen flex flex-col">
    <nav
      class="rm-creation__nav flex w-full h-62px relative justify-between
    items-center b-1px-solid-light-gray "
    >
      <RouterLink
        to="/"
        class="z-1 fg-foreground decoration-none"
      >
        <UiIcon
          name="arrow-left"
          class="font-size-30px pl-40px"
        />
      </RouterLink>

      <div class="rm-creation__title absolute z-1 w-full flex flex-col items-center">
        <input
          type="text"
          class="block bg-transparent b-0 font-size-20px w-460px
        text-center mb-4px fg-foreground font-500"
          maxlength="35"
          placeholder="Título do projeto"
        >

        <div
          v-color="levelColors[selectedLevel]"
          class="rm-creation__level
        font-400 font-size-16px"
        >
          <span>nível: </span>
          <UiDropDown
            :items="['iniciante', 'intermediário', 'avançado']"
            class="mb-4px"
            @selected="data => selectedLevel = data.index"
          />
        </div>
      </div>

      <div class="rm-creation__config pr-40px flex items-center z-1">
        <UiIcon
          :name="privacity[selectedPrivacity].icon"
          color="light-gray"
          class="font-size-20px mr-8px"
        />
        <UiDropDown
          class="font-size-14px font-500 mr-20px" 
          :items="['todos podem ver', 'somente eu']"
          @selected="data => selectedPrivacity = data.index"
        />
        <UiBtn class="font-size-16px">
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
        class="rm-creation__side-menu w-250px h-full
      b-1px-solid-light-gray flex flex-col items-center" 
      >
        <span class="w-68% block my-20px text-center fg-gray font-500">
          Componentes (arrastar e soltar)
        </span>
        <UiBtn
          draggable
          color="brand-orange"
          @pointerdown.left="onGrab('topic')"
        >
          Tópico
        </UiBtn>
      </div>
      <div 
        class="rm-creation__canvas w-full h-full"
        @pointerleave="onLeave"
      >
        <RmCanvas
          v-model:scale="scale"
          :items="roadmapItems"
          @on-move="onMove"
          @on-enter="onEnter"
        />
      </div>
    </div>
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