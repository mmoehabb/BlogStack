import type { Bookmark } from '@/lib/types'
import { reactive } from 'vue'
import { defineStore } from 'pinia'

export const useBookmarkStore = defineStore('bookmark', () => {
  const bookmarks = reactive({
    list: [] as Array<Bookmark>
  })

  const bookmarkExists = (bookmark: Bookmark) => {
    const filtered = bookmarks.list.filter((elem) => {
      for (const key in elem) {
        if ((elem as unknown as any)[key] !== (bookmark as unknown as any)[key]) return false
      }
      return true
    })
    return filtered.length > 0
  }

  const addBookmark = (bookmark: Bookmark) => {
    bookmarks.list.push(bookmark)
  }

  const rmvBookmark = (bookmark: Bookmark) => {
    bookmarks.list = bookmarks.list.filter((elem) => {
      for (const key in elem) {
        if ((elem as unknown as any)[key] !== (bookmark as unknown as any)[key]) return false
      }
      return true
    })
  }

  return { bookmarkExists, addBookmark, rmvBookmark }
})
