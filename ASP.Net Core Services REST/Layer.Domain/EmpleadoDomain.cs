using Layer.Entity;
using Layer.AccessData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Domain
{
    public class EmpleadoDomain
    {
        public List<EmpleadoEntity> Listar()
        {
            return EmpleadoAccessData.Listar();
        }

        public List<EmpleadoEntity> Filtrar(EmpleadoEntity entidad)
        {
            return EmpleadoAccessData.Filtrar(entidad);
        }

        public string Registrar(EmpleadoEntity entidad)
        {
            return EmpleadoAccessData.Registrar(entidad);

        }

        public string Modificar(EmpleadoEntity entidad)
        {
            return EmpleadoAccessData.Modificar(entidad);

        }

        public string Eliminar(EmpleadoEntity entidad)
        {
            return EmpleadoAccessData.Eliminar(entidad);

        }
    }
}
