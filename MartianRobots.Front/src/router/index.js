import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/Layout.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Layout',
    component: Home
  }
]

const router = new VueRouter({
  mode: 'history',
  routes
})

export default router
