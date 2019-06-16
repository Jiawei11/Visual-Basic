Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Public Class Form1
    Private Sub from_close() Handles Me.FormClosing
        Dim Url As New Uri("https://localhost/web/test.php")
        Dim web As New System.Net.WebClient()
        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf cate)
        web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        Dim res = web.UploadData(Url, "POST", System.Text.Encoding.ASCII.GetBytes("vb=" & "I like vb.net"))
    End Sub

    Private Function cate() As Boolean
        Return True
    End Function
End Class
