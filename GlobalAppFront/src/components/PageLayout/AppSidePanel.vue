<template>
  <v-navigation-drawer permanent>
    <v-list class="text-h5 text-center">
      <!-- TOP OF PAGE -->
      <v-list-item>
        <p>
          <!-- First name-->
          <span v-if="store.loggedin">{{ store.user.firstname }} {{ store.user.lastname }}</span>
          <span v-else>Global App</span>
        </p>
      </v-list-item>
      <v-divider />
      <v-list-item title="Strona główna" @click="router.push('/')">
        <template #prepend><v-icon icon="mdi-home" /></template>
      </v-list-item>
      <v-list-item title="Użytkownicy" @click="router.push('/manageusers')">
        <template #prepend><v-icon icon="mdi mdi-account-group" /></template>
      </v-list-item>
      <v-list-item title="Grupy" @click="router.push('/managegroups')">
        <template #prepend><v-icon icon="mdi-human-capacity-increase" /></template>
      </v-list-item>
      <v-list-item title="Aplikacje" @click="router.push('/manageapps')">
        <template #prepend><v-icon icon="mdi mdi-application-cog-outline" /></template>
      </v-list-item>
      <v-list-item title="Opcje" @click="router.push('/options')">
        <template #prepend><v-icon icon="mdi-cog-box" /></template>
      </v-list-item>
      <v-list-item title="Zarządzaj uprawnieniami" @click="router.push('/managepermissions')">
        <template #prepend><v-icon icon="mdi mdi-key-chain-variant" /></template>
      </v-list-item>
      <v-list-item title="Zaloguj się" @click="router.push('/login')">
        <template #prepend><v-icon icon="mdi-login" /></template>
      </v-list-item>
      <v-list-item title="Wyloguj się">
        <template #prepend><v-icon icon="mdi-logout" /></template>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>
<script setup lang="ts">
  import { Router, useRouter } from 'vue-router'
  import { useAppStore } from '@/stores/app'
  const router: Router = useRouter()
  const store = useAppStore()
</script>
