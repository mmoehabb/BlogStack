<script setup lang="ts">
import Logo from '@/assets/logo.svg'
import ModeSwitchBtn from '@/mini_components/ModeSwitchBtn.vue'
import RegisterForm from '@/components/RegisterForm.vue'
</script>

<template>
  <section class="flex flex-col items-center w-screen h-screen p-16 bg-background">
    <ModeSwitchBtn class="absolute text-primary self-end" />

    <div class="flex flex-col items-center">
      <img :src="Logo" class="h-52" />
      <h1 class="text-6xl text-primary">BlogStack</h1>
    </div>

    <RegisterForm class="my-12" />
  </section>
</template>
