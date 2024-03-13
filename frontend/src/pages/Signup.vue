<script setup lang="ts">
  import { RouterLink } from 'vue-router';
  import UiInput from '@/ui/input/UiInput.vue';
  import UiBtn from '@/ui/btn/UiBtn.vue';
</script>

<template>
  <section class="w-100% h-80vh flex items-center justify-center">
    <div class="flex flex-col gap-20px items-center">
      <span class="fg-foreground block font-600 font-size-24px self-start">Inscreva se</span>
      <div class="flex flex-col gap-10px">
        <UiInput placeholder="Nome Completo"></UiInput>
        <UiInput placeholder="E-mail"></UiInput>
        <UiInput type="password" placeholder="Senha"></UiInput>
      </div>
      <UiBtn large>Cadastre-se</UiBtn>
      <hr class="fg-foreground bg-red w-100%"/>
      <span class="font-size-16px">ou
        <RouterLink to="signin" class="underline fg-brand-blue cursor-pointer">
          <span>Fazer login</span>
        </RouterLink>
      </span>
    </div>
  </section>
</template>

<style scoped>

</style>