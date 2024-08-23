<script setup lang="ts">
import Card from '@/components/card/Card.vue';
import { useAuthStore } from '@/stores/auth.store';

const user = useAuthStore().user;

</script>

<template>
  <section
    v-if="user"
    class="pa-60px flex gap-15px flex-wrap"
  >
    <h1 class="w-full"> 
      Meus Roadmaps
    </h1>
    <Card
      v-for="rm in user.roadmaps"
      :key="rm.title"
      class="cursor-pointer"
      :title="rm.title"
      :user-name="user.name"
      :user-picture="user.profileImage"
      :description="rm.description"
      :rating="0"
      :level="rm.level"
      :card-picture="rm.imageURL"
    />
  </section>
</template>
<style scoped>

</style>