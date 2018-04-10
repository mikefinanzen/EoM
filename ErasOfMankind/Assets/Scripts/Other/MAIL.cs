using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public static class MAIL {

    public static void SEND(string subject, string message) {

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(GooglePlayController.instance != null ? GooglePlayController.instance.getMail() : "unknown@erasofmankind.de");
        mail.To.Add("erasofmankinderror@gmail.com");
        mail.Subject = subject;
        mail.Body = message;

        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("erasofmankinderror@gmail.com", "YtwaFT].w5P2") as ICredentialsByHost;
        smtp.EnableSsl = true;

        ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                    return true;
                };
        try {
            smtp.Send(mail);
            UnityEngine.Debug.Log("MAIL SEND");
        } catch (Exception e) {
            UnityEngine.Debug.Log(string.Format("MAIL EXCEPTION: {0}", e));
        }

    }
}