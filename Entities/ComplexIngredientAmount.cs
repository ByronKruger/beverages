namespace Coffeeg.Entities
{
    public class ComplexIngredientAmount
    {
        public int Id { get; set; }
        public int BeverageCustomisationId { get; set; }
        public int ComplexIngredientId { get; set; }
        public decimal Amount { get; set; }
    }
}
