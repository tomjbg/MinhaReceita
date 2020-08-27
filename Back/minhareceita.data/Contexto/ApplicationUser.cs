using System;
using Microsoft.AspNetCore.Identity;

namespace minhareceita.data.Contexto
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DataNascimento { get; private set; }
        public DateTime DataInscricao { get; private set; }
        public string Foto { get; private set; }
    }
}