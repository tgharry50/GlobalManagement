<script setup lang="ts">
// Imports
  import { CreateUser } from '@/types/User'
  import { defineEmits, defineProps, ref } from 'vue'
  import axios from 'axios'
  import Snackbar from '@/components/multiuse/Snackbar.vue'
  // Inject
  const base_url = inject<string>('url')
  //
  const emits = defineEmits(['edit', 'dialog-closed']) // Emits
  const props = defineProps<{
    userdata: CreateUser,
    uuid: string
  }>()
  const dialog = ref(false) // Define the dialog property
  const isValid = ref(false) // Use ref for reactivity
  const showSnackbar = ref(false) // Use for snackbar display
  const colorSnackbar = ref('white') // Use for background color of snackbar
  const message = ref('Default');
  const item = ref<CreateUser>({ // Modified user
    userName: props.userdata.userName,
    firstName: props.userdata.firstName,
    lastName: props.userdata.lastName,
    email: props.userdata.email,
    card: props.userdata.card,
    password: props.userdata.password,
    pin: props.userdata.pin,
  })
  const reset_item = ref<CreateUser>({ ...item.value }) 
  // Function
  const saveItem = async () => { // Function to save the item
    try{
      const result = await axios.put(`${base_url}/users/edit/${props.uuid}`, item.value)
      if(result){
        colorSnackbar.value = 'green'
        message.value = 'Zmodyfikowano użytkownika'
        emits('edit', item)
        showSnackbar.value = true
        closeDialog()
      } else{
        console.error(result)
        colorSnackbar.value = 'yellow'
        message.value = 'Nie udało się zmodyfikować użytkownika'
        emits('edit', item)
        showSnackbar.value = true
        closeDialog()
      }
    } catch(Error){
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się zmodyfikować użytkownika'
      emits('edit', item)
      showSnackbar.value = true
      closeDialog()
    }
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
      <v-btn
        v-tooltip:bottom="'Edytuj'"
        class="mt-1 mb-1 me-1 ms-1"
        color="blue"
        size="30"
        v-bind="props"
        @click="isActive"
      >
        <v-icon>mdi-pencil</v-icon>
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">Edytuj</span>
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
                    v => /^[a-zA-Z]*$/.test(v) || 'Login musi składać się z liter',
                    v => v.length >= 2 || 'Login musi mieć minimum 2 znaki'
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
              <v-col>
                <v-text-field
                maxlength="64"
                required
                v-model="item.email"
                counter="64"
                label="E-mail"
                :rules="
                  [
                    v => /.+@.+\..+/.test(v) || 'E-mail musi być poprawny',
                    v => v.length >= 4 || 'E-mail musi mieć minimum 4 znaki'
                  ]"
                />
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="gray" @click="closeDialog">Zamknij</v-btn>
        <v-btn color="green" :disabled="!isValid" @click="saveItem">Zapisz</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
  <Snackbar :color="colorSnackbar" :message="message" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>
