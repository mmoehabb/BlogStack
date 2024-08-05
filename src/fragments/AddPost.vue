<script setup lang="ts">
import { onBeforeMount, onBeforeUnmount, ref } from 'vue'
import Editor from 'primevue/editor'
import { usePreset } from '@primevue/themes'
import nora from '@primevue/themes/nora'
import TextInput from '@/mini_components/TextInput.vue'

const editor_value = ref('')
onBeforeMount(() => usePreset(nora))

onBeforeUnmount(() => usePreset({}))
</script>

<template>
  <form class="w-full md:w-2/3 py-8 px-12 md:px-32">
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
  </form>
</template>
