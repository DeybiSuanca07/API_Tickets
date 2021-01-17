using System;
using System.Collections.Generic;

#nullable disable

namespace API_Tickets.Models
{
    public partial class Ticket
    {
        public string Usuario { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Status { get; set; }
        public int IdTicket { get; set; }
    }
}
