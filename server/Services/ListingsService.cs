
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
}
