import '@unocss/reset/normalize.css';
import '@/assets/style.css';
import 'uno.css';
import { vColor } from '@/directive/vColor';
import { vRoundDecimals } from './directive/vRoundDecimals';
import { createApp } from 'vue';
import { createPinia } from 'pinia';
import router from '@/modules/router/router';
import App from './App.vue';
import { useAuthStore } from './stores/auth.store';

const pinia = createPinia();
const app = createApp(App);

app.directive('color', vColor);
app.directive('roundDecimals', vRoundDecimals);

app.use(router);
app.use(pinia);


if (localStorage.getItem('token')) {
  (async () => {
    const auth = useAuthStore();
    auth.setIsAuth(true);
    auth.setIsAuth(await auth.verifyToken());
    if (auth.isAuth == false) {
      await router.push({ name: 'login' });
    }
  })();
}

app.mount('#app');