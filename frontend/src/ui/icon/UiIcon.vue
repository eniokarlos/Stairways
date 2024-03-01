<script setup lang="ts">
  import { PropType } from 'vue';

  const props = defineProps({
    name: String,
    variant: {
      type: String as PropType<'outline' | 'default'>,
      default: 'default'
    },
    color: {
      type: String,
      default: 'blue'
    },
    pointer: Boolean
  })

  function getClassName() {
    if (props.variant === 'default') 
      return `mdi-${props.name}`
    else
      return `mdi-${props.name}-outline`
  }
</script>

<template>
    <i v-color="color"
    class="ui-icon mdi flex items-center justify-center"
      :class="[getClassName(), {'ui-icon--pointer': pointer}]"
    />
</template>

<style lang="css" scoped>
  @import url("https://cdn.jsdelivr.net/npm/@mdi/font@7.4.47/css/materialdesignicons.min.css");

  .ui-icon {
    color: var(--current-color) !important;
    user-select: none;
  }

  .ui-icon--pointer {
    cursor: pointer;
  }

  .ui-icon::before {
    font-size: inherit;
    font-weight: inherit;
  }

</style>