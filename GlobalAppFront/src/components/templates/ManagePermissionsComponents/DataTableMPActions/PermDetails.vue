<script setup lang="ts">
import { defineEmits, defineProps, ref } from 'vue'
import axios from 'axios'
import Snackbar from '@/components/multiuse/Snackbar.vue'
import { ControlReportPerms, GlobalAppPerms, UserName } from '@/types/Permissions';
const base_url = inject<string>('url')
const emits = defineEmits(['dialog-closed']) // Emits
const props = defineProps<{
    item: UserName
}>()
const editMode = ref(true) // Edit mode
const dialog = ref(false) // Define the dialog property
const isValid = ref(false) // Use ref for reactivity
const showSnackbar = ref(false) // Use for snackbar display
const colorSnackbar = ref('white') // Use for background color of snackbar
//
const closeDialog = () => { // Function to close the dialog
    editMode.value = false
    dialog.value = false
    emits('dialog-closed', true)
}
const globalPerms = ref<GlobalAppPerms>(); const globalReady = ref(false)
const controlReportPerms = ref<ControlReportPerms>(); const cRReady = ref(false)
async function FetchGlobal(param: string) {
    try{
        const result = await axios.get(`${base_url}/global/${param}`)
        if(result){
            globalPerms.value = result.data;
            globalReady.value = true;
        }
    } catch(Error){
        console.error(Error);
    }
}
async function FetchControlReport(params:string) {
    try{
        const result = await axios.get(`${base_url}/controlreport/${params}`)
        if(result){
            controlReportPerms.value = result.data;
            cRReady.value = true;
        }
    } catch(Error){
        console.error(Error)
    }
}
</script>
<template>
    <v-dialog v-model="dialog" max-width="850px">
        <template #activator="{isActive, props}">
            <v-btn
            v-tooltip:bottom="'Szczegóły'"
            class="mt-1 mb-1 me-1 ms-1"
            color="blue"
            v-bind="props"
            @click="isActive"
            ><v-icon>mdi-card-account-details-outline</v-icon></v-btn>
        </template>
        <v-card>
            <v-card-title>
                <p class="headline">Uprawnienia</p>
                <div class="text-end"> <!-- Edit mode --> 
                    <v-btn :color="(editMode) ? 'yellow' : 'green'" icon="mdi-file-edit" v-model="editMode" @click="editMode = !editMode"> 
                    </v-btn>
                </div>
            </v-card-title>
            <v-card-text>
                <v-expansion-panels :readonly="!globalReady">
                    <v-expansion-panel>
                        <v-expansion-panel-title class="elevation-1 mb-1">
                            <span v-if="!globalReady">
                                Brak połączenia z bazą Global App
                            </span>
                            <span v-else>
                                Global App
                            </span>
                        </v-expansion-panel-title>
                        <v-expansion-panel-text>
                            <v-row>
                                <v-col>
                                    <v-row>
                                        <v-col>
                                            <p>Użytkownicy</p>
                                            <v-switch :readonly="editMode" label="Tworzenie"></v-switch>
                                            <v-switch :readonly="editMode" label="Usuwanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Aktualizowanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Role</p>
                                            <v-switch :readonly="editMode" label="Tworzenie"></v-switch>
                                            <v-switch :readonly="editMode" label="Usuwanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Aktualizowanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Grupy</p>
                                            <v-switch :readonly="editMode" label="Tworzenie"></v-switch>
                                            <v-switch :readonly="editMode" label="Usuwanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Aktualizowanie"></v-switch>
                                        </v-col>
                                    </v-row>
                                    <v-row>
                                        <v-col>
                                            <p>Inne</p>
                                            <v-switch :readonly="editMode" label="Dostęp do aplikacji Global App"></v-switch>
                                            <v-switch :readonly="editMode" label="Rola jest edytowalna"></v-switch>
                                        </v-col>
                                    </v-row>
                                    <v-row v-if="!editMode" class="text-center">
                                        <v-col>
                                            <v-btn color="green">Zapisz zmiany</v-btn>
                                        </v-col>
                                    </v-row>
                                </v-col>
                            </v-row>
                        </v-expansion-panel-text>
                    </v-expansion-panel>
                </v-expansion-panels>
                <v-expansion-panels :readonly="!cRReady">
                    <v-expansion-panel>
                        <v-expansion-panel-title class="elevation-1 mb-1">
                            <v-row>
                                <v-col>
                                    <span v-if="!cRReady">
                                        Brak połączenia z bazą Control
                                    </span>
                                    <span v-else>
                                        Control Report
                                    </span>
                                </v-col>
                            </v-row>

                        </v-expansion-panel-title>
                        <v-expansion-panel-text>
                            <v-row>
                                <v-col>
                                    <v-select></v-select> <!---->
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col>
                                    <v-row>
                                        <v-col>
                                            <p>Referencje</p>
                                            <v-switch :readonly="editMode" label="Tworzenie"></v-switch>
                                            <v-switch :readonly="editMode" label="Usuwanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Aktualizowanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Oglądanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Interwencje</p>
                                            <v-switch :readonly="editMode" label="Tworzenie"></v-switch>
                                            <v-switch :readonly="editMode" label="Usuwanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Aktualizowanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Oglądanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Zlecenia</p>
                                            <v-switch :readonly="editMode" label="Tworzenie"></v-switch>
                                            <v-switch :readonly="editMode" label="Usuwanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Aktualizowanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Oglądanie"></v-switch>
                                        </v-col>
                                    </v-row>
                                    <v-row>
                                        <v-col>
                                            <p>Dewiacje</p>
                                            <v-switch :readonly="editMode" label="Tworzenie"></v-switch>
                                            <v-switch :readonly="editMode" label="Usuwanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Aktualizowanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Oglądanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>ECR</p>
                                            <v-switch :readonly="editMode" label="Tworzenie"></v-switch>
                                            <v-switch :readonly="editMode" label="Usuwanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Aktualizowanie"></v-switch>
                                            <v-switch :readonly="editMode" label="Oglądanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Inne</p>
                                            <v-switch :readonly="editMode" label="Rola jest modyfikowalna"></v-switch>
                                            <v-switch :readonly="editMode" label="Master key"></v-switch>
                                            <v-switch :readonly="editMode" label="Dostęp do aplikacji"></v-switch>
                                        </v-col>
                                    </v-row>
                                    <v-row v-if="!editMode" class="text-center">
                                        <v-col>
                                            <v-btn color="green">Zapisz zmiany</v-btn>
                                        </v-col>
                                    </v-row>
                                </v-col>
                            </v-row>
                        </v-expansion-panel-text>
                    </v-expansion-panel>
                </v-expansion-panels>
            </v-card-text>
        </v-card>
    </v-dialog>
    <Snackbar :color="colorSnackbar" :message="'Test'" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>