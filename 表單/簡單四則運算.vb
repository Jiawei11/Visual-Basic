Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "第一個數字"
        Label2.Text = "第二個數字"
        Label3.Text = ""
        RadioButton1.Text = "+"
        RadioButton2.Text = "-"
        RadioButton3.Text = "x"
        RadioButton4.Text = "/"
        Button1.Text = "計算"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Bool As Boolean = True
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("不能為空")
            Bool = False
        End If

        If Bool Then
            For Each Check In TextBox1.Text
                If Asc(Check) >= 48 And Asc(Check) <= 57 Then
                    Bool = True
                Else
                    Bool = False
                    MsgBox("請輸入只有數字")
                    Exit For
                End If
            Next
        End If
        If Bool Then
            If RadioButton1.Checked Then
                Label3.Text = Val(TextBox1.Text) + Val(TextBox2.Text)
            ElseIf RadioButton2.Checked Then
                Label3.Text = Val(TextBox1.Text) - Val(TextBox2.Text)
            ElseIf RadioButton3.Checked Then
                Label3.Text = Val(TextBox1.Text) * Val(TextBox2.Text)
            Else
                If TextBox2.Text = "0" Then
                    MsgBox("算除法時第二個數字不能為0")
                Else
                    Label3.Text = Val(TextBox1.Text) / Val(TextBox2.Text)
                End If
            End If
        End If
    End Sub
End Class