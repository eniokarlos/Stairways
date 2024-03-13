<script setup lang="ts">

  import UiIcon from '../icon/UiIcon.vue';

  defineProps({
    title: {
      type: String,
      default: 'Insert a title'
    }
  })

  var scrollPos: number;

  function scrollTo(direction: 'left' | 'right', el: any) {
    const list = el.target.parentNode.parentNode.getElementsByClassName('ui-list__items')[0];
    const scrollOffset = 300;
    scrollPos = list.scrollLeft;
  
    if (direction === 'right') {
      list.scrollTo({
        left: scrollPos + scrollOffset,
        behavior: 'smooth'
      })
    }
    else {
      list.scrollTo({
        left: scrollPos - scrollOffset,
        behavior: 'smooth'
      })
    }

  }

  function pickRandomColor() {
    const colors = ['brand-blue', 'brand-orange', 'brand-magenta'];
    let random = Math.floor(Math.random() * 3);
    return colors[random]
  }
</script>

<template>
  <div class="ui-list mt-50px px-30px">
    <span v-color="pickRandomColor()" class="ui-list__title relative pb-5px ml-20px font-size-28px font-600">{{ title }}</span>

    <div class="ui-list__wrapper mt-10px relative flex m-auto">
      <div class="h-100% absolute left-0 z-2 flex items-center">
        <UiIcon @click="(el) => scrollTo('left', el)" pointer name="chevron-left" color="foreground" class="ui-list__arrow bg-white rd-100% font-size-38px w-48px h-48px"/>
      </div>

      <div class="ui-list__items flex w-98% m-auto  py-10px gap-20px">
        <slot></slot>
      </div>

      <div class="h-100% absolute right-0 z-2 flex items-center">
        <UiIcon @click="(el) => scrollTo('right', el)" pointer name="chevron-right" color="foreground" class="ui-list__arrow bg-white rd-100% font-size-38px w-48px h-48px"/>
      </div>
    </div>
  </div>
</template>


<style scoped>
  .ui-list__title::before {
    content: '';
    display: block;
    background-color: var(--current-color);
    width: 320px;
    height: 3px;
    border-radius: 4px;
    position: absolute;
    bottom: 0;
    left: 0;
  }
  .ui-list__items {
    overflow-x: auto;
  }
  .ui-list__items::-webkit-scrollbar{
    display: none;
  }

  .ui-list__arrow {
    box-shadow: 2px 2px 4px rgba(0, 0, 0, 25%), -2px 2px 4px rgba(0, 0, 0, 25%);
  }
</style>