namespace api.DTOs
{
    public class SampleDTO
    {
        public string Id { get; set; }
        public string CreatedAt { get; set; }

        //nullable boolean
        public bool? TestBool {get; set;}

        //non-nullable boolean
        public bool SecondTestBool {get;set;}
        public int FavouriteNumber { get; set; }
    }
}
