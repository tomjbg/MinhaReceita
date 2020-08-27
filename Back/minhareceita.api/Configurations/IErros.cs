using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minhareceita.api.Configurations
{
    public interface IErros
    {
        void AddErrorMessage(string message);
        List<string> GetAllErrors();
        bool HasErrors();

    }
}
