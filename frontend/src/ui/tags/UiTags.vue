<script setup lang="ts">
import UiInput from '../input/UiInput.vue';
import UiIcon from '../icon/UiIcon.vue';
import { ref } from 'vue';

const tags = defineModel<string[]>({ required: true });
const tagText = ref<string>('');

function addNewTag() {
  if (tagText.value && tags.value.length < 10) {
    tags.value.push(tagText.value);
  }
}

</script>

<template>
  <label class="block w-full font-500 mt-20px mb-10px">
    Tags
    <UiInput
      v-model="tagText"
      color="dark-gray"
      variant="rounded"
      class="border-gray w-100% font-size-18px 
      mt-4px h-35px"
      prepend-icon="tag-outline"
      append-icon="plus"
      placeholder="Adicionar uma tag"
      :max-lenght="20"
      @submitted="addNewTag"
      @right-icon-clicked="addNewTag"
    />
  </label>
  <div class="flex gap-5px flex-wrap">
    <div
      v-for="tag, i in tags"
      :key="tag"
      class="relative tag flex bg-brand-blue 
      fg-white w-fit-content h-30px rd-15px 
      items-center justify-center px-15px"
    >
      <span class="text-nowrap mr-25px">{{ tag }}</span>
      <div
        class="tag-close absolute right-0 cursor-pointer
        w-30px h-full flex items-center justify-center"
        @pointerdown="tags.splice(i,1)"
      >
        <UiIcon 
          name="close"
        />
      </div>
    </div>
  </div>
</template>

<style scoped>
  .tag {
    font-family: 'Fredoka';
  }

  .tag-close {
    border-radius: 0 15px 15px 0;
  }

  .border-gray {
    border: 1px solid #929495;
  }
</style>