<script setup lang="ts">
import PostsWrapper from '@/components/PostsWrapper.vue'
import { getPosts } from '@/lib/actions'
import type { Post } from '@/lib/types'
import { onMounted, ref } from 'vue'
import { RouterLink } from 'vue-router'

const posts = ref([] as Array<Post>)

onMounted(async () => {
  try {
    const res = await getPosts()
    posts.value = res
  } catch (err: any) {
    console.error(err)
  }
})
</script>

<template>
  <PostsWrapper :posts="posts" />

  <div class="self-start text-center w-1/3 bg-accent text-white rounded">
    <h1 class="text-2xl py-4">Most Popular</h1>
    <div class="pb-6 px-6 text-left text-lg">
      <ol>
        <li v-for="({ title, id }, i) in posts" class="truncate hover:underline">
          <RouterLink :to="`/post/${id}`">{{ i + 1 }}. {{ title }}</RouterLink>
        </li>
      </ol>
    </div>
  </div>
</template>
