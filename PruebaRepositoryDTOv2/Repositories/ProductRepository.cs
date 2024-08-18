using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using PruebaRepositoryDTOv2.DTOs;

namespace PruebaRepositoryDTOv2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connection;

        public ProductRepository(IConfiguration configuration)
        {
            var constring = configuration.GetConnectionString("connection");
            if (constring != null)
            {
                _connection = constring;
            }
            else
                _connection = "";
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            using SqlConnection connection = new(_connection);
            using SqlCommand command = new("SP_AddProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", productDTO.Nombre);
            command.Parameters.AddWithValue("@IDProveedor", productDTO.IDProveedor);
            command.Parameters.AddWithValue("@IDTipo", productDTO.IDTipo);
            command.Parameters.AddWithValue("@Cantidad", productDTO.Cantidad);
            command.Parameters.AddWithValue("@Modelo", productDTO.Modelo);
            command.Parameters.AddWithValue("@Marca", productDTO.Marca);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            using SqlConnection connection = new(_connection);
            using SqlCommand command = new("SP_GetProducts", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            var products = new List<ProductDTO>();
            while (await reader.ReadAsync())
            {
				ProductDTO product = new ProductDTO()
				{
					Id = reader.GetInt32(reader.GetOrdinal("Id")),
					Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
					IDProveedor = reader.GetInt32(reader.GetOrdinal("IDProveedor")),
					IDTipo = reader.GetInt32(reader.GetOrdinal("IDTipo")),
					Cantidad = reader.GetInt32(reader.GetOrdinal("Cantidad")),
					FechaAlta = reader.GetDateTime(reader.GetOrdinal("FechaAlta")),
					Modelo = reader.GetString(reader.GetOrdinal("Modelo")),
					Marca = reader.GetString(reader.GetOrdinal("Marca"))
				};
				products.Add(product);
			}
            return products;
        }
    }
}
