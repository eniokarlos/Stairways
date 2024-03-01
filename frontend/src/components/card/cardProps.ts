import { PropType } from "vue";

export default {
  title: {
    type: String,
    default: ''
  },
  description: {
    type: String,
    default: ''
  },
  userName: {
    type: String,
    default: ''
  },
  rating: {
    type: Number,
    default: 0
  },
  userPicture: {
    type: String,
    default: undefined
  },
  cardPicture: {
    type: String,
    default: undefined
  },
  level: {
    type: String as PropType<'beginner' | 'intermediate' | 'advanced'>,
    default: 'beginner'
  }
}