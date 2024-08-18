using System.Data.SqlClient;
using System.Data;
using PruebaRepositoryDTOv2.DTOs;

namespace PruebaRepositoryDTOv2.Repositories
{
    public class ProductReportRepository : IProductReportRepository
    {
        private readonly string _connection;

        public ProductReportRepository(IConfiguration configuration)
        {
            var constring = configuration.GetConnectionString("connection");
            if (constring != null)
            {
                _connection = constring;
            }
            else
                _connection = "";
        }

        public async Task<IEnumerable<ProductReportDTO>> GetProductReportAsync()
        {
            using SqlConnection connection = new(_connection);
            using SqlCommand command = new("SP_GetProductsReport", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            var productsReport = new List<ProductReportDTO>();
            while (await reader.ReadAsync())
            {
                productsReport.Add(new ProductReportDTO
                {
                    IDProducto = (int)reader["IDProducto"],
                    NombreProducto = (string)reader["NombreProducto"],
                    Marca = (string)reader["Marca"],
                    Modelo = (string)reader["Modelo"],
                    TipoProducto = (string)reader["TipoProducto"],
                    Proveedor = (string)reader["Proveedor"],
                    Cantidad = (int)reader["Cantidad"]
                });
            }
            return productsReport;
        }
    }
}
