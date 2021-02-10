<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Coriunder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <div id="paymentsId">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        Cardholder Name: *
                    </div>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtCardholderName" runat="server"></asp:TextBox>
                       <%-- <input id="txtCardholderName" type="text" />--%>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        Email Address: 
                    </div>
                    <div class="col-md-12">
                         <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                     
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        Card Number: *
                    </div>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
                       
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="Label1" runat="server" Text="Exp Date: *"></asp:Label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:Label ID="Label2" runat="server" Text="CVV:"></asp:Label> 
                    </div>
                    <div class="col-md-12">
                        <asp:DropDownList id="ddlExpMonth" runat="server"></asp:DropDownList> &nbsp
                        <asp:DropDownList id="ddlExpYear" runat="server"></asp:DropDownList>  &nbsp&nbsp&nbsp&nbsp
                        <asp:TextBox ID="txtCvv" runat="server"></asp:TextBox>
                    </div>
                </div>    
                <div class="row">
                    <div class="col-md-12">
                        Address 1:
                    </div>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
                        <asp:Label ID="lblZipCode" runat="server" Text="Zip Code:"></asp:Label>    
                    </div>
                    
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                     <div class="col-md-12">
                         <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
                     </div>
                     <div class="col-md-12">
                        
                         <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>
                     </div>
                    
                </div>
                 <div class="row">
                    <div class="col-md-12">
                        Phone Number: *
                    </div>
                    <div class="col-md-12">
                         <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                       
                    </div>
                </div>
                <%--<div class="row">
                    <br>
                </div>--%>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Button id="btnContinue" style=" width:350px;color:white; background-color:#578623;" runat="server" Text="CONTINUE" OnClick="btnContinue_Click" />
                    </div>     
                </div>
            </div>
        </div>  

</asp:Content>
