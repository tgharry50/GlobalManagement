<script lang="ts" setup>
import { defineEmits, ref } from 'vue';
import Snackbar from '@/components/multiuse/Snackbar.vue';
import axios from 'axios';
import { Application } from '@/types/Applications';
import { API_BASE_URL } from '@/globals/globals';
const emits = defineEmits(['create', 'dialog-closed'])
const dialog = ref(false) // Define the dialog property
const isValid = ref(false) // Use for checking if form is Valid
const showSnackbar = ref(false) // Use for snackbar display
const colorSnackbar = ref('white') // Use for background color of snackbar
const message = ref('Default'); // Message text
const item = ref<Application>({
    isActive: false,
    address: '',
    description: '',
    name: '',
    uuid: ''
})
const reset_item = ref<Application>({...item.value});
//
const closeDialog = () => { // Function to close the dialog
    dialog.value = false
    item.value = { ...reset_item.value }
    emits('dialog-closed', true)
}
const saveItem = async () => { // Function to save the item
    const form = new FormData();
    form.append("Address", item.value.address)
    form.append("Description", item.value.description)
    form.append("Name", item.value.name)
    try{
      const result = await axios.post(`${API_BASE_URL}/application/create`, form);
      if(result){
        colorSnackbar.value = 'green'
        message.value = 'Edytowano aplikacje'
        emits('create', item)
        showSnackbar.value = true
        closeDialog()
      } else {
        console.error(result)
        colorSnackbar.value = 'yellow'
        message.value = 'Nie udało się edytować aplikacji'
        emits('create', item)
        showSnackbar.value = true
        closeDialog()
      }
    } catch(Error){
      console.error() //result
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się edytować aplikacji'
      emits('create', item)
      showSnackbar.value = true
      closeDialog()
    }
}
</script>
<template>
    <v-dialog v-model="dialog" max-width="500px">
        <template #activator="{isActive, props}">
            <v-btn color="primary" v-bind="props" @click="isActive">
                <v-icon icon="mdi-plus" left />
                Dodaj Aplikacje
            </v-btn>
        </template>
        <v-card>
            <v-card-title>
                <span class="headline">Dodaj Aplikacje</span>
            </v-card-title>
            <v-card-text>
                <v-form v-model="isValid">
                    <v-row>
                        <v-col>
                            <v-text-field
                            v-model="item.name"
                            counter
                            label="Nazwa"
                            maxlength="16"
                            required
                            :rules="
                            [
                                v => /^[a-zA-Z]*$/.test(v) || 'Nazwa nie może zawierać liczb ani znaków specjalnych',
                                v => v.length >= 4 || 'Nazwa musi mieć minimum 4 znaki'
                            ]"
                        />
                        </v-col>
                        <v-col>
                            <v-text-field
                            v-model="item.address"
                            counter
                            label="Adres"
                            maxlength="32"
                            required
                            :rules="
                            [
                                v => /\d+(?:\.\d+)?/g.test(v) || 'Adres nie może zawierać liter ani znaków specjalnych',
                                v => v.length >= 15 || 'Adres musi mieć minimum 15 znaki'
                            ]"
                        />
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col>
                            <v-textarea clearable label="Opis" v-model="item.description"
                            counter maxlength="256"
                            ></v-textarea>
                        </v-col>
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