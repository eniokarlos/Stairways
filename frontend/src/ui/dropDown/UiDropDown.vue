<script setup lang="ts">
import { onBeforeUnmount, onMounted, onUpdated, ref, watch } from 'vue';
import UiIcon from '../icon/UiIcon.vue';

interface DropDownItem {
  title: string,
  value: unknown
}

const props = defineProps({
  items: {
    type: Array<DropDownItem>,
    required: true,
  },
  large: {
    type: Boolean,
    default: false,
  },
});

const model = defineModel<unknown>({ required: true });
const selected = ref<DropDownItem>(props.items[0]);
const list = ref<HTMLElement>();

watch(model, () => {
  const res = props.items.find(item =>
    item.value === model.value,
  );

  if (res) {
    selected.value = res;
  }
  
}, { immediate: true });

var isOpened = ref(false);

function closeOpenedMenus() {
  const openedMenus = document.querySelectorAll('.opened');
  
  openedMenus.forEach(menu => menu.classList.remove('opened'));
  
  isOpened.value = false;
}

function toggleMenu() {
  isOpened.value = !isOpened.value;
}

onUpdated(() => {
  if (list.value) {
    const offsetRight = list.value.getBoundingClientRect().right + 10;
    
    if (offsetRight > document.body.clientWidth) {
      list.value.style.transform = `translate(${document.body.clientWidth - offsetRight}px)`;
    }
  }
});

onMounted(() => {
  document.removeEventListener('pointerdown', closeOpenedMenus);
  document.addEventListener('pointerdown', closeOpenedMenus);
});

onBeforeUnmount(() => {
  document.removeEventListener('pointerdown', closeOpenedMenus);
});


</script>

<template>
  <div
    :class="{'drop-down--large': large}"
    class="drop-down relative select-none inline-block fg-foreground" 
    @pointerdown.stop="toggleMenu"
  >
    <div
      class="drop-down__content cursor-pointer flex"
    >
      <span class="drop-down__text mr-4px">{{ selected.title }}</span>
      <UiIcon
        class="drop-down__icon"
        name="chevron-down"
      />
    </div>

    <div
      v-show="isOpened"
      ref="list"
      class="drop-down__options wa mt-5px rd-4px py-9px absolute z-2 bg-white"
    >
      <ul class="list-none">
        <li
          v-for="item in items" 
          :key="item.title"
          class="drop-down__item cursor-pointer 
          pl-24px pr-58px h-40px flex items-center"
          @pointerdown.stop="
            model = item.value;
            isOpened = false;"
        >
          {{ item.title }}
        </li>
      </ul>
    </div>
  </div> 
</template>

<style scoped>
  .drop-down--large .drop-down__content{
    padding-right: 10px;
    width: 100%;
  }

  .drop-down--large .drop-down__text{
    flex-grow: 1;
  }

  .drop-down__options {
    white-space: nowrap;
    box-shadow: 0 2px 5px 0 rgba(11,20,26,.26),
    0 2px 10px 0 rgba(11,20,26,.16);
  }

  .drop-down__item:hover {
    background-color: var(--dropdown-hover)
  }
</style>