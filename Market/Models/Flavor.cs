using System.Collections.Generic;

namespace Market.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.JoinEntities = new HashSet<FlavorSweet>();
    }

    public int FlavorId { get; set; }
    public string Details { get; set; }
    public string Name { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<FlavorSweet> JoinEntities { get; set; }
  }
}