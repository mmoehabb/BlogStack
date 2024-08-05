<script setup lang="ts">
import PostsWrapper from '@/components/PostsWrapper.vue'
import type { Post } from '@/lib/types'

import { useUserStore } from '@/stores/UserStore'
const { user } = useUserStore()

const posts: Array<Post> = [
  {
    id: 1,
    blogger_username: 'User1',
    title: 'My first post!',
    content: `Curiously, a closer study of the operating speed model is of a great interest. Furthermore, one should not forget that the development of the essence what can be classified as the systolic approach general tendency of The Knowledge of Authorized Impact
(Antwan Newberry in The Book of the System Concepts)`,
    date: 'June 04, 2010'
  }
]
</script>

<template>
  <PostsWrapper v-if="user.signedin" :posts="posts" />
  <div v-else class="flex w-full justify-center mt-16">
    <label class="text-xl text-red-400">You must login to enable this section.</label>
  </div>
</template>
