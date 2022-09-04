namespace Market.Models
{
  public class FlavorSweet
  {       
    public int FlavorSweetId { get; set; }
    public int SweetId { get; set; }
    public int FlavorId { get; set; }
    public virtual Sweet Sweet { get; set; }
    public virtual Flavor Flavor { get; set; }
  }
}