<script setup lang="ts">
import ModeSwitchBtn from '@/mini_components/ModeSwitchBtn.vue'
import Logo from '@/assets/logo.svg'
import { RouterLink } from 'vue-router'
</script>

<template>
  <section class="flex flex-col justify-between w-screen h-screen p-2 md:p-16 bg-background">
    <ModeSwitchBtn class="absolute text-primary self-end" />

    <div class="w-full">
      <img :src="Logo" class="h-[25vh] md:h-[35vh] mt-16 md:my-6" />
      <h1 class="ml-4 mr-2 md:ml-8 md:my-6 text-5xl md:text-8xl text-primary">BlogStack</h1>
      <h2 class="ml-4 mr-2 md:ml-8 my-6 text-3xl md:text-5xl text-secondary">
        Create your <span class="text-primary">free blog</span> and share it world wide now.
      </h2>
    </div>

    <div
      class="flex-1 flex flex-col md:flex-row items-center justify-end md:justify-between px-2 md:px-12 mb-12 md:mb-0"
    >
      <div class="w-full md:w-auto my-8 md:my-0">
        <RouterLink to="/dashboard" class="w-full text-3xl md:text-5xl text-primary">
          Explore
        </RouterLink>
        <div class="h-1 w-8 ml-2 mt-2 bg-primary animate-bounce"></div>
      </div>

      <div class="flex flex-col md:items-center md:flex-row w-full md:w-auto">
        <RouterLink
          to="/login"
          class="btn btn-ghost mb-2 md:mb-0 md:mr-12 border-2 md:border-0 border-primary text-xl md:text-3xl text-primary"
        >
          Login
        </RouterLink>
        <RouterLink
          to="/register"
          :class="`p-2 md:p-6 md:border-2 md:border-primary rounded md:rounded-none bg-primary md:bg-base-content 
          text-base-content md:text-primary text-center text-xl md:text-3xl font-medium`"
        >
          Register
        </RouterLink>
      </div>
    </div>
  </section>
</template>
