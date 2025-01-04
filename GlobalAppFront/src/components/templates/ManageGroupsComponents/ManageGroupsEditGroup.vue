<script setup lang="ts">
// Imports
import { defineEmits, ref } from 'vue'
import Snackbar from '@/components/multiuse/Snackbar.vue'
import axios from 'axios'
import { halls, sections, API_BASE_URL } from '@/globals/globals'
import { Group_Add } from '@/types/Groups'
// Props and emits
const emits = defineEmits(['edit', 'dialog-closed'])
const props = defineProps<{
    uuid: string,
    current: Group_Add
}>()
const dialog = ref(false) // Define the dialog property
const isValid = ref(false) // Use for checking if form is Valid
const showSnackbar = ref(false) // Use for snackbar display
const colorSnackbar = ref('white') // Use for background color of snackbar
const message = ref('Default'); // Message text
//
const item = ref<Group_Add>({
    Name: props.current.Name,
    Description: props.current.Description,
    Hala: props.current.Hala,
    Section: props.current.Section,
})
const reset_item = ref<Group_Add>(item.value);
// Function
const saveItem = async () => { // Function to run the delete
    const form = new FormData();
    form.append("Name", item.value.Name)
    form.append("Description", item.value.Description)
    form.append("Hala", item.value.Hala)
    form.append("Section", item.value.Section)
    try{
      const result = await axios.put(`${API_BASE_URL}/group/edit/${props.uuid}`, form);
      if(result){
        colorSnackbar.value = 'green'
        message.value = 'Edytowano grupę'
        emits('edit', item)
        showSnackbar.value = true
        closeDialog()
      } else {
        console.error(result)
        colorSnackbar.value = 'yellow'
        message.value = 'Nie udało się edytować grupy'
        emits('edit', item)
        showSnackbar.value = true
        closeDialog()
      }
    } catch(Error){
      console.error() //result
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się edytować grupy'
      emits('edit', item)
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
        <v-btn v-bind="props" color="yellow" variant="text" @click="isActive">
          <v-icon icon="mdi mdi-delete" left />
          Edytuj grupę
        </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">Edytuj grupę</span>
        </v-card-title>
        <v-card-text>
            <v-form v-model="isValid">
                <v-row>
                <v-col>
                  <v-text-field
                    v-model="item.Name"
                    counter
                    label="Nazwa"
                    maxlength="16"
                    required
                    :rules="
                      [
                        v => /^[a-zA-Z0-9]+$/.test(v) || 'Nazwa nie może znaków specjalnych',
                        v => v.length >= 2 || 'Nazwa musi mieć minimum 2 znaki'
                      ]"
                  />
                </v-col>
                <v-col>
                  <v-text-field
                    v-model="item.Description"
                    counter
                    label="Opis"
                    maxlength="256"
                  />
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-autocomplete 
                  label="Hala"
                  v-model="item.Hala"
                  :items="halls"
                  :item-title="'key'"
                  :item-value="'value'"
                  :rules="[v => !!v]"
                  required
                  />
                </v-col>
                <v-col>
                  <v-autocomplete
                  label="Sekcja"
                  v-model="item.Section"
                  :items="sections"
                  :item-title="'key'"
                  :item-value="'value'"
                  required
                  :rules="[v => !!v]"
                  />
                </v-col>
              </v-row>
                <v-row>
                  <v-expand-transition>
                  <v-col class="text-center" v-if="isValid">
                      <v-btn :disabled="!isValid" @click="saveItem" color="yellow" >Edytuj grupę</v-btn>
                    </v-col>
                  </v-expand-transition>
                </v-row>
            </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>
    <Snackbar :color="colorSnackbar" :message="message" :show="showSnackbar" @update:show="showSnackbar = $event" />
  </template>