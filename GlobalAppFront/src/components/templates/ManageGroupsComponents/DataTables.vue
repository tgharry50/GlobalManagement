<script setup lang="ts">
  import mgag from './ManageGroupsAddGroup.vue' // Add group
  import mgam from './ManageGroupsAddMember.vue'; // Add member
  import mggm from './ManageGroupsGroupMenu.vue'; // Menu
  import { onMounted } from 'vue';
  import { API_BASE_URL } from '@/globals/globals';
  import { Group, GroupMember } from '@/types/Groups';
  import axios from 'axios';
  //
  let isVisible = ref(false);
  // As written
  let items = ref<Group[]>([]);
  const fetchAll = async () => {
    try{
      const result = await axios.get<Group[]>(`${API_BASE_URL}/group/all`)
      if(result){
        items.value = result.data
        isVisible.value = true;
      } else{
        isVisible.value = false;
      }
    } catch(Error){
      const err = Error as { status?: number };
      if(err.status === 404){
        isVisible.value = true;
      } else{
        console.error(err)
        isVisible.value = false;
      }
    }
  };
  // fetchAllMembersOfGroup
  let isVisibleMembers = ref(false);
  let members = ref<GroupMember[]>([]);
  const fetchAllMembersOfGroup = async (address: string) => {
    members.value = []
    try{
      const result = await axios.get<GroupMember[]>(`${API_BASE_URL}/group/members/get/${address}`)
      if(result){
        members.value = result.data
        isVisibleMembers.value = true;
      } else{
        members.value = []
        isVisibleMembers.value = true;
      }
    } catch(Error){
      const err = Error as { status?: number };
      if(err.status === 404){
        members.value = []
        isVisibleMembers.value = true;
      } else{
        isVisibleMembers.value = false;
        console.error(err)
      }
    }
  }
  // Default object
  let selected = ref<Group>(
    {
      uuid: 'none',
      name: 'Wybierz Grupę',
      description: 'Wybierz kategorie grupy, a następnie grupe by wczytać jej informacje',
      hala: '',
      isActive: false,
      section: '',
      type: 'Przykład'
    }
  );  
  // Reset let reset_selected = ref<Group>({ ...selected.value })
  // On mounted
  onMounted(async () => {
    await fetchAll();
  })
  const filter = ref('default') // filter
  const filteredItems = computed(() => { // filter method
    if(filter.value === 'default'){
      console.log('default')
      return items.value
    } else if(filter.value === 'role'){
      console.log('role')
      return items.value.filter(x => x.type === 'role')
    } else if(filter.value === 'section'){
      console.log('section')
      return items.value.filter(x => x.type === 'section')
    } else if(filter.value === 'other'){
      console.log('other')
      return items.value.filter(x => x.type === 'other')
    } else{
      return items.value
    }
  })
  function changeGroup(item: Group){
    selected.value = item
    fetchAllMembersOfGroup(selected.value.uuid)
  }
