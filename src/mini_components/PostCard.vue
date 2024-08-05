<script setup lang="ts">
import { computed } from 'vue'
import { RouterLink } from 'vue-router'
import type { Post } from '@/lib/types'
const props = defineProps<{
  post: Post
  mine?: boolean
}>()

import { useUserStore, useBookmarkStore } from '@/stores/stores'
const { user } = useUserStore()
const { bookmarkExists } = useBookmarkStore()
const bookmared = computed(() =>
  bookmarkExists({
    blogger_username: user.username,
    post_id: props.post.id
  })
)
</script>

<template>
  <div
    class="max-w-3xl p-12 bg-white rounded-lg shadow-lg select-none hover:scale-[105%] transition ease-in"
  >
    <div>
      <RouterLink
        :to="`/dashboard/post/${post.id}`"
        class="text-3xl text-primary cursor-pointer hover:underline underline-offset-8"
        >{{ post.title }}</RouterLink
      >
      <h2 class="mt-2 text-lg text-secondary">by {{ post.blogger_username }}</h2>
    </div>
    <p class="max-h-52 text-base-100 text-pretty my-6 truncate">{{ post.content }}</p>
    <div class="flex w-full justify-between">
      <label>{{ post.date }}</label>
      <span
        v-if="!props.mine"
        :class="{ 'pi pi-bookmark-fill': bookmared, 'pi pi-bookmark': !bookmared }"
        class="cursor-pointer hover:translate-y-1 transition"
      ></span>
      <span v-else class="cursor-pointer pi pi-trash hover:translate-y-1 transition"></span>
    </div>
  </div>
</template>
