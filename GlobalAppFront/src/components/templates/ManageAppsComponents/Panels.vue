<script setup lang="ts">
import { defineProps } from 'vue';
const props = defineProps<{
    refresh: boolean
}>();
watch(() => props.refresh, async (value) => {
    console.log(122);
    if(value){
        await fetchData();
    }
});
import EditApp from './EditApp.vue';
import RemoveApp from './RemoveApp.vue';
import Contact from './Contact.vue';
import axios from 'axios';
import {ref, onMounted} from 'vue';
import { API_BASE_URL } from '@/globals/globals';
import { Application } from '@/types/Applications';
import { is } from '@babel/types';
const applications = ref<Application[]>([]);
const isLoaded = ref(false);
async function fetchData() {
    const response = await axios.get<Application[]>(`${API_BASE_URL}/application/all`);
    try{
        applications.value = response.data;
    } catch (error) {
        console.error(error);
    }
}
onMounted(async () => {
    await fetchData();
    isLoaded.value = true;
});
async function DelayFetch() {
    setTimeout(() => {
        fetchData();
    }, 2500);
}
</script>
<template>
    <v-item-group>
        <v-row v-if="isLoaded">
            <v-col
             v-for="app in applications"
            :key="app.uuid"
            cols="12"
            md="4"
            >
            <v-card width="300" height="200" class="border-thin">
                <v-card-title width="100%">
                    {{ app.name }}
                </v-card-title>
                <v-card-text width="100%">
                    <p>{{ app.description }}</p>
                </v-card-text>
                <v-card-actions>
                    <EditApp :item="app" @edit="DelayFetch()"/>
                    <RemoveApp :name="app.name" :uuid="app.uuid" @delete="DelayFetch()" />
                    <a :href="'//' + app.address" target="_blank">
                        Przejdź do aplikacji
                    </a>
                </v-card-actions>
                
            </v-card>
            </v-col>
        </v-row>
        <v-row v-else>
            <v-col class="text-center">
                <p>Wczytywanie</p>
                <v-progress-circular
                indeterminate
                color="primary"
                ></v-progress-circular>
            </v-col>
        </v-row>
    </v-item-group>
</template>