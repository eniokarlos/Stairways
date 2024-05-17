<script setup lang="ts">
import UiInput from '@/ui/input/UiInput.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import { RouterLink } from 'vue-router';
import { useAuthStore } from '@/stores/auth.store';

const auth = useAuthStore();
</script>

<template>
  <nav class="nav-bar h-70px flex items-center justify-center gap-8">
    <RouterLink
      to="/"
      class="h-32px"
    >
      <img
        class="block h-inherit"
        src="../../assets/logo.svg"
      >
    </RouterLink>

    <span class="fg-foreground cursor-pointer">Categorias</span>
    
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
      <div class="flex items-center">
        <img
          v-if="auth.user?.profileImage !== ''"
          class="h-60% rd-100% "
          :src="auth.user?.profileImage"
        >
        <img
          v-else
          class="h-60% rd-100% "
          src="https://cdn-icons-png.flaticon.com/512/9187/9187604.png"
        >
      </div>
    </div>
  </nav>
</template>

<style lang="css" scoped>
  .nav-bar {
    box-shadow: 0 2px 2px rgba(0,0,0,25%);
  }
</style>