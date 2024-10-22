<script setup lang="ts">
import { computed, onBeforeMount, onBeforeUnmount, onMounted, ref } from 'vue'
import Editor from 'primevue/editor'
import { usePreset } from '@primevue/themes'
import nora from '@primevue/themes/nora'

import { useUserStore } from '@/stores/UserStore'
import type { Post } from '@/lib/types'
import { getPostsOf } from '@/lib/actions'
const { user } = useUserStore()

onBeforeMount(() => usePreset(nora))
onBeforeUnmount(() => usePreset({}))

const posts = ref([] as Array<Post>)

const editor_value = ref('')
const editorSetter = ref((val: string) => {})

// eslint-disable-next-line vue/no-side-effects-in-computed-properties
const selected = ref({})
const selectHandler = (e: { target: { selectedIndex: any } }) => {
  editorSetter.value(posts.value[e.target.selectedIndex].content)
}

onMounted(async () => {
  try {
    const res = await getPostsOf(user?.username)
    posts.value = res
  } catch (err: any) {
    console.error(err)
  }
})

function initEditorValue({ instance }: any) {
  editorSetter.value = (val) =>
    instance.setContents(
      instance.clipboard.convert({
        html: val
      })
    )
}

import { useToast } from 'vue-toast-notification'
const $toast = useToast()
function saveHandler() {
  $toast.error('Something went wrong!')
}
</script>

<template>
  <form v-if="user?.signedin" class="w-full md:w-2/3 py-8 px-12 md:px-32">
    <label class="form-control w-full max-w-xs mb-4">
      <div class="label">
        <span class="label-text text-lg text-base-100">Select Post</span>
      </div>
      <select
        @change="selectHandler"
        v-model="selected"
        class="select select-bordered bg-neutral text-base-100"
      >
        <option v-for="post in posts" :value="post">{{ post.title }}</option>
      </select>
    </label>

    <label class="text-lg text-base-100">Write your post:</label>
    <Editor
      class="mt-2 rounded overflow-hidden shadow-lg bg-secondary"
      v-model="editor_value"
      @load="initEditorValue"
      editorStyle="height: 320px; background-color: #FFF; color: #000;"
    />
    <button
      @click.prevent="saveHandler"
      class="px-12 py-6 my-12 bg-accent text-white text-xl rounded-xl"
    >
      Save Post
    </button>
  </form>
  <div v-else class="flex w-full h-screen justify-center mt-52">
    <label class="text-xl text-red-400">You must login to enable this section.</label>
  </div>
</template>