</script>
<template>
  <v-row v-if="isVisible">
    <!--LEFT-->
    <v-col cols="3">
      <v-card>
        <v-card-title>
          <span class="headline">Grupy</span>
        </v-card-title>
        <v-divider />
        <v-card-text>
          <mgag @create="fetchAll"/> <!--DODAJ GRUPĘ-->
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
                    @click="filter = 'default'"
                  >
                    Wszystkie grupy
                  </v-btn>
                </template>

                <v-list style="max-height: 200px; overflow-y: auto;">
                  <v-list-item class="border-b hoverable"
                    v-for="(item, index) in filteredItems"
                    :key="index"
                  >
                    <v-list-item-title style="cursor: pointer;" @click="changeGroup(item)">{{ item.name }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </v-list-item>
            <!-- Section -->
            <v-list-item>
              <v-menu location="bottom">
                <template #activator="{ props }">
                  <v-btn
                    color="red"
                    dark
                    width="100%"
                    v-bind="props"
                    @click="filter = 'section'"
                  >
                    Grupy Sekcyjne
                  </v-btn>
                </template>

                <v-list style="max-height: 200px; overflow-y: auto;">
                  <v-list-item class="border-b hoverable"
                    v-for="(item, index) in filteredItems"
                    :key="index"
                  >
                    <v-list-item-title style="cursor: pointer;" @click="changeGroup(item)">{{ item.name }}</v-list-item-title>
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
                    @click="filter = 'role'"
                  >
                    Grupy Rolowe
                  </v-btn>
                </template>

                <v-list style="max-height: 200px; overflow-y: auto;">
                  <v-list-item class="border-b hoverable"
                    v-for="(item, index) in filteredItems"
                    :key="index"
                  >
                  <v-list-item-title style="cursor: pointer;" @click="changeGroup(item)">{{ item.name }}</v-list-item-title>
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
                    @click="filter = 'other'"
                  >
                    Inne
                  </v-btn>
                </template>

                <v-list style="max-height: 200px; overflow-y: auto;">
                  <v-list-item class="border-b hoverable"
                    v-for="(item, index) in filteredItems"
                    :key="index"
                  >
                    <v-list-item-title style="cursor: pointer;" @click="changeGroup(item)">{{ item.name }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </v-list-item>
          </v-list>
        </v-card-text>
      </v-card>
    </v-col>
    <!--RIGHT-->
    <v-col cols="9">
      <v-card>
        <v-card-title>
          <span class="headline"> </span>
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-col>
              <h1>Grupa: {{ selected.name }}</h1>
            </v-col>
            <!--Group Options-->
            <v-col class="text-right">
              <mggm></mggm>
            </v-col>
          </v-row>
          <v-divider></v-divider>
          <v-row class="mt-1">
            <v-col>
              <p>{{ selected.description }}</p>
            </v-col>
          </v-row>
          <v-row>
            <v-col v-if="selected.uuid !== 'none'">
              <h3>Hala: {{ selected.hala }}</h3>
              <h3>Sekcja: {{ selected.section }}</h3>
            </v-col>
          </v-row>
          <v-row class="mb-1" v-if="selected.uuid !== 'none'">
            <v-col class="text-center">
              <div v-if="selected.isActive">
                <span style="color: green; font-weight: bold;">Aktywna</span>
              </div>
              <div v-else>
                <span style="color: red; font-weight: bold;">Nie aktywna</span>
              </div>
            </v-col>
          </v-row>
          <v-divider></v-divider>
          <v-row v-if="selected.uuid !== 'none'">
            <v-col>
              <v-data-table v-if="isVisibleMembers === true"
                class="elevation-1"
                density="comfortable"
                :items="members"
                :headers="[
                  {title: 'Status', key: 'role', width: '5%'},
                  {title: 'Imię i Nazwisko', key: 'username', align: 'center'},
                  {title: 'Funkcje', key: 'actions', align: 'center', sortable: false, width: '25%'}
                ]"
                :items-per-page="10"
                :items-per-page-options="[5, 10, 15, 20]"
              >
              <template #top>
                <v-toolbar flat>
                  <v-toolbar-title>Członkowie</v-toolbar-title>
                  <v-spacer></v-spacer>
                  <mgam :groupuuid="selected.uuid" @add="fetchAllMembersOfGroup(selected.uuid)"></mgam> <!--Przycisk-->
                </v-toolbar>
              </template>
              </v-data-table>
              <p v-else>Brak połączenia</p>
            </v-col>
          </v-row>
        </v-card-text>
      </v-card>
    </v-col>
  </v-row>
  <!--ERROR CASE-->
  <v-row v-else>
    <v-col>
      <v-card>
        <v-card-title>
          <span class="headline">Problem</span>
        </v-card-title>
        <v-divider></v-divider>
        <v-card-text>
          <p>Brak połączenia z serwerem, odśwież karte, zgłoś problem do IT bądź spróbuj ponownie później.</p>
        </v-card-text>
      </v-card>
    </v-col>
  </v-row>
</template>
<style scoped>
.hoverable:hover{
  background-color: rgb(226, 226, 226);
}
</style>