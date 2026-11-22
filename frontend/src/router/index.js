import { useAuthStore } from '@/stores/auth'
import LoginView from '@/views/LoginView.vue'
import SignUpView from '@/views/SignUpView.vue'
import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {path: '/', name: 'login', component: LoginView, meta: { requiresAuth: false }},
    {path: '/sign-up', name: 'sign-up', component: SignUpView, meta: { requiresAuth: false }}
  ],
})

router.beforeEach(async (to) => {
  const auth = useAuthStore();
  await auth.initialized
  if (to.meta.requiresAuth && !auth.isAuthenticated) return {name: 'login'}
})

export default router
