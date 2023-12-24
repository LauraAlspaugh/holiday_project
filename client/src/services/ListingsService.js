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
}
export const listingsService = new ListingsService()