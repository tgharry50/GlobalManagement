<script setup lang="ts">
</script>
<template>
    <v-container>
        <v-expansion-panels>
            <v-expansion-panel>
                <v-expansion-panel-title>
                    Title
                </v-expansion-panel-title>
                <v-expansion-panel-text>
                    <v-row>
                        <v-col>
                        </v-col>
                        <v-col class="text-end">
                            <v-btn>Dodaj</v-btn>
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col>
                            <v-expansion-panels>
                                <v-expansion-panel>
                                    <v-expansion-panel-title>
                                        Title 2
                                    </v-expansion-panel-title>
                                    <v-expansion-panel-text>
                                        <v-row>
                                            <v-col>
                                                Opcje
                                            </v-col>
                                            <v-col class="text-end">
                                                <v-btn>Menu</v-btn>
                                            </v-col>
                                        </v-row>
                                        <v-row>
                                            <v-col>
                                                Dane
                                            </v-col>
                                        </v-row>
                                    </v-expansion-panel-text>
                                </v-expansion-panel>
                            </v-expansion-panels>
                        </v-col>
                    </v-row>
                </v-expansion-panel-text>
            </v-expansion-panel>
        </v-expansion-panels>
    </v-container>
</template>