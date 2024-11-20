<script setup lang="ts">
  import { CreateUser } from '@/types/User'
  import { defineEmits, ref } from 'vue'
  import Snackbar from '@/components/multiuse/Snackbar.vue'
  import axios from 'axios'
  //
  const emits = defineEmits(['create', 'dialog-closed'])
  const dialog = ref(false) // Define the dialog property
  const isValid = ref(false) // Use for checking if form is Valid
  const showSnackbar = ref(false) // Use for snackbar display
  const colorSnackbar = ref('white') // Use for background color of snackbar
  const item = ref<CreateUser>({ // Created User data
    userName: '',
    firstName: '',
    lastName: '',
    email: '',
    card: '',
    password: '',
    pin: null,
  })

  const reset_item = ref<CreateUser>({ ...item.value })
  // Function
  const saveItem = () => { // Function to save the item
    showSnackbar.value = true
    closeDialog()
    item.value = { ...reset_item.value }
    emits('create', item)
  }

  const closeDialog = () => { // Function to close the dialog
    dialog.value = false
    item.value = { ...reset_item.value }
    emits('dialog-closed', true)
  }
</script>
<template>
  <v-dialog v-model="dialog" max-width="500px">
    <template #activator="{isActive, props}">
      <v-btn color="primary" v-bind="props" @click="isActive">
        <v-icon icon="mdi-plus" left />
        Dodaj użytkownika
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">Dodaj użytkownika</span>
      </v-card-title>
      <v-card-text>
        <v-form v-model="isValid">
          <v-row>
            <v-col>
              <v-text-field
                v-model="item.userName"
                counter
                label="Login"
                maxlength="16"
                required
                :rules="
                  [
                    v => /^[a-zA-Z]*$/.test(v) || 'Login nie może zawierać liczb ani znaków specjalnych',
                    v => v.length >= 4 || 'Login musi mieć minimum 4 znaki'
                  ]"
              />
              <v-text-field
                v-model="item.firstName"
                counter="16"
                label="Imię"
                maxlength="16"
                required
                :rules="
                  [
                    v => /^[a-zA-Z]*$/.test(v) || 'Imie nie może zawierać liczb ani znaków specjalnych',
                    v => v.length >= 4 || 'Imię musi mieć minimum 4 znaki'
                  ]"
              />
              <v-text-field
                v-model="item.card"
                counter="16"
                label="Karta"
                maxlength="16"
                required
                :rules="
                  [
                    v => /^\d+$/.test(v) || 'Numer karty nie może zawierać liter ani znaków specjalnych',
                    v => v.length >= 4 || 'Numer karty musi mieć minimum 4 znaki'
                  ]"
              />
            </v-col>
            <v-col>
              <v-text-field
                v-model="item.password"
                counter="256"
                label="Hasło"
                maxlength="256"
                required
                :rules="
                  [
                    v => v.length >= 8 || 'Hasło musi mieć minimum 8 znaków',
                  ]"
                type="password"
              />
              <v-text-field
                v-model="item.lastName"
                counter="16"
                label="Nazwisko"
                maxlength="16"
                required
                :rules="
                  [
                    v => /^[a-zA-Z]*$/.test(v) || 'Nazwisko nie może zawierać liczb ani znaków specjalnych',
                    v => v.length >= 4 || 'Nazwisko musi mieć minimum 4 znaki'
                  ]"
              />
              <v-text-field
                v-model="item.pin"
                counter="8"
                label="PIN karty"
                maxlength="8"
                required
                :rules="
                  [
                    v => /^\d+$/.test(v) || 'PIN nie może zawierać liter ani znaków specjalnych',
                    v => v.length >= 4 || 'PIN musi mieć minimum 4 znaki'
                  ]"
              />
            </v-col>
          </v-row>
          <v-row>
            <v-text-field
              v-model="item.email"
              counter="64"
              label="E-mail"
              maxlength="64"
              required
              :rules="
                [
                  v => /.+@.+\..+/.test(v) || 'E-mail musi być poprawny',
                  v => v.length >= 4 || 'E-mail musi mieć minimum 4 znaki'
                ]"
            />
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="gray" @click="closeDialog">Zamknij</v-btn>
        <v-btn color="green" :disabled="!isValid" @click="saveItem">Utwórz</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
  <Snackbar :color="colorSnackbar" :message="'Test'" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>
