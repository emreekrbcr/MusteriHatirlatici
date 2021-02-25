using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.AccessAdonet
{
    public class DBConnection //Saygıdeğer DBConnection. Hata ile ilgili günahını aldım. Hakkını helal et reis :):):)
    {
        private readonly string _connectionString;
        private static DBConnection _instance;
        private OleDbConnection _connection;

        private DBConnection() //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Buraya bak
        {
            //Veritabanına dışarıdan manuel giriş yapmasınlar diye .mdb uzantısını .veritabani olarak değiştirdim <<<<<
            _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database\MusteriHatirlaticiDB.veritabani";
        }

        public static DBConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance=new DBConnection();
            }
            return _instance;
        }
        private OleDbConnection ConnectionControl()
        {
            _connection = new OleDbConnection(_connectionString);
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public OleDbCommand GetCommandAfterConCont(string sqlCommand)
        {
            OleDbCommand command=new OleDbCommand()
            {
                Connection = ConnectionControl(),
                CommandText = sqlCommand
            };
            return command;
        }
    }
}
