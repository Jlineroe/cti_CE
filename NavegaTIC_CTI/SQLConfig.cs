using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;

namespace MIS.Utilities
{
    public class SQLConfig
    {
        public static SqlCommand ProcedureCommandRH(string DbConnectionString = null)
        {
            SqlConnection conex = new SqlConnection("Data Source=SQLAIB;Initial Catalog=RH;Persist Security Info=True;User ID=apps_user;Password=B0got0Qq.AIB;Connect Timeout=300");
            SqlCommand cmd = conex.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public static SqlCommand TextCommandRH(string DbConnectionString = null)
        {
            SqlConnection conex = new SqlConnection("Data Source=SQLAIB;Initial Catalog=RH;Persist Security Info=True;User ID=apps_user;Password=B0got0Qq.AIB;Connect Timeout=300");
            SqlCommand cmd = conex.CreateCommand();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        public static SqlCommand ProcedureCommandMIS(string DbConnectionString = null)
        {
            SqlConnection conex = new SqlConnection("Data Source=SQLAIB;Initial Catalog=MIS;Persist Security Info=True;User ID=apps_user;Password=B0got0Qq.AIB;Connect Timeout=300");
            SqlCommand cmd = conex.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public static SqlCommand TextCommandMIS(string DbConnectionString = null)
        {
            SqlConnection conex = new SqlConnection("Data Source=SQLAIB;Initial Catalog=MIS;Persist Security Info=True;User ID=apps_user;Password=B0got0Qq.AIB;Connect Timeout=300");
            SqlCommand cmd = conex.CreateCommand();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        public static SqlCommand ProcedureCommandCampData(string DbConnectionString = null)
        {
            SqlConnection conex = new SqlConnection("Data Source=SQLAIB;Initial Catalog=Camp_Data;Persist Security Info=True;User ID=sa;Password=AtlItSys01;Connect Timeout=300");
            SqlCommand cmd = conex.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public static SqlCommand TextCommandCampData(string DbConnectionString = null)
        {
            SqlConnection conex = new SqlConnection("Data Source=SQLAIB;Initial Catalog=Camp_Data;Persist Security Info=True;User ID=sa;Password=AtlItSys01;Connect Timeout=300");
            SqlCommand cmd = conex.CreateCommand();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        public static SqlCommand ProcedureCommandCMS13_TMP(string DbConnectionString = null)
        {
            SqlConnection conex = new SqlConnection("Data Source=SQLAIB;Initial Catalog=CMS13_TMP;Persist Security Info=True;User ID=sa;Password=AtlItSys01;Connect Timeout=300");
            SqlCommand cmd = conex.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public static SqlCommand TextCommandCMS13_TMP(string DbConnectionString = null)
        {
            SqlConnection conex = new SqlConnection("Data Source=SQLAIB;Initial Catalog=CMS13_TMP;Persist Security Info=True;User ID=sa;Password=AtlItSys01;Connect Timeout=300");
            SqlCommand cmd = conex.CreateCommand();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        //public static string ExecuteScalar(SqlCommand cmd)
        //{
        //    string valuestr = "";
        //    try
        //    {
        //        cmd.Connection.Open();
        //        valuestr = cmd.ExecuteScalar().ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("Referencia a objeto no establecida")) { }
        //        else
        //        {
        //            throw new Exception("Utilities.SQLConfig.ExecuteScalar(" + Funciones.getLineErr(ex) + "): " + ex.Message);
        //        }
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return valuestr;
        //}
        public static DataTable DataTableExecuteCommand(SqlCommand cmd)
        {
            DataTable table;
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Utilities.SQLConfig.DataTableExecuteCommand(" + Funciones.getLineErr(ex) + "): " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return table;
        }
        public static DataTable SetDataTableExecuteCommand(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            try
            {
                string NameTransaction = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                SqlTransaction tx;
                cmd.Connection.Open();
                tx = cmd.Connection.BeginTransaction(NameTransaction);
                try
                {
                    cmd.Transaction = tx;
                    SqlDataReader reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Utilities.SQLConfig.SetDataTableExecuteCommand(): {ex.Message}");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return table;
        }
    }
}