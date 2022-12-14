using AllSpice.Interfaces;

namespace AllSpice.Models;

public class Ingredient : ICreated, IRepoItem<int>
{
  public int Id { get; set; }
  public int RecipeId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string Quantity { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}