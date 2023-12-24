<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
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
  // background-image: url("https://i.pinimg.com/474x/40/a6/a6/40a6a650136c0d5e86b49b27095895a3.jpg");
  background-color: white;
  background-size: cover;
  background-attachment: fixed;
  color: black;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
