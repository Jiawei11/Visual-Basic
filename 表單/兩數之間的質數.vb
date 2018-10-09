Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "第一個數字"
        Label2.Text = "第二個數字"
        Label3.Text = ""
        Button1.Text = "兩數之間質數"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Temp As String = ""
        Dim max As Integer = Math.Max(Val(TextBox1.Text), Val(TextBox2.Text))
        If max = TextBox1.Text Then
            For i = Val(TextBox2.Text) To Val(TextBox1.Text)
                Dim Bool As Boolean = True
                If i = 2 Then
                    Temp &= i & ","
                Else
                    For j = 2 To i - 1
                        If i Mod j = 0 Then
                            Bool = False
                            Exit For
                        Else
                            Bool = True
                        End If
                    Next
                    If Bool Then Temp &= i & ","
                End If
            Next
        Else
            For i = Val(TextBox1.Text) To Val(TextBox2.Text)
                Dim Bool As Boolean = True
                If i = 2 Then
                    Temp &= i & ","
                Else
                    For j = 2 To i - 1
                        If i Mod j = 0 Then
                            Bool = False
                            Exit For
                        Else
                            Bool = True
                        End If
                    Next
                    If Bool Then Temp &= i & ","
                End If
            Next
        End If
        Label3.Text = Mid(Temp, 1, Temp.Length - 1)
    End Sub
End Class