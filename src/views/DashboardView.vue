<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router'

import Header from '@/components/Header.vue'
import Footer from '@/components/Footer.vue'
import Dashboard from '@/components/Dashboard.vue'

import Explore from '@/fragments/Explore.vue'
import MyBlog from '@/fragments/MyBlog.vue'
import AddPost from '@/fragments/AddPost.vue'
import EditPost from '@/fragments/EditPost.vue'
import Bookmarks from '@/fragments/Bookmarks.vue'

const router = useRoute()

const fragment = computed(() => {
  switch (router.params.fragment) {
    case 'explore':
      return Explore
    case 'myblog':
      return MyBlog
    case 'addpost':
      return AddPost
    case 'editpost':
      return EditPost
    case 'bookmarks':
      return Bookmarks
  }
  return Explore
})
</script>

<template>
  <Header class="fixed bg-base-content opacity-1 z-[2] h-32" />
  <section class="flex w-screen p-12 mt-32">
    <component :is="Dashboard" class="fixed self-start z-[1]"></component>
    <component :is="fragment" class="ml-52"></component>
  </section>
  <Footer />
</template>
