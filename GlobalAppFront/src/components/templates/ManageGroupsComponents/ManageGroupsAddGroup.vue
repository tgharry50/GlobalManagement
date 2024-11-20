<script setup lang="ts">
  import { defineEmits, ref } from 'vue'
  import Snackbar from '@/components/multiuse/Snackbar.vue'
  import axios from 'axios'
  import { Group_Add } from '@/types/Groups'
  //
  const emits = defineEmits(['create', 'dialog-closed'])
  const dialog = ref(false) // Define the dialog property
  const isValid = ref(false) // Use for checking if form is Valid
  const showSnackbar = ref(false) // Use for snackbar display
  const colorSnackbar = ref('white') // Use for background color of snackbar
  const selectedGroup = ref('');
  // Function
  const saveItem = () => { // Function to save the item
    showSnackbar.value = true
    closeDialog()
    emits('create', true)
  }
  //
  const item = ref<Group_Add>({
    Name: '',
    Description: '',
    Hala: '',
    Section: '',
  })
  const reset_item = ref<Group_Add>({ ...item.value })
  //
  const closeDialog = () => { // Function to close the dialog
    dialog.value = false
    emits('dialog-closed', true)
  }
  const e1 = ref(1)
  const finishStepper = () => {
    console.log('Stepper finished')
  }
</script>
<template>
  <v-dialog v-model="dialog" max-width="600px">
    <template #activator="{isActive, props}">
      <v-btn v-bind="props" color="primary" variant="text" @click="isActive">
        <v-icon icon="mdi-plus" left />
        Dodaj grupę
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">Dodaj grupę</span>
      </v-card-title>
      <v-card-text>
        <v-stepper v-model="e1" :items="['Kategoria grupy', 'Dane grupy']" hide-actions>
          <template #item.1>
            <v-row>
              <v-col>
                <v-radio-group inline v-model="selectedGroup">
                    <v-radio value="other" true-icon="" false-icon="">
                      <template v-slot:label>
                        <v-card width="100" :class="{'ss' : selectedGroup === 'other'}" height="100" color="yellow">
                          <v-card-text class="text-center">
                            Inne
                          </v-card-text>
                        </v-card>
                      </template>
                    </v-radio>
                    <v-radio value="role" true-icon="" false-icon="">
                      <template v-slot:label>
                        <v-card width="100" :class="{'ss' : selectedGroup === 'role'}" height="100" color="#9521b0">
                          <v-card-text class="text-center">
                            Rolowe
                          </v-card-text>
                        </v-card>
                      </template>
                    </v-radio>
                    <v-radio value="section" true-icon="" false-icon="">
                      <template v-slot:label >
                        <v-card width="100" :class="{'ss' : selectedGroup === 'section'}" height="100" color="blue">
                          <v-card-text class="text-center">
                            Sekcyjne
                          </v-card-text>
                        </v-card>
                      </template>
                    </v-radio>
                </v-radio-group>
              </v-col>
            </v-row>
          </template>
          <template #item.2>
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
                  :items="[]"
                  :rules="[v => !!v]"
                  required
                  />
                </v-col>
                <v-col>
                  <v-autocomplete
                  label="Sekcja"
                  v-model="item.Section"
                  :items="[]"
                  required
                  :rules="[v => !!v]"
                  />
                </v-col>
              </v-row>
              <v-row>
                <v-col class="text-center">
                  <v-btn :disabled="!isValid" color="green">
                    Utwórz
                  </v-btn>
                </v-col>
              </v-row>
            </v-form>
          </template>
          <v-stepper-actions :disabled="selectedGroup.length === 0"
            @click:next="(e1 === 1) ? e1+=1 : e1" @click:prev="(e1 === 2) ? e1-=1 : e1" v-bind:v-slot:prev="false"
          />
        </v-stepper>
      </v-card-text>
    </v-card>
  </v-dialog>
  <Snackbar :color="colorSnackbar" :message="'Test'" :show="showSnackbar" @update:show="showSnackbar = $event" />
</template>
<style scoped>
.ss{
  border: 3px green solid;
}
</style>