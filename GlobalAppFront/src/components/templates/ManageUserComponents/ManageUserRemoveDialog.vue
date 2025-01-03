<script setup lang="ts">
  import { defineEmits, defineProps, ref } from 'vue'
  import axios from 'axios'
  import Snackbar from '@/components/multiuse/Snackbar.vue'
  // Inject
  const base_url = inject<string>('url')
  //
  const emits = defineEmits(['delete', 'dialog-closed']) // Emits
  const props = defineProps<{
    uuid: string,
    fullname: string
  }>()
  const agreed = ref(false)
  const dialog = ref(false) // Define the dialog property
  const showSnackbar = ref(false) // Use for snackbar display
  const colorSnackbar = ref('white') // Use for background color of snackbar
  const message = ref('') // Message
  //
  // Function
  const deleteItem = async () => { // Function to save the item
    try{
      const result = await axios.post(`${base_url}/users/delete/${props.uuid}`)  
      if(result){
        message.value = 'Usunięto użytkownika'
        colorSnackbar.value = 'green'
        emits('delete', props.uuid)
        agreed.value = false
        showSnackbar.value = true
        closeDialog()
      }  else {
        colorSnackbar.value = 'yellow'
        message.value = 'Nie udało się usunąć użytkownika'
        emits('delete', props.uuid)
        showSnackbar.value = true
        closeDialog()
      }
    } catch(Error){
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się usunąć użytkownika'
      emits('delete', props.uuid)
      showSnackbar.value = true
      closeDialog()
    }
  }
  const closeDialog = () => { // Function to close the dialog
    dialog.value = false
    agreed.value = false
    emits('dialog-closed', true)
  }
</script>

<template>
  <v-dialog v-model="dialog" max-width="500px">
    <template #activator="{isActive, props}">
      <v-btn
        v-tooltip:bottom="'Usuń użytkownika'"
        v-bind="props"
        class="mt-1 mb-1 me-1 ms-1"
        color="yellow"
        size="30"
        @click="isActive"
      >
        <v-icon>mdi-delete</v-icon>
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">Usuń użytkownika</span>
      </v-card-title>
      <v-card-text>
        <p>Czy napewno chcesz usunąć użytkownika: {{ props.fullname }} ?</p>
        <v-checkbox v-model="agreed" label="Tak, chce usunąć użytkownika" />
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="gray" @click="closeDialog">Zamknij</v-btn>
        <v-btn color="red" :disabled="!agreed" @click="deleteItem">Usuń</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
  <Snackbar :color="colorSnackbar" :message="message" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>
