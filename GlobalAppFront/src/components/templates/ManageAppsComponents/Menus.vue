<script setup lang="ts">
import CreateApp from './CreateApp.vue';
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
                            <CreateApp />
                        </v-list-item>
                    </v-list-item>
                </v-list>
            </v-menu>
        </div>
</template>