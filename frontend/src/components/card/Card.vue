<script setup lang="ts">
import UiIcon from '@/ui/icon/UiIcon.vue';
import cardProps from '@/components/card/cardProps';
import { ref, Ref, watch } from 'vue';

const props = defineProps({ ...cardProps });
var isSaved: Ref<boolean> = ref(false),
  isLiked: Ref<boolean> = ref(false);

  type BtnVariant = 'outline' | 'default'; 

var saveBtnVariant: Ref<BtnVariant> = ref(isSaved.value? 'default': 'outline'),
  likeBtnVariant: Ref<BtnVariant> = ref(isLiked.value? 'default': 'outline');

const cardColors = {
  beginner: 'brand-blue',
  intermediate: 'brand-orange',
  advanced: 'brand-magenta',
};

function getRatingColor(): string{
  const rating = props.rating;
    
  if (rating <= 50) {
    return 'brand-blue';
  }
  else if (rating > 50 && rating <= 70) {
    return 'brand-orange';
  }
  else {
    return 'brand-magenta';
  }
}

watch([
  isSaved,
  isLiked,
], ([
  newSaved,
  newLiked,
]) => {
  saveBtnVariant.value = newSaved ? 'default' : 'outline';
  likeBtnVariant.value = newLiked ? 'default' : 'outline';
});


</script>/

<template>
  <div
    v-color="cardColors[level]"
    class="card relative w-250px h-350px flex flex-col justify-between 
    rd-15px bg-light-gray-alfa"
  >
    <div>
      <div class="card__header flex items-center h-12% mb-15px mt-8px pl-10px">
        <img
          v-if="userPicture"
          :src="userPicture"
          class="w-28px h-28px rd-100% "
        >
        <UiIcon
          v-else
          name="account"
          class="bg-light-gray w-25px h-25px font-size-20px rd-100%"
        />
        <span class="font-500 pl-10px pt-5px">{{ userName }}</span>
        <div class="card-header__side w-30px h-10px absolute right-0">
&nbsp;
        </div>
      </div>

      <div class="card__body flex flex-col items-center gap-10px">
        <img
          :src="cardPicture"
          class="w-210px h-118px rd-4px"
        >
        <div class="card__text w-180px text-center">
          <h4 class="fg-foreground mb-5px">
            {{ title }}
          </h4>
          <span class="fg-gray font-size-12px">{{ description }}</span>
        </div>
      </div>
    </div>

    <div class="card__footer flex justify-between pr-15px mb-18px text-center font-500">
      <div>
        <span
          class="card__level block bg-brand-blue fg-white font-size-12px 
        px-15px py-4px"
        >Level: {{ level }}</span>
        <span class="fg-gray font-size-12px block mt-2px">
          Avaliações: <span
            v-color="getRatingColor()"
            class="card__rating fg-brand-magenta"
          >{{ rating }}%</span>
        </span>
      </div>
      <div class="flex text-size-30px gap-2px items-start">
        <UiIcon
          pointer
          name="bookmark"
          :variant="saveBtnVariant"
          color="brand-blue"
          @click="isSaved = !isSaved"
        />
        <UiIcon
          pointer
          name="heart"
          :variant="likeBtnVariant"
          color="brand-magenta"
          @click="isLiked = !isLiked"
        />
      </div>
    </div>
  </div>
</template>

<style lang="css" scoped>
  .card {
    box-shadow: 3px 3px 2px rgba(0,0,0,25%);
    min-width: 250px;
    min-height: 320px;
    user-select: none;
  }

  .card-header__side {
    background-color: var(--current-color);
  }

  .card__level {
    border-radius: 0 3px 3px 0;
    background-color: var(--current-color);
  }

  .card__rating {
    color: var(--current-color);
  }
</style>