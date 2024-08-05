<!-- eslint-disable vue/valid-v-for -->
<script setup lang="ts">
/* __placeholder__ */
import type { Post } from '@/lib/types'
import PostCard from '@/mini_components/PostCard.vue'

const props = defineProps<{
  posts: Array<Post>
  mine?: boolean
}>()

console.log(props.mine)
</script>

<template>
  <div class="flex flex-col items-center w-full p-12">
    <PostCard v-for="post in props.posts" :post="post" :mine="props.mine" />
  </div>
</template>
