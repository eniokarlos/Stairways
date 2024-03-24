<script setup lang="ts">
import { RouterLink } from 'vue-router';
import UiInput from '@/ui/input/UiInput.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
</script>

<template>
  <section class="w-100% h-80vh flex items-center justify-center">
    <div class="flex flex-col gap-20px items-center">
      <span class="fg-foreground block font-600 font-size-24px self-start">Fazer login</span>
      <div>
        <UiInput
          class="mb-10px"
          placeholder="E-mail"
        />
        <UiInput
          type="password"
          placeholder="Senha"
        />
      </div>
      <UiBtn large>
        Fazer login
      </UiBtn>
      <span class="font-size-16px">ou
        <RouterLink
          to="password_reset"
          class="underline fg-brand-blue cursor-pointer"
        >
          <span>Esqueci a senha</span>
        </RouterLink>
      </span>
      <hr class="fg-foreground bg-red w-100%">
      <span class="text-center font-size-16px">Ainda não tem uma conta? <br>
        <RouterLink
          to="signup"
          class="underline fg-brand-blue cursor-pointer"
        >
          Cadastre-se
        </RouterLink>
      </span>
    </div>
  </section>
</template>


<style scoped>

</style>