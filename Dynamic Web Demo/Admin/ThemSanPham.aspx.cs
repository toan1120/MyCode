using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ThemSanPham : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LayDanhMucSanPham();
        }
    }

    protected void LayDanhMucSanPham()
    {
        DataAccess dataAccess = new DataAccess();
        dataAccess.MoKetNoiCSDL();

        string sql = $"SELECT * FROM DanhMuc";

        DataTable dataTable = dataAccess.LayBangDuLieu(sql);

        //  data binding
        this.ddlDanhMuc.DataTextField = "Ten";
        this.ddlDanhMuc.DataValueField = "Id";
        this.ddlDanhMuc.DataSource = dataTable;
        this.ddlDanhMuc.DataBind();

        dataAccess.DongKetNoiCSDL();
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        DataAccess dataAccess = new DataAccess();

        dataAccess.MoKetNoiCSDL();

        string tenSanPham = tbTenSanPham.Text;
        int idDanhMuc = int.Parse(ddlDanhMuc.SelectedValue);
        int giaSanPham = int.Parse(tbGia.Text);
        string hinhAnhSanPham = UpLoadHinhAnh();
        string mieuTaSanPham = tbMieuTa.Text;

        string sql = $@"
            INSERT INTO SanPhamm
            VALUES(N'{tenSanPham}', {idDanhMuc}, {giaSanPham}, '{hinhAnhSanPham}', N'{mieuTaSanPham}')";

        int soDongTacDong = dataAccess.ThucThiCauLenhSql(sql);

        if (soDongTacDong > 0)
        {
            XoaDuLieuCuaCacControl();
            ltThongBao.Text = "<p>Sản phẩm đã vào giỏ hàng :)</p>";
        }
        else
        {
            ltThongBao.Text = "<p>Thêm không được bạn eeii :(</p>";
        }

        dataAccess.DongKetNoiCSDL();
    }

    protected string UpLoadHinhAnh()
    {
        if (fuHinhAnh.HasFile)
        {
            //  đường dẫn thư mục hinhanh
            string thuMucHinhAnh = Server.MapPath("~/Hinhanh/");
            // lấy Tên file hình ảnh được upload
            string tenFileHinhAnhDuocUpload = fuHinhAnh.FileName;
            //ra tên đường dẫn hình ảnh được lưu
            string duongDanHinhAnhDuocLuu = thuMucHinhAnh + tenFileHinhAnhDuocUpload;
            // gọi ra phương thức SaveAs để lưu hình ảnh được upload lên vào thư mục hinhanh
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