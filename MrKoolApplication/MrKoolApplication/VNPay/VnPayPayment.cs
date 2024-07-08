using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
namespace MrKoolApplication.VNPay;
public class VnPayPayment
{
    private string vnp_TmnCode = "P33EJ7K2";
    private string vnp_HashSecret = "5EY4VJEE82EJWYVWNK1X5N51V7CWN3A2";
    private string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
    private string vnp_Returnurl = "https://serverswd.ddnsking.com/vnpay_return";

    public string CreatePaymentUrl(string orderId, decimal amount, string orderInfo)
    {
        var vnpayData = new Dictionary<string, string>
        {
            {"vnp_Version", "2.0.0"},
            {"vnp_Command", "pay"},
            {"vnp_TmnCode", vnp_TmnCode},
            {"vnp_Amount", ((int)(amount * 100)).ToString()},
            {"vnp_CurrCode", "VND"},
            {"vnp_TxnRef", orderId},
            {"vnp_OrderInfo", orderInfo},
            {"vnp_OrderType", "other"},
            {"vnp_Locale", "vn"},
            {"vnp_ReturnUrl", vnp_Returnurl},
            {"vnp_IpAddr", GetIpAddress()}
        };

        var vnpayUrl = vnp_Url + "?" + BuildQuery(vnpayData) + "&vnp_SecureHash=" + ComputeHash(vnpayData);
        return vnpayUrl;
    }

    private string GetIpAddress()
    {
        return "127.0.0.1";
    }

    private string BuildQuery(Dictionary<string, string> data)
    {
        var query = new StringBuilder();
        foreach (var item in data)
        {
            query.Append(System.Web.HttpUtility.UrlEncode(item.Key) + "=" + System.Web.HttpUtility.UrlEncode(item.Value) + "&");
        }
        return query.ToString().TrimEnd('&');
    }

    private string ComputeHash(Dictionary<string, string> data)
    {
        var query = BuildQuery(data);
        var hash = new HMACSHA512(Encoding.UTF8.GetBytes(vnp_HashSecret));
        var hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(query));
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }

    public bool ValidateSignature(Dictionary<string, string> vnpayData)
    {
        var receivedHash = vnpayData["vnp_SecureHash"];
        vnpayData.Remove("vnp_SecureHash");

        var computedHash = ComputeHash(vnpayData);
        return receivedHash == computedHash;
    }
}
