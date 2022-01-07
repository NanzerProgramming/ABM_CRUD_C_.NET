using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM
{
    public class CapaDeAccesoDatos
    {
        //private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CRUD;Data Source=DESKTOP-KCF03C0\\SQLEXPRESS");
        private SqlConnection conn = new SqlConnection("workstation id=ProyectosNanzerProg.mssql.somee.com;packet size=4096;user id=Nanzer_SQLLogin_1;pwd=7d26t13ar4;data source=ProyectosNanzerProg.mssql.somee.com;persist security info=False;initial catalog=ProyectosNanzerProg");

        public void InsertUsuarios(Usuarios usuarios)
        {
            try
            {
                conn.Open();
                string query = @"
                            INSERT INTO USUARIOS (usuario, contrasena, mail, telefono, direccion)
                            VALUES (@usuario, @contrasena, @mail, @telefono, @direccion)";

                //SqlParameter usuarioParametro = new SqlParameter();
                //usuarioParametro.ParameterName = "@usuario";
                //usuarioParametro.Value = usuarios.usuarioParametro;
                //usuarioParametro.DbType = System.Data.DbType.String;

                SqlParameter usuario = new SqlParameter("@usuario", usuarios.usuario);
                SqlParameter contrasena = new SqlParameter("@contrasena", usuarios.contrasena);
                SqlParameter mail = new SqlParameter("@mail", usuarios.mail);
                SqlParameter telefono = new SqlParameter("@telefono", usuarios.telefono);
                SqlParameter direccion = new SqlParameter("@direccion", usuarios.direccion);

                SqlCommand Command = new SqlCommand(query, conn);
                Command.Parameters.Add(usuario);
                Command.Parameters.Add(contrasena);
                Command.Parameters.Add(mail);
                Command.Parameters.Add(telefono);
                Command.Parameters.Add(direccion);

                Command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public void UpdateUsuarios(Usuarios usuarios)
        {
            try
            {
                conn.Open();
                string query = @"UPDATE USUARIOS
                                    SET usuario = @usuario, 
                                        contrasena = @contrasena, 
                                        mail = @mail, 
                                        telefono = @telefono, 
                                        direccion = @direccion
                                    WHERE id = @id";

                SqlParameter Id = new SqlParameter("@id", usuarios.Id);
                SqlParameter usuario = new SqlParameter("@usuario", usuarios.usuario);
                SqlParameter contrasena = new SqlParameter("@contrasena", usuarios.contrasena);
                SqlParameter mail = new SqlParameter("@mail", usuarios.mail);
                SqlParameter telefono = new SqlParameter("@telefono", usuarios.telefono);
                SqlParameter direccion = new SqlParameter("@direccion", usuarios.direccion);

                SqlCommand Command = new SqlCommand(query, conn);
                Command.Parameters.Add(Id);
                Command.Parameters.Add(usuario);
                Command.Parameters.Add(contrasena);
                Command.Parameters.Add(mail);
                Command.Parameters.Add(telefono);
                Command.Parameters.Add(direccion);

                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public void DeleteUsuarios(int Id)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM USUARIOS WHERE id = @id";

                SqlCommand Command = new SqlCommand(query, conn);
                Command.Parameters.Add(new SqlParameter("@id", Id));

                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public List<Usuarios> GetUsuarios(string buscarText = null)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            try
            {
                conn.Open();
                string query = @"SELECT id, usuario, contrasena, mail, telefono, direccion
                                    FROM USUARIOS";
                SqlCommand command = new SqlCommand(query, conn);



                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(new Usuarios
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        usuario = (reader["usuario"].ToString()),
                        contrasena = (reader["contrasena"].ToString()),
                        mail = (reader["mail"].ToString()),
                        telefono = (reader["telefono"].ToString()),
                        direccion = (reader["direccion"].ToString())
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return usuarios;
        }


    }

}
