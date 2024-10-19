<script setup lang="ts">
import { useRoute } from 'vue-router'
import { usePostStore } from '@/stores/PostStore'

const route = useRoute()
const { getPost } = usePostStore()
const { id } = route.params

const post = getPost(parseInt(String(id)))
document.scrollingElement?.scroll(0, 0)
</script>

<template>
  <div class="w-full min-h-screen px-2 md:px-12">
    <h1 class="text-pretty text-4xl md:text-5xl text-primary">{{ post?.title }}</h1>
    <label class="p-2 text-lg text-secondary">By {{ post?.blogger_username }}</label
    ><br />
    <label class="p-2 text-md text-secondary">{{ post?.date }}</label>
    <p class="text-lg md:text-xl text-base-100 p-4 text-justify">{{ post?.content }}</p>
  </div>
</template>
