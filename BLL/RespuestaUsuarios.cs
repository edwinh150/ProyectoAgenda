using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RespuestaUsuarios : ClaseMaestra
    {
        public int RespuestaUsuarioId { get; set; }

        public override bool Buscar(int IdBuscado)
        {
            throw new NotImplementedException();
        }

        public override bool Editar(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Insertar()
        {
            throw new NotImplementedException();
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }
    }
}
