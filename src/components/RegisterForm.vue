<script setup lang="ts">
import { RouterLink } from 'vue-router'
import TextInput from '@/mini_components/TextInput.vue'
</script>

<template>
  <form class="flex flex-col justify-center items-center w-full md:w-1/2">
    <div class="flex flex-wrap justify-center">
      <TextInput class="w-1/3 m-3" label="Nickname" placeholder="Enter your nickname" type="text" />
      <TextInput
        class="w-1/3 m-3"
        label="Username"
        placeholder="Enter unique username"
        type="text"
      />
      <TextInput
        class="w-1/3 m-3"
        label="Password"
        placeholder="Enter password"
        type="password"
        :feedback="true"
      />
      <TextInput class="w-1/3 m-3" label="Email" placeholder="Enter your email" type="email" />
    </div>

    <div class="flex flex-col items-center my-12 w-full md:w-2/3">
      <button class="text-3xl py-6 text-white bg-primary w-full">Register</button>
      <RouterLink
        to="/login"
        class="text-center text-3xl mt-4 px-12 py-6 text-primary bg-background border-4 border-primary w-full"
        >Login</RouterLink
      >
    </div>
  </form>
</template>
