using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrangDanhMuc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataAccess dataAccess = new DataAccess();
        dataAccess.MoKetNoiCSDL();

        string idDanhMuc = Request.QueryString.Get("idDanhMuc");

        string sql;

        if(idDanhMuc == null)
        {
            sql = "SELECT * FROM SanPhamm";
        }
        else
        {
            sql = $"SELECT * FROM SanPhamm WHERE IdDanhMuc = {idDanhMuc}";
        }
        DataTable dataTable = dataAccess.LayBangDuLieu(sql);

        this.rptDanhSachSanPham.DataSource = dataTable;
        this.rptDanhSachSanPham.DataBind();

        dataAccess.DongKetNoiCSDL();





    }
}