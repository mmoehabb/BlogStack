import { reactive, computed } from 'vue'
import { defineStore } from 'pinia'

export const usePostStore = defineStore('user', () => {
  const user = reactive({
    username: '',
    signedin: false
  })

  const signIn = computed(() => (user.signedin = true))
  const signOut = computed(() => (user.signedin = false))

  return { user, signIn, signOut }
})
