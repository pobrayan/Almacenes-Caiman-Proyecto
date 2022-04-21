using Almacenes_Caiman_Proyecto.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Almacenes_Caiman_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public ActionResult ObtenerProductos()
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                var obtener = (from d in db.Productos select d).ToList();
                return Ok(obtener);
            }
        }

        [HttpPost]
        public ActionResult AgregarProducto([FromBody] Entidades.Productos.ProductoRequest entidad)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                Entidades.Producto oProducto = new Entidades.Producto();
                oProducto.Descripcion = entidad.Descripcion;
                oProducto.Categoria = entidad.Categoria;
                oProducto.PrecioCompra = entidad.PrecioCompra;
                oProducto.Precioventa = entidad.Precioventa;
                oProducto.Stock = entidad.Stock;
                oProducto.Estado = entidad.Estado;
                db.Productos.Add(oProducto);
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpPut]
        public ActionResult ActualizarElProducto([FromBody] Entidades.Productos.ProductoEdit entidad)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                Entidades.Producto actualizar = db.Productos.Find(entidad.Idproducto);
                actualizar.Descripcion = entidad.Descripcion;
                actualizar.Categoria = entidad.Categoria;
                actualizar.PrecioCompra = entidad.PrecioCompra;
                actualizar.Precioventa = entidad.Precioventa;
                actualizar.Stock = entidad.Stock;
                actualizar.Estado = entidad.Estado;
                db.Entry(actualizar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpDelete]
        public async Task<ActionResult>EliminarProducto(int ID)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                var existe = await db.Productos.AnyAsync(x => x.Idproducto == ID);
                if (!existe)
                {
                    return BadRequest("El id del producto no fue encontrado :C");
                }

                db.Remove(new Producto() { Idproducto = ID });
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
