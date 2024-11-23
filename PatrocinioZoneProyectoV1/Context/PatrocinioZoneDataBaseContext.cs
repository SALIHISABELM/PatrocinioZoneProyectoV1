using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatrocinioZoneProyectoV1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatrocinioZoneProyectoV1.Context
{
    public class PatrocinioZoneDataBaseContext: DbContext
    {
        public PatrocinioZoneDataBaseContext(DbContextOptions<PatrocinioZoneDataBaseContext>
        options) : base(options)
        {

        }

        public DbSet<Patrocinador> Patrocinadores { get; set; }

        public DbSet<Club> Clubes { get; set; }

        public DbSet<ZonaPatrocinio> ZonaPatrocinios { get; set; }

        public DbSet<Oferta> Ofertas { get; set; }

        public virtual Patrocinador? Patrocinador { get; set; }
        public virtual Club? Club { get; set; }
        public virtual ZonaPatrocinio? ZonaDePatrocinio { get; set; }



        // public DbSet<PatrocinioZoneProyectoV1.Models.Club> Club { get; set; } = default!;

    }
}
