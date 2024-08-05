<script setup lang="ts">
import { RouterView } from 'vue-router'

import { onMounted } from 'vue'
import { useBookmarkStore } from './stores/BookmarkStore'
import { usePostStore } from './stores/PostStore'
import { getBookmarks, getPosts } from './lib/actions'

const { addPost } = usePostStore()
const { addBookmark } = useBookmarkStore()

onMounted(async () => {
  // initialize the stores
  const posts = await getPosts()
  const bookmarks = await getBookmarks()
  for (let post of posts) {
    addPost(post)
  }
  for (let bookmark of bookmarks) {
    addBookmark(bookmark)
  }
})
</script>

<template>
  <main class="overflow-x-hidden">
    <RouterView />
  </main>
</template>
