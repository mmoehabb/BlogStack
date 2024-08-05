<script setup lang="ts">
import { RouterLink } from 'vue-router'
import TextInput from '@/mini_components/TextInput.vue'
</script>

<template>
  <form class="flex flex-col justify-center items-center w-full md:w-1/2">
    <div class="flex flex-wrap justify-center">
      <TextInput
        class="w-full m-3"
        label="Username"
        placeholder="Enter your username"
        type="text"
      />
      <TextInput class="w-full m-3" label="Password" placeholder="Enter password" type="password" />
    </div>

    <div class="flex flex-col items-center my-12 w-full md:w-2/3">
      <button class="text-3xl py-6 text-white bg-primary w-full">Login</button>
      <RouterLink
        to="/register"
        class="text-center text-3xl mt-4 px-12 py-6 text-primary bg-background border-4 border-primary w-full"
        >Register</RouterLink
      >
    </div>
  </form>
</template>
