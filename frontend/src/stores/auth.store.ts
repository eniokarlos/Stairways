import services from '@/services/user.services';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useAuthStore = defineStore('auth', () => {
  const token = ref(localStorage.getItem('token'));
  const isAuth = ref<boolean>(false);

  function setToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
    token.value = tokenValue;
  }

  function setIsAuth(auth: boolean) {
    isAuth.value = auth;
  }

  function clear() {
    localStorage.removeItem('token');
    isAuth.value = false;
    token.value = '';
  }

  async function verifyToken(): Promise<boolean> {
    const res = await services.verifyToken(token.value);
    if (res != 200) {
      clear();
    } 
    else {
      isAuth.value = true;
    }
    return isAuth.value;
  }

  return {
    token,
    isAuth,
    setToken,
    verifyToken,
    setIsAuth,
    clear,
  };
});