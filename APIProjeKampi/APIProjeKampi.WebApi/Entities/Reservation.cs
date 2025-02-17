namespace APIProjeKampi.WebApi.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationTime { get; set; }
        public int PeopleCount { get; set; }
        public string Message { get; set; }
        public string ReservationStatus { get; set; }


    }
}
