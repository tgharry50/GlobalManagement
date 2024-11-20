<template>
  <v-layout>
    <v-container>
      <DataTable
        :headers="tableHeaders"
        :items="tableItems"
      />
    </v-container>
  </v-layout>
</template>
<script setup lang="ts">
// Imports
  import DataTable from '@/components/templates/ManageUserComponents/DataTable.vue'
  import { inject, onMounted, ref } from 'vue'
  import axios from 'axios'
  import { User } from '@/types/User'
  // Inject
  const base_url = inject<string>('url')
  //
  const tableHeaders = ref([
    { title: 'Login', key: 'userName' },
    { title: 'Imię', key: 'firstName' },
    { title: 'Nazwisko', key: 'lastName' },
    { title: 'Pełne I+N', key: 'fullName', sortable: false },
    { title: 'Email', key: 'email', sortable: false },
    { title: 'Karta', key: 'card', sortable: false },
    { title: 'Konto', key: 'isActive' },
    { title: 'Funkcje', key: 'actions', sortable: false, width: '25%' },
  ])
  const tableItems = ref<User[]>([])

  onMounted(async () => {
    try {
      const response = await axios.get<User[]>(`${base_url}/users`)
      tableItems.value = response.data
    } catch (error) {
      console.error('Error fetching data:', error)
    }
  })

</script>
