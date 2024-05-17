<script setup lang="ts">
import UiList from '@/ui/uiList/UiList.vue';
import Card from '@/components/card/Card.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import UiIcon from '@/ui/icon/UiIcon.vue';
import { useAuthStore } from '@/stores/auth.store';

const auth = useAuthStore();
</script>

<template>
  <section>
    <RouterLink 
      v-if="auth.isAuth"
      to="roadmap-creation"
    >
      <UiBtn
        class="w-60px h-60px fixed 
      bottom-40px right-10px z-10 bg-brand-orange"
        variant="rounded"
      >
        <UiIcon
          color="white"
          name="plus"
          class="font-500 font-size-38px"
        />
      </UiBtn>
    </RouterLink>
    <UiList title="Desenvolvimento">
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
    </UiList>
    <UiList title="Programação">
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
      <Card 
        title="Desenvolvimento web"
        user-name="Enio Carlos"
        user-picture="https://avatars.githubusercontent.com/u/76124109?v=4"
        description="Eiusmod cupidatat ea irure et do quis qui id qui elit."
        :rating="80"
        level="beginner"
        card-picture="https://cdn.pixabay.com/photo/2017/08/10/08/47/laptop-2620118_960_720.jpg"
      />
    </UiList>
    <UiList title="Música">
      <Card
        title="Violão Básico"
        card-picture="https://cdn.pixabay.com/photo/2016/01/14/06/09/woman-1139397_960_720.jpg"
        level="beginner"
        description="Enim occaecat sit consequat excepteur eu consectetur qui enim Lorem qui cupidatat cillum sit."
        :rating="100"
        user-name="Joao Manoel"
        user-picture="https://avatars.githubusercontent.com/u/83477417?v=4"
      />
      <Card
        title="Violão intermediário"
        card-picture="https://cdn.pixabay.com/photo/2015/09/17/14/24/woman-944261_1280.jpg"
        level="intermediate"
        description="Enim occaecat sit consequat excepteur eu consectetur qui enim Lorem qui cupidatat cillum sit."
        :rating="100"
        user-name="Joao Manoel"
        user-picture="https://avatars.githubusercontent.com/u/83477417?v=4"
      />
      <Card
        title="Violão avançado"
        card-picture="https://cdn.pixabay.com/photo/2015/05/07/11/02/guitar-756326_1280.jpg"
        level="advanced"
        description="Enim occaecat sit consequat excepteur eu consectetur qui enim Lorem qui cupidatat cillum sit."
        :rating="100"
        user-name="Joao Manoel"
        user-picture="https://avatars.githubusercontent.com/u/83477417?v=4"
      />
      <Card
        title="Violão Básico"
        card-picture="https://cdn.pixabay.com/photo/2016/01/14/06/09/woman-1139397_960_720.jpg"
        level="beginner"
        description="Enim occaecat sit consequat excepteur eu consectetur qui enim Lorem qui cupidatat cillum sit."
        :rating="100"
        user-name="Joao Manoel"
        user-picture="https://avatars.githubusercontent.com/u/83477417?v=4"
      />
      <Card
        title="Violão Básico"
        card-picture="https://cdn.pixabay.com/photo/2016/01/14/06/09/woman-1139397_960_720.jpg"
        level="beginner"
        description="Enim occaecat sit consequat excepteur eu consectetur qui enim Lorem qui cupidatat cillum sit."
        :rating="100"
        user-name="Joao Manoel"
        user-picture="https://avatars.githubusercontent.com/u/83477417?v=4"
      />
      <Card
        title="Violão Básico"
        card-picture="https://cdn.pixabay.com/photo/2016/01/14/06/09/woman-1139397_960_720.jpg"
        level="beginner"
        description="Enim occaecat sit consequat excepteur eu consectetur qui enim Lorem qui cupidatat cillum sit."
        :rating="100"
        user-name="Joao Manoel"
        user-picture="https://avatars.githubusercontent.com/u/83477417?v=4"
      />
    </UiList>
  </section>
</template>

<style scoped>

</style>