<template>
  <v-layout>
    <v-container fill-height fluid>
      <v-row>
        <v-col>
          <h2>Aplikacje</h2>
        </v-col>
        <v-col>
          <Menus />
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <Panels />
        </v-col>
      </v-row>
    </v-container>
  </v-layout>
</template>

<script lang="ts">
import Menus from '@/components/templates/ManageAppsComponents/Menus.vue'
import Panels from '@/components/templates/ManageAppsComponents/Panels.vue'
</script>
