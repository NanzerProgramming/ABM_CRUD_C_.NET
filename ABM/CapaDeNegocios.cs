using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM
{
    public class CapaDeNegocios //Reglas (validaciones por ejemplo)
    {
        private CapaDeAccesoDatos _CapaDeAccesoDatos;
        public CapaDeNegocios()
        {
            _CapaDeAccesoDatos = new CapaDeAccesoDatos();
        }
        public Usuarios SaveUsuarios(Usuarios usuarios)
        {
            if (usuarios.Id == 0)
                _CapaDeAccesoDatos.InsertUsuarios(usuarios);
            else
                _CapaDeAccesoDatos.UpdateUsuarios(usuarios);
            
            return usuarios;        
        }
        public List<Usuarios> GetUsuarios(string buscarText = null)
        {
           return _CapaDeAccesoDatos.GetUsuarios(buscarText);
        }

        public void DeleteUsuarios(int Id)
        {
            _CapaDeAccesoDatos.DeleteUsuarios(Id);
        }
    }
}
