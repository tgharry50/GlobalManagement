<script setup lang="ts">
import { defineEmits, defineProps, ref } from 'vue'
import axios from 'axios'
import Snackbar from '@/components/multiuse/Snackbar.vue'
import { ControlReportPerms, GlobalAppPerms, UserName, AppPerms } from '@/types/Permissions';
const base_url = inject<string>('url')
const emits = defineEmits(['dialog-closed']) // Emits
const props = defineProps<{
    value: UserName
}>()
const editMode = ref(true) // Edit mode
const dialog = ref(false) // Define the dialog property
// const isValid = ref(false) // Use ref for reactivity
const showSnackbar = ref(false) // Use for snackbar display
const colorSnackbar = ref('white') // Use for background color of snackbar
//
const globalPerms = ref<GlobalAppPerms>(); 
const controlReportPerms = ref<ControlReportPerms>(); 
const isReady = ref(true);
async function FetchPermsForUser(uuid: string) {
    try{
        const result = await axios.get(`${base_url}/permission/user/${uuid}`)
        if(result){
            globalPerms.value = result.data.globalPermissions;
            controlReportPerms.value = result.data.controlReportRolePermission;
        }
    } catch(Error){
        console.error(Error);
    }
}
onMounted(async () => {
    await FetchPermsForUser(props.value.uuid).then(() => {
        isReady.value = true;
    })

})
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
                <v-expansion-panels :readonly="!isReady">
                    <v-expansion-panel>
                        <!-- GLobalApp -->
                        <v-expansion-panel-title class="elevation-1 mb-1">
                            <span v-if="!isReady">
                                Brak połączenia z bazą Global App
                            </span>
                            <span v-else>
                                Global App
                            </span>
                        </v-expansion-panel-title>
                        <v-expansion-panel-text>
                            <v-row v-if="!editMode">
                                <v-col>
                                    <v-select></v-select> <!---->
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col>
                                    <v-row>
                                        <v-col>
                                            <p>Użytkownicy</p>
                                            <v-switch color="green" :model-value="globalPerms?.createUser" :v-model="globalPerms?.createUser" readonly label="Tworzenie"></v-switch>
                                            <v-switch color="green" :model-value="globalPerms?.deleteUser" :v-model="globalPerms?.deleteUser" readonly label="Usuwanie"></v-switch>
                                            <v-switch color="green" :model-value="globalPerms?.updateUser" :v-model="globalPerms?.updateUser" readonly label="Aktualizowanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Role</p>
                                            <v-switch color="green" :model-value="globalPerms?.createCustomRole" :v-model="globalPerms?.createCustomRole" readonly label="Tworzenie"></v-switch>
                                            <v-switch color="green" :model-value="globalPerms?.deleteCustomRole" :v-model="globalPerms?.deleteCustomRole" readonly label="Usuwanie"></v-switch>
                                            <v-switch color="green" :model-value="globalPerms?.updateCustomRole" :v-model="globalPerms?.updateCustomRole" readonly label="Aktualizowanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Grupy</p>
                                            <v-switch color="green" :model-value="globalPerms?.canCreateGroup" :v-model="globalPerms?.canCreateGroup" readonly label="Tworzenie"></v-switch>
                                            <v-switch color="green" :model-value="globalPerms?.canDeleteGroup" :v-model="globalPerms?.canDeleteGroup" readonly label="Usuwanie"></v-switch>
                                            <v-switch color="green" :model-value="globalPerms?.canUpdateGroup" :v-model="globalPerms?.canUpdateGroup" readonly label="Aktualizowanie"></v-switch>
                                        </v-col>
                                    </v-row>
                                    <v-row>
                                        <v-col>
                                            <p>Inne</p>
                                            <v-switch color="green" :model-value="globalPerms?.canAccessGlobal" :v-model="globalPerms?.canAccessGlobal" readonly label="Dostęp do aplikacji Global App"></v-switch>
                                            <v-switch color="green" :model-value="globalPerms?.canBeEdited" :v-model="globalPerms?.canBeEdited" readonly label="Rola jest edytowalna"></v-switch>
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
                <v-expansion-panels :readonly="!isReady">
                    <v-expansion-panel>
                        <v-expansion-panel-title class="elevation-1 mb-1">
                            <v-row>
                                <v-col>
                                    <span v-if="!isReady">
                                        Brak połączenia z bazą Control
                                    </span>
                                    <span v-else>
                                        Control Report
                                    </span>
                                </v-col>
                            </v-row>

                        </v-expansion-panel-title>
                        <!-- ControlReport -->
                        <v-expansion-panel-text>
                            <v-row v-if="!editMode">
                                <v-col>
                                    <v-select></v-select> <!---->
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col>
                                    <v-row>
                                        <v-col>
                                            <p>Referencje</p>
                                            <v-switch :model-value="controlReportPerms?.canCreateReference" :v-model="controlReportPerms?.canCreateReference" color="green"readonly label="Tworzenie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canDeleteReference" :v-model="controlReportPerms?.canDeleteReference" color="green"readonly label="Usuwanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canUpdateReference" :v-model="controlReportPerms?.canUpdateReference" color="green"readonly label="Aktualizowanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canReadReference" :v-model="controlReportPerms?.canReadReference" color="green"readonly label="Oglądanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Interwencje</p>
                                            <v-switch :model-value="controlReportPerms?.canCreateIntervention" :v-model="controlReportPerms?.canCreateIntervention" color="green"readonly label="Tworzenie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canDeleteIntervention" :v-model="controlReportPerms?.canDeleteIntervention" color="green"readonly label="Usuwanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canUpdateInterevention" :v-model="controlReportPerms?.canUpdateInterevention" color="green"readonly label="Aktualizowanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canReadIntervention" :v-model="controlReportPerms?.canReadIntervention" color="green"readonly label="Oglądanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Zlecenia</p>
                                            <v-switch :model-value="controlReportPerms?.canCreateTask" :v-model="controlReportPerms?.canCreateTask" color="green"readonly label="Tworzenie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canDeleteTask" :v-model="controlReportPerms?.canDeleteTask" color="green"readonly label="Usuwanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canUpdateTask" :v-model="controlReportPerms?.canUpdateTask" color="green"readonly label="Aktualizowanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canReadTask" :v-model="controlReportPerms?.canReadTask" color="green"readonly label="Oglądanie"></v-switch>
                                        </v-col>
                                    </v-row>
                                    <v-row>
                                        <v-col>
                                            <p>Dewiacje</p>
                                            <v-switch :model-value="controlReportPerms?.canCreateDeviation" :v-model="controlReportPerms?.canCreateDeviation" color="green"readonly label="Tworzenie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canDeleteDeviation" :v-model="controlReportPerms?.canDeleteDeviation" color="green"readonly label="Usuwanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canUpdateDeviation" :v-model="controlReportPerms?.canUpdateDeviation" color="green"readonly label="Aktualizowanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canReadDeviation" :v-model="controlReportPerms?.canReadDeviation" color="green"readonly label="Oglądanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>ECR</p>
                                            <v-switch :model-value="controlReportPerms?.canCreateEcr" :v-model="controlReportPerms?.canCreateEcr" color="green"readonly label="Tworzenie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canDeleteEcr" :v-model="controlReportPerms?.canDeleteEcr" color="green"readonly label="Usuwanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canUpdateEcr" :v-model="controlReportPerms?.canUpdateEcr" color="green"readonly label="Aktualizowanie"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canReadEcr" :v-model="controlReportPerms?.canReadEcr" color="green"readonly label="Oglądanie"></v-switch>
                                        </v-col>
                                        <v-col>
                                            <p>Inne</p>
                                            <v-switch :model-value="controlReportPerms?.canBeEdited" :v-model="controlReportPerms?.canBeEdited" color="green"readonly label="Rola jest modyfikowalna"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.hasAllPrivelage" :v-model="controlReportPerms?.hasAllPrivelage" color="green"readonly label="Master key"></v-switch>
                                            <v-switch :model-value="controlReportPerms?.canUseApp" :v-model="controlReportPerms?.canUseApp" color="green"readonly label="Dostęp do aplikacji"></v-switch>
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