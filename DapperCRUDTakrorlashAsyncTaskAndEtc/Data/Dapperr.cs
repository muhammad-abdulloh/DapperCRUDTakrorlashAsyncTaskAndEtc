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
        private readonly IDbConnection db; 
        public Dapperr()
        {
            db = GetConnection();
        }
        async Task IDapper.CreateAsync<T>(string query, DynamicParameters pars)
        {
            await db.QueryAsync<T>(query, param: pars);
        }

        public async  Task DeleteAsync<T>(string query, DynamicParameters pars)
        {
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

            IEnumerable<T> results = await db.QueryAsync<T>(query,param: pars, commandType : cmdType);
            return results;
        }


        public IDbConnection GetConnection()
        {
            return new SqlConnection(Constants.Constants.CONNECTION_STRING);   
        }

        public async Task UpdateAsync<T>(string query, DynamicParameters pars)
        {

            await db.QueryAsync<T>(query, param: pars);

        }

        public async Task<T> GetAsync<T>(string query, DynamicParameters pars, CommandType cmdType = CommandType.StoredProcedure)
        {
            
            IEnumerable<T> results = await db.QueryAsync<T>(query, param: pars, commandType: cmdType);
            return  results.FirstOrDefault();
        }
    }
}
