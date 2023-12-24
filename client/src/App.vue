<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="">
    <p class="m-5"><i class="mdi mdi-copyright"></i> 2023 by Laura Alspaugh.</p>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

body {
  background-image: url("https://images.unsplash.com/photo-1512668033346-09cfb0d8597b?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8d2FsbCUyMHBhcGVyJTIwY2hyaXN0bWFzJTIwYWVzdGV0aWN8ZW58MHx8MHx8fDA%3D");

  background-size: cover;
  background-attachment: fixed;
  color: black;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
  background-color: #996600;
  color: black;
}
</style>
