<script setup lang="ts">
import { onBeforeMount, onBeforeUnmount, ref } from 'vue'
import Editor from 'primevue/editor'
import { usePreset } from '@primevue/themes'
import nora from '@primevue/themes/nora'
import TextInput from '@/mini_components/TextInput.vue'

import { useUserStore } from '@/stores/UserStore'
const { user } = useUserStore()

const editor_value = ref('')
onBeforeMount(() => usePreset(nora))
onBeforeUnmount(() => usePreset({}))

import { useToast } from 'vue-toast-notification'
const $toast = useToast()
function addHandler() {
  $toast.error('Something went wrong!')
}
</script>

<template>
  <form v-if="user.signedin" class="w-full md:w-2/3 py-8 px-12 md:px-32">
    <TextInput
      class="md:w-2/3 mb-4"
      label="Post Title"
      labelClass="text-base-100"
      placeholder="Enter a Title"
      type="text"
    />
    <label class="text-lg text-base-100">Write your post:</label>
    <Editor
      class="mt-2 rounded overflow-hidden shadow-lg bg-secondary"
      v-model="editor_value"
      editorStyle="height: 320px; background-color: #FFF; color: #000;"
    />
    <button
      @click.prevent="addHandler"
      class="px-12 py-6 my-12 bg-accent text-white text-xl rounded-xl"
    >
      Add Post
    </button>
  </form>
  <div v-else class="flex w-full h-screen justify-center mt-52">
    <label class="text-xl text-red-400">You must login to enable this section.</label>
  </div>
</template>
