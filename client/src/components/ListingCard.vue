<template>
    <div class="listing-card mb-3">
        <img class="img-fluid" :src="listingProp.img" alt="img of listing">
        <p class="listing-name text-center mt-4">{{ listingProp.name }}</p>
        <p class="text-center listing-name">${{ listingProp.price }}</p>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Listing } from '../models/Listing.js';
export default {
    props: { listingProp: { type: Listing, required: true } },
    setup() {
        return {
            listings: computed(() => AppState.listings)
        }
    }
};
</script>


<style lang="scss" scoped>
.listing-card {
    width: 350px;
    border: 2px solid #996600;
    padding: 5px;
    border-radius: 7px;
    /* From https://css.glass */
    // background: #996600(187, 174, 174, 0.62);
    border-radius: 16px;
    box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
    backdrop-filter: blur(3.6px);
    -webkit-backdrop-filter: blur(3.6px);
    border: 1px solid #996600(30, 23, 23, 0.78);
}

img {
    border-radius: 7px;
    width: 350px;
    height: 18rem;
    object-fit: cover;
    position: center;
    ;
}

.listing-name {
    font-family: 'Pinyon Script', cursive;
    color: #996600;
    text-shadow: 2px 1px 2px rgb(87, 82, 82);
}
</style>