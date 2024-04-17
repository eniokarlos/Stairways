<script setup lang="ts">

defineProps({
  name: String,
  color: {
    type: String,
    default: 'blue',
  },
});

</script>

<template>
  <i
    v-color="color"
    :class="`mdi mdi-${name}`"
    class="ui-icon flex items-center justify-center"
  />
</template>

<style lang="css" scoped>
  @import url("https://cdn.jsdelivr.net/npm/@mdi/font@7.4.47/css/materialdesignicons.min.css");

  .ui-icon {
    color: var(--current-color) !important;
    user-select: none;
  }

  .ui-icon::before {
    font-size: inherit;
    font-weight: inherit;
  }

</style>