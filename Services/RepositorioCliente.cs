using System;
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
        public ClientList clientList();
        void TclientInsert(Tclient tclient);
        public TclientList tclientList();
        void TiterInsert(Titer titer);
        public TiterList titerList();
        void TtranInsert(Ttran ttran);
        public TtranList ttranList();

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
        public ClientList clientList()
        {
            ClientList listado = new ClientList();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = "select id,name ,address ,phone ,email ,type ,active,file from clients";
                    conn.Query<Client>(comando, conn);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }

            return listado;
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
        public TclientList tclientList()
        {
            TclientList listado = new TclientList();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = "select id,name ,[user] ,Note from tclients";
                    conn.Query<Tclient>(comando, conn);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }

            return listado;
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
        public TiterList titerList()
        {
            TiterList listado = new TiterList();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = "select id,name,[user],note from titeractions";
                    conn.Query<Tclient>(comando, conn);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
            return listado;
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
        public TtranList ttranList()
        {
            TtranList listado = new TtranList();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = "select id, name ,[user] ,Note from ttransactions";
                    conn.Query<Tclient>(comando, conn);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
            return listado;
        }


    }
}