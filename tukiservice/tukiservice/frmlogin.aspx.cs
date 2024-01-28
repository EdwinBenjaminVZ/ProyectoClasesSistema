using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tukiservice.Servicios;
using tukiservice.Servicios.Models;

namespace tukiservice
{
    public partial class frmlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            servicioAutenticar oservicioAutenticar = new servicioAutenticar();
            usuarioLogin ousuarioLogin = oservicioAutenticar.RecuperaToken(txtUsuario.Text.ToString(), txtPassword.Text.ToString());

            if (ousuarioLogin.token != null)
            {
                Session.Add("ousuarioLogin", ousuarioLogin);
                Response.Redirect("./Formularios/wfRol.aspx");
            }
        }
    }
}