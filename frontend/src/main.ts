import '@unocss/reset/normalize.css';
import '@/assets/style.css';
import 'virtual:uno.css';
import { vColor } from '@/directive/vColor';
import { vRoundDecimals } from './directive/vRoundDecimals';
import { createApp } from 'vue';
import router from '@/modules/router/router';
import App from './App.vue';

const app = createApp(App);

app.directive('color', vColor);
app.directive('roundDecimals', vRoundDecimals);
app.use(router);

app.mount('#app');