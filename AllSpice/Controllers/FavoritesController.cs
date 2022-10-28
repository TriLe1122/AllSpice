namespace AllSpice.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class FavoritesController : ControllerBase
{


  private readonly Auth0Provider _auth0provider;

  private readonly FavoritesService _fs;

  public FavoritesController(Auth0Provider auth0provider, FavoritesService fs)
  {
    _auth0provider = auth0provider;
    _fs = fs;
  }

  [HttpPost]
  public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite newFavorite)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newFavorite.AccountId = userInfo.Id;
      Favorite createdFavorite = _fs.CreateFavorite(newFavorite);
      return Ok(createdFavorite);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  
}