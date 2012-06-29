using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using CommonDomain.Core;

namespace CommonDomain.Persistence.EventStore
{
    public class SqlServerCommandRepository : ICommandRepository
    {
        private readonly string _connectionString;


        public SqlServerCommandRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TCommand GetById<TCommand>(Guid commitId) where TCommand :  ICommand
        {
            throw new NotImplementedException();
        }

        public bool IsExecuted(Guid commitId)
        {
            //Quick 'n dirty...
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("Select * from Commands where CommitId=@CommitId and IsExecuted=1");
                cmd.Parameters.AddWithValue("@CommitId", commitId);

                connection.Open();
                var NbLine = cmd.ExecuteNonQuery();
                connection.Close();
                return NbLine > 0;
            }
        }

        public void Save(ICommand command)
        {
            //Quick 'n dirty...
            using (var connection = new SqlConnection(_connectionString))
            {
                byte[] payLoad;
                
                using (var stream = new MemoryStream())
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(stream,command);
                    payLoad = stream.ToArray();
                }

                //var cmd = connection.CreateCommand();
                var cmd = new SqlCommand("INSERT INTO Commands (CommitId,CommitStamp,IsExecuted, PayLoad) Values (@CommitId, @CommitStamp,0, @PayLoad)", connection);
                cmd.Parameters.AddWithValue("@CommitId", command.CommitId) ;
                cmd.Parameters.AddWithValue("@CommitStamp", DateTime.Now) ;
                cmd.Parameters.AddWithValue("@PayLoad", payLoad);

                connection.Open();
                cmd.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        public void SaveAsExecuted(ICommand command)
        {
            //Quick 'n dirty...
            using (var connection = new SqlConnection(_connectionString))
            {
                //var cmd = connection.CreateCommand();
                var cmd = new SqlCommand("Update Commands set IsExecuted=1 where CommitId = @CommitId", connection);
                cmd.Parameters.AddWithValue("@CommitId", command.CommitId);
                
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
