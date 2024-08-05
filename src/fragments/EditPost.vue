<script setup lang="ts">
import { onBeforeMount, onBeforeUnmount, ref } from 'vue'
import Editor from 'primevue/editor'
import { usePreset } from '@primevue/themes'
import nora from '@primevue/themes/nora'

import { useUserStore } from '@/stores/UserStore'
const { user } = useUserStore()

const editor_value = ref('')
onBeforeMount(() => usePreset(nora))
onBeforeUnmount(() => usePreset({}))

const myposts = [
  {
    title: 'My first post',
    content: 'sadas'
  },
  {
    title: 'My seconds post',
    content: 'dsasdas'
  }
]
</script>

<template>
  <form v-if="user.signedin" class="w-full md:w-2/3 py-8 px-12 md:px-32">
    <label class="form-control w-full max-w-xs mb-4">
      <div class="label">
        <span class="label-text text-lg text-base-100">Select Post</span>
      </div>
      <select class="select select-bordered bg-white text-base-100">
        <option v-for="post in myposts">{{ post.title }}</option>
      </select>
    </label>

    <label class="text-lg text-base-100">Write your post:</label>
    <Editor
      class="mt-2 rounded overflow-hidden shadow-lg bg-secondary"
      v-model="editor_value"
      editorStyle="height: 320px; background-color: #FFF; color: #000;"
    />
  </form>
  <div v-else class="flex w-full justify-center mt-16">
    <label class="text-xl text-red-400">You must login to enable this section.</label>
  </div>
</template>
