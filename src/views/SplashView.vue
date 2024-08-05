<script setup lang="ts">
import ModeSwitchBtn from '@/mini_components/ModeSwitchBtn.vue'
import Logo from '@/assets/logo.svg'
import { RouterLink } from 'vue-router'
</script>

<template>
  <section class="flex flex-col justify-between w-screen h-screen p-16 bg-background">
    <ModeSwitchBtn class="absolute text-primary self-end" />

    <div class="w-full">
      <img :src="Logo" class="h-[35vh] my-6" />
      <h1 class="ml-8 my-6 text-8xl text-primary">BlogStack</h1>
      <h2 class="ml-8 my-6 text-5xl text-secondary">
        Create your <snap class="text-primary">free blog</snap> and share it world wide now.
      </h2>
    </div>

    <div class="flex justify-between px-12">
      <div>
        <RouterLink to="/dashboard" class="text-5xl text-primary"> Explore </RouterLink>
        <div class="h-1 w-8 ml-2 mt-2 bg-primary"></div>
      </div>

      <div>
        <RouterLink to="/login" class="btn btn-ghost text-primary text-3xl mr-12">
          Login
        </RouterLink>
        <RouterLink
          to="/register"
          class="p-6 border-2 border-primary rounded-none text-primary text-3xl font-medium"
        >
          Register
        </RouterLink>
      </div>
    </div>
  </section>
</template>
