<script setup lang="ts">
import EditApp from './EditApp.vue';
import RemoveApp from './RemoveApp.vue';
import Contact from './Contact.vue';
</script>
<template>
    <v-item-group>
        <v-row>
            <v-col
            v-for="n in 4"
            :key="n"
            cols="12"
            md="4"
            >
            <v-card width="200" height="200" class="border-thin">
                <v-card-title width="100%">
                    bb
                </v-card-title>
                <v-card-text width="100%">
                    aa
                </v-card-text>
                <v-card-actions>
                    <EditApp :uuid="'123'" :item="{address: '123', description: '123',name: '123'}" />
                    <RemoveApp :name="'123'" :uuid="'123'"/>
                    <Contact :uuid="'123'" />
                </v-card-actions>
                
            </v-card>
            </v-col>
        </v-row>
    </v-item-group>
</template>