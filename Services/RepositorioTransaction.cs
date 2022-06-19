using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using CRMventas.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CRMventas.Services
{
    public interface ITranRepository
    {
        void TranInsert(Transaction tran);
        Task<IEnumerable<Transaction>> TranList();
        void IterInsert(Iteraction iter);
        Task<IEnumerable<Iteraction>> IterList();
    }

    public class TranRepository : ITranRepository
    {
        private readonly string connectionString;
        private readonly string elusuario = "Admin";
        public TranRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void TranInsert(Transaction tran)
        {
            tran.User = elusuario;
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"Insert transactions (clientId ,Type, Date,amount ,[user] , note , status ) values" +
                                                    $" (@ClientId, @Type,@Date,@Amount,@User,@Note,@Status)";
                    conn.Query(comando, tran);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }
        public async Task<IEnumerable<Transaction>> TranList()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<Transaction>(@"Select a.*,b.Name as Client from Transactions a left outer join Clients b on a.ClientId=b.Id order by id desc");
        }
        public void IterInsert(Iteraction iter)
        {
            iter.User = elusuario;
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"Insert iteractions (clientId ,Type, Date ,[user] , note , status ) values" +
                                                    $" (@ClientId,@Type,@Date,@User,@Note,@Status)";
                    conn.Query(comando, iter);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }
        public async Task<IEnumerable<Iteraction>> IterList()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<Iteraction>(@"Select a.*,b.Name as Client from Iteractions a left outer join Clients b on a.ClientId=b.Id order by id desc");

        }
    }
}