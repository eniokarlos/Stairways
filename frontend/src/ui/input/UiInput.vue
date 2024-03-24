<script setup lang="ts">
import UiIcon from '../icon/UiIcon.vue';
import UiInputProps from './UiInputProps';
import { ref, watchEffect } from 'vue';
  
const model = ref('');
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
      {'ui-input--large': large},
      {'ui-input--focused': inputFocused}
    ]"
    class="ui-input select-none cursor-text block relative b-1px-solid-foreground 
    w-550px h-60px rd-10px flex"
  >
    <UiIcon
      v-if="prependIcon"
      class="pl-15px"
      :name="prependIcon"
      :color="color"
    />
      
    <div
      v-if="variant === 'default'"
      class="flex items-end w-100%"
    >
      <span class="block flex items-center absolute h-100%">
        <span
          class="ui-input__span block text-center font-size-16px 
          font-500 pl-20px"
        >{{ placeholder }}</span>
      </span>
      <input
        v-model="model"
        :type="type"
        class="ui-input__text font-size-18px
        bg-transparent b-0 w-100% h-80% pl-20px"
      >
    </div>

    <input
      v-else
      :type="type"
      :placeholder="placeholder" 
      class="ui-input__text b-0 block bg-transparent 
      font-size-16px pl-20px"
    >
      
    <UiIcon
      v-if="appendIcon"
      class="pr-15px"
      :name="appendIcon"
      :color="color"
    />
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
  .ui-input--large{
    width: 50%;
    height: 50px;
  }

  .ui-input--rounded {
    height: 45px;
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