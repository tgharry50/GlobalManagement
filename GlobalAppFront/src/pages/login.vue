<template>
  <v-layout>
    login
  </v-layout>
</template>
<script setup lang="ts">
  import { UserData } from '@/typescript_types/globals'
  import axios, { AxiosResponse } from 'axios'
  import { useAppStore } from '@/stores/app'
  const store = useAppStore()
  const login = ref('')
  const password = ref('')
  async function Login (): Promise<boolean> {
    const form = new FormData()
    form.append('Login', login.value)
    form.append('Password', password.value)
    try {
      const response: AxiosResponse<UserData> = await axios.post('', form)
      return await store.SetUserData(response.data)
    } catch (error) {
      console.error(error)
      throw error
    }
  }
</script>
