using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minhareceita.api.Configurations;
using minhareceita.domain.Models;
using minhareceita.domain.Interfaces;
using minhareceita.api.Dtos;
using AutoMapper;
using minhareceita.api.Configurations.Binders;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace minhareceita.api.Controllers
{
    [Route("api/v1/receitas")]
    [ApiController]
    public class ReceitaController : BaseController
    {
        private readonly IReceitaRep _receitaRep;
        private readonly IReceitaService _receitaService;
        private readonly IHostEnvironment _host;
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly IMapper _mapper;
        public ReceitaController(IErros ierros, IMapper imapper,
                                 IReceitaRep receitaRep, IReceitaService receitaService, 
                                 IHostEnvironment hostEnvironment) : base(ierros)
        {
            _mapper = imapper;
            _receitaRep = receitaRep;
            _receitaService = receitaService;
            _host = hostEnvironment;
        }

        [HttpPost("AdicionarModelAndFileStream")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> AdicionarModelAndFiles([ModelBinder(typeof(JsonAndFileModelBinder))] ReceitaDto receitaDto, [Optional] IFormFileCollection files)
        {

            if (!ModelState.IsValid) return Response(ModelState);

            try
            {
                foreach (IFormFile fl in files)
                {
                    string fullFileName = string.Concat(_host.ContentRootPath, "\\wwwroot\\Imagens\\", Guid.NewGuid(),"_",fl.FileName);
                    await fl.CopyToAsync(new System.IO.FileStream(path: fullFileName, FileMode.Create));
                }

                Receita receita = _mapper.Map<Receita>(receitaDto);
                await _receitaService.Adicionar(receita);

                return Response(receita);
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return Response();
            }

        }

        [HttpPost("AdicionarModelAndBase64")]
        public async Task<ActionResult> AdicionarModel([FromBody] ReceitaDto receitaDto)
        {
            if (!ModelState.IsValid) return Response(ModelState);
           
            try
            {
                Receita receita = _mapper.Map<Receita>(receitaDto);
                await _receitaService.Adicionar(receita);
                receitaDto = _mapper.Map<ReceitaDto>(receita);
                return Response(receitaDto);
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
                return Response();
            }

        }

        private async Task<bool> UploadArquivo(string arquivo, string imgNome)
        {
            var imageDataByteArray = Convert.FromBase64String(arquivo);
            if (string.IsNullOrEmpty(arquivo))
            {
                AdicionarErro("Forneça uma imagem.");
                return false;
            }

            string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}//Imagens",imgNome);

            if (System.IO.File.Exists(filePath))
            {
                AdicionarErro("Já existe um arquivo com este nome.");
                return false;
            }

            await System.IO.File.WriteAllBytesAsync(filePath, imageDataByteArray);

            return true;
        }



    }
}