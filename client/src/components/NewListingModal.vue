<template>
    <div class="modal fade" id="createListingModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-color" id="exampleModalLabel">Create Listing</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body text-dark">
                    <form @submit.prevent="createListing()">
                        <div class="mb-3">
                            <label for="name" class="form-label">Name</label>
                            <input v-model="editable.name" type="text" required class="form-control" id="name"
                                placeholder="Name...">

                        </div>
                        <div class="mb-3">
                            <label for="imageUrl" class="form-label">Image</label>
                            <input v-model="editable.img" type="url" required class="form-control" id="imgUrl"
                                placeholder="Image Url...">
                        </div>
                        <div class="mb-3">
                            <label for="description" class="form-label">Description</label>
                            <textarea v-model="editable.description" rows="3" type="text-area" required class="form-control"
                                id="description" placeholder="Description..."></textarea>

                        </div>
                        <div class="mb-3">
                            <label for="price" class="form-label">Price</label>
                            <input v-model="editable.price" type="text-area" required class="form-control" id="price"
                                placeholder="Price...">

                        </div>

                        <div class="mb-3">
                            <label for="category" class="form-label">Category</label>
                            <select v-model="editable.category" type="text" required class="form-select" id="category"
                                placeholder="Category...">
                                <option :value="category" v-for="category in categories" :key="category">
                                    {{ category }}
                                </option>
                            </select>
                        </div>

                        <button type="submit" class="btn btn-outline-dark">Submit</button>
                    </form>

                </div>
                <div class="modal-footer">
                    <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button> -->
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { listingsService } from '../services/ListingsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { Modal } from 'bootstrap';
export default {
    setup() {
        const editable = ref({})
        const categories = ["Casual", "Formal", "Holiday", "Sport"]
        return {
            editable,
            categories,
            listings: computed(() => AppState.listings),
            async createListing() {
                try {
                    const listingData = editable.value
                    const listing = await listingsService.createListing(listingData)
                    Pop.success('You have posted a listing!')
                    editable.value = {}
                    Modal.getOrCreateInstance("#createListingModal").hide()
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped>
.modal-footer {
    background-color: #003300;
}

.modal-header {
    background-color: #003300;
}

.text-color {
    color: #996600;
}
</style>