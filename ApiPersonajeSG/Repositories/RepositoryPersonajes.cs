using ApiPersonajeSG.Data;
using ApiPersonajeSG.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajeSG.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            //List<Personaje> personajes = new List<Personaje>();
            return await this.context.Personajes.ToListAsync();

        }

        public async Task<Personaje> FindPersonajeAsync(int IdPersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == IdPersonaje);

        }

        public async Task InsertarPersonajeAsync(int IdPersonaje, string NombrePersonaje, string Imagen, int IdSerie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = IdPersonaje;
            personaje.NombrePersonaje = NombrePersonaje;
            personaje.Imagen = Imagen;
            personaje.IdSerie = IdSerie;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonaje(int IdPersonaje, string NombrePersonaje, string Imagen, int IdSerie)
        {
            Personaje personaje = await this.FindPersonajeAsync(IdPersonaje);
            personaje.NombrePersonaje = NombrePersonaje;
            personaje.Imagen = Imagen;
            personaje.IdSerie = IdSerie;

            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonaje(int IdPersonaje)
        {
            Personaje personaje = await this.FindPersonajeAsync(IdPersonaje);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();

        }


    }
}
