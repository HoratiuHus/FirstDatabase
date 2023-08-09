using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Collections;

namespace DataAccess.DatabaseAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;
    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadDataAsync<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure); // Talk to our connection, execute the stored procedure
                                                       // you have the parameters and you have to store the procedure
                                                       // it is gonna return an IEnumerable of type <T>
    }

    public async Task<(IEnumerable<T>, IEnumerable<V>)> LoadDataAsync<T, V, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        var result =  connection.QueryMultiple(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure); // Talk to our connection, execute the stored procedure
                                                       // you have the parameters and you have to store the procedure
                                                       // it is gonna return an IEnumerable of type <T>

        var t = result.Read<T>().ToList();
        var v = result.Read<V>().ToList();
        return (t, v);
    }

    public async Task SaveDataAsync<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure); //Talks to our connection .....
                                                       // and now the stored procedure is savedata
                                                       // and then we say it is really a command and not just sql text
    }
}
