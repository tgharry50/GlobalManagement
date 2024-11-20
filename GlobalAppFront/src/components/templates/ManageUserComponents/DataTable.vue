<script setup lang="ts">
// Imports
  import { defineProps } from 'vue'
  import mucd from '@/components/templates/ManageUserComponents/ManageUserCreateDialog.vue'
  import mued from './ManageUserEditDialog.vue'
  import murd from './ManageUserRemoveDialog.vue'
  import muacd from './ManageUserActivityChangeDialog.vue'
  import mucpd from './ManageUserChangePasswordDialog.vue'
  import { User } from '@/types/User'
  //
  type ItemType = Record<string, any>

  const props = defineProps<{
    headers: Array<object>,
    items: Array<User>
  }>()
  const handleEdit = (item: ItemType) => {
    console.log('Edit item:', item.uuid)
  }

  const handleRemove = (item: ItemType) => {
    console.log('Remove item:', item)
  }

  const handleAdd = (item: ItemType) => {
    console.log('Add item', item)
  }

</script>
<template>
  <v-data-table
    class="elevation-1"
    density="comfortable"
    :headers="props.headers"
    :items="props.items"
    :items-per-page="10"
  >
    <!-- Top -->
    <template #top>
      <v-toolbar flat>
        <v-toolbar-title>Użytkownicy</v-toolbar-title>
        <v-spacer />
        <mucd @create="handleAdd" />
      </v-toolbar>
    </template>
    <!-- isActive -->
    <template #item.isActive="{ item }">
      <v-chip
        :color="item.isActive ? 'green' : 'red'"
      >
        {{ item.isActive ? 'Aktywny' : 'Nieaktywny' }}
      </v-chip>
    </template>
    <!-- Actions -->
    <template #item.actions="{ item }">
      <!-- Edit -->
      <mued
        :userdata="{
          userName: item.userName,
          firstName: item.firstName,
          lastName: item.lastName,
          email: item.email,
          card: item.card,
          password: item.password,
          pin: item.pin
        }"
        :uuid="item.uuid"
        @edit="handleEdit"
      />
      <!-- Delete -->
      <murd :fullname="item.fullName" :uuid="item.uuid" />
      <!-- Change Status -->
      <muacd :fullname="item.fullName" :status="item.isActive" :uuid="item.uuid" />
      <!-- Force change password -->
      <mucpd :uuid="item.uuid" />
    </template>
  </v-data-table>
</template>
<style scoped>

</style>
