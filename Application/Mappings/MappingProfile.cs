using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public  class MappingProfile : Profile
    {

        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // fragment gotowego kodu ktory wyszuka wszystkie klasy dto wyszukanie ich instancji 
            //a potem wywolanie metody maping w przypadku uzycia//

            // Wyszukuje wszystkie typy w projekcie Application
            // wybiera tylko te ktore sa typu IMap lub go implementuja
            // odrzuca te o typie Interface czyli dostajesz tylko te ktore chcesz .

            var types = assembly.GetExportedTypes().Where(x =>
              typeof(IMap).IsAssignableFrom(x) && !x.IsInterface).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
            #region
            ////*
            //// w sumie to jest dobre bo tylko jak tworzysz nowy typ DTO to w nim wpisujesz schemastycznie
            //// to co jesdt potrzebne i masz ustawione a nie szukasz po projekcie gdzie musisz cos zmienic
            //// zseby dzialalo
            // //
            #endregion
        }
    }
}
