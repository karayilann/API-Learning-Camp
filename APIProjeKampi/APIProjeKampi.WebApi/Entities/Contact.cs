﻿namespace APIProjeKampi.WebApi.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }

    }
}
