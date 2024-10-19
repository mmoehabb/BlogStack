<script setup lang="ts">
import Logo from '@/assets/logo.svg'
import ModeSwitchBtn from '@/mini_components/ModeSwitchBtn.vue'
import RegisterForm from '@/components/RegisterForm.vue'
</script>

<template>
  <section
    class="flex flex-col items-center justify-around lg:justify-center w-screen h-screen p-2 md:p-16 bg-background"
  >
    <ModeSwitchBtn class="absolute text-primary self-end top-6 right-6" />

    <div class="flex-1 lg:flex-[0] flex flex-col items-center justify-center">
      <img :src="Logo" class="h-[50vw] max-h-56" />
      <h1 class="text-5xl md:text-6xl text-primary">BlogStack</h1>
    </div>

    <RegisterForm class="flex-1 lg:flex-[0] md:my-12" />
  </section>
</template>
