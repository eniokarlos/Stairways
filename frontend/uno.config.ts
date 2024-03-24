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
      'fg-inverted': '#fff',
      'foreground': '#2E2E2E',
      'light-gray': '#BFBFBF',
      'light-gray-alfa': '#BFBFBF60',
      'dropdown-hover': '#f6f6f6',
      'gray': '#8F8F8F',
      'card-bg': '#E6E6E6',
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