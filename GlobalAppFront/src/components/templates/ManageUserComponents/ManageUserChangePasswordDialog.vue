<script setup lang="ts">
  import { defineEmits, defineProps, ref } from 'vue'
  import axios from 'axios'
  import Snackbar from '@/components/multiuse/Snackbar.vue'
  // Inject
  const base_url = inject<string>('url')
  const emits = defineEmits(['change', 'dialog-closed']) // Emits
  const props = defineProps<{
    uuid: string,
  }>()
  const dialog = ref(false) // Define the dialog property
  const showSnackbar = ref(false) // Use for snackbar display
  const colorSnackbar = ref('white') // Use for background color of snackbar
  const message = ref('') // Message

  //
  const change_value = ref<Number | null>()
  const change_value2 = ref<Number | null>()
  const isValid = ref(false)
  const agreed = ref(false)
  //
  const saveItem = async () => { // Function to save the item
    try{
      const result = await axios.post(`${base_url}/users/password/${props.uuid}`)  
      if(result){
        message.value = 'Zmieniono hasło użytkownika'
        colorSnackbar.value = 'green'
        emits('change', props.uuid)
        agreed.value = false
        showSnackbar.value = true
        closeDialog()
      }  else {
        colorSnackbar.value = 'yellow'
        message.value = 'Nie udało się zmienić hasła użytkownika'
        emits('change', props.uuid)
        showSnackbar.value = true
        closeDialog()
      }
    } catch(Error){
      colorSnackbar.value = 'red'
      message.value = 'Nie udało się zmienić hasła użytkownika'
      emits('change', props.uuid)
      showSnackbar.value = true
      closeDialog()
    }
  }

  const closeDialog = () => { // Function to close the dialog
    change_value.value = null
    change_value2.value = null
    dialog.value = false
    emits('dialog-closed', true)
  }
  const activeTab = ref('1') // active tab
</script>

<template>
  <v-dialog v-model="dialog" max-width="500px">
    <template #activator="{ isActive, props }">
      <v-btn
        v-tooltip:bottom="'Reset hasła'"
        v-bind="props"
        class="mt-1 mb-1 me-1 ms-1"
        size="30"
        @click="isActive"
      >
        <v-icon>mdi mdi-lock-reset</v-icon>
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">Reset hasła</span>
      </v-card-title>
      <v-card-text>
        <!-- TOP -->
        <v-tabs v-model="activeTab">
          <v-tab value="1">Zmiana hasła</v-tab>
          <v-tab value="2">Reset hasła</v-tab>
        </v-tabs>
        <v-tabs-window v-model="activeTab">
          <v-tabs-window-item value="1">
            <v-card flat>
              <v-card-text>
                <v-form v-model="isValid">
                  <v-text-field
                    v-model="change_value"
                    counter="256"
                    label="Wpisz nowe hasło"
                    maxlength="256"
                    required
                    :rules="[
                      v => !v || v.length >= 8 || 'Hasło musi mieć minimum 8 znaków'
                    ]"
                  />
                  <v-text-field
                    v-model="change_value2"
                    counter="256"
                    label="Wpisz ponownie nowe hasło"
                    maxlength="256"
                    required
                    :rules="[
                      v => change_value == change_value2 || 'Hasła nie są zgodnę'
                    ]"
                  />
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="green" :disabled="(!isValid) || !!change_value || !!change_value2" @click="saveItem">Zmień</v-btn>
              </v-card-actions>
            </v-card>
          </v-tabs-window-item>
          <v-tabs-window-item value="2">
            <v-card flat>
              <v-card-text>
                <p>Hasło zostanie ustawione na podstawowe</p>
                <v-divider />
                <v-checkbox v-model="agreed" label="Tak, chce zmienić hasło na podstawowe" />
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="green" :disabled="!isValid && !agreed" @click="saveItem">Zresetuj</v-btn>
              </v-card-actions>
            </v-card>
          </v-tabs-window-item>
        </v-tabs-window>
      </v-card-text>
      <v-card-actions>
        <v-spacer>
          <v-btn color="gray" @click="closeDialog">Zamknij</v-btn>
        </v-spacer>
      </v-card-actions>
    </v-card>
  </v-dialog>
  <Snackbar :color="colorSnackbar" :message="'Test'" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>
