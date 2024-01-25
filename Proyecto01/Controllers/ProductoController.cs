using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto01.Controllers
{
	[ApiController]
	[Route("producto")]

	public class ProductoController : ControllerBase
	{

		[HttpGet]
		[Route("listar")]

		public dynamic ListarProductos()
		{
			List<Parametro> parametros = new List<Parametro>
			{ 
				new Parametro("@Estado", true)
			};
			DataTable tCategoria = DBDatos.Listar("Categoria_Listar", parametros);

            DataTable tProducto = DBDatos.Listar("Producto_Listar");

			string jsonCategoría = JsonConvert.SerializeObject(tCategoria);
			string jsonProducto = JsonConvert.SerializeObject(tProducto);

			return new
			{
				success = true,
				message = "exito",
				result = new
				{
					categoria = JsonConvert.DeserializeObject<List<Categoria>>(jsonCategoría),
					producto = JsonConvert.DeserializeObject<List<Producto>>(jsonProducto)
				};
			}
        }

	}
}