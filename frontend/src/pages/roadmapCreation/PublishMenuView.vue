<script setup lang="ts">
import UiDropDown from '@/ui/dropDown/UiDropDown.vue';
import { useRoadmapStore } from '@/stores/roadmap.store';
import UiIcon from '@/ui/icon/UiIcon.vue';
import { onMounted, ref } from 'vue';
import UiTags from '@/ui/tags/UiTags.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import UiInput from '@/ui/input/UiInput.vue';

const store = useRoadmapStore();
const imageSearch = ref<string>('');
const isOnFirstStep = ref<boolean>(true);
const isActive = defineModel<boolean>();
const title = ref<HTMLTextAreaElement>();
// eslint-disable-next-line @typescript-eslint/no-explicit-any
const imageResult = ref<Array<any>>();

function autoGrow() {
  if (title.value) {
    title.value.style.height = '5px';
    title.value.style.height = (title.value.scrollHeight) + 'px';
  }
}

const emits = defineEmits(['published']);

async function getImages() {
  const API_KEY = '43438261-1366a182f6ecb194485b76aa6';

  const URL = `https://pixabay.com/api/?key=${API_KEY}&`+
  `q=${encodeURIComponent(imageSearch.value)}&`+
  'image-type=photo&lang=pt&'+
  'orientation=horizontal&'+
  'per_page=150&safesearch=true';

  const init: RequestInit = {
    method: 'GET',
    mode: 'cors',
    cache: 'default',
  };

  await fetch(URL, init)
    .then(async (res) => {
      const json = await res.json();
      imageResult.value = JSON.parse(JSON.stringify(json.hits));
    });
}

onMounted(getImages);

</script>
  
<template>
  <Transition :duration="550">
    <div
      v-if="isActive"
      class="menu-bg absolute h-full w-full flex flex-col 
      items-center justify-center z-9"
    >
      <div
        v-if="isOnFirstStep"
        class="menu relative w-25% 
        h-fit-content bg-white pa-25px rd-20px"
      >
        <UiIcon 
          color="light-gray"
          name="close"
          class="absolute cursor-pointer 
          font-600 font-size-24px right-20px"
          @pointerdown="isActive = false"
        />
        <textarea
          ref="title"
          v-model="store.roadmap.meta.title"
          rows="1"
          type="text"
          class="title block b-0 resize-none font-size-20px w-90%
          fg-foreground font-500 mb-8px"
          maxlength="35"
          placeholder="Título do projeto"
          @input="autoGrow"
        />
        <span class="font-500">Nível: </span>
        <UiDropDown
          v-model="store.roadmap.meta.level"
          :items="[
            {title: 'Iniciante', value: 0}, 
            {title: 'Intermediário', value: 1}, 
            {title: 'Avançado', value: 2}]"
          class="mb-4px font-500"
        />
  
        <label class="block w-full font-500 mt-20px">
          Descrição
          <textarea
            v-model="store.roadmap.meta.description"
            class="border-gray resize-none w-full mt-4px rd-5px
          h-100px font-size-16px pa-10px fg-dark-gray"
            maxlength="150"
          />
        </label>
        <UiTags 
          v-model="store.roadmap.meta.tags"
        />
        <div class="flex justify-end mt-20px">
          <UiBtn
            @pointerdown="isOnFirstStep = false"
          >
            Próximo
          </UiBtn>
        </div>
      </div>
      <div
        v-else
        class="menu relative w-800px 
        h-fit-content bg-white pa-25px rd-20px"
      >
        <div
          class="h-30px flex items-center 
        mb-10px"
        >
          <UiIcon 
            color="light-gray"
            name="arrow-left"
            class="cursor-pointer 
            font-size-24px"
            @pointerdown="isOnFirstStep = true"
          />
          <span
            class="grow text-center fg-gray 
          font-size-18px"
          >
            Adicione uma imagem
          </span>
          <UiIcon 
            color="light-gray"
            name="close"
            class="cursor-pointer 
          font-600 font-size-24px"
            @pointerdown="isActive = false"
          />
        </div>
        <UiInput
          v-model="imageSearch"
          color="dark-gray"
          variant="rounded"
          class="b-1px-solid-light-gray w-80% font-size-20px 
            mt-4px h-35px m-auto mb-20px"
          prepend-icon="magnify"
          placeholder="pesquisar"
          @submitted="getImages"
        />
        <div
          v-if="store.roadmap.meta.imageURL" 
          class="flex justify-center mb-10px"
        >
          <img
            :src="store.roadmap.meta.imageURL"
            class="w-180px h-120px"
          >
        </div>
        <div
          class="flex flex-wrap gap-4px 
        max-h-370px overflow-auto"
        >
          <div
            v-for="image in imageResult"
            :key="image.id"
            :class="{'selected-img': 
              image.webformatURL === store.roadmap.meta.imageURL}"
            class="cursor-pointer relative 
            w-180px h-120px"
            @pointerdown="store.roadmap.meta.imageURL = image.webformatURL;"
          >
            <img 
              :src="image.webformatURL"
              class="h-full w-full"
            >
          </div>
        </div>
        <div class="flex justify-end mt-20px">
          <UiBtn
            @pointerdown="
              emits('published');
              isActive=false;"
          >
            Publicar
          </UiBtn>
        </div>
      </div>
    </div>
  </Transition>
</template>

<style scoped>
  .border-gray {
    border: 1px solid #929495;
  }

  .selected-img::before {
    content: url('../../assets/check.svg');
    position: absolute;
    z-index: 2;
    width: 40%;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
  }

  .selected-img img {
    filter: brightness(0.2);
  }

  .title::-webkit-scrollbar {
    display: none;
  } 
  .title {
    scrollbar-width: none;
  }
  .menu-bg {
    background: rgba(0, 0, 0, 0.2);
  }

  .v-enter-active,
  .v-leave-active {
    transition: all 0.2s ease;
  }

  .v-enter-from,
  .v-leave-to {
    opacity: 0;
  }

  .v-enter-active .menu,
  .v-leave-active .menu {
    transition: all 0.2s ease;
  }

  .v-enter-active .menu {
    transition-delay: 0.15s;
  }

  .v-enter-from .menu,
  .v-leave-to .menu {
    transform: scale(1.2);
    opacity: 0;
  }
</style>