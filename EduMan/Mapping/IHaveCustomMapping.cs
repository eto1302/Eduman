using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Eduman.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(IMapperConfigurationExpression mapper);
    }
}