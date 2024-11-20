<!-- src/components/Snackbar.vue -->
<script setup lang="ts">
  import { defineEmits, defineProps, ref, watch } from 'vue'

  const emits = defineEmits(['update:show'])
  const props = defineProps<{
    message: string;
    show: boolean;
    color: string;
  }>()

  const snackbar = ref(props.show)

  watch(() => props.show, newVal => {
    snackbar.value = newVal
  })

  watch(snackbar, newVal => {
    if (!newVal) {
      emits('update:show', false)
    }
  })
</script>

<template>
  <v-snackbar
    v-model="snackbar"
    bottom
    :color="color"
    :timeout="3000"
    vertical
  >
    <div class="text-subtitle-1 pb-2">Alert</div>
    <p>{{ props.message }}</p>
    <template #actions="{ isActive }">
      <v-btn color="white" v-bind="isActive" variant="text" @click="snackbar = false">Zamknij</v-btn>
    </template>
  </v-snackbar>
</template>
