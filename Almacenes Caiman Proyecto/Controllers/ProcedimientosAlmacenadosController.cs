using Almacenes_Caiman_Proyecto.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Almacenes_Caiman_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientosAlmacenadosController: ControllerBase
    {

        [HttpPut]
        [Route("api/Categorias/ModificaPrecio/{idProducto}/{nuevoPrecio}")]
        public ActionResult ModificarPrecio(int idProducto, decimal nuevoPrecio)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                db.Database.ExecuteSqlRaw(@"EXECUTE SP_modificarPrecio {0}, {1}", idProducto, nuevoPrecio);
                return Ok();
            }
        }

        [HttpGet]
        [Route("api/Categorias/ListaProductos")]
        public ActionResult ListaProductos(bool stock)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                List<Producto> items = db.Productos.FromSqlRaw(@"EXECUTE SP_GetProductos {0}", stock).ToList();
                return Ok(items);
            }
        }
    }
}
