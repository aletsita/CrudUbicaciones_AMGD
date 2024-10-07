using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Capas
using BLL;
using DAL;

namespace CrudUbicaciones_AMGD
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicaciones_BLL oUbicacionesBLL;
        ubicacionesDAL oUbicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
        }
        //Metodo encargado de listar los datos de la BD en un GRIDView
        public void ListarUbicaciones() 
        {
            oUbicacionesDAL = new ubicacionesDAL();
            gvUbicaciones.DataSource = oUbicacionesDAL.Listar();
            gvUbicaciones.DataBind();
        }
        //Metodo encargado de recolectar los datos de nuestra interfaz
        public ubicaciones_BLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new ubicaciones_BLL();

            //Recolectar datos de la capa de presentacion
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;

        }



        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL();
            oUbicacionesDAL.Eliminar (datosUbicacion());
            ListarUbicaciones();

        }

        protected void btModificar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL ();
            oUbicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaciones ();
        }

        protected void gvUbicaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnSeleccionar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow filaSeleccion = gvUbicaciones.Rows[indice];

                string idUbicacion = filaSeleccion.Cells[1].Text;
                string ubicacion = filaSeleccion.Cells[2].Text;
                string latitud = filaSeleccion.Cells[3].Text;
                string longitud = filaSeleccion.Cells[4].Text;

                txtID.Value = idUbicacion;
                txtUbicacion.Text = ubicacion;
                txtLat.Text = latitud;
                txtLong.Text = longitud;
            }
        }
    }
}