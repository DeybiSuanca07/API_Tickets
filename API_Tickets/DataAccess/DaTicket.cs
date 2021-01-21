using API_Tickets.Context;
using API_Tickets.Interfaces;
using API_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tickets.DataAccess
{
    public class DaTicket : I_Ticket
    {
        private readonly I_DBManager Manager;
        public DaTicket(I_DBManager dBManager)
        {
            this.Manager = dBManager;
        }

        public bool CreateTicket(Ticket ticket)
        {
            try
            {
                using (var db = new TicketsContext(Manager))
                {
                    Ticket modelTicket = new Ticket();
                    modelTicket.Usuario = ticket.Usuario;
                    modelTicket.FechaCreacion = DateTime.Now;
                    modelTicket.FechaActualizacion = DateTime.Now;
                    modelTicket.Status = "Abierto";
                    db.Tickets.Add(modelTicket);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteTicket(int Id)
        {
            try
            {
                using (var db = new TicketsContext(Manager))
                {
                    var ticket = db.Tickets.Where(i => i.IdTicket == Id).FirstOrDefault();
                    db.Tickets.Remove(ticket);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditTicket(Ticket ticket)
        {
            try
            {
                using (var db = new TicketsContext(Manager))
                {
                    var ticketObj = db.Tickets.Where(i => i.IdTicket == ticket.IdTicket).FirstOrDefault();
                    if (ticketObj != null)
                    {
                        ticketObj.Usuario = ticket.Usuario;
                        ticketObj.FechaActualizacion = DateTime.Now;
                        ticketObj.Status = ticket.Status;
                        db.Tickets.Update(ticketObj);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Ticket> RetrieveTicket(Ticket ticket)
        {
            try
            {
                using (var db = new TicketsContext(Manager))
                {
                    List<Ticket> listTicketResponse = new List<Ticket>();
                    if (ticket.IdTicket != 0)
                    {
                        listTicketResponse = db.Tickets.Where(i => i.IdTicket == ticket.IdTicket).ToList();
                    }
                    else
                    {
                        listTicketResponse = db.Tickets.ToList();
                    }
                    return listTicketResponse;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
