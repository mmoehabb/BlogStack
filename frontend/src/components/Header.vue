<script setup lang="ts">
import Logo from '@/assets/logo.svg'
import ModeSwitchBtn from '@/mini_components/ModeSwitchBtn.vue'
import Dashboard from './Navigation.vue'
const screenWidth = document.documentElement.clientWidth
</script>

<template>
  <div v-if="screenWidth > 1279" class="flex items-center w-screen px-2 md:px-8 py-6 bg-background">
    <img :src="Logo" class="h-16 md:h-20" />
    <h1 class="ml-4 text-4xl md:text-5xl font-semibold text-primary">BlogStack</h1>
    <ModeSwitchBtn class="absolute text-primary right-4 md:right-16" />
  </div>

  <div v-else class="navbar bg-background text-primary">
    <div class="navbar-start">
      <div class="dropdown">
        <div tabindex="0" role="button" class="btn btn-ghost btn-circle">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="h-6 w-6"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M4 6h16M4 12h16M4 18h7"
            />
          </svg>
        </div>
        <ul tabindex="0" class="menu menu-sm dropdown-content">
          <Dashboard />
        </ul>
      </div>
    </div>
    <div class="navbar-center">
      <img :src="Logo" class="h-8 md:h-20" />
      <h1 class="ml-4 text-xl md:text-5xl font-semibold text-primary">BlogStack</h1>
    </div>
    <div class="navbar-end">
      <ModeSwitchBtn class="absolute text-primary right-4 md:right-16 scale-75" />
    </div>
  </div>
</template>
