import { reactive } from 'vue'
import { defineStore } from 'pinia'

export const useUserStore = defineStore('user', () => {
  const user = reactive({
    username: '',
    password: '',
    signedin: false
  })

  const setUser = (username: string, password: string, signedin: boolean) => {
    user.username = username
    user.password = password
    user.signedin = signedin
  }

  return { user, setUser }
})
