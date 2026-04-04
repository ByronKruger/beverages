namespace Coffeeg.Dtos
{
    public class UserBeverageCustomisationResult
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public BeverageTypeDto BeverageType { get; set; }
        public IEnumerable<IngredientAmountDto> IngredientAmounts { get; set; }
        public IEnumerable<ComplexIngredientAmountDto> ComplexIngredientAmounts { get; set; }
    }

    public class UserDto
    {
        public string Username { get; set; }
    }

    public class BeverageTypeDto
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
    }

    public class IngredientDto
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public bool? IsComplex { get; set; }
        public IEnumerable<ComplexIngredientDto> ComplexIngredients { get; set; }
    }

    public class ComplexIngredientDto
    {
        public int Id { get; set; }
        public string Descr { get; set; }
    }

    public class IngredientAmountDto
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public decimal Amount { get; set; }
    }

    public class ComplexIngredientAmountDto
    {
        public int Id { get; set; }
        public int ComplexIngredientId { get; set; }
        public decimal Amount { get; set; }
    }
}

