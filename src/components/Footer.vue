<script setup lang="ts">
import Logo from '@/assets/logo-secondary.svg'
import FacebookLogo from '@/assets/facebook.png'
import TwitterLogo from '@/assets/twitter.png'
import DiscordLogo from '@/assets/discord.png'
</script>

<template>
  <div
    class="flex justify-between items-center w-screen px-2 md:px-32 py-8 bg-primary text-secondary"
  >
    <div class="flex flex-col items-start">
      <img :src="Logo" class="h-20 md:h-32" />
      <h1 class="ml-4 text-2xl md:text-4xl font-semibold">BlogStack</h1>
      <p class="ml-4 text-lg md:text-xl font-semibold">Free online blogs website</p>
    </div>

    <div class="lg:mr-32">
      <h1 class="ml-2 text-2xl md:text-3xl font-semibold">SOCIAL</h1>
      <div class="flex my-4">
        <a href="#"><img :src="FacebookLogo" class="h-8 md:h-12 mx-2" /></a>
        <a href="#"><img :src="TwitterLogo" class="h-8 md:h-12 mx-2" /></a>
        <a href="#"><img :src="DiscordLogo" class="h-8 md:h-12 mx-2" /></a>
      </div>
    </div>
  </div>
</template>
