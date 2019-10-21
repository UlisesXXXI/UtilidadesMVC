using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Utilidades.ViewModels.Tag
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descripcion { get; set; }


    }
}