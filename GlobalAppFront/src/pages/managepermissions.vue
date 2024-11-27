<template>
  <v-layout>
    <v-container fill-height fluid>
        <v-tabs
        v-model="tab"
        bg-color="red">
         <v-tab :value="0">Uprawnienia użytkowników</v-tab>
         <v-tab :value="1">Uprawnienia</v-tab>
        </v-tabs>
        <v-tabs-window v-model="tab">
          <v-tabs-window-item :value="0">
            <permissions-user />
          </v-tabs-window-item> 
          <v-tabs-window-item :value="1">
            <permissions />
          </v-tabs-window-item>
        </v-tabs-window>
      </v-container>
  </v-layout>
</template>
<script setup lang="ts">
const tab = ref(0);
import PermissionsUser from '@/components/templates/ManagePermissionsComponents/PermissionsUser.vue';
import Permissions from '@/components/templates/ManagePermissionsComponents/Permissions.vue';
</script>
