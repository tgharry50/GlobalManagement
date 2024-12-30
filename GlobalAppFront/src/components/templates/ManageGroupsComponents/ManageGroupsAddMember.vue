<script setup lang="ts">
  import { defineEmits, ref } from 'vue'
  import Snackbar from '@/components/multiuse/Snackbar.vue'
  import { GroupMemberAdd, GroupMemberSelectRole } from '@/types/Groups';
  import { API_BASE_URL } from '@/globals/globals';
  import axios from 'axios'
import { User } from '@/types/User';
  //
  const emits = defineEmits(['add', 'dialog-closed'])
  const props = defineProps<{
    groupuuid: string,
  }>()
  //
  const dialog = ref(false) // Define the dialog property
  const isValid = ref(false) // Use for checking if form is Valid
  const showSnackbar = ref(false) // Use for snackbar display
  const colorSnackbar = ref('white') // Use for background color of snackbar
  const message = ref('');
  const item = ref<GroupMemberAdd>({ // Created User data
    groupuuid: '',
    userguid: '',
    roleguid: '',
  })
  const reset_item = ref<GroupMemberAdd>({ ...item.value })
  // Function 
  const saveItem = async () => { // Function to save the item
    const form = new FormData();
    form.append("GroupUUID", props.groupuuid)
    form.append("UserGuid", item.value.userguid)
    form.append("RoleGuid", item.value.roleguid)
    try{
        const result = await axios.post(`${API_BASE_URL}/group/members/add`, form);
        if(result){
            colorSnackbar.value = 'green'
            message.value = 'Dodano użytkownika do grupy'
            emits('add', item)
            showSnackbar.value = true
            closeDialog()
        } else {
            console.error(result)
            colorSnackbar.value = 'yellow'
            message.value = 'Nie udało się dodać grupy'
            emits('add', item)
            showSnackbar.value = true
            closeDialog()
        }
        item.value = { ...reset_item.value }
    } catch(Error){
      console.error() //result
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się dodać grupy'
      showSnackbar.value = true
      emits('add', item)
      closeDialog()
    }
  }
  const closeDialog = () => { // Function to close the dialog
    dialog.value = false
    item.value = { ...reset_item.value }
    emits('dialog-closed', true)
  }
  //
  // Users
  const users = ref<User[]>([]); const isLoaded = ref<boolean>(false); const isFatal = ref<boolean>(false);
  async function fetchUsers() {
    isFatal.value = false;
    isLoaded.value = false;
    const result = await axios.get<User[]>(`${API_BASE_URL}/users`);
    try{
        if(result){
            users.value = result.data;
            isLoaded.value = true;
        } else{
            console.error(result)
            isFatal.value = true;
        }
    } catch(Error){
        console.error(result)     
        isFatal.value = true;  
    }
  }  
  // Roles  
  const roles = ref<GroupMemberSelectRole[]>([]);
  async function fetchRoles(uuid: string) {
    const result = await axios.get<GroupMemberSelectRole[]>(`${API_BASE_URL}/group/roles/${uuid}`);
    try{
        if(result){
            roles.value = result.data
        } else{
            console.error(result)
            isFatal.value = true;
        }
    } catch(Error){
        console.error(result)     
        isFatal.value = true;  
    }
  }
  onMounted(async () => {
    await fetchUsers();
    await fetchRoles(props.groupuuid)
  })
</script>
<template>
  <v-dialog v-model="dialog" max-width="500px">
    <template #activator="{isActive, props}">
      <v-btn color="primary" v-bind="props" @click="isActive">
        <v-icon icon="mdi-plus" left />
        Dodaj członka grupy
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">Dodaj członka grupy</span>
      </v-card-title>
      <v-card-text v-if="isLoaded === true">
        <v-form v-model="isValid">
          <!--User-->
            <v-row>
            <v-col>
                <v-autocomplete v-model="item.userguid"
                :items="users"
                :item-title="'fullName'"
                :item-value="'uuid'"
                label="'Wybierz użytkownika który ma należeć do grupy'"
                density="comfortable"
                :rules="[v => v.length > 0 || 'Wybierz użytkownika']"
                >
                </v-autocomplete>
            </v-col>
          </v-row>
          <!--Role-->
          <v-row>
            <v-col>
                <v-autocomplete v-model="item.roleguid"
                :items="roles"
                :item-title="'roleName'"
                :item-value="'uuid'"
                :label="'Wybierz role użytkownika'"
                density="comfortable"
                :rules="[v => v.length > 0 || 'Wybierz role']"
                >
                </v-autocomplete>
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-text v-else-if="isLoaded === false && isFatal === false">
        <p>Wczytywanie</p>
      </v-card-text>
      <v-card-text v-else-if="isFatal === true">
        <p style="color: red;">Problem z połączeniem do bazy danych</p>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="gray" @click="closeDialog">Zamknij</v-btn>
        <v-btn color="green" :disabled="!isValid" @click="saveItem">Utwórz</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
  <Snackbar :color="colorSnackbar" :message="message" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>
