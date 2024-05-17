import { useAuthStore } from '@/stores/auth.store';
import { createRouter, createWebHistory } from 'vue-router';

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      component: () => import('@/layouts/Default.vue'),
      children: [
        {
          path: '/',
          component: () => import('@/pages/IndexView.vue'),
          name: 'index', 
        },
        {
          path: '/signin',
          component: () => import('@/pages/SigninView.vue'),
          name: 'login',
        },
        {
          path: '/signup',
          component: () => import('@/pages/SignupView.vue'),
          name: 'register',
        },
        {
          path: '/password-reset',
          component: () => import('@/pages/PasswordResetView.vue'), 
        },
      ],
    },
    {
      path: '/roadmap-creation',
      component: () => import('@/pages/roadmapCreation/RoadmapCreationView.vue'),
      meta: { auth: true }, 
      name: 'roadmapCreation',
    },
  ],
});

router.beforeEach((to) => {
  if (to.meta?.auth == true) {
    const auth = useAuthStore();
    if (!auth.isAuth && to.name !== 'login') {
      return { name: 'login' };
    }
  }
});

export default router;