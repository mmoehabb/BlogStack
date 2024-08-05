<script setup lang="ts">
import { onMounted } from 'vue'
import { RouterView } from 'vue-router'

onMounted(() => {
  // initialize the store
})
</script>

<template>
  <main class="overflow-x-hidden">
    <RouterView />
  </main>
</template>
