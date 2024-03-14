using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentDesk;


public class BaseDao { 
    protected readonly IConfiguration _configuration;
    protected string _connectionString;
    public SqlConnection _SqlConnection;
    public BaseDao(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("MyDatabaseConnection");
        _SqlConnection = new SqlConnection(_connectionString);
    }

    public void ConnectionOpen() {
        if (_SqlConnection.State == ConnectionState.Closed) {
            _SqlConnection.Open();
        }

        if (_SqlConnection.State == ConnectionState.Broken) {
            _SqlConnection.Close();
            _SqlConnection.Open();
        }
    }

    public void ConnectionClose() {
        if (_SqlConnection.State == ConnectionState.Broken) {
            _SqlConnection.Close();
        }

        if (_SqlConnection.State == ConnectionState.Open) {
            _SqlConnection.Close();
        }
    }
    
}