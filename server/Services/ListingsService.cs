


namespace holiday_project.Services;
public class ListingsService
{
    private readonly ListingsRepository _listingsRepository;
    private readonly Auth0Provider _auth0Provider;

    public ListingsService(Auth0Provider auth0Provider, ListingsRepository listingsRepository)
    {
        _auth0Provider = auth0Provider;
        _listingsRepository = listingsRepository;
    }

    internal Listing CreateListing(Listing listingData)
    {
        Listing listing = _listingsRepository.CreateListing(listingData);
        return listing;
    }

    internal Listing EditListing(int listingId, Listing listingData, string userId)
    {
        Listing listing = GetListingById(listingId);
        if (listing.CreatorId != userId)
        {
            throw new Exception("this is not your listing to edit!");
        }
        listing.Name = listingData.Name ?? listing.Name;
        listing.Description = listingData.Description ?? listing.Description;
        listing.Img = listingData.Img ?? listing.Img;
        _listingsRepository.EditListing(listing);
        return listing;
    }

    internal List<Listing> GetAllListings()
    {
        List<Listing> listings = _listingsRepository.GetAllListings();
        return listings;
    }

    internal Listing GetListingById(int listingId)
    {
        Listing listing = _listingsRepository.GetListingById(listingId);
        if (listing == null)
        {
            throw new Exception("Not a valid listing id!");
        }
        return listing;
    }
}
