Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        Do Until EOF(1)
            For j = 1 To 2
                Call Mub(j)
                PrintLine(3)
            Next
        Loop
        Close()
    End Sub
    Sub Mub(ByVal value As Integer)
        Dim data As String = LineInput(value)
        If data = "EOF" Then
            End
        End If
        Dim eng() As String = LineInput(value).Split(" ")
        Dim l As String = Strings.Left(data, 1)
        Dim nstr As String = data.Replace(l, l.ToUpper)
        Dim count As Integer = 0
        Dim len As Integer = eng.Length
        For i = 0 To UBound(eng)
            If eng(i) = data Or eng(i) = nstr Then
                count += 1
            End If
        Next
        Dim ans = count & "," & len
        PrintLine(3, ans)
    End Sub
End Class
