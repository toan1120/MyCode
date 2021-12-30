<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SuaSanPham.aspx.cs" Inherits="Admin_SuaSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Sửa Sản Phẩm</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="frmSuaSanPham" runat="server">
        <div>
            <p style="font-weight:bold">Hình ảnh</p>
            <asp:FileUpload ID="fuHinhAnh" runat="server" />
        </div>
        <div>
            <p style="font-weight:bold">Tên sản phẩm:</p>
            <asp:TextBox ID="tbTenSanPham" runat="server" style="width:500px"></asp:TextBox>
        </div>
        <div>
            <p style="font-weight:bold">Danh mục sản phẩm</p>
            <asp:DropDownList ID="ddlDanhMuc" runat="server" style="width:200px"></asp:DropDownList>
        </div>
        <div>
            <p style="font-weight:bold">Giá:</p>
            <asp:TextBox ID="tbGia" runat="server" style="width:200px"></asp:TextBox>
        </div>
        <div>
            <p style="font-weight:bold">Miêu tả</p>
            <asp:TextBox ID="tbMieuTa" runat="server" TextMode="MultiLine" style="width:500px" Rows ="8" Columns="65"></asp:TextBox>
        </div>
        <div style="margin-top:20px">
            <asp:Literal ID="ltThongBao" runat="server"></asp:Literal>
            <asp:Button ID="btSua" runat="server" Text="Sửa" OnClick="btSua_Click" />

        </div>


    </form>


</asp:Content>

