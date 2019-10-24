using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Data
{
    class ConnectData
    {
        public SQLiteConnection conn = new SQLiteConnection("Data Source=TaskGestor.sqlite;Version=3;");
        public void ConectarDbSqLite()
        {
            conn.Open();
        }
        public void DesconectarDbSqLite()
        {
            conn.Close();
        }
        public void CriarDbSqLite()
        {
            SQLiteConnection.CreateFile("TaskGestor.sqlite");
            SQLiteConnection m_dbConnection = new SQLiteConnection(conn);
            m_dbConnection.Open();
            string sql = " CREATE TABLE 'tasks' (                         ";
            sql += "    'id'    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,   ";
            sql += "    'name'    varchar(20) NOT NULL,                         ";
            sql += "    'description'    varchar(50),                                  ";
            sql += "    'date_begin'    datetime NOT NULL,                                 ";
            sql += "    'date_end'    datetime NOT NULL);                        ";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            //sql = "INSERT INTO [configuracoes] (id, type_alert, row_excel, column_excel, source_excel, title, time, numeroColuna) VALUES (1, 2, 3, 'A', 'Ex: C:/Planilha.xlsx', 'Tilulo do alerta', 1, 0)";
            //command = new SQLiteCommand(sql, m_dbConnection);
            //command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
    }
}
