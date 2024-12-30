<script setup lang="ts">
  import { defineEmits, defineProps, ref } from 'vue'
  import axios from 'axios'
  import Snackbar from '@/components/multiuse/Snackbar.vue'
  // Inject
  const base_url = inject<string>('url')
  const emits = defineEmits(['status', 'dialog-closed']) // Emits
  const props = defineProps<{
    uuid: string,
    fullname: string,
    status: boolean
  }>()
  const agreed = ref(false)
  const dialog = ref(false) // Define the dialog property
  const showSnackbar = ref(false) // Use for snackbar display
  const colorSnackbar = ref('white') // Use for background color of snackbar
  const message = ref('') // Message
  // Function
  const desactive = async () => { // Function to save the item
    try{
      const result = await axios.put(`${base_url}/users/deactive/${props.uuid}`)  
      if(result){
        message.value = 'Zmieniono status użytkownika na nieaktywny'
        colorSnackbar.value = 'green'
        emits('status', props.uuid)
        agreed.value = false
        showSnackbar.value = true
        closeDialog()
      }  else {
        colorSnackbar.value = 'yellow'
        message.value = 'Nie udało się zmienić statusu'
        emits('status', props.uuid)
        showSnackbar.value = true
        closeDialog()
      }
    } catch(Error){
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się zmienić statusu'
      emits('status', props.uuid)
      showSnackbar.value = true
      closeDialog()
    }
  }

  const active = async () => { // Function to save the item
    try{
      const result = await axios.put(`${base_url}/users/active/${props.uuid}`)  
      if(result){
        message.value = 'Zmieniono status użytkownika na aktywny'
        colorSnackbar.value = 'green'
        emits('status', props.uuid)
        agreed.value = false
        showSnackbar.value = true
        closeDialog()
      }  else {
        colorSnackbar.value = 'yellow'
        message.value = 'Nie udało się zmienić statusu'
        emits('status', props.uuid)
        showSnackbar.value = true
        closeDialog()
      }
    } catch(Error){
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się zmienić statusu'
      emits('status', props.uuid)
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
      <!-- true -->
      <v-btn
        v-tooltip:bottom="'Zmień status konta'"
        v-bind="props"
        class="mt-1 mb-1 me-1 ms-1 two-toned-button"
        size="30"
        @click="isActive"
      >
        <v-icon>mdi mdi-check-circle-outline</v-icon>
      </v-btn>
      <!-- false -->
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">
          <span v-if="props.status" class="red-text">Dezaktywacja</span>
          <span v-else class="green-text" color="green">Aktywacja</span>
        </span>
      </v-card-title>
      <v-card-text>
        <span class="headline">Czy chcesz
          <span v-if="props.status" color="red">dezaktywować</span>
          <span v-else color="green">aktywować</span>
          użytkownika {{ props.fullname }}
        </span>
        <v-checkbox v-model="agreed" :label="`Tak, chce ${(props.status) ? 'dezaktyować' : 'aktywować'} użytkownika`" />
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="gray" @click="closeDialog">Zamknij</v-btn>
        <v-btn v-if="props.status" color="red" :disabled="!agreed" @click="desactive">Dezaktywuj</v-btn>
        <v-btn v-else color="green" :disabled="!agreed" @click="active">Aktywuj</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
  <Snackbar :color="colorSnackbar" :message="'Test'" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>
<style scoped>
.two-toned-button {
  background: linear-gradient(to right, red 50%, green 50%);
  color: white;
}
.red-text {
  color: red;
}

.green-text {
  color: green;
}
</style>
