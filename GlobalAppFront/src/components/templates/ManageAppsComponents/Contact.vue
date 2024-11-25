<script setup lang="ts">
import { defineEmits, defineProps, ref } from 'vue'
import axios from 'axios'
import { Owner } from '@/types/AppType';
import caud from './_Contact/ContactAddUserDialog.vue';
import crud from './_Contact/ContactRemoveUserDialog.vue';
const base_url = inject<string>('url')
const emits = defineEmits(['dialog-closed']) // Emits
const dialog = ref(false) // Define the dialog property
const props = defineProps<{
    uuid: string,
}>()
const items = ref<Owner[]>([{appuuid: '1', fullname: '2', uuid: '3'}]);
onMounted(async () => {
    try{
        const response = await axios.get<Owner[]>(`${base_url}/application_details/${props.uuid}`);
        items.value = response.data;
    } catch(error){
        console.error(error);
    }
});
</script>
<template>
<v-dialog v-model="dialog" max-width="500px">
    <template #activator="{isActive, props}">
        <v-btn
        v-tooltop:bottom="`Osoby zarządzające`"
        class="mt-1 mb-1 me-1 ms-1"
        color="blue"
        size="30"
        v-bind="props"
        @click="isActive"
        ><v-icon>mdi-account-box-outline</v-icon>
        </v-btn>
    </template>
        <v-card>
            <v-card-title>
                <span class="headline">Osoby zarządzające</span>
            </v-card-title>
            <v-card-text>
                <v-data-table
                class="elevation-1"
                density="comfortable"
                :headers="[{title: 'Osoby', key: 'fullname', width: '80%'},
                    {title: 'Opcje', key: 'actions', sortable: false}
                ]"
                :items="items"
                :items-per-page="10"
                :items-per-page-options="[5, 10, 15, 20]"
                >
                <template #top>
                    <v-toolbar flat>
                        <v-toolbar-title>Personel</v-toolbar-title>
                        <v-spacer></v-spacer>
                        <caud :uuid="'123'" />
                    </v-toolbar>
                </template>
                <template #item.actions="{item}">
                    <crud :uuid="item.uuid" :fullname="item.fullname" />
                </template>
                </v-data-table>
            </v-card-text>
        </v-card>
</v-dialog> 
</template>