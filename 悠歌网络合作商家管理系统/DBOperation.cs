﻿using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;

namespace 悠歌网络合作商家管理系统
{
    public class DBOperation
    {
        private const string connectstring = "Database='yg_db';Data Source='localhost';User Id='root';Password='1234';pooling=false ;charset=utf8";        /// <summary>
        /// 得到连接对象
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetConn()
        {
            MySqlConnection mysqlconn = new MySqlConnection(connectstring);
            return mysqlconn;
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Selectinfo(string sql)
        {
            MySqlConnection mysqlconn = null;
            MySqlDataAdapter sda = null;
            DataTable dt = null;
            try
            {
                mysqlconn = this.GetConn();
                mysqlconn.Open();
                sda = new MySqlDataAdapter(sql, mysqlconn);
                dt = new DataTable();
                sda.Fill(dt);
                mysqlconn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MyOperation.DebugPrint(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 增删改操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>执行后的条数</returns>
        public int AddDelUpdate(string sql)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                conn = this.GetConn();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
            catch (Exception ex)
            {
                MyOperation.DebugPrint(ex.Message);
                throw;
            }
        }
    }
}