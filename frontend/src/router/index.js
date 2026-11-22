import LoginView from '@/views/LoginView.vue'
import SignUpView from '@/views/SignUpView.vue'
import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {path: '/', name: 'login', component: LoginView},
    {path: '/sign-up', name: 'sign-up', component: SignUpView}
  ],
})

export default router
