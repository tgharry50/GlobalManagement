<template>
  <v-layout>
    <v-container fill-height fluid>
      <v-row >
        <v-col align="center">
          <v-card width="50%" class="elevation-5">
            <v-card-title>
            </v-card-title>
            <v-card-text>
              <v-form v-model="isValid">
                <v-row>
                  <v-col>
                    <v-text-field 
                    v-model="login"
                    label="Login"
                    maxlength="32"
                    counter
                    :rules="[
                        v => /^[a-zA-Z]*$/.test(v) || 'Login nie może zawierać liczb ani znaków specjalnych'
                    ]"
                    ></v-text-field>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col>
                    <v-text-field 
                    v-model="password"
                    label="Hasło"
                    maxlength="256"
                    counter
                    type="password"
                    :rules="[
                      v => v.length !== 0 || 'Hasło jest błędne'
                    ]"
                    ></v-text-field>
                  </v-col>
                </v-row>
                <v-row class="justify-center mb-1">
                  <v-btn
                  :prepend-icon="'mdi-login'"
                  color="green"
                  :disabled="!isValid" @click="Login"
                  >Zaloguj się</v-btn>
                </v-row>
              </v-form>
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
    <Snackbar :color="colorSnackbar" :message="'Test'" :show="showSnackbar" @update:show="showSnackbar = $event" />
  </v-layout>
</template>
<script setup lang="ts">
  import { UserData } from '@/typescript_types/globals'
  import axios, { AxiosResponse } from 'axios'
  import { useAppStore } from '@/stores/app'
  const store = useAppStore()
  const login = ref('')
  const password = ref('')
  const isValid = ref(false)
  const showSnackbar = ref(false) // Use for snackbar display
  const colorSnackbar = ref('white') // Use for background color of snackbar
  async function Login (): Promise<boolean> {
    const form = new FormData()
    form.append('Login', login.value)
    form.append('Password', password.value)
    try {
      const response: AxiosResponse<UserData> = await axios.post(``, form)
      showSnackbar.value = true
      return await store.SetUserData(response.data)
    } catch (error) {
      showSnackbar.value = true
      throw error
    }
  }
</script>
