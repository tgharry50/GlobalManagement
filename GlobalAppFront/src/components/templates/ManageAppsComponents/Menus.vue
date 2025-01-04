<script setup lang="ts">
import CreateApp from './CreateApp.vue';
const emits = defineEmits(['created'])
</script>
<template>
        <div class="text-end">
            <v-menu location="start">
                <template v-slot:activator="{props}">
                    <v-btn
                    icon="mdi mdi-cog"
                    color="blue"
                    v-bind="props"
                    ></v-btn>
                </template>
                <v-list>
                    <v-list-item>
                        <v-list-item>
                            <CreateApp @create="emits('created', true)"/>
                        </v-list-item>
                    </v-list-item>
                </v-list>
            </v-menu>
        </div>
</template>