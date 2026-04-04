namespace Coffeeg.Entities
{
    public class IngredientAmount
    {
        //public int Id { get; set; }
        public int BeverageCustomisationId { get; set; }
        public int IngredientId { get; set; }
        public decimal Amount { get; set; }
    }
}
