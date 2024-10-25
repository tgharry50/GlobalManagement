<template>
    <v-navigation-drawer permanent>
        <v-list class="text-h5 text-center">
            <!-- TOP OF PAGE -->
           <v-list-item>
                <p>
                    <!-- First name-->
                    <span v-if="store.loggedin">{{ store.user.firstname }} {{ store.user.lastname }}</span> 
                    <span v-else>Global App</span>
                </p>
           </v-list-item>
           <v-divider></v-divider>
           <v-list-item title="Strona główna" @click="router.push('/')">
            <template v-slot:prepend><v-icon icon="mdi-home"></v-icon></template>
           </v-list-item>
           <v-list-item title="Zarządzaj użytkownikami" @click="router.push('/manageusers')">
            <template v-slot:prepend><v-icon icon="mdi-human-capacity-increase"></v-icon></template>
           </v-list-item>
           <v-list-item title="Zarządzaj uprawnieniami" @click="router.push('/managepermissions')">
            <template v-slot:prepend><v-icon icon="mdi mdi-key-chain-variant"></v-icon></template>
           </v-list-item>
           <v-list-item title="Opcje" @click="router.push('/options')">
            <template v-slot:prepend><v-icon icon="mdi-cog-box"></v-icon></template>
           </v-list-item>
           <v-list-item title="Zaloguj się" @click="router.push('/login')">
            <template v-slot:prepend><v-icon icon="mdi-login"></v-icon></template>
           </v-list-item>
           <v-list-item title="Wyloguj się">
            <template v-slot:prepend><v-icon icon="mdi-logout"></v-icon></template>
           </v-list-item>
        </v-list>
    </v-navigation-drawer>
</template>
<script setup lang="ts">
import { Router, useRouter } from 'vue-router';
let router: Router = useRouter();
import { useAppStore } from '@/stores/app';
let store = useAppStore();
</script>