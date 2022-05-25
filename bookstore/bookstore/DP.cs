﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace bookstore
{
    public class DP
    {
        private static DP instance;

        public static DP Instance
        {
            get
            {
                if (instance == null)
                    instance = new DP();
                return DP.instance;
            }
            private set { DP.instance = value; }
        }

        private DP() { }


        private string connectionSTR = @"Data Source=NAM-PC;Initial Catalog=QLNS;Integrated Security=True";


        public DataTable ExecuteQuery(string query, object[] paramater = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] lisrPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisrPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }


        public int ExecuteNonQuery(string query, object[] paramater = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] lisrPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisrPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }


        public object ExecuteScalar(string query, object[] paramater = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] lisrPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisrPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }


        public DataSet ExecuteQueryList(string query, object[] paramater = null)
        {
            DataSet data = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] lisrPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisrPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
    }
}
