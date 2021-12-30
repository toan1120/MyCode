<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DanhSachSanPham.aspx.cs" Inherits="Admin_DanhSachSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Danh Sách Sản Phẩm</title>

    <style>
        .tieu-de-trang{
            color:green;
            font-size:20px;
            font-weight:bold;
        }
        .danh-sach-san-pham{
            border-collapse:collapse;
            width:100%;
            font-size:13px;
        }
        .danh-sach-san-pham th{
            border:1px solid black;
            background-color:cornflowerblue;
            text-align:left;
            padding:8px;
        }
        .danh-sach-san-pham td{
            border:1px solid black;
            text-align:left;
            padding:8px;          
        }
        .danh-sach-san-pham tr:nth-child(even){
            background-color:lightgrey;
        }


    </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--Ten san pham -->
    <p class="tieu-de-trang">
        Danh Sách Sản Phẩm
    </p>

    <table class="danh-sach-san-pham">
        <tr>
            <th> Hình ảnh</th>
            <th> Tên Sản Phẩm</th>
            <th> Danh Mục</th>
            <th> Giá</th>
            <th> Chức Năng</th>          
        </tr>
        <asp:Repeater ID="rptDanhSachSanPham" runat="server">
            <ItemTemplate>
                <tr>
                    <td style="width:60px; text-align:center">
                        <img src="../Hinhanh/<%# Eval("HinhAnh") %>" style="width:50px" />
                    </td>
                    <td> <%# Eval("Ten") %></td>
                    <td><%# Eval("TenDanhMuc") %></td>
                    <td><%# Eval("Gia") %></td>
                    <td style="width:70px; text-align:center">
                        <a href="SuaSanPham.aspx?idSanPham=<%# Eval("Id") %>">Sửa</a>
                        <a href="#">Xóa</a>
                    </td>
                </tr>

            </ItemTemplate>

        </asp:Repeater>
       
    </table>

    <p>
        <a href="ThemSanPham.aspx">Thêm Sản Phẩm</a>
    </p>

</asp:Content>

