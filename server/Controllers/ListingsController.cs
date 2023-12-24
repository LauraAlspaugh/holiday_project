using Microsoft.AspNetCore.Http.HttpResults;

namespace holiday_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingsController : ControllerBase
{
    private readonly ListingsService _listingsService;
    private readonly Auth0Provider _auth0Provider;

    public ListingsController(Auth0Provider auth0Provider, ListingsService listingsService)
    {
        _auth0Provider = auth0Provider;
        _listingsService = listingsService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Listing>> CreateListing([FromBody] Listing listingData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            listingData.CreatorId = userInfo.Id;
            Listing listing = _listingsService.CreateListing(listingData);
            return Ok(listing);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet]
    public ActionResult<List<Listing>> GetAllListings()
    {
        try
        {
            List<Listing> listings = _listingsService.GetAllListings();
            return Ok(listings);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}
