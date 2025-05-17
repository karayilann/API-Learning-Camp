namespace APIProjeKampi.WebApi.Dtos.YummyEventDto
{
    public class CreateEventDto
    {
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

    }
}
