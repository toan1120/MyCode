<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrangDanhMuc.aspx.cs" Inherits="TrangDanhMuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        Trang danh mục sản phẩm
    </title>
    <style>
        .page-title{
            color:green;
            font-size:20px;
            font-weight:bold;
        }
        .danh-sach-san-pham{
            display:flex;
            flex-wrap:wrap;
        }
        .san-pham{
            width:25%;
            margin-bottom:40px;
        }
        .thong-tin-san-pham{
            padding:10px;
        }
        .hinh-anh-san-pham{
            margin-bottom:10px;
        }
        .hinh-anh-san-pham img{
            width:80%;
        }
        .ten-san-pham{
            font-size:15px;
        }
        .gia-san-pham{
            font-size:15px;
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <!--Tiêu đề trang -->
    <p class="page-title">
        Danh sách sản phẩm
    </p>

    <!--Danh sách sản phẩm-->
    <div class="danh-sach-san-pham">

        <asp:Repeater ID="rptDanhSachSanPham" runat="server">
            <ItemTemplate>
                
        <!-- sản phẩm 1-->
        <div class="san-pham">

            <!--Thông tin san phẩm-->
          <div class="thong-tin-san-pham" >
            
            <!--Hình ảnh sản phẩm-->
            <div class="hinh-anh-san-pham">
                <img src="Hinhanh/<%# Eval("HinhAnh") %>"/>
            </div>

            <!--Tên sản phẩm-->
              <p class="ten-san-pham">
                  <a href="TrangSanPham.aspx?idSanPham=<%# Eval("Id") %>">
                      <%# Eval("Ten") %>
                     
                  </a> 
              </p>
                            
            <!--Gia Sản Phẩm-->
              <p class="gia-san-pham">
                  <b> Giá</b>:<%# Eval("Gia") %>đ              
              </p>
               
            </div>
         </div>
            </ItemTemplate>

        </asp:Repeater>

    </div>
    
</asp:Content>

