<template>
  <v-layout>
      <v-container fill-height fluid>
        <v-row>
          <v-col>
        <h2>Aplikacje</h2>
          </v-col>
          <v-col>
        <Menus @created="CreatedFetch"/>
          </v-col>
        </v-row>
        <v-row>
          <v-col>
        <Panels :refresh="refresh"/>
          </v-col>
        </v-row>
      </v-container>
  </v-layout>
</template>

<script setup lang="ts">
import Menus from '@/components/templates/ManageAppsComponents/Menus.vue'
import Panels from '@/components/templates/ManageAppsComponents/Panels.vue'
import { defineEmits } from 'vue'
let refresh = ref(false)
const emits = defineEmits(['refresh'])
async function CreatedFetch(value: boolean) {
  if(value){
    refresh.value = true
  }
}
</script>
