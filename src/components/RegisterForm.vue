<script setup lang="ts">
import { RouterLink } from 'vue-router'
import TextInput from '@/mini_components/TextInput.vue'
import { reactive } from 'vue'
import { register } from '@/lib/actions'
import { useToast } from 'vue-toast-notification'

const formData = reactive({
  nickname: '',
  username: '',
  password: '',
  email: ''
})

const $toast = useToast()

const registerHandler = async () => {
  const res = register(formData)
  if (await res) {
    $toast.success('Your account has been registered. Try login.')
  } else {
    $toast.error('Something went wrong!')
  }
}
</script>

<template>
  <form class="flex flex-col justify-center items-center w-full lg:w-1/2 p-6 lg:p-0">
    <div class="flex flex-col lg:flex-row lg:flex-wrap justify-center w-full lg:w-auto">
      <TextInput
        :onChange="(val: any) => (formData.nickname = val)"
        class="mt-4 lg:w-1/3 lg:m-3"
        label="Nickname"
        placeholder="Enter your nickname"
        type="text"
      />
      <TextInput
        :onChange="(val: any) => (formData.username = val)"
        class="mt-4 lg:w-1/3 lg:m-3"
        label="Username"
        placeholder="Enter unique username"
        type="text"
      />
      <TextInput
        :onChange="(val: any) => (formData.password = val)"
        class="mt-4 lg:w-1/3 lg:m-3"
        label="Password"
        placeholder="Enter password"
        type="password"
        :feedback="true"
      />
      <TextInput
        :onChange="(val: any) => (formData.email = val)"
        class="mt-4 lg:w-1/3 lg:m-3"
        label="Email"
        placeholder="Enter your email"
        type="email"
      />
    </div>

    <div class="flex flex-col items-center my-12 w-full md:w-2/3">
      <button @click.prevent="registerHandler" class="text-3xl py-6 text-white bg-primary w-full">
        Register
      </button>
      <RouterLink
        to="/login"
        class="text-center text-3xl mt-4 px-12 py-6 text-primary bg-background border-4 border-primary w-full"
        >Login</RouterLink
      >
    </div>
  </form>
</template>
