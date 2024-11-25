<script setup lang="ts">
import { defineEmits, ref } from 'vue'
import Snackbar from '@/components/multiuse/Snackbar.vue'
import axios from 'axios'
import { CreateApp } from '@/types/AppType';
const emits = defineEmits(['edit', 'dialog-closed'])
const props = defineProps<{
    uuid: string,
    item: CreateApp
}>();
const dialog = ref(false) // Define the dialog property
const isValid = ref(false) // Use for checking if form is Valid
const showSnackbar = ref(false) // Use for snackbar display
const colorSnackbar = ref('white') // Use for background color of snackbar
const item = ref<CreateApp>({
    address: props.item.address,
    description: props.item.description,
    name: props.item.name
})
const reset_item = ref<CreateApp>({...item.value});
//
const closeDialog = () => { // Function to close the dialog
    dialog.value = false
    item.value = reset_item.value
    emits('dialog-closed', true)
}
const saveItem = () => { // Function to save the item
    emits('edit', item)
    showSnackbar.value = true
    closeDialog()
}
</script>
<template>
     <v-dialog v-model="dialog" max-width="500px">
        <template #activator="{isActive, props}">
            <v-btn
            v-tooltop:bottom="'Edytuj'"
            color="blue"
            class="mt-1 mb-1 me-1 ms-1"
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
                <v-btn color="green" :disabled="!isValid" @click="saveItem">Edytuj</v-btn>
            </v-card-actions>
        </v-card>
     </v-dialog>
     <Snackbar :color="colorSnackbar" :message="'Test'" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>