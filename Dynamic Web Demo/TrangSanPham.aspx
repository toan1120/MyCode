<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrangSanPham.aspx.cs" Inherits="TrangSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        Trang chi tiết sản phẩm
    </title>
    <style> 
        .ten-san-pham{
            color:forestgreen;
            font-size:20px;
            font-weight:bold;
        }
        .hinh-anh-san-pham{
            text-align:center;
        }
        .hinh-anh-san-pham img{
            width:350px;
        }
        .gia-san-pham{
            font-size:15px;
        }
        .gia-tri-san-pham{
            color:red;
        }
        .mieu-ta-san-pham{
            font-size:15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--Tên san pham-->
    <p class="ten-san-pham">
        <asp:Literal ID="ltTenSanPham" runat="server"></asp:Literal>
    </p>

    <!--Hình ảnh sản phẩm-->
    <div class="hinh-anh-san-pham">
        <asp:Image ID="imgHinhAnhSanPham" runat="server" ></asp:Image>
    </div>

    <!--Giá Sản phẩm-->
    <p class="gia-san-pham">
        <b>Giá: </b>
        <span class="gia-tri-san-pham">
            <asp:Literal ID="ltGiaSanPham" runat="server"></asp:Literal> đ 
        </span>
    </p>

    <!--Mieu tả sản phẩm-->
    <p class="mieu-ta-san-pham">
        <asp:Literal ID="ltMieuTaSanPham" runat="server"></asp:Literal>
    </p>

</asp:Content>

