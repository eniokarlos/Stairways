import {defineConfig, presetMini, presetUno} from 'unocss'

export default defineConfig({
  presets: [
    presetUno(),
    presetMini(),
  ],
  theme: {
    colors: {
      'brand-orange': '#FF8811',
      'brand-blue': '#009FB7',
      'brand-magenta': '#DB2763',
      'fg-inverted': '#fff',
      'foreground': '#2E2E2E',
      'light-gray': '#BFBFBF',
      'gray': '#8F8F8F',
      'card-bg': '#E6E6E6'
    }
  },
  rules: [
    [/^theme-light$/, (match, {theme}) => {
      if (theme.colors) {
        const css: Record<string,string> = {}

        for (const [token, value] of Object.entries(theme.colors)) {
          css[`--${token}`] = value as string;
        }
        return css;
      }
    }],

    [/^fg-(.+)$/, match => ({'color' : `var(--${match[1]})`})],

    [/^b-(\d+[^-]*)-(\w+)-(.*)$/, match => ({
      'border': `${match[1]} ${match[2]} var(--${match[3]})`
    })]
  ],
})