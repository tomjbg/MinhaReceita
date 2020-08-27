using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using minhareceita.api.Configurations;
using System.Collections.Generic;
using AutoMapper;
using minhareceita.domain.Models;
using minhareceita.api.Dtos;
using minhareceita.domain.Interfaces;

namespace minhareceita.api.Controllers
{
    [ApiController]
    [Route("api/v1/perfis")]
    public class PerfilController : BaseController
    {

        private readonly IPerfilRep _perfilRep;
        private readonly IMapper _mapper;
        public PerfilController(IErros ierros, IPerfilRep perfilRep, IMapper mapper) : base(ierros)
        {
            _perfilRep = perfilRep;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            var perfis = _mapper.Map<ICollection<PerfilDto>>(await _perfilRep.ObterTodos());

            return Response(perfis);
        }



    }
}