using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using minhareceita.api.Configurations;

namespace minhareceita.api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IErros _ierros;

        public BaseController(IErros ierros)
        {
            _ierros = ierros;
        }

        protected new ActionResult Response(object obj = null)
        {
            if (obj != null)
            {
                return Ok(new
                {
                    success = true,
                    data = obj
                });
            }
            return BadRequest(new
            {
                success = false,
                errors = _ierros.GetAllErrors()
            });
        }

        protected new ActionResult Response(ModelStateDictionary modelstate)
        {
            AdicionarModelStateErros(modelstate);
            return Response();
        }


        protected void AdicionarModelStateErros(ModelStateDictionary modelstate)
        {
            var erros = modelstate.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                string msgErr = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                _ierros.AddErrorMessage(msgErr);
            }

        }

        protected void AdicionarErro(string mensagem)
        {
            if (mensagem.Length > 0)
            {
                _ierros.AddErrorMessage(mensagem);
            }
        }





    }
}
