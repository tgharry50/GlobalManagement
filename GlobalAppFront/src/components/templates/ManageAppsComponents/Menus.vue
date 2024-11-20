<template>
        <div class="text-end">
            <v-menu location="start">
                <template v-slot:activator="{props}">
                    <v-btn
                    icon="mdi mdi-cog"
                    color="yellow"
                    v-bind="props"
                    ></v-btn>
                </template>
                <v-list>
                    <v-list-item>
                        <v-list-item-title>
                            Item
                        </v-list-item-title>
                    </v-list-item>
                </v-list>
            </v-menu>
        </div>
</template>