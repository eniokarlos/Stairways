<script setup lang="ts">
import UiInput from '@/ui/input/UiInput.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import { RouterLink } from 'vue-router';
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
      class="font-size-20px"
      variant="rounded"
      large
      prepend-icon="magnify"
      placeholder="Pesquisar alguma coisa"
      color="gray"
    />
    
    <div>
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
  </nav>
</template>

<style lang="css" scoped>
  .nav-bar {
    box-shadow: 0 4px 4px rgba(0,0,0,25%);
  }
</style>