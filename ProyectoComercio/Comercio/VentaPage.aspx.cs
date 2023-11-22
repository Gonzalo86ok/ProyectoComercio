using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class VentaPage : System.Web.UI.Page
    {
        public List<Categoria> listaCategorias { get; set; }
        public List<Producto> listaProducto { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            listaCategorias = categoriaNegocio.listar();
            listaProducto = productoNegocio.listarActivos();

            if (!IsPostBack)
            {
                dgvProducto.DataSource = listaProducto;
                dgvProducto.DataBind();

                gdvCompra.DataSource = (List<Venta>)Session["listaSesionVenta"];
                gdvCompra.DataBind();


                string sumaVentasFormateada = Session["sumaVentas"] != null ? $"$ {Session["sumaVentas"]:#,##0.00}" : "$0.00";
                if (Session["listaSesionVenta"] != null)
                {
                    decimal sumaVentas = CalcularSumaVentas((List<Venta>)Session["listaSesionVenta"]);
                    sumaVentasFormateada = $"$ {sumaVentas:#,##0.00}";
                    txtSumaVentas.Text = sumaVentasFormateada;
                    txtSumaVentas.CssClass = "texto-grande";
                }

                txtSumaVentas.CssClass = "texto-grande";
                txtSumaVentas.Text = sumaVentasFormateada;
                txtSumaVentas.Enabled = false;
            }
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(((Button)sender).CommandArgument);

            StockNegocio stockNegocio = new StockNegocio();
            decimal cantidadDeStock = stockNegocio.ObtenerCantidadStock(idProducto);

            RepeaterItem repeaterItem = (sender as Button).NamingContainer as RepeaterItem;
            TextBox txtCantidad = repeaterItem.FindControl("txtCantidad") as TextBox;

            if (txtCantidad != null)
            {
                decimal cantidad;

                if (!decimal.TryParse(txtCantidad.Text, out cantidad) || cantidad < 0 || txtCantidad.Text.Contains(".") || cantidad == 0)
                {
                    lbMensaje.Text = "Error al ingresar cantidad..";
                    lbMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else if ((cantidad - cantidadDeStock) > 0)
                {
                    lbMensaje.Text = "No hay Stock suficiente para este producto (Disponibilidad: " + cantidadDeStock + ")..";
                    lbMensaje.ForeColor = System.Drawing.Color.Red;
                }

                else
                {
                    // Crear una nueva venta
                    Venta venta = new Venta();
                    Producto producto = new Producto();
                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    producto = productoNegocio.obtenerProducto(idProducto);
                    venta.Producto = producto;

                    // Verificar la cantidad total incluyendo la cantidad existente en la lista
                    decimal cantidadTotal = cantidad + ObtenerCantidadEnLista(idProducto);

                    if (cantidadTotal > cantidadDeStock)
                    {
                        lbMensaje.Text = "No hay suficiente Stock para este producto (Disponibilidad: " + cantidadDeStock + ")..";
                        lbMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        venta.Cantidad = cantidad;
                        venta.Monto = cantidad * producto.Precio;

                        if (Session["listaSesionVenta"] == null)
                        {
                            List<Venta> listaVenta = new List<Venta>();
                            Session["listaSesionVenta"] = listaVenta;
                        }

                        AgregarVentaALista(venta);

                        decimal sumaVentas = CalcularSumaVentas((List<Venta>)Session["listaSesionVenta"]);
                        string sumaVentasFormateada = $"$ {sumaVentas:#,##0.00}";
                        txtSumaVentas.Text = sumaVentasFormateada;
                        txtSumaVentas.CssClass = "texto-grande";

                        gdvCompra.DataSource = (List<Venta>)Session["listaSesionVenta"];
                        gdvCompra.DataBind();
                        lbMensaje.Text = "Producto agregado...";
                        lbMensaje.ForeColor = System.Drawing.Color.Green;
                    }
                }



            }
            txtCantidad.Text = string.Empty;
        }

        // Método para agregar venta a la lista o actualizar cantidad si ya existe
        private void AgregarVentaALista(Venta nuevaVenta)
        {
            List<Venta> listaVenta = (List<Venta>)Session["listaSesionVenta"];

            // Buscar si el producto ya está en la lista
            Venta ventaExistente = listaVenta.FirstOrDefault(v => v.Producto.Id == nuevaVenta.Producto.Id);

            if (ventaExistente != null)
            {
                // Si el producto existe, actualiza la cantidad y el monto
                ventaExistente.Cantidad += nuevaVenta.Cantidad;
                ventaExistente.Monto = ventaExistente.Cantidad * nuevaVenta.Producto.Precio;

            }
            else
            {
                // Si no existe, agrega el nuevo producto a la lista
                nuevaVenta.Numero = listaVenta.Count + 1; // Asigna el número de venta
                listaVenta.Add(nuevaVenta);
            }

            Session["listaSesionVenta"] = listaVenta;
        }



        private decimal CalcularSumaVentas(List<Venta> listaVentas)
        {
            decimal suma = 0;
            foreach (Venta venta in listaVentas)
            {
                suma += venta.Monto;
            }
            return suma;
        }
        private decimal ObtenerCantidadEnLista(int idProducto)
        {
            decimal cantidadEnLista = 0;

            // Lógica para obtener la cantidad del producto en la lista de ventas
            if (Session["listaSesionVenta"] != null)
            {
                List<Venta> listaVenta = (List<Venta>)Session["listaSesionVenta"];
                cantidadEnLista = listaVenta.Where(v => v.Producto.Id == idProducto).Sum(v => v.Cantidad);
            }

            return cantidadEnLista;
        }

        protected void BtnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (CalcularSumaVentas((List<Venta>)Session["listaSesionVenta"]) == 0)
            {
                lbMensaje.Text = "No hay productos agregados...";
                lbMensaje.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                // Esta funcion es para actualizar el Stock de la venta
                ActualizarStock((List<Venta>)Session["listaSesionVenta"]);

                limpiarVentanaVenta();
                lbMensaje.Text = "Venta realizada con exito...";
                lbMensaje.ForeColor = System.Drawing.Color.Green;
            }

        }

        protected void btnCancalar_Click(object sender, EventArgs e)
        {

            limpiarVentanaVenta();
            lbMensaje.Text = "Venta Cancelada...";
            lbMensaje.ForeColor = System.Drawing.Color.Yellow;

        }
        protected void ActualizarStock(List<Venta> listaVenta)
        {
            StockNegocio negocio = new StockNegocio();

            foreach (Venta venta in listaVenta)
            {
                negocio.DecrementarCantidadStock(venta.Producto.Id, venta.Cantidad);
            }
        }
        protected void limpiarVentanaVenta()
        {
            List<Venta> listaVenta = new List<Venta>(); // Crea una nueva lista vacía

            // Asigna la lista vacía al origen de datos del GridView
            gdvCompra.DataSource = listaVenta;
            gdvCompra.DataBind(); // Vuelve a enlazar el GridView con la lista vacía

            // Guarda la lista vacía en la sesión
            Session["listaSesionVenta"] = listaVenta;

            decimal sumaVentas = 0;
            string sumaVentasFormateada = $"$ {sumaVentas:#,##0.00}";
            txtSumaVentas.Text = sumaVentasFormateada;
            txtSumaVentas.CssClass = "texto-grande";
            Session["sumaVentas"] = sumaVentasFormateada;

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // Convierte el objeto sender a un botón
            int idProductoEliminar = int.Parse(btn.CommandArgument); // Accede al CommandArgument enviado desde el botón

            if (Session["listaSesionVenta"] != null)
            {
                List<Venta> listaSesionVenta = (List<Venta>)Session["listaSesionVenta"];

                // Busca la venta en la lista que coincide con el ID del producto proporcionado
                Venta ventaAEliminar = listaSesionVenta.FirstOrDefault(v => v.Producto.Id == idProductoEliminar);

                if (ventaAEliminar != null)
                {
                    listaSesionVenta.Remove(ventaAEliminar);
                    Session["listaSesionVenta"] = listaSesionVenta;

                    // Recalcular la suma total de ventas después de eliminar una venta
                    decimal sumaVentas = CalcularSumaVentas(listaSesionVenta);
                    string sumaVentasFormateada = $"$ {sumaVentas:#,##0.00}";

                    // Recorrer la lista y reasignar los números de compra
                    ReasignarNumerosCompra(listaSesionVenta);

                    // Actualizar la suma de ventas en el TextBox y en la sesión
                    txtSumaVentas.Text = sumaVentasFormateada;
                    Session["sumaVentas"] = sumaVentasFormateada;

                    gdvCompra.DataSource = listaSesionVenta;
                    gdvCompra.DataBind();

                    lbMensaje.Text = "Se elimino de la lista...";
                    lbMensaje.ForeColor = System.Drawing.Color.Yellow;

                }
            }
        }

        private void ReasignarNumerosCompra(List<Venta> listaVentas)
        {
            // Recorrer la lista y asignar los números de compra actualizados
            for (int i = 0; i < listaVentas.Count; i++)
            {
                listaVentas[i].Numero = i + 1;
            }
        }

    }
}