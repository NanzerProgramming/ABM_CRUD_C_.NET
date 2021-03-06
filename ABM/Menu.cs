using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ABM
{
    public partial class Menu : Form
    {
        private CapaDeNegocios _CapaDeNegocios;
        
        public Menu()
        {
            InitializeComponent();
            _CapaDeNegocios = new CapaDeNegocios();
            
        }

        #region EVENTS
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenAgregarDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            PopulateUsuarios();
        }
        private void gridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)gridUsuarios.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value.ToString() == "Editar")
            {
                Agregar agregar = new Agregar();
                agregar.LoadUsuarios(new Usuarios
                {
                    Id = int.Parse(gridUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    usuario = gridUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    contrasena = gridUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    mail = gridUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    telefono = gridUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    direccion = gridUsuarios.Rows[e.RowIndex].Cells[5].Value.ToString(),
                });
                agregar.ShowDialog(this);
            }
            else if (cell.Value.ToString() == "Eliminar")
            {
                DeleteUsuarios(int.Parse(gridUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString()));
                PopulateUsuarios();
            }
        }
        
        #endregion

        #region PRIVATE METHODS
        private void OpenAgregarDialog() 
        {
            Agregar Agregar = new Agregar();
            Agregar.ShowDialog(this);
        }
        private void DeleteUsuarios(int Id)
        {
            _CapaDeNegocios.DeleteUsuarios(Id);
        }
        #endregion

        #region PUBLIC METHODS
        public void PopulateUsuarios()
        {
            List<Usuarios> usuarios = _CapaDeNegocios.GetUsuarios();
            gridUsuarios.DataSource = usuarios;
        }
        #endregion
       
    }
}
