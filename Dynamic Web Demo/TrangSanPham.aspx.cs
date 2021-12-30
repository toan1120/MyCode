using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrangSanPham : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataAccess dataAccess = new DataAccess();
        dataAccess.MoKetNoiCSDL();

        //Lấy ID sp từ qurey
        string idSanPham = Request.QueryString.Get("idSanPham");

        if(idSanPham != null)
        {
            string sql = $"SELECT * FROM SanPhamm WHERE Id={idSanPham}";

            DataTable dataTable = dataAccess.LayBangDuLieu(sql);

            //Gans DL vao cac control
            ltTenSanPham.Text = dataTable.Rows[0]["Ten"].ToString();
            imgHinhAnhSanPham.ImageUrl = "HinhAnh/" + dataTable.Rows[0]["HinhAnh"].ToString();
            ltGiaSanPham.Text = dataTable.Rows[0]["Gia"].ToString();
            ltMieuTaSanPham.Text = dataTable.Rows[0]["MieuTa"].ToString();         
        }

        dataAccess.DongKetNoiCSDL();

    }
}