using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public EventoController()
        {
        }

        private IEnumerable<Evento> _evento = new Evento[] {
              new Evento() {
              EventoId = 1,
              Tema = ".Net 5",
              Local = "Em casa",
              Lote = "Primeiro Lote",
              QuantidadePessoas = 250,
              DataEvento = DateTime.Now.AddDays(2).ToString(),
              ImagemURL = "foto.png",
           },
           new Evento() {
              EventoId = 2,
              Tema = ".Net 5",
              Local = "Em casa",
              Lote = "Primeiro Lote",
              QuantidadePessoas = 250,
              DataEvento = DateTime.Now.AddDays(2).ToString(),
              ImagemURL = "foto.png",
           },
         };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento; 
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id); 
        }

        [HttpPost]
        public string Post()
        {
            return "Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Delete com id = {id}";
        }
    }
}
