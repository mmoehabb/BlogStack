<!-- eslint-disable vue/valid-v-for -->
<script setup lang="ts">
/* __placeholder__ */
import type { Post } from '@/lib/types'
import PostCard from '@/mini_components/PostCard.vue'

const props = defineProps<{
  posts: Array<Post>
  mine?: boolean
}>()
</script>

<template>
  <div class="flex flex-col items-center w-full h-auto p-12 overflow-y-auto">
    <PostCard class="mb-12" v-for="post in props.posts" :post="post" :mine="props.mine" />
  </div>
</template>
