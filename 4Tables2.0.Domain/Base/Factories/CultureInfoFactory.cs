using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Tables2._0.Domain.Base.Factories
{
    public static class CultureInfoFactory
    {
        public static CultureInfo Brasil => new CultureInfo("pt-BR");
    }
}