<script setup lang="ts">
import UiIcon from '@/ui/icon/UiIcon.vue';
import UiDropDown from '@/ui/dropDown/UiDropDown.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import RmCanvas from '@/components/canvas/RmCanvas.vue';
import { ref } from 'vue';


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

</script>

<template>
  <section class="h-screen">
    <nav
      class="rm-creation__nav flex h-8% relative justify-between
    items-center b-1px-solid-light-gray"
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

      <div class="rm-creation__title absolute z-0 w-full flex flex-col items-center">
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

    <div class="rm-creation__body h-92% flex">
      <div class="rm-creation__side-menu w-10% b-1px-solid-light-gray w-230px h-100%">
        <span class="w-70% block m-auto text-center fg-gray font-500 mt-20px">
          Componentes (arrastar e soltar)
        </span>
      </div>
      <div class="rm-creation__canvas w-90% h-100%">
        <RmCanvas />
      </div>
    </div>
  </section>
</template>


<style scoped>


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