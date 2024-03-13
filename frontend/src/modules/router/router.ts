import { createRouter, createWebHistory } from 'vue-router';

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      component: () => import('@/layouts/Default.vue'),
      children: [
        {
          path: '/',
          component: () => import('@/pages/Index.vue'), 
        },
        {
          path: '/signin',
          component: () => import('@/pages/Signin.vue'), 
        },
        {
          path: '/signup',
          component: () => import('@/pages/Signup.vue'), 
        },
        {
          path: '/password_reset',
          component: () => import('@/pages/PasswordReset.vue'), 
        },
      ],
    },
    {
      path: '/roadmap_creation',
      component: () => import('@/pages/RoadmapCreation.vue'), 
    },
  ],
});