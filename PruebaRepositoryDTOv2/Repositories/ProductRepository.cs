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
                products.Add(new ProductDTO
                {
                    Id = (int)reader["Id"],
                    Nombre = (string)reader["Nombre"],
                    IDProveedor = (int)reader["IDProveedor"],
                    IDTipo = (int)reader["IDTipo"],
                    Cantidad = (int)reader["Cantidad"],
                    FechaAlta = (DateTime)reader["FechaAlta"],
                    Modelo = (string)reader["Modelo"],
                    Marca = (string)reader["Marca"]
                });
            }
            return products;
        }
    }
}
