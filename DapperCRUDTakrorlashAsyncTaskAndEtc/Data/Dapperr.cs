using Dapper;
using DapperCRUDTakrorlashAsyncTaskAndEtc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DapperCRUDTakrorlashAsyncTaskAndEtc.Data
{
    public class Dapperr : IDapper
    {
        async Task IDapper.CreateAsync<T>(string query, DynamicParameters pars)
        {
            var db = GetConnection();

            await db.QueryAsync<T>(query, param: pars);
        }

        async  Task IDapper.DeleteAsync<T>(string query, DynamicParameters pars)
        {
            var db = GetConnection();

            await db.QueryAsync<T>(query, param: pars);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        // asinxron funksiyamiz tayyor
        public async Task<IEnumerable<T>> GetAllAsync<T>(string query, DynamicParameters pars, CommandType cmdType = CommandType.StoredProcedure)
        {
            // databasa bilan uladik
            IDbConnection db =  GetConnection();

            IEnumerable<T> results = await db.QueryAsync<T>(query,param: pars, commandType : cmdType);
            return results;
        }


        public IDbConnection GetConnection()
        {
            return new SqlConnection(Constants.Constants.CONNECTION_STRING);   
        }

        async Task IDapper.UpdateAsync<T>(string query, DynamicParameters pars)
        {
            var db = GetConnection();

            await db.QueryAsync<T>(query, param: pars);

        }

        public async Task<T> GetAsync<T>(string query, DynamicParameters pars, CommandType cmdType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetConnection();

            IEnumerable<T> results = await db.QueryAsync<T>(query, param: pars, commandType: cmdType);
            return results.FirstOrDefault();
        }
    }
}
