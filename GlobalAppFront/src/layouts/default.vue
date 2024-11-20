<template>
  <v-app>
    <Header />
    <v-main>
      <SidePanel />
      <router-view />
    </v-main>
    <Footer />
  </v-app>
</template>

<script lang="ts" setup>
  import Footer from '@/components/PageLayout/AppFooter.vue'
  import Header from '@/components/PageLayout/AppHeader.vue'
  import SidePanel from '@/components/PageLayout/AppSidePanel.vue'
</script>
