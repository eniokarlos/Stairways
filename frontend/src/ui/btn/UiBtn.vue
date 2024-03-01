<script setup lang="ts">
import { PropType } from 'vue';
  
defineProps({
    color: {
      type: String,
      default: "brand-blue"
    },
    large: Boolean,
    rounded: Boolean,
    draggable: Boolean,
    variant: {
      type: String as PropType<'outline' | 'default' | 'spherical'>,
      default: 'default'
    }
  })
</script>

<template>
  <button v-if="draggable"
    v-color="color"
    class="relative ui-btn--draggable fg-foreground border-0 cursor-grabbing w-160px h-45px rd-4px 
    font-size-16px font-600 overflow-hidden"
  >
    <div class="ui-btn__side absolute w-5px h-100% top-0 left-0">&nbsp;</div>
    <div class="absolute h-100% top-0 left-0 flex box-border py-14px px-15px">
      <img src="../../assets/draggable-icon.svg" class="block">
    </div>
    <slot/>
  </button>
  <button v-else
    v-color="color"
    :class="[`ui-btn--${variant}`, {
      'ui-btn--large': large
    }]"
    class="border-0 cursor-pointer w-140px h-42px rd-10px
    font-size-15px font-500">
    <slot/>
  </button>
</template>

<style lang="css" scoped>
  .ui-btn--default {
    background: var(--current-color) !important; 
    color: var(--fg-inverted)
  }

  .ui-btn--outline {
    background-color: transparent;
    border: 2px solid black;
  }

  .ui-btn--spherical {
    padding: 8px;
    border-radius: 100%;
  }

  .ui-btn--large {
    font-size: 24px;
    font-weight: 500;
    width: 615px !important;
    height: 70px !important;
  }

  .ui-btn--draggable {
    background-color: transparent !important;
    border: 2px solid var(--light-gray);
  }

  .ui-btn__side {
    background: var(--current-color) !important;
  }
</style>