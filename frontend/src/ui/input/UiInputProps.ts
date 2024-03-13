import { PropType } from 'vue';

export default {
  color: {
    type: String,
    default: 'foreground',
  },
  large: Boolean,
  error: {
    type: String,
    default: undefined,
  },
  type: {
    type: String,
    default: 'text',
  },
  variant: {
    type: String as PropType<'rounded' | 'default' | 'transparent'>,
    default: 'default',
  },
  placeholder: {
    type: String,
    default: '',
  },
  prependIcon: {
    type: String,
    default: undefined,
  },
  appendIcon: {
    type: String,
    default: undefined,
  },
} as const;