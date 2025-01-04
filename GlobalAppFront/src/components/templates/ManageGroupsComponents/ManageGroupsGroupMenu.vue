<script setup lang="ts">
const props = defineProps<{
uuid: string,
current: Group
}>()
import mgdg from './ManageGroupsDeleteGroup.vue';
import mgcgs from './ManageGroupsChangeGroupStatus.vue';
import mgeg from './ManageGroupsEditGroup.vue';
import { Group } from '@/types/Groups';
const emits = defineEmits(['delete', 'status', 'edit'])

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
                <mgeg :uuid="props.uuid" :current="{Description: props.current.description, Hala: props.current.hala, Name: props.current.name, Section: props.current.section}"
                @edit="emits('edit', true)"
                ></mgeg>
            </v-list-item>
            <!--Change Status-->
            <v-list-item>
                <mgcgs :uuid="props.uuid" @status="emits('status', true)"></mgcgs>
            </v-list-item>
            <!--DELETE-->
            <v-list-item>
                <mgdg :uuid="props.uuid" @delete="emits('delete', true)"></mgdg> 
            </v-list-item>
        </v-list>
    </v-menu>
</template>
