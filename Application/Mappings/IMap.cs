using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings // mapowanie po nowemu
{
    public interface IMap
    {

        void Mapping(Profile profile); // konfiguracja mapy implementujemy go w klasach dto
    }
}
