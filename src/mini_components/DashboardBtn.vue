<script setup lang="ts">
import { ref, computed } from 'vue'
import { useRoute } from 'vue-router'

const props = defineProps<{
  label: String
  to: String
  primeicon: String
  default?: boolean
}>()

const route = useRoute()
const isSelected = computed(() => {
  return (
    route.params.fragment === props.label.toLocaleLowerCase().replace(/\s/g, '') ||
    (props.default && route.params.fragment === '')
  )
})
</script>

<template>
  <RouterLink
    :to="props.to"
    class="flex justify-between items-center border-0 w-full py-4 px-8 text-xl no-animation shadow-none"
    :class="{
      'text-white bg-accent': isSelected,
      'text-accent bg-background': !isSelected
    }"
  >
    <span class="mx-4" :class="props.primeicon"></span>
    <label class="text-left w-full cursor-pointer">{{ props.label }}</label>
  </RouterLink>
</template>
