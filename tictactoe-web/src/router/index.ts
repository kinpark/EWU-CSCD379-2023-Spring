import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import TikTacToe from '../views/TikTacToe.vue'
import LeaderboardView from '../views/LeaderboardView.vue'
import { Services } from '@/scripts/services'
import { inject } from 'vue'
import { SignInService } from '@/scripts/signInService'
import AboutView from '@/views/AboutView.vue'
import EasyBot from '@/views/EasyBot.vue'
import HardBot from '@/views/HardBot.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/TikTacToe',
      name: 'TikTacToe',
      component: TikTacToe
    },
    {
      path: '/Hardbot',
      name: 'Hardbot',
      component: HardBot
    },
    {
      path: '/Easybot',
      name: 'Easybot',
      component: EasyBot
    },
    {
      path: '/leaderboard',
      name: 'leaderboard',
      component: LeaderboardView
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView
    }
  ]
})

export default router
