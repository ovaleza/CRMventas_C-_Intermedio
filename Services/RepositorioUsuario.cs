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
    public interface IUserRepository {
        void UserInsert(User user);
        User UserById(string id);
        void UserUpdate(User user);
        void UserDelete(string id);
        Task<IEnumerable<User>> UserList();
    }

    public class UserRepository: IUserRepository
    {
        private readonly string connectionString;
        public List<User> listUsers = new List<User>();
        //public UserList list = new UserList();

        public UserRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void UserInsert(User user)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"Insert users (name ,type , email, username, password, passwordconfirm, active) values" +
                                                    $" (@Name,@Type,@Email,@Username,@Password,@PasswordConfirm,@Active)";
                    conn.Query(comando, user);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }
        public void UserUpdate(User user)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"update users set name=@Name, type=@Type, email=@Email, username=@Username, " +
                                        $"password=@Password, passwordconfirm=@Passwordconfirm, active=@Active";
                    conn.Query(comando, user);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }

        public void UserDelete(string Id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    int id2 = Int32.Parse(Id);
                    string comando = $"delete users where id={id2}";
                    conn.Query(comando);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }

        public User UserById(string id)
        {
            User user = new(); 
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    string comando = $@"select id, name, email, username, type, Active, File from users";
                    var uno = conn.Query(comando).AsList();
                    if (uno != null)
                    {
                        User user2 = new()
                        {
                            Id = uno[0],
                            Name = uno[1],
                            Email = uno[2],
                            UserName = uno[3],
                            Type = uno[4],
                            Active = uno[5],
                            File = uno[6]
                        };
                        user = user2;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
            return user;
        }

        public async Task<IEnumerable<User>> UserList()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<User>(@"Select * from Users");

        }
        //public UserList UserList2()
        //{
        //    UserList userList = new UserList();
        //    using (var conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {

        //            conn.Open();
        //            string sql = "select id,name,email,username,type,Active,File from users";
        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        User user = new() { 
        //                            Id = reader.GetString(0),
        //                            Name = reader.GetString(1),
        //                            Email = reader.GetString(2),
        //                            UserName = reader.GetString(3),
        //                            Type = reader.GetString(4),
        //                            Active = reader.GetBoolean(5),
        //                            File = reader.GetString(6)
        //                        };
        //                    userList.Users.Add(user);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("Hubo un error");
        //        }
        //    }
        //    return userList;
        //}
    }
}
