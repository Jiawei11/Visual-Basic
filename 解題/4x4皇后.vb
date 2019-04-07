Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n As Integer = LineInput(1)
        For q = 1 To n
            Dim Index As New List(Of String)
            Dim Arr(3, 3) As Integer
            For i = 0 To 3
                Dim Data As Integer = LineInput(1)
                Arr(i, Data - 1) = Data
                Index.Add(i & "," & Data)
            Next
            Dim IsQueen As Boolean = True
            For i = 0 To 3
                Dim Count As Integer = 0
                For j = 0 To 3
                    If Arr(j, i) <> 0 Then Count += 1
                Next
                If Count > 1 Then IsQueen = False : Exit For
            Next

            For i = 0 To Index.Count - 1
                Dim Data As List(Of Integer) = Index(i).Split(",").Select(Function(x) CInt(x)).ToList
                Data = Data.Select(Function(x) x - 1).ToList
                Do Until Data.First <= 0 Or Data.Last <= 0
                    Data(0) -= 1
                    Data(1) -= 1
                    If Arr(Data.First, Data.Last) <> 0 Then IsQueen = False : Exit Do
                Loop
                Data = Index(i).Split(",").Select(Function(x) CInt(x)).ToList
                Data = Data.Select(Function(x) x - 1).ToList
                Do Until Data.First >= 2 Or Data.Last >= 2
                    Data(0) += 1
                    Data(1) += 1
                    If Arr(Data.First, Data.Last) <> 0 Then IsQueen = False : Exit Do
                Loop
                If Not IsQueen Then Exit For
            Next
            PrintLine(2, If(IsQueen, "T", "F"))
        Next
        FileClose()
        Close()
    End Sub
End Class