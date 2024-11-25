<script setup lang="ts">
import { defineEmits, ref } from 'vue'
import Snackbar from '@/components/multiuse/Snackbar.vue'
import axios from 'axios'
import { CreateOwner, UserList } from '@/types/AppType';
//
const base_url = inject<string>('url')
const emits = defineEmits(['create', 'dialog-closed'])
const dialog = ref(false) // Define the dialog property
const isValid = ref(false) // Use for checking if form is Valid
const showSnackbar = ref(false) // Use for snackbar display
const colorSnackbar = ref('white') // Use for background color of snackbar
const props = defineProps<{
    uuid: string
}>()
const item = ref<CreateOwner>({ // Created User data
    appuuid: props.uuid,
    useruuid: ''
});
const reset_item = ref<CreateOwner>({...item.value});
//
const users = ref<UserList[]>([]) // Users
//
onMounted(async () => {
    try{
        await FetchUsers()
    } catch(error){
        console.error(error)
        users.value.push({uuid: 'Brak połączenia', fullName: 'Brak połączenia'})
    }
})
async function FetchUsers() {
    try{
        const result = await axios.get<UserList[]>(`${base_url}/contact_users`)
        users.value = result.data;
    } catch(error){
        console.error(error)
    }
}
const saveItem = async () => { // Function to save the item
    showSnackbar.value = true
    closeDialog()
    item.value = { ...reset_item.value }
    await FetchUsers()
    emits('create', item)
}

const closeDialog = async () => { // Function to close the dialog
    dialog.value = false
    item.value = { ...reset_item.value }
    users
    await FetchUsers()
    emits('dialog-closed', true)
}
</script>
<template>
    <v-dialog v-model="dialog" max-width="400px">
            <template #activator="{isActive, props}">
                <v-btn>
                    <v-btn v-tooltip:bottom="'Dodaj użytkownika'" color="primary" v-bind="props" @click="isActive">
                        <v-icon icon="mdi-plus"/>
                    </v-btn>
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
                                <v-autocomplete
                                label="Aplikacja"
                                v-model="item.appuuid"
                                item-title="name"
                                item.value="abbr"
                                :items="[{name: 'a', abbr: 'b'}]"
                                readonly
                                ></v-autocomplete>
                            </v-col>
                            <v-col>
                                <v-autocomplete
                                label="Użytkownik"
                                v-model="item.useruuid"
                                item-title="name"
                                item.value="abbr"
                                :items="[{name: 'a', abbr: 'b'}]"
                                :rules="[v => !!v]"
                                ></v-autocomplete>
                            </v-col>
                        </v-row>
                    </v-form>
                </v-card-text>
                <v-card-actions>
                    <v-spacer />
                    <v-btn color="gray" @click="closeDialog">Zamknij</v-btn>
                    <v-btn color="green" :disabled="!isValid" @click="saveItem">Dodaj</v-btn>
                </v-card-actions>
            </v-card>
    </v-dialog>
    <Snackbar :color="colorSnackbar" :message="'Test'" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>