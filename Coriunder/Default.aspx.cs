using Coriunder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coriunder
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillCountryDdl();
        }

        private void FillCountryDdl()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");

            //IL Israel
            //RU Russia
            //AU Australia
            //AT Austria
            //DK Denmark

            DataRow row = dt.NewRow();
            row["Id"] = "IL";
            row["Name"] = "Israel";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["Id"] = "RU";
            row["Name"] = "Russia";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["Id"] = "AT";
            row["Name"] = "Austria";
            dt.Rows.Add(row);

            ddlCountry.DataSource = dt;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "Id";
            ddlCountry.DataBind();
        }

        protected void btnPayments_Click(object sender, EventArgs e)
        {
            // Response.Redirect("PaymentDetails.aspx");
            // CompanyNum

            // TransType 2 Transaction type: 0 = Debit Transaction 1 = Authorization only 2 = Capture 3 = Charge stored credit card(pass the stored card ID in CcStorageID field)

            //CardNum Credit card number to be charged    20  Yes 3
            //ExpMonth Expiration month(MM)   2   Yes 3
            //ExpYear Expiration year(YYYY)  4   Yes 3

            //Member Cardholder name as it appears on the card   50  Yes 3
            //TypeCredit 2    1 = Debit 8 = Installments 0 = Refund   1   Yes
            //Payments    Number of installments, 1 for regular transaction   2   Yes
            //Amount  Amount to be charged, e.g. 199.95   10  Yes
            //Currency    0 = ILS(Israel New Shekel)
            //1 = USD(US Dollar)
            //2 = EUR(Euro)
            //3 = GBP(UK Pound Sterling)

            //CVV2    3 - 5 digits from back of the credit card 5   Optional
            //Email

            //PhoneNumber Cardholder phone number 20  Optional
            //ClientIP
            //BillingAddress1 1st Address line
            //BillingCity City name   60  Optional
            //BillingZipCode
            //BillingCountry
            //Signature


        }
        public string GetIPAddress()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            return ipAddress.ToString();
        }

        private void SilentPostCharge(TransactionsData data)
        {
           
            //------------- building url string to send
            String sendStr;
            sendStr = "https://process.coriunder.cloud/member/remote_charge.asp?";
            sendStr += "CompanyNum=" + HttpUtility.UrlEncode(data.CompanyNumber) + "&";
            sendStr += "TransType=" + HttpUtility.UrlEncode(Convert.ToInt32(TransactionType.ChargeCC).ToString()) + "&";
            sendStr += "CardNum="   + HttpUtility.UrlEncode(data.CardNumber);
            sendStr += "ExpMonth="  + HttpUtility.UrlEncode(data.Month.ToString());
            sendStr += "ExpYear="   + HttpUtility.UrlEncode(data.Year.ToString());
            sendStr += "Member="    + HttpUtility.UrlEncode(data.CardHolderName.ToString());
            sendStr += "TypeCredit=" + HttpUtility.UrlEncode(TypeCredit.Refund.ToString());
            sendStr += "Payments=" + HttpUtility.UrlEncode("1");            // 1 - for regular transaction
            sendStr += "Amount=" + HttpUtility.UrlEncode(data.Amount.ToString());
            sendStr += "Currency=" + HttpUtility.UrlEncode(data.Currency.ToString());
            sendStr += "CVV2=" + HttpUtility.UrlEncode(data.Cvv.ToString());
            sendStr += "Email=" + HttpUtility.UrlEncode(data.Email);
            sendStr += "PhoneNumber=" + HttpUtility.UrlEncode(data.Phone);
            string ipAddress = GetIPAddress();
            sendStr += "BillingAddress1=" + HttpUtility.UrlEncode(data.BillingAddress);
            sendStr += "BillingCity=" + HttpUtility.UrlEncode(data.City);
            sendStr += "BillingZipCode=" + HttpUtility.UrlEncode(data.ZipCode);
            sendStr += "BillingCountry=" + HttpUtility.UrlEncode(data.CountryCode);

            string refTransID = "1234";
            //Signature for verifying the authenticity of the request parameters.
            //Field values to use: CompanyNum + TransType + TypeCredit + Amount + Currency + CardNum + RefTransID + PersonalHashKey
            //Refer to BASIC INFO SIGNATURE for detailed explanation.
            //"1234567" + "1" + "1" + "5.4" + "1" + "4580000000000000" + "1234" + "AU7E468HNF"

            //Signature 
            string signature = data.CompanyNumber + TransactionType.ChargeCC.ToString() + TypeCredit.Refund.ToString() +
                               data.Amount.ToString() + data.Currency.ToString() + data.CardNumber + refTransID + data.PersonalHashKey;
            string shaSignature = Signature.GenerateSHA256(signature);
            string encodedTo64 = Signature.EncodeTo64(shaSignature);
            sendStr += "Signature=" + HttpUtility.UrlEncode(encodedTo64);
   
            //------------- creating the request
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(sendStr);
            webReq.Method = "GET";
            //------------- checking the response
            try
            {
                HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(webRes.GetResponseStream());
                String resStr = sr.ReadToEnd();
                Response.Write("Response String: " + resStr + "<br />");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            TransactionsData data = FillTransactionsData();
            SilentPostCharge(data);
        }

        private TransactionsData FillTransactionsData()
        {
            TransactionsData data = new TransactionsData();
            data.CompanyNumber = "3355796";    //merchant id
            data.CardHolderName = txtCardholderName.Text;
            data.Email = txtEmail.Text;
            data.CardNumber = txtCardNumber.Text;
            data.Month = Convert.ToInt32(ddlExpMonth.SelectedValue);
            data.Year = this.ddlExpYear.SelectedValue;
            data.Cvv = txtCvv.Text;
            data.BillingAddress = txtAddress.Text;
            data.City = txtCity.Text;
            data.ZipCode = txtZipCode.Text;
            data.CountryCode = ddlCountry.SelectedValue;
            data.Phone = txtPhone.Text;
            data.Amount = 100;          //Hardcoded for the exam, the value must be transferred from Order details screen
            data.PersonalHashKey = "7ZIQHB7YYN";
            return data;
        }
    }
}