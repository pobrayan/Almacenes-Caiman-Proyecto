using Almacenes_Caiman_Proyecto.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Almacenes_Caiman_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult ObtenerClientes()
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                var obtener = (from d in db.Clientes select d).ToList();
                return Ok(obtener);
            }
        }

        [HttpPost]
        public ActionResult AgregarClientes([FromBody] Entidades.ClientesContoller.AgregarCliente entidad)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                Entidades.Cliente oClientes = new Entidades.Cliente();
                oClientes.Nit = entidad.Nit;
                oClientes.Nombres = entidad.Nombres;
                oClientes.Apellidos = entidad.Apellidos;
                oClientes.Telefono = entidad.Telefono;
                oClientes.Correo = entidad.Correo;
                oClientes.Estado = entidad.Estado;
                db.Clientes.Add(oClientes);
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpPut]
        public ActionResult ActualizarCliente([FromBody] Entidades.ClientesContoller.ClientesActualizar entidad)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                Entidades.Cliente actualizar = db.Clientes.Find(entidad.Idclientes);
                actualizar.Nit = entidad.Nit;
                actualizar.Nombres = entidad.Nombres;
                actualizar.Apellidos = entidad.Apellidos;
                actualizar.Telefono = entidad.Telefono;
                actualizar.Correo = entidad.Correo;
                actualizar.Estado = entidad.Estado;
                db.Entry(actualizar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpDelete]
        public async Task<ActionResult>EliminarCliente(int ID)
        {
            using (Entidades.ALMACENES_CAIMANContext db = new Entidades.ALMACENES_CAIMANContext())
            {
                var existe = await db.Clientes.AnyAsync(x => x.Idclientes == ID);
                if (!existe)
                {
                    return BadRequest("El id de la categoria no fue encontrado :C");
                }

                db.Remove(new Cliente() { Idclientes = ID });
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
