<script setup lang="ts">
  import Navbar from '@/components/nav-bar/NavBar.vue';
  import Footer from '@/components/footer/Footer.vue';
  import {RouterView} from 'vue-router'
</script>
  
<template>
  <Navbar></Navbar>
  <RouterView></RouterView>
  <Footer></Footer>
</template>


<style scoped>

</style>