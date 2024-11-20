<script setup lang="ts">
  import mgag from './ManageGroupsAddGroup.vue'
</script>
<template>
  <v-row>
    <v-col cols="3">
      <v-card>
        <v-card-title>
          <span class="headline">Grupy</span>
        </v-card-title>
        <v-divider />
        <v-card-text>
          <mgag />
          <v-divider />
          <v-list>
            <!-- ALL -->
            <v-list-item>
              <v-menu location="bottom">
                <template #activator="{ props }">
                  <v-btn
                    color="grey"
                    dark
                    width="100%"
                    v-bind="props"
                  >
                    Wszystkie grupy
                  </v-btn>
                </template>

                <v-list>
                  <v-list-item
                    v-for="(item, index) in [{id: 1, title: 'banan'}]"
                    :key="index"
                  >
                    <v-list-item-title>{{ item.title }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </v-list-item>
            <!-- Section -->
            <v-list-item>
              <v-menu location="bottom">
                <template #activator="{ props }">
                  <v-btn
                    color="purple"
                    dark
                    width="100%"
                    v-bind="props"
                  >
                    Grupy rolowe
                  </v-btn>
                </template>

                <v-list>
                  <v-list-item
                    v-for="(item, index) in [{id: 1, title: 'banan'}]"
                    :key="index"
                  >
                    <v-list-item-title>{{ item.title }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </v-list-item>
            <!-- Role -->
            <v-list-item>
              <v-menu location="bottom">
                <template #activator="{ props }">
                  <v-btn
                    color="indigo"
                    dark
                    width="100%"
                    v-bind="props"
                  >
                    Grupy sekcyjne
                  </v-btn>
                </template>

                <v-list>
                  <v-list-item
                    v-for="(item, index) in [{id: 1, title: 'banan'}]"
                    :key="index"
                  >
                    <v-list-item-title>{{ item.title }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </v-list-item>
            <!-- Other -->
            <v-list-item>
              <v-menu location="bottom">
                <template #activator="{ props }">
                  <v-btn
                    color="yellow"
                    dark
                    width="100%"
                    v-bind="props"
                  >
                    Inne
                  </v-btn>
                </template>

                <v-list>
                  <v-list-item
                    v-for="(item, index) in [{id: 1, title: 'banan'}]"
                    :key="index"
                  >
                    <v-list-item-title>{{ item.title }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </v-list-item>
          </v-list>
        </v-card-text>
      </v-card>
    </v-col>
    <v-col cols="9">
      <v-card>
        <v-card-title>
          <span class="headline" />
        </v-card-title>
        <v-card-text>
          opis grupy
        </v-card-text>
      </v-card>
    </v-col>
  </v-row>
</template>
