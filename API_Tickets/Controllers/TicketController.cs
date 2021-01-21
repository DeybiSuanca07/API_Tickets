using API_Tickets.Context;
using API_Tickets.Interfaces;
using API_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tickets.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class TicketController : Controller
    {
        private Response response;
        public I_DBManager Manager { get; set; }
        private readonly I_Ticket _ticket;
        public TicketController(I_DBManager dBManager, I_Ticket ticket)
        {
            this.response = new Response();
            this.Manager = dBManager;
            this._ticket = ticket;
        }

        [HttpPost]
        public ActionResult<Response> CreateTicket(Ticket ticket)
        {
            try
            {
                if (_ticket.CreateTicket(ticket))
                {
                    using (var db = new TicketsContext(Manager))
                    {
                        int Id = Convert.ToInt32(db.Tickets.OrderByDescending(i => i.IdTicket).First().IdTicket);
                        response.Message = $"El ticket ha sido creado correctamente, el id del ticket es: {Id}";
                        response.Status = true;
                        response.Object = null;
                    }
                }
                else
                {
                    response.Message = "El ticket no ha sido creado";
                    response.Status = false;
                    response.Object = null;
                }
            }
            catch (Exception ex)
            {
                response.Message = $"Ocurrio un error {ex.Message}";
                response.Status = false;
                response.Object = null;
            }
            return response;
        }

        [HttpDelete]
        public ActionResult<Response> DeleteTicket(Ticket ticket)
        {
            try
            {
                if (_ticket.DeleteTicket(ticket.IdTicket))
                {
                    response.Message = "El ticket ha sido eliminado correctamente";
                    response.Status = true;
                    response.Object = null;
                }
                else
                {
                    response.Message = "El ticket no ha sido eliminado";
                    response.Status = false;
                    response.Object = null;
                }
            }
            catch (Exception ex)
            {
                response.Message = $"Ocurrio un error {ex.Message}";
                response.Status = false;
                response.Object = null;
            }
            return response;
        }

        [HttpPut]
        public ActionResult<Response> EditTicket(Ticket ticket)
        {
            try
            {
                if (_ticket.EditTicket(ticket))
                {
                    response.Message = "El ticket ha sido actualizado correctamente";
                    response.Status = true;
                    response.Object = null;
                }
                else
                {
                    response.Message = "El ticket no ha sido actualizado";
                    response.Status = false;
                    response.Object = null;
                }
            }
            catch (Exception ex)
            {
                response.Message = $"Ocurrio un error {ex.Message}";
                response.Status = false;
                response.Object = null;
            }
            return response;
        }

        [HttpGet]
        public ActionResult<Response> RetrieveTicket(Ticket ticket)
        {
            try
            {
                var objResponse = _ticket.RetrieveTicket(ticket);
                if (objResponse.Count != 0)
                {
                    response.Message = "Tickets creados";
                    response.Status = true;
                    response.Object = objResponse;
                }
                else
                {
                    response.Message = "No se encontraron tickets relacionados";
                    response.Status = true;
                    response.Object = null;
                }
            }
            catch (Exception ex)
            {
                response.Message = $"Ocurrio un error {ex.Message}";
                response.Status = false;
                response.Object = null;
            }
            return response;
        }
    }
}
