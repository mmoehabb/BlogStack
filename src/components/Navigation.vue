<script setup lang="ts">
import NavBtn from '@/mini_components/NavBtn.vue'
import { RouterLink } from 'vue-router'
import { useUserStore } from '@/stores/stores'
const { user, setUser } = useUserStore()

const logoutHanlder = () => {
  setUser('', '', false)
}
</script>

<template>
  <div class="flex flex-col w-auto xl:w-52 h-auto">
    <div class="bg-neutral shadow-lg rounded-lg overflow-hidden">
      <NavBtn primeicon="pi pi-search" to="/dashboard/explore" label="Explore" default />
      <NavBtn primeicon="pi pi-user" to="/dashboard/myblog" label="My Blog" />
      <NavBtn primeicon="pi pi-file-plus" to="/dashboard/addpost" label="Add Post" />
      <NavBtn primeicon="pi pi-file-edit" to="/dashboard/editpost" label="Edit Post" />
      <NavBtn primeicon="pi pi-bookmark" to="/dashboard/bookmarks" label="Bookmarks" />
    </div>
    <button
      v-if="user?.signedin"
      @click="logoutHanlder"
      to="/logout"
      class="w-full text-center bg-error text-white xl:text-xl xl:my-12 py-2 rounded-lg shadow"
    >
      Logout
    </button>
    <RouterLink
      v-else
      to="/login"
      class="w-full text-center bg-success text-white xl:text-xl xl:my-12 py-2 rounded-lg shadow"
      >Login</RouterLink
    >
  </div>
</template>
