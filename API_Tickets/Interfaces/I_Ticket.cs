using API_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tickets.Interfaces
{
    public interface I_Ticket
    {
        bool CreateTicket(Ticket ticket);
        bool DeleteTicket(int Id);
        bool EditTicket(Ticket ticket);
        List<Ticket> RetrieveTicket(Ticket ticket);
    }
}
