<script setup lang="ts">
import { RouterLink } from 'vue-router';
import UiInput from '@/ui/input/UiInput.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import { User } from '@/services/user.services';
import userServices from '@/services/user.services';
import { onBeforeUnmount, ref } from 'vue';
import { useAuthStore } from '@/stores/auth.store';
import router from '@/modules/router/router';

const auth = useAuthStore();
const user = ref<User>(new User());

async function signUp() {
  let res;
  try {
    res = await userServices.register(user.value)
      .then(res => res.json());
    console.log(res);
  }
  catch {
    auth.clear();
    return;
  }
  auth.setToken(res.token);
  auth.setUser(res.user);
  auth.setIsAuth(true);
  router.push('/');
}

async function signUpOnEnter(e : KeyboardEvent) {
  if (e.key === 'Enter') {
    await signUp();
  }
}

window.addEventListener('keydown', signUpOnEnter);

onBeforeUnmount(() => {
  window.removeEventListener('keydown', signUpOnEnter);
});

</script>

<template>
  <section class="w-100% h-80vh flex items-center justify-center">
    <div class="flex flex-col gap-20px items-center">
      <span class="fg-foreground block font-600 font-size-24px self-start">Inscreva se</span>
      <div class="flex flex-col gap-10px">
        <UiInput 
          v-model="user.name"
          class="w-550px h-60px"
          placeholder="Nome Completo"
        />
        <UiInput
          v-model="user.email"
          class="w-550px h-60px"
          placeholder="E-mail"
        />
        <UiInput
          v-model="user.password"
          class="w-550px h-60px"
          type="password"
          placeholder="Senha"
        />
      </div>
      <UiBtn 
        large
        @pointerdown="signUp"
      >
        Cadastre-se
      </UiBtn>
      <hr class="fg-foreground bg-red w-100%">
      <span class="font-size-16px">ou
        <RouterLink
          to="signin"
          class="underline fg-brand-blue cursor-pointer"
        >
          <span>Fazer login</span>
        </RouterLink>
      </span>
    </div>
  </section>
</template>

<style scoped>

</style>