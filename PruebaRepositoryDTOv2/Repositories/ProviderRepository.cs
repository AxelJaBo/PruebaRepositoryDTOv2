using System.Data.SqlClient;
using System.Data;
using PruebaRepositoryDTOv2.DTOs;

namespace PruebaRepositoryDTOv2.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly string _connection;

        public ProviderRepository(IConfiguration configuration)
        {
            var constring = configuration.GetConnectionString("connection");
            if (constring != null)
            {
                _connection = constring;
            }
            else
                _connection = "";
        }

        public async Task<IEnumerable<ProviderDTO>> GetProvidersAsync()
        {
            using SqlConnection connection = new(_connection);
            using SqlCommand command = new("SP_GetProviders", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            var providers = new List<ProviderDTO>();
            while (await reader.ReadAsync())
            {
                providers.Add(new ProviderDTO
                {
                    ID = (int)reader["ID"],
                    Nombre = (string)reader["Nombre"]
                });
            }
            return providers;
        }
    }
}
