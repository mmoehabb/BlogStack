<script setup lang="ts">
import PostsWrapper from '@/components/PostsWrapper.vue'
import { getBookmarkedPostsOf } from '@/lib/actions'
import type { Post } from '@/lib/types'

import { useUserStore } from '@/stores/UserStore'
import { onMounted, ref } from 'vue'
const { user } = useUserStore()

const posts = ref([] as Array<Post>)

onMounted(async () => {
  try {
    const res = await getBookmarkedPostsOf(user?.username)
    posts.value = res
  } catch (err: any) {
    console.error(err)
  }
})
</script>

<template>
  <PostsWrapper
    v-if="user?.signedin"
    class="flex flex-col lg:grid grid-cols-2 gap-8"
    :posts="posts"
    :limit="5"
  />
  <div v-else class="flex w-full h-screen justify-center mt-52">
    <label class="text-xl text-red-400">You must login to enable this section.</label>
  </div>
</template>
