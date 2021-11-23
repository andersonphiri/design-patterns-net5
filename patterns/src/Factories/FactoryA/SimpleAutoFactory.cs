using Factories.Kernel.Autos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryA
{
    public class SimpleAutoFactory
    {
        Dictionary<string, Type> autos;

        public SimpleAutoFactory()
        {
            LoadTypesICanReturn();
        }
        public IAuto CreateInstance(string name)
        {
            Type t = GetTypeToCreate(name);
            return t is null ? new CarNotFound() : Activator.CreateInstance(t) as IAuto;
        }

        Type GetTypeToCreate(string name)
        {
            return autos.TryGetValue(name.ToLowerInvariant(), out var type) ? type : null;
        }

        void LoadTypesICanReturn()
        {
            autos = new Dictionary<string, Type>();
            var typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterface(typeof(IAuto).ToString()) is not null );
            foreach (var type in typesInThisAssembly)
            {
                autos.Add(type.Name.ToLower(), type);
            }
        }
    }
}
