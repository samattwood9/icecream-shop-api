namespace api.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string FavouriteFlavour { get; set; }
        public decimal AmountSpent { get; set; }
    }
}