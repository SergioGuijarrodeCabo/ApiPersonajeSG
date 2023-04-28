﻿using ApiPersonajeSG.Models;
using ApiPersonajeSG.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajeSG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {

        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }


        [HttpPost]
        public async Task<ActionResult>
            InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertarPersonajeAsync
                (personaje.IdPersonaje, personaje.NombrePersonaje, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje
           (Personaje personaje)
        {
            await this.repo.UpdatePersonaje(personaje.IdPersonaje, personaje.NombrePersonaje, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonaje(id);
            return Ok();
        }


    }
}
