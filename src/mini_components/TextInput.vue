<script setup lang="ts">
import Password from 'primevue/password'

const props = defineProps<{
  label: String
  labelClass?: String
  placeholder: String
  type: 'password' | 'text' | 'email'
  feedback?: boolean
  onChange?: Function
}>()

import { ref } from 'vue'
const value = ref(null)

const hanlder = (e: any) => {
  value.value = e.target.value
  if (props.onChange) {
    props.onChange(value.value)
  }
}
</script>

<template>
  <div class="form-control">
    <div class="label">
      <span class="text-base-100 label-text text-lg" :class="labelClass">{{ props.label }}</span>
    </div>
    <input
      v-if="props.type !== 'password'"
      :value="value"
      @input="hanlder"
      :type="props.type"
      :placeholder="props.placeholder"
      class="input input-bordered w-full bg-neutral text-primary border-secondary"
    />
    <Password
      v-else
      v-model="value"
      @input="hanlder"
      placeholder="Enter a passowrd"
      class="input input-bordered w-full bg-neutral text-primary border-secondary"
      :feedback="feedback || false"
    >
      <template #header>
        <div class="mt-4"></div>
      </template>
    </Password>
  </div>
</template>
