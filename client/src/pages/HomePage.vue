<template>
  <div class="container fashion-page">
    <section class="row">
      <div class="col-12">
        <h1 class="text-center p-3 fashion-name">Find Your Style. Showcase Confidence.</h1>
      </div>
    </section>
    <section class="row">
      <div v-for="listing in listings" :key="listing.id" class="col-4">
        <ListingCard :listingProp="listing" />
      </div>
    </section>

  </div>
</template>

<script>

import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { listingsService } from '../services/ListingsService.js';
import ListingCard from '../components/ListingCard.vue';

export default {
  setup() {
    onMounted(() => {
      getListings();
    });
    async function getListings() {
      try {
        await listingsService.getListings();
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    return {
      listings: computed(() => AppState.listings)
    };
  },
  components: { ListingCard }
}
</script>

<style scoped lang="scss">
.fashion-name {
  font-family: 'Pinyon Script', cursive;
  color: black;
}

.fashion-page {

  //   background-image: url("https://i.pinimg.com/474x/40/a6/a6/40a6a650136c0d5e86b49b27095895a3.jpg");
  //   background-size: cover;
  //   position: center;

  //   background-attachment: fixed;
}
</style>
