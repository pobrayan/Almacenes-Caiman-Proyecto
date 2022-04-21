using Almacenes_Caiman_Proyecto.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Almacenes_Caiman_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public ActionResult ObtenerCategorias()
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                var obtener = (from d in db.Categorias select d).ToList();
                return Ok(obtener);
            }
        }


        [HttpPost]
        public ActionResult AgregarCategoria([FromBody] Entidades.CategoriaController.AnadirCategoria entidad)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                Entidades.Categorias oCategoria = new Entidades.Categorias();
                oCategoria.Descripcion = entidad.Descripcion;
                oCategoria.Estado = entidad.Estado;
                db.Categorias.Add(oCategoria);
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpPut]
        public ActionResult ActualizarElProducto([FromBody] Entidades.CategoriaController.CategoriaActualizar entidad)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                Entidades.Categorias actualizar = db.Categorias.Find(entidad.Id);
                actualizar.Descripcion = entidad.Descripcion;
                actualizar.Estado = entidad.Estado;
                db.Entry(actualizar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarCategoria(int ID)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                var existe = await db.Categorias.AnyAsync(x => x.Id == ID);
                if (!existe)
                {
                    return BadRequest("El id de la categoria no fue encontrado :C");
                }

                db.Remove(new Categorias() { Id = ID });
                await db.SaveChangesAsync();
                return Ok();
            }
        }

    }
}
