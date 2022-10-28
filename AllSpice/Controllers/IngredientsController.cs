namespace AllSpice.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]

public class IngredientsController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;

  private readonly IngredientsService _is;

  public IngredientsController(Auth0Provider auth0provider, IngredientsService @is)
  {
    _auth0provider = auth0provider;
    _is = @is;
  }



  [HttpPost]
  public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient newIngredient)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newIngredient.CreatorId = userInfo.Id;
      Ingredient createdIngredient = _is.CreateIngredient(newIngredient);
      createdIngredient.Creator = userInfo;
      return Ok(createdIngredient);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{ingredientId}")]

  public async Task<ActionResult<String>> RemoveIngredient(int ingredientId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _is.RemoveIngredient(ingredientId, userInfo.Id);
      return Ok("Recipe successfully removed");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



}