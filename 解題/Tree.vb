Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            For i = 1 To Val(LineInput(q))
                Dim Num As Integer = LineInput(q)
                Dim Count As Integer = 0
                Do Until Num = 1
                    Count += 1
                    If Num Mod 2 = 0 Then
                        Num /= 2
                    ElseIf Num Mod 2 = 1 Then
                        If ((Num - 1) / 2) Mod 2 = 0 OrElse (Num - 1) / 2 = 1 Then
                            Num -= 1
                        ElseIf ((Num + 1) / 2) Mod 2 = 0 OrElse (Num + 1) / 2 = 1 Then
                            Num += 1
                        End If
                    End If
                Loop
                PrintLine(3, Count.ToString)
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
End Class