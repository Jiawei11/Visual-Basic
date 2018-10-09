Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "第一個數字"
        Label2.Text = "第二個數字"
        Label3.Text = "第三個數字"
        Button1.Text = "計算"
        Button2.Text = "重新輸入"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" OrElse TextBox2.Text = "" OrElse TextBox3.Text = "" Then
            MsgBox("請輸入三個數字在按下按鈕")
        ElseIf Asc(TextBox1.Text) >= 48 And Asc(TextBox1.Text) <= 57 And Asc(TextBox2.Text) >= 48 And Asc(TextBox2.Text) <= 57 And Asc(TextBox3.Text) >= 48 And Asc(TextBox3.Text) <= 57 Then
            Dim List As New List(Of Integer)
            List.Add(TextBox1.Text)
            List.Add(TextBox2.Text)
            List.Add(TextBox3.Text)
            If TextBox1.Text = List.Max Then
                TextBox1.BackColor = Color.Red
            ElseIf TextBox2.Text = List.Max Then
                TextBox2.BackColor = Color.Red
            Else
                TextBox3.BackColor = Color.Red
            End If
        Else
            MsgBox("請輸入三個數字")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class
