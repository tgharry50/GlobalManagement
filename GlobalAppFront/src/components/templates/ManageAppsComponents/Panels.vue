<template>
    <v-item-group>
        <v-row>
            <v-col
            v-for="n in 4"
            :key="n"
            cols="12"
            md="4"
            >
                <v-btn width="200" height="200" color="#663366">
                    test
                </v-btn>
            </v-col>
        </v-row>
    </v-item-group>
</template>