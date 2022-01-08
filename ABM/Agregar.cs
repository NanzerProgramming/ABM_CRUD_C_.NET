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
    public partial class Agregar : Form
    {
        private CapaDeNegocios _capaDeNegocios;
        private Usuarios _usuarios; 
        public Agregar()
        {
            InitializeComponent();
            _capaDeNegocios = new CapaDeNegocios();
        }

        #region EVENTS
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveUsuarios();
            this.Close();
            ((Menu)this.Owner).PopulateUsuarios();
        }

        private void txtAgregarUsu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtAgregarContra.Focus();
            }
        }
        private void txtAgregarContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtAgregarMail.Focus();
            }
        }
        private void txtAgregarMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtAgregarTel.Focus();
            }
        }
        private void txtAgregarTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtAgregarDire.Focus();
            }
        }

        private void txtAgregarDire_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnAdd.Focus();
            }
        }

        private void Agregar_Shown(object sender, EventArgs e)
        {
            txtAgregarUsu.Focus();
        }
        private void btnAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Right))
            {
                btnCancelar.Focus();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void SaveUsuarios()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.usuario = txtAgregarUsu.Text;
            usuarios.contrasena = txtAgregarContra.Text;
            usuarios.mail = txtAgregarMail.Text;
            usuarios.telefono = txtAgregarTel.Text;
            usuarios.direccion = txtAgregarDire.Text;

            usuarios.Id = _usuarios != null ? _usuarios.Id : 0;

            _capaDeNegocios.SaveUsuarios(usuarios);
        }

        private void ClearForm()
        {
            txtAgregarUsu.Text = string.Empty;
            txtAgregarContra.Text = string.Empty;
            txtAgregarMail.Text = string.Empty;
            txtAgregarTel.Text = string.Empty;
            txtAgregarDire.Text = string.Empty;
        }
        #endregion

        #region PUBLIC METHODS
        public void LoadUsuarios(Usuarios usuarios)
        {

            _usuarios = usuarios;
            if (usuarios != null)
            {
                ClearForm();

                txtAgregarUsu.Text = usuarios.usuario;
                txtAgregarContra.Text = usuarios.contrasena;
                txtAgregarMail.Text = usuarios.mail;
                txtAgregarTel.Text = usuarios.telefono;
                txtAgregarDire.Text = usuarios.direccion;
            }

        }


        #endregion

        
    }
}
