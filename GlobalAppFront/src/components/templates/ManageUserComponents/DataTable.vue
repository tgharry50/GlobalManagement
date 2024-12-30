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
  const emits = defineEmits(['update']) // Emits
  const props = defineProps<{
    headers: Array<object>,
    items: Array<User>
  }>()
  const handleEdit = () => {
    emits('update', true)
  }
  const handleUpdate = () => {
    emits('update', true)
  }
  const handleRemove = () => {
    emits('update', true)
  }

  const handleAdd = () => {
    emits('update', true)
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
      <murd :fullname="item.fullName" :uuid="item.uuid" @delete="handleRemove"/>
      <!-- Change Status -->
      <muacd :fullname="item.fullName" :status="item.isActive" :uuid="item.uuid" @status="handleUpdate" />
      <!-- Force change password -->
      <mucpd :uuid="item.uuid"  />
    </template>
  </v-data-table>
</template>
<style scoped>

</style>
