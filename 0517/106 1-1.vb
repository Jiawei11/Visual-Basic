Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For read = 1 To 2
            Call myfunction(read)
        Next
        FileClose()
        Close()
    End Sub
    Sub myfunction(ByVal read As Integer)
        Dim n As Integer = LineInput(read)
        For i = 1 To n
            Dim data() As String = LineInput(read).Split(" ")
            Dim count As Integer = 0
            For j = 0 To UBound(data)
                Dim len As Integer = data(j).Length
                Dim arr(len - 1) As String
                Dim temp(arr.Length - 1) As String
                For k = 0 To data(j).Length - 1
                    arr(k) = Mid(data(j), k + 1, 1)
                    If arr(k) = "s" Or arr(k) = "S" Then
                        Dim search As Integer = Array.IndexOf(temp, arr(k))
                        If search = -1 Then
                            temp(k) = arr(k)
                            count += 1
                        End If
                    End If
                Next
            Next
            PrintLine(3, Trim(count))
        Next
        PrintLine(3, "")
    End Sub
End Class
