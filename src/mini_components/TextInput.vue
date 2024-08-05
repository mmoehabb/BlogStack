<script setup lang="ts">
import Password from 'primevue/password'

const props = defineProps<{
  label: String
  labelClass?: String
  placeholder: String
  type: 'password' | 'text' | 'email'
  feedback?: boolean
}>()

import { ref } from 'vue'
const value = ref(null)
</script>

<template>
  <div class="form-control">
    <div class="label">
      <span class="label-text text-lg" :class="labelClass">{{ props.label }}</span>
    </div>
    <input
      v-if="props.type !== 'password'"
      :type="props.type"
      :placeholder="props.placeholder"
      class="input input-bordered w-full bg-white text-primary border-secondary"
    />
    <Password
      v-else
      v-model="value"
      placeholder="Enter a passowrd"
      class="input input-bordered w-full bg-white text-primary border-secondary"
      :feedback="feedback || false"
    >
      <template #header>
        <div class="mt-4"></div>
      </template>
    </Password>
  </div>
</template>
