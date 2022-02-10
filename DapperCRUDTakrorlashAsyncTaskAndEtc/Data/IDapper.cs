using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUDTakrorlashAsyncTaskAndEtc.Data
{
    public interface IDapper : IDisposable   
    {
        #region qo'llanma
        /// <summary>
        /// Bu joyda T ixtiyoriy tip ya'ni biz hozir ixtiyoriy tip uchun ishledigon Generic funksiya yozyabmiz
        /// </summary>
        /// <typeparam name="T"></typeparam> Ixtiyoriy type
        /// <param name="query"></param> Biz jo'natmoqchi bo'lgan query
        /// <param name="pars"></param> ana shu queryning bir nechta parametrlari
        /// <param name="cmdType"></param> va shu larning type laari text, structuredProtsedur, Table va shunga o'xshash
        /// <returns></returns>
        /// 

        // Task qo'ymasak shunchaki T tipda bo'ladi Asinxron funksiya bo'lmaydi

        #endregion
        
        Task CreateAsync<T>(string query, DynamicParameters pars);
        Task UpdateAsync<T>(string query, DynamicParameters pars);
        Task<T> GetAsync<T>(string query, DynamicParameters pars, CommandType cmdType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> GetAllAsync<T>(string query, DynamicParameters pars, CommandType cmdType = CommandType.StoredProcedure);
        Task DeleteAsync<T>(string query, DynamicParameters pars);
        
        // databazani ulash uchun method
        IDbConnection GetConnection();
    }
}
