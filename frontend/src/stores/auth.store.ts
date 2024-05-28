import services, { UserApi} from '@/services/user.services';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useAuthStore = defineStore('auth', () => {
  const user = ref<UserApi| null>(JSON.parse(localStorage.getItem('user')!));
  const token = ref(localStorage.getItem('token'));
  const isAuth = ref<boolean>(false);

  function setToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
    token.value = tokenValue;
  }

  function setIsAuth(value: boolean) {
    isAuth.value = value;
  }

  function setUser(newUser: User){
    localStorage.setItem('user', JSON.stringify(newUser));
    user.value = newUser;
  }

  function clear() {
    localStorage.removeItem('token');
    user.value = null;
    isAuth.value = false;
    token.value = '';
  }

  async function verifyToken(): Promise<boolean> {
    try {
      await services.verifyToken(token.value);
    }
    catch {
      clear();
      return false;
    }
    isAuth.value = true;
    return true;
  }

  return {
    user,
    token,
    isAuth,
    setToken,
    setUser,
    verifyToken,
    setIsAuth,
    clear,
  };
});