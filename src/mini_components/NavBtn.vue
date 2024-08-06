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
    class="flex justify-center items-center border-0 w-full py-2 md:py-4 px-4 md:px-8 text-md md:text-xl no-animation shadow-none"
    :class="{
      'text-white bg-accent': isSelected,
      'text-accent bg-background': !isSelected
    }"
  >
    <span class="mr-2 md:mx-4" :class="props.primeicon"></span>
    <label class="text-left w-full cursor-pointer">{{ props.label }}</label>
  </RouterLink>
</template>
