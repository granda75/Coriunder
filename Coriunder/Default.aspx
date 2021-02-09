<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Coriunder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
            <div id="ordersDetailsId" style="height: 383px">
                <h1 style="color:green">Order details</h1>
                <h2>Pay for Purchase </h2>
                <hr>
            <table>
                <tr>
                    <td style="border:solid;">Total</td><td></td>
                    
                    <td>
                        <asp:Label ID="lblOrderTotal" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                    <td>
                        In case you wish to make changes to your order, please click Back to return to the merchant's site to adjust your order.
                    </td>
                    
                </tr>
            </table>
             <br>
            <br>
            <div>
                <asp:Button ID="btnPayments" runat="server" Text="Payments" OnClick="btnPayments_Click" /> 
            </div>
        </div>
    </div>

</asp:Content>
