import { defineConfig } from 'vite';
import path from 'path';
import vue from '@vitejs/plugin-vue';
import UnoCSS from 'unocss/vite';
import { fileURLToPath } from 'url';
import vueJsx from '@vitejs/plugin-vue-jsx';

// https://vitejs.dev/config/
export default defineConfig({
  resolve: { alias: { '@': path.resolve(fileURLToPath(import.meta.url), '../src') } },
  plugins: [
    vue(),
    vueJsx(),
    UnoCSS(),
  ],
});
