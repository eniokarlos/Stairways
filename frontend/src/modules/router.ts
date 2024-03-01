import DefaultVue from "@/layouts/Default.vue";
import IndexVue from "@/pages/Index.vue";
import SigninVue from "@/pages/Signin.vue";
import SignupVue from "@/pages/Signup.vue";
import PasswordResetVue from "@/pages/PasswordReset.vue";
import { createRouter, createWebHistory } from "vue-router"

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/', component: DefaultVue, children:[
        {path: '/', component: IndexVue},
        {path: '/signin', component: SigninVue},
        {path: '/signup', component: SignupVue},
        {path: '/password_reset', component: PasswordResetVue}
      ],
    },
  ]
})