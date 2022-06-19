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
    public interface IClientRepository
    {
        void ClientInsert(Client client);
        Task<IEnumerable<Client>> ClientList();
        void TclientInsert(Tclient tclient);
        Task<IEnumerable<Tclient>> TclientList();
        void TiterInsert(Titer titer);
        Task<IEnumerable<Titer>> TiterList();
        void TtranInsert(Ttran ttran);
        Task<IEnumerable<Ttran>> TtranList();
    }

    public class ClientRepository : IClientRepository
    {
        private readonly string connectionString;
        private readonly string elusuario = "Admin";
        public ClientRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void ClientInsert(Client client)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"Insert clients (name ,address ,phone ,email ,type ,active ) values" +
                                                    $" (@Name,@Address,@Phone,@Email,@Type,@Active)";
                    conn.Query(comando, client);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }
        public async Task<IEnumerable<Client>> ClientList()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<Client>(@"Select * from Clients order by id desc");

        }
        public void TclientInsert(Tclient tclient)
        {
            tclient.User = elusuario;
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"Insert tclients (name,[user],note) values" +
                                                    $" (@Name,@User,@Note)";
                    conn.Query(comando, tclient);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }
        public async Task<IEnumerable<Tclient>> TclientList()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<Tclient>(@"Select * from Tclients order by id desc");

        }

        public void TiterInsert(Titer titer)
        {
            titer.User = elusuario;
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"Insert titeractions (name ,[user] ,Note ) values" +
                                                    $" (@Name,@User,@Note)";
                    conn.Query(comando, titer);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }
        public async Task<IEnumerable<Titer>> TiterList()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<Titer>(@"Select * from Titeractions order by id desc");

        }

        public void TtranInsert(Ttran ttran)
        {
            ttran.User = elusuario;
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"Insert ttransactions (name ,[user] ,Note ) values" +
                                                    $" (@Name,@User,@Note)";
                    conn.Query(comando, ttran);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }
        public async Task<IEnumerable<Ttran>> TtranList()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<Ttran>(@"Select * from Ttransactions order by id desc");

        }

    }
}