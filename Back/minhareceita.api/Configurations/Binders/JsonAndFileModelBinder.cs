using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using minhareceita.api.Dtos;
using Newtonsoft.Json;

namespace minhareceita.api.Configurations.Binders
{
    public class JsonAndFileModelBinder : IModelBinder
    {
        private readonly FormFileModelBinder _formFileModelBinder;
        private readonly ILoggerFactory _loggerFactory;

        public JsonAndFileModelBinder(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _formFileModelBinder = new FormFileModelBinder(_loggerFactory);
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            
            Type modelType = bindingContext.ModelType;
            string modelName = bindingContext.FieldName;

            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                bindingContext.ModelState.TryAddModelError(modelName, "Model nulo");
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var jsonValue = valueProviderResult.FirstValue;
            
            if (string.IsNullOrEmpty(jsonValue))
            {
                bindingContext.ModelState.TryAddModelError(modelName, "Nenhum valor json");
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            var model = JsonConvert.DeserializeObject(jsonValue, modelType);

            bindingContext.Result = ModelBindingResult.Success(model);
            
        }
    }
}
