<script setup lang="ts">
  import { onBeforeUnmount, ref } from 'vue';
  import UiIcon from '../icon/UiIcon.vue';

  const props = defineProps({
    items: {
      type: Array<string>,
      default: ['']
    },
  })

  const selected = ref(props.items[0])
  var isOpened = ref(false);

  function closeOpenedMenus() {
    let openedMenus = document.querySelectorAll('.opened');
  
    openedMenus.forEach(menu => menu.classList.remove('opened'))
  
    isOpened.value = false;
  }

  document.addEventListener('click', closeOpenedMenus)

  onBeforeUnmount(() => {
    window.removeEventListener('click', closeOpenedMenus)
  })


</script>

<template>
  <div @click.stop="isOpened = !isOpened" 
  class="drop-down select-none inline-block relative fg-foreground ">

    <div class="cursor-pointer flex">
      <span class="mr-4px">{{ selected }}</span>
      <UiIcon name="chevron-down"></UiIcon>
    </div>

    <div class="drop-down__options wa mt-5px rd-4px py-9px absolute z-2 bg-white
    hidden" :class="{opened: isOpened}">
      <ul class="list-none">
        <li class="drop-down__item cursor-pointer 
        pl-24px pr-58px h-40px flex items-center" 
            v-for="item,i in items" :key="i"
            @click.stop="selected = item;
            isOpened = false
            $emit('selected', {item, index:i})"
          >
          {{ item }}
        </li>
      </ul>
    </div>
  </div> 
</template>

<style scoped>
  .drop-down__options {
    white-space: nowrap;
    box-shadow: 0 2px 5px 0 rgba(11,20,26,.26),
    0 2px 10px 0 rgba(11,20,26,.16);
  }

  .drop-down__item:hover {
    background-color: var(--dropdown-hover)
  }

  .opened {
    display: block;
  }
</style>