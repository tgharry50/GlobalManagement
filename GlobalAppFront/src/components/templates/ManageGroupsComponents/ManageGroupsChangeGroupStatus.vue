<script setup lang="ts">
// Imports
import { defineEmits, ref } from 'vue'
import Snackbar from '@/components/multiuse/Snackbar.vue'
import axios from 'axios'
import { API_BASE_URL } from '@/globals/globals'
// Props and emits
const emits = defineEmits(['status', 'dialog-closed'])
const props = defineProps<{
    uuid: string
}>()
const dialog = ref(false) // Define the dialog property
const isValid = ref(false) // Use for checking if form is Valid
const showSnackbar = ref(false) // Use for snackbar display
const colorSnackbar = ref('white') // Use for background color of snackbar
const message = ref('Default'); // Message text
//
const item = ref<string>(''); // Group UUID
const reset_item = ref<string>(item.value);
// Function
const saveItem = async () => { // Function to run the delete
    try{
      const result = await axios.put(`${API_BASE_URL}/group/change/${props.uuid}`);
      if(result){
        colorSnackbar.value = 'green'
        message.value = 'Zmieniono status grupy'
        emits('status', item)
        showSnackbar.value = true
        closeDialog()
      } else {
        console.error(result)
        colorSnackbar.value = 'yellow'
        message.value = 'Nie udało się zmienić statusu grupy'
        emits('status', item)
        showSnackbar.value = true
        closeDialog()
      }
    } catch(Error){
      console.error() //result
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się zmienić statusu grupy'
      emits('status', item)
      showSnackbar.value = true
      closeDialog()
    }
  }
  const closeDialog = () => { // Function to close the dialog
    dialog.value = false
    item.value = reset_item.value
    emits('dialog-closed', true)
  }
</script>
<template>
    <v-dialog v-model="dialog" max-width="600px">
      <template #activator="{isActive, props}">
        <v-btn v-bind="props" color="blue" variant="text" @click="isActive">
          <v-icon icon="mdi mdi-check-circle-outline" left />
          Zmień status
        </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">Zmień status grupy</span>
        </v-card-title>
        <v-card-text>
            <v-form>
                <v-row>
                  <v-col>
                    <p>Czy napewno chcesz zmienić status grupy ?</p>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col>
                    <v-checkbox v-model="isValid" label="Tak, chce zmienić status grupy"></v-checkbox>
                  </v-col>
                </v-row>
                <v-row>
                  <v-expand-transition>
                  <v-col class="text-center" v-if="isValid">
                      <v-btn :disabled="!isValid" @click="saveItem" color="blue" >Zmień status</v-btn>
                    </v-col>
                  </v-expand-transition>
                </v-row>
            </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>
    <Snackbar :color="colorSnackbar" :message="message" :show="showSnackbar" @update:show="showSnackbar = $event" />
  </template>