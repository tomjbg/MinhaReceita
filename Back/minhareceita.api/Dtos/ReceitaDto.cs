using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;

namespace minhareceita.api.Dtos
{
    public class ReceitaDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Nome { get; set; }
        public int Avaliacao { get; set; }
        public ICollection<string> Imagens { get; set; }
        public string Video { get; set; }
        public int Curtidas { get; set; }
        public int TempoPreparoMinutos { get; set; }
        public int QtdPorcoes { get; set; }
        public int QtdFavoritados { get; set; }

        // public virtual Usuario Usuario { get; private set; }
        // public virtual ICollection<Comentario> Comentarios { get; private set; }
        // public virtual ICollection<Ingrediente> Ingredientes { get; private set; }
        // public virtual ModoPreparo ModoPreparo { get; private set; }
    }
}