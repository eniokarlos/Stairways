<script setup lang="ts">
import UiIcon from '../icon/UiIcon.vue';
import UiInputProps from './UiInputProps';
import { watchEffect } from 'vue';
  
const model = defineModel<string>();

const emit = defineEmits<{
  (name: 'submitted'): void,
  (name: 'leftIconClicked'): void,
  (name: 'rightIconClicked'): void
}>();

var inputFocused = false;

defineProps({ ...UiInputProps });

watchEffect(() => {
  if (model.value) {
    inputFocused = true;
  }
  else {
    inputFocused = false;
  }
});
</script>

<template>
  <label
    v-color="color"
    :class="[  
      `ui-input--${variant}`,
      {'ui-input--focused': inputFocused}
    ]"
    class="ui-input select-none cursor-text block relative b-1px-solid-foreground 
    min-w-100px min-h-20px rd-10px flex"
  >
    <div
      v-if="prependIcon"
      class="flex items-center
      justify-center cursor-pointer w-50px h-full"
      @pointerdown="emit('leftIconClicked')"
    >
      <UiIcon
        :name="prependIcon"
        :color="color"
      /> 
    </div>
      
    <div
      v-if="variant === 'default'"
      class="flex items-end w-100%"
    >
      <span class="block flex items-center z-0 absolute w-full h-full">
        <span
          class="ui-input__span block text-center font-size-16px 
          font-500 pl-2%"
        >{{ placeholder }}</span>
      </span>
      <input
        v-model="model"
        :type="type"
        :maxlength="maxLenght"
        class="ui-input__text font-size-18px
        bg-transparent b-0 z-1 w-100% h-80% pl-2%"
        @keydown.enter="emit('submitted')"
      >
    </div>

    <input
      v-else
      v-model="model"
      :type="type"
      :placeholder="placeholder"
      :maxlength="maxLenght"
      class="ui-input__text b-0 block bg-transparent 
      font-size-16px w-full"
      @keydown.enter="emit('submitted')"
    >
      
    <div
      v-if="appendIcon"
      class="flex items-center
      justify-center cursor-pointer w-50px h-full"
      @pointerdown="emit('rightIconClicked')"
    >
      <UiIcon
        :name="appendIcon"
        :color="color"
      /> 
    </div>
  </label>
</template>


<style lang="css" scoped>
  .ui-input .ui-input__text{
    color: var(--current-color) !important;
  }

  .ui-input__text::placeholder{
    color: var(--current-color) !important;
    opacity: 1;
  }

  .ui-input--rounded {
    border-radius: 24px;
  }
  
  .ui-input__span {
    transition: all 0.2s ease;
  }

  .ui-input:focus-within .ui-input__span,
  .ui-input--focused  .ui-input__span{
    font-size: 14px;
    transform: translateY(-16px);
  }

</style>