<script setup lang="ts">
import { RouterLink } from 'vue-router'
import TextInput from '@/mini_components/TextInput.vue'
import { useRouter } from 'vue-router'
import { useToast } from 'vue-toast-notification'
import { useUserStore } from '@/stores/UserStore'
import { signIn } from '@/lib/actions'
import { ref } from 'vue'

const $toast = useToast()
const { user, setUser } = useUserStore()

const router = useRouter()

if (user?.signedin) {
  router.push({ path: 'dashboard' })
}

const username = ref('')
const password = ref('')

const loginHandler = async () => {
  const res = await signIn(username.value, password.value)
  if (res) {
    setUser(username.value, password.value, true)
    router.push({ path: 'dashboard' })
  } else {
    $toast.error('Invalid credentials! Check your username and password.')
  }
}
</script>

<template>
  <form class="flex flex-col justify-between items-center w-full md:w-1/2 px-6 md:px-0">
    <div class="flex flex-wrap justify-center">
      <TextInput
        :onChange="(value: any) => (username = value)"
        class="w-full m-3"
        label="Username"
        placeholder="Enter your username"
        type="text"
      />
      <TextInput
        :onChange="(value: any) => (password = value)"
        class="w-full m-3"
        label="Password"
        placeholder="Enter password"
        type="password"
      />
    </div>

    <div class="flex flex-col items-center my-12 w-full md:w-2/3">
      <button
        @click.prevent="loginHandler"
        class="text-2xl md:text-3xl py-2 md:py-6 text-white bg-primary w-full"
      >
        Login
      </button>
      <RouterLink
        to="/register"
        class="text-center text-2xl md:text-3xl mt-4 px-12 py-2 md:py-6 text-primary bg-background border-4 border-primary w-full"
        >Register</RouterLink
      >
    </div>
  </form>
</template>
