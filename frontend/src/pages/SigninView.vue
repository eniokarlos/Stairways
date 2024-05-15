<script setup lang="ts">
import { RouterLink } from 'vue-router';
import UiInput from '@/ui/input/UiInput.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import UserServices from '@/services/user.services';
import { onBeforeUnmount, reactive } from 'vue';
import { useAuthStore } from '@/stores/auth.store';
import router from '@/modules/router/router';

const loginModel = reactive({
  email: '',
  password: '',
});

const auth = useAuthStore();

async function login() {
  const data = await UserServices.login(loginModel.email, loginModel.password)
    .then(res => res.text());
  auth.setToken(data);

  await auth.verifyToken();
}

async function loginOnEnter(e : KeyboardEvent) {
  if (e.key === 'Enter') {
    await login();
    router.push({ name: 'roadmapCreation' });
  }
}

window.addEventListener('keydown', loginOnEnter);

onBeforeUnmount(() => {
  window.removeEventListener('keydown', loginOnEnter);
});
</script>

<template>
  <section class="w-100% h-80vh flex items-center justify-center">
    <div class="flex flex-col gap-20px items-center">
      <span class="fg-foreground block font-600 font-size-24px self-start">Fazer login</span>
      <div>
        <UiInput
          v-model="loginModel.email"
          class="mb-10px w-550px h-60px"
          placeholder="E-mail"
        />
        <UiInput
          v-model="loginModel.password"
          class="w-550px h-60px"
          type="password"
          placeholder="Senha"
        />
      </div>
      <RouterLink to="roadmap-creation">
        <UiBtn 
          large
          @pointerdown="login"
        >
          Fazer login
        </UiBtn>
      </RouterLink>
      <span class="font-size-16px">ou
        <RouterLink
          to="password-reset"
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