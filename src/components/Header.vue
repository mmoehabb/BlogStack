<script setup lang="ts">
import Logo from '@/assets/logo.svg'
import ModeSwitchBtn from '@/mini_components/ModeSwitchBtn.vue'
</script>

<template>
  <div class="flex items-center w-screen px-8 py-6 bg-background">
    <img :src="Logo" class="h-20" />
    <h1 class="ml-4 text-5xl font-semibold text-primary">BlogStack</h1>
    <ModeSwitchBtn class="absolute text-primary right-16" />
  </div>
</template>
