﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

    namespace PatrocinioZoneProyectoV1.Models
    {
        public class Usuario
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public string Nombre { get; set; }

            public string Email { get; set; }

            [Display(Name = "Fecha ingreso")]
            public DateTime FechaIngreso { get; set; }

        

        }
    }
