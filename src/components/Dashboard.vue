<script setup lang="ts">
import DashboardBtn from '@/mini_components/DashboardBtn.vue'
import { RouterLink } from 'vue-router'
import { useUserStore } from '@/stores/stores'
const { user, setUser } = useUserStore()

const logoutHanlder = () => {
  setUser('', '', false)
}
</script>

<template>
  <div class="flex flex-col w-52 h-auto">
    <div class="bg-background shadow-lg rounded-lg overflow-hidden">
      <DashboardBtn primeicon="pi pi-search" to="/dashboard/explore" label="Explore" default />
      <DashboardBtn primeicon="pi pi-user" to="/dashboard/myblog" label="My Blog" />
      <DashboardBtn primeicon="pi pi-file-plus" to="/dashboard/addpost" label="Add Post" />
      <DashboardBtn primeicon="pi pi-file-edit" to="/dashboard/editpost" label="Edit Post" />
      <DashboardBtn primeicon="pi pi-bookmark" to="/dashboard/bookmarks" label="Bookmarks" />
    </div>
    <button
      v-if="user.signedin"
      @click="logoutHanlder"
      to="/logout"
      class="w-full text-center bg-red-400 text-white text-xl my-12 py-2 rounded-lg shadow"
    >
      Logout
    </button>
    <RouterLink
      v-else
      to="/login"
      class="w-full text-center bg-green-400 text-white text-xl my-12 py-2 rounded-lg shadow"
      >Login</RouterLink
    >
  </div>
</template>
