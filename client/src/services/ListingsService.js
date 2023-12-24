import { AppState } from "../AppState.js"
import { Listing } from "../models/Listing.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ListingsService {
    async getListings() {
        const res = await api.get('api/listings')
        logger.log('getting listings', res.data)
        AppState.listings = res.data.map(pojo => new Listing(pojo))
    }
    async createListing(listingData) {
        const res = await api.post('api/listings', listingData)
        logger.log('posting a listing', res.data)
        const newListing = new Listing(res.data)
        AppState.listings.push(newListing)
        return newListing
    }
}
export const listingsService = new ListingsService()