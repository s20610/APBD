﻿using System;

namespace Cwiczenie7.DTO.Request
{
    public class ClientRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Pesel { get; set; }
        public int IdTrip { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
