using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Khai báo lớp dataaccess
/// </summary>
public class DataAccess
{
    SqlConnection connection;
     
    //Mowe kết nối đến CSDL
    public void MoKetNoiCSDL()
    {
        connection = new SqlConnection();

        connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                        AttachDbFilename=""E:\Học về web\Dynamic Web 3\Dynamic Web Demo\App_Data\Database.mdf"";
                                        Integrated Security=True";

        connection.Open();
    }
    public DataTable LayBangDuLieu(string sql)
    {
        SqlDataAdapter adapter = new SqlDataAdapter(sql, this.connection);

        DataTable dataTable = new DataTable();

        // Thực thi câu lệnh sql, điền dữ liệu vào dataTable
        adapter.Fill(dataTable);

        return dataTable;
    }

    public int ThucThiCauLenhSql(string sql)
    {
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = this.connection;
        cmd.CommandText = sql;

        // Thực thi câu lệnh sql, trả về số dòng tác động
        return cmd.ExecuteNonQuery();
    }

    // Đóng kết nối đến CSDL
    public void DongKetNoiCSDL()
    {
        // Kiểm tra tình trạng kết nối đến CSDL
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }
}