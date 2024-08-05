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
  <Header />
  <section class="flex w-screen h-screen p-12">
    <Dashboard class="self-start" />
    <component :is="fragment"></component>
  </section>
  <Footer />
</template>
