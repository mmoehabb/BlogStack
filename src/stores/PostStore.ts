import { reactive } from 'vue'
import { defineStore } from 'pinia'
import type { Post } from '@/lib/types'

export const usePostStore = defineStore('post', () => {
  const posts = reactive({
    list: [] as Array<Post>
  })

  const addPost = (post: Post) => {
    posts.list.push(post)
  }

  return { addPost }
})
