using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minhareceita.api.Configurations
{
    public class Erros : IErros
    {
        private List<string> _lstErros;
        public Erros()
        {
            _lstErros = new List<string>();
        }
        public void AddErrorMessage(string message)
        {
            _lstErros.Add(message);
        }

        public List<string> GetAllErrors()
        {
            return _lstErros;
        }

        public bool HasErrors()
        {
            return _lstErros.Any();
        }
    }
}
