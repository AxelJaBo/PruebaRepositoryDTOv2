using System.Data.SqlClient;
using System.Data;
using PruebaRepositoryDTOv2.DTOs;

namespace PruebaRepositoryDTOv2.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly string _connection;

        public ProductTypeRepository(IConfiguration configuration)
        {
            var constring = configuration.GetConnectionString("connection");
            if (constring != null)
            {
                _connection = constring;
            }
            else
                _connection = "";
        }

        public async Task<IEnumerable<ProductTypeDTO>> GetProductTypesAsync()
        {
            using SqlConnection connection = new(_connection);
            using SqlCommand command = new("SP_GetProductTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            var productTypes = new List<ProductTypeDTO>();
            while (await reader.ReadAsync())
            {
                productTypes.Add(new ProductTypeDTO
                {
                    ID = (int)reader["ID"],
                    Nombre = (string)reader["Nombre"]
                });
            }
            return productTypes;
        }
    }
}
