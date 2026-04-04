namespace Coffeeg.Entities
{
    public class BeverageType
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
