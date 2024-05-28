import { defineConfig, presetMini, presetUno, presetWebFonts, presetTypography } from 'unocss';

export default defineConfig({
  presets: [
    presetUno(),
    presetMini(),
    presetTypography(),
    presetWebFonts({
      fonts: {
        sans: {
          name: 'Fredoka',
          weights: [
            300,
            400,
            500,
            600,
            700,
          ], 
        }, 
      }, 
    }),
  ],
  theme: {
    colors: {
      'brand-orange': '#FF8811',
      'brand-blue': '#009FB7',
      'brand-magenta': '#DB2763',
      'sub-topic': '#FFE599',
      'fg-inverted': '#fff',
      'foreground': '#2E2E2E',
      'light-gray': '#BFBFBF',
      'light-gray-alfa': '#BFBFBF40',
      'pink': '#ffe4e8',
      'white': '#ffffff',
      'red': '#FF0000',
      'green': '#7FB069',
      'dropdown-hover': '#f6f6f6',
      'dark-gray': '#727272',
      'gray': '#8F8F8F',
    },
  },
  rules: [
    [
      /^theme-light$/,
      (match, { theme }) => {
        if (theme.colors) {
          const css: Record<string,string> = {};

          for (const [
            token,
            value,
          ] of Object.entries(theme.colors)) {
            css[`--${token}`] = value as string;
          }
          return css;
        }
      },
    ],

    [
      /^fg-(.+)$/,
      match => ({ 'color': `var(--${match[1]})` }),
    ],

    [
      /^b-(\d+[^-]*)-(\w+)-(.*)$/,
      match => ({ 'border': `${match[1]} ${match[2]} var(--${match[3]})` }),
    ],
  ],
});