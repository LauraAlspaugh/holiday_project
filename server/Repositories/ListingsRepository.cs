

namespace holiday_project.Repositories;
public class ListingsRepository
{
    private readonly IDbConnection _db;

    public ListingsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Listing CreateListing(Listing listingData)
    {
        string sql = @"
    INSERT INTO
    listings(name, description, img, price, category, creatorId)
    VALUES(@Name, @Description, @Img, @Price, @Category, @CreatorId);
    SELECT
    lis.*,
    acc.*
    FROM listings lis
    JOIN accounts acc ON lis.creatorId = acc.id
    WHERE lis.id = LAST_INSERT_ID();
    ";
        Listing listing = _db.Query<Listing, Account, Listing>(sql, (listing, account) =>
         {
             listing.Creator = account;
             return listing;
         }, listingData).FirstOrDefault();
        return listing;
    }

    internal List<Listing> GetAllListings()
    {
        string sql = @"
    SELECT
    lis.*,
    acc.*
    FROM listings lis
    JOIN accounts acc ON lis.creatorId = acc.id
    ;";
        List<Listing> listings = _db.Query<Listing, Account, Listing>(sql, (listing, account) =>
        {
            listing.Creator = account;
            return listing;
        }).ToList();
        return listings;
    }
}