using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataAccess dataAccess = new DataAccess();

        dataAccess.MoKetNoiCSDL();

        string sql = "SELECT * FROM DanhMuc";
        DataTable dataTable = dataAccess.LayBangDuLieu(sql);

        //Thực hiện data Binding
        this.rptMenu.DataSource = dataTable;
        this.rptMenu.DataBind();

        dataAccess.DongKetNoiCSDL();

    }
}
