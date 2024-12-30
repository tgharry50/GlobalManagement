<script setup lang="ts">
const props = defineProps<{
uuid: string
}>()
import mgdg from './ManageGroupsDeleteGroup.vue';
</script>

<template>
    <v-menu>
        <template v-slot:activator="{isActive, props}">
            <v-btn v-tooltip="'Opcje grupy'" color="primary" class="mb-1" v-bind="props" @click="isActive" icon="mdi mdi-cog-box"> 
            </v-btn>
        </template>
        <v-list>
            <!--Edit-->
            <v-list-item>
                Edytuj grupę
            </v-list-item>
            <!--Change Status-->
            <v-list-item>
                Wyłącz/Włącz grupę
            </v-list-item>
            <!--DELETE-->
            <v-list-item>
                <mgdg :uuid="props.uuid"></mgdg>
            </v-list-item>
        </v-list>
    </v-menu>
</template>
