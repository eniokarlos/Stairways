<script setup lang="ts">
import UiInput from '@/ui/input/UiInput.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import { RouterLink } from 'vue-router';
import { useAuthStore } from '@/stores/auth.store';
import UiOverlayMenu from '@/ui/overlayMenu/uiOverlayMenu.vue';
import { useCategoryStore } from '@/stores/category.store';

const auth = useAuthStore();
const categories = useCategoryStore();
</script>

<template>
  <nav class="shadow h-70px flex items-center justify-center gap-8">
    <RouterLink
      to="/"
      class="h-32px"
    >
      <img
        class="block h-inherit"
        src="../../assets/logo.svg"
      >
    </RouterLink>
    <UiOverlayMenu 
      close-on-click
      close-on-click-content
      origin="bottom-start"
    >
      <template #activator="{attrs}">
        <span
          v-bind="attrs"
          class="fg-foreground cursor-pointer"
        >Categorias</span>
      </template>
      <div
        class="shadow max-h-30vh overflow-auto w-400px mt-5px rd-4px py-9px absolute z-2 bg-white"
      >
        <ul class="list-none">
          <li
            v-for="c in categories.list" 
            :key="c.id"
            class="cursor-pointer hover:bg-dropdown-hover
          pl-24px pr-58px h-40px flex items-center"
          >
            {{ c.name }}
          </li>
        </ul>
      </div>
    </UiOverlayMenu>
    
    <UiInput
      class="font-size-20px w-50% h-45px"
      variant="rounded"
      large
      prepend-icon="magnify"
      placeholder="Pesquisar alguma coisa"
      color="gray"
    />
    
    <div v-if="!auth.isAuth">
      <RouterLink to="signup">
        <UiBtn class="mr-14px">
          Cadastre-se
        </UiBtn>
      </RouterLink>
      <RouterLink to="signin">
        <UiBtn variant="outline">
          Fazer login
        </UiBtn>
      </RouterLink>
    </div>
    <div
      v-else
      class="h-full flex w-320px gap-20px"
    >
      <RouterLink
        to="/"
        class="font-size-15px fg-foreground decoration-none flex items-center"
      >
        Meu Progresso
      </RouterLink>
      <RouterLink
        to="/"
        class="font-size-15px fg-foreground decoration-none flex items-center"
      >
        Meus Roadmaps
      </RouterLink>
      <UiOverlayMenu
        close-on-click
        close-on-click-content
        origin="bottom-end"
      >
        <template #activator="{attrs}">
          <div
            v-bind="attrs"
            class="flex cursor-pointer items-center"
          >
            <img
              v-if="auth.user?.profileImage !== ''"
              class="h-70% rd-100% "
              :src="auth.user?.profileImage"
            >
            <div 
              v-else
              class="bg-black fg-white w-40px h-40px rd-100% 
          flex items-center justify-center font-500 font-size-18px"
            >
              {{ auth.user?.name[0].toUpperCase() }}
            </div>
          </div>
        </template>
        <div
          class="bg-white cursor-pointer hover:bg-dropdown-hover px-20px py-10px shadow rd-4px"
          @click="auth.clear()"
        >
          Sair
        </div>
      </UiOverlayMenu>
    </div>
  </nav>
</template>

<style lang="css" scoped>
  .shadow {
    box-shadow: 0 2px 2px rgba(0,0,0,25%);
  }
</style>