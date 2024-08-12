<script setup lang="ts">
import { ref } from 'vue';

const props = defineProps({
  initialValue: {
    type: Boolean,
    default: false,
  },
});
const isChecked = ref<boolean>(props.initialValue);

const emits = defineEmits<{
  'change': [value: boolean]
}>();
</script>

<template>
  <div
    class="flex items-center gap-10px cursor-pointer"
    @click="isChecked = !isChecked; emits('change', isChecked)"
  >
    <div
      :class="{'checked': isChecked}" 
      class="container relative bg-light-gray w-50px h-28px rd-25px "
    >
      <div class="button bg-white w-25px h-25px rd-25px absolute m-2px" />
    </div>
    <span class="font-size-18px font-500">Concluído</span>
  </div>
</template>

<style scoped>
  .container {
    transition: .2s;
  }
  .button {
    transition: .2s;
  }
  .checked {
    background-color: var(--green);
  }
  .checked .button {
    transform: translateX(20px);
  }
</style>