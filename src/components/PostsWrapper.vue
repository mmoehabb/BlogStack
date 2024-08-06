<!-- eslint-disable vue/valid-v-for -->
<script setup lang="ts">
/* __placeholder__ */
import type { Post } from '@/lib/types'
import PostCard from '@/mini_components/PostCard.vue'
import { computed, ref, onBeforeUpdate } from 'vue'

const props = defineProps<{
  posts: Array<Post>
  limit: number
  mine?: boolean
  loadMore?: () => Promise<Array<Post>>
}>()

const index = ref(1)
const loadedPosts = ref([] as Array<Post>)
const slicedPosts = computed(() => loadedPosts.value.slice(0, index.value * props.limit))

onBeforeUpdate(async () => {
  loadedPosts.value = [...props.posts]
})

async function showMoreHandler() {
  if (props.loadMore) {
    const loaded = await props.loadMore()
    loadedPosts.value.push(...loaded)
  }
  index.value += 1
}
</script>

<template>
  <div class="h-auto p-12 overflow-y-auto">
    <PostCard class="mb-12" v-for="post in slicedPosts" :post="post" :mine="props.mine" />
    <button
      @click="showMoreHandler"
      v-if="slicedPosts.length < loadedPosts.length"
      class="btn btn-ghost btn-primary text-accent"
    >
      Show More...
    </button>
  </div>
</template>
