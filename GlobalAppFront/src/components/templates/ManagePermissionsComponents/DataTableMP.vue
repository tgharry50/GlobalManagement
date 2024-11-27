<script setup lang="ts">
import {defineProps} from 'vue'
import axios from 'axios'
import { UserName } from '@/types/Permissions';
import pd from './DataTableMPActions/PermDetails.vue';
const base_url = inject<string>('url')
const loading = ref(false);

const tableItems = ref<UserName[]>([])

onMounted(async () => {
try {
    const response = await axios.get<UserName[]>(`${base_url}/users`)
    if(response){
        loading.value = true
        tableItems.value = response.data
    }
} catch (error) {
    console.error('Error fetching data:', error)
}
})
</script>
<template>
    <v-data-table
    class="elevation-1"
    density="comfortable"
    :items-per-page="10"
    :items-per-page-options="[10,25,50,-1]"
    :items="tableItems"
    :headers="[
        {title: 'Użytkownik', key: 'fullName', width: '80%'},
        {title: 'Funkcje', key: 'actions', width: '20%', sortable: false}
        ]"
    >
    <template #top>
        <v-toolbar flat>
            <v-toolbar-title>Użytkownicy i uprawnienia</v-toolbar-title>
            <v-spacer></v-spacer>
        </v-toolbar>
    </template>
    <template #item.fullName="{item}">
        {{ item.fullName }}
    </template>
    <template #item.actions>
        <pd></pd>
    </template>
    </v-data-table>
</template>