using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SuaSanPham : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            LayDanhMucSanPham();
            LayThongTinSanPham();
        }
    }

    protected void LayDanhMucSanPham()
    {
        DataAccess dataAccess = new DataAccess();
        dataAccess.MoKetNoiCSDL();

        string sql = $"SELECT * FROM DanhMuc";

        DataTable dataTable = dataAccess.LayBangDuLieu(sql);
        
        this.ddlDanhMuc.DataTextField = "Ten";
        this.ddlDanhMuc.DataValueField = "Id";

        // Thực hiện data Bind
        this.ddlDanhMuc.DataSource = dataTable;
        this.ddlDanhMuc.DataBind();

        dataAccess.DongKetNoiCSDL();
    }

    protected void LayThongTinSanPham()
    {
        DataAccess dataAccess = new DataAccess();
        dataAccess.MoKetNoiCSDL();

        // Lấy id SanPham từ Query String 
        string idSanPham = Request.QueryString.Get("idSanPham");

        if (idSanPham != null)
        {
            string sql = $"SELECT * FROM SanPhamm WHERE Id = {idSanPham}";

            DataTable dataTable = dataAccess.LayBangDuLieu(sql);

            DataRow dataRow = dataTable.Rows[0];

            // gán dữ liệu 
            tbTenSanPham.Text = dataRow["Ten"].ToString();
            ddlDanhMuc.SelectedValue = dataRow["idDanhMuc"].ToString();
            tbGia.Text = dataRow["Gia"].ToString();
            tbMieuTa.Text = dataRow["MieuTa"].ToString();
        }

        dataAccess.DongKetNoiCSDL();
    }    
    protected void btSua_Click(object sender, EventArgs e)
    {
        DataAccess dataAccess = new DataAccess();

        dataAccess.MoKetNoiCSDL();

        // Lấy idSanPham từ Query String của URL
        string idSanPham = Request.QueryString.Get("idSanPham");

        string tenSanPham = tbTenSanPham.Text;
        int idDanhMuc = int.Parse(ddlDanhMuc.SelectedValue);
        int giaSanPham = int.Parse(tbGia.Text);
        string hinhAnhSanPham = UpLoadHinhAnh();
        string mieuTaSanPham = tbMieuTa.Text;

        string sql = $@"
            UPDATE SanPhamm
            SET
	            Ten = N'{tenSanPham}',
	            IdDanhMuc = {idDanhMuc},
	            Gia = {giaSanPham},
	            HinhAnh = '{hinhAnhSanPham}',
	            MieuTa = N'{mieuTaSanPham}'
            WHERE Id = {idSanPham}";

        int soDongTacDong = dataAccess.ThucThiCauLenhSql(sql);

        if (soDongTacDong > 0)
        {
            XoaDuLieuCuaCacControl();
            ltThongBao.Text = "<p>Sửa được rồi b êi !!!</p>";
        }
        else
        {
            ltThongBao.Text = "<p>Sửa thất bại làm lại now !!!</p>";
        }

        dataAccess.DongKetNoiCSDL();
    }

    protected string UpLoadHinhAnh()
    {
        if (fuHinhAnh.HasFile)
        {
            // đườngdẫn thư mục Hinhanh
            string thuMucHinhAnh = Server.MapPath("~/HinhAnh/");

            // Tênfile hình ảnh 
            string tenFileHinhAnhDuocUpload = fuHinhAnh.FileName;

            //đường dẫn hình ảnh được lưu
            string duongDanHinhAnhDuocLuu = thuMucHinhAnh + tenFileHinhAnhDuocUpload;

            // gọi phương thức SaveAs để lưu hình ảnh được upload lên vào thư mục hinhanh
            fuHinhAnh.SaveAs(duongDanHinhAnhDuocLuu);

            return tenFileHinhAnhDuocUpload;
        }
        else
        {
            return "";
        }
    }

    protected void XoaDuLieuCuaCacControl()
    {
        tbTenSanPham.Text = "";
        ddlDanhMuc.ClearSelection();
        tbGia.Text = "";
        tbMieuTa.Text = "";
    }

}