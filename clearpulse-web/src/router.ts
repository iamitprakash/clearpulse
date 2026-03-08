import { createRouter, createWebHistory } from 'vue-router'
import Home from './views/Home.vue'
import PulseManage from './views/PulseManage.vue'
import PulsePublic from './views/PulsePublic.vue'
import Features from './views/Features.vue'
import Privacy from './views/Privacy.vue'

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', component: Home },
    { path: '/manage/:token', component: PulseManage },
    { path: '/p/:id', component: PulsePublic },
    { path: '/features', component: Features },
    { path: '/privacy', component: Privacy },
  ]
})

export default router
