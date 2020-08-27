using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using minhareceita.api.Dtos;

namespace minhareceita.api.Configurations.Binders
{
    public class JsonAndFileBinderProvider : IModelBinderProvider
    {

        public JsonAndFileBinderProvider()
        {
        }


        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(ReceitaDto))
            {
                var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
                return new JsonAndFileModelBinder(loggerFactory);
            }

            return null;
        }
    }
}
