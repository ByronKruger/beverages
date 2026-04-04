namespace Coffeeg.Entities
{
    public class BeverageCustomisation
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int BeverageTypeId { get; set; }
        public BeverageType BeverageType { get; set; }

        public ICollection<IngredientAmount> IngredientAmounts { get; set; } = new List<IngredientAmount>();
        public ICollection<ComplexIngredientAmount> ComplexIngredientAmounts { get; set; } = new List<ComplexIngredientAmount>();
    }
}
