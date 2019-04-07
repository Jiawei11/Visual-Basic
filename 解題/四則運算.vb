Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim Table As New DataTable
        Dim n As Integer = LineInput(1)
        For q = 1 To n
            Dim Data As List(Of String) = LineInput(1).Select(Function(x) x.ToString).ToList
            Dim Left As List(Of Integer) = Data.Select(Function(x, y) If(x = "(", y, -1)).ToList.FindAll(Function(x) x <> -1).ToList
            Dim Right As List(Of Integer) = Data.Select(Function(x, y) If(x = ")", y, -1)).ToList.FindAll(Function(x) x <> -1).ToList
            While Left.Count > 0 And Right.Count > 0
                Dim Max As List(Of Integer) = Right.FindAll(Function(x) x >= Left.Max).ToList
                Dim Temp As List(Of String) = Data.GetRange(Left.Max + 1, Max.First - Left.Max - 1).ToList
                Data.Insert(Left.Max, Table.Compute(String.Join("", Temp.Select(Function(x) x.ToString)), Nothing))
                Data.RemoveRange(Left.Max + 1, Max.First - Left.Max + 1)
                Right = Data.Select(Function(x, y) If(x = ")", y, -1)).ToList.FindAll(Function(x) x <> -1).ToList
                Left = Data.Select(Function(x, y) If(x = "(", y, -1)).ToList.FindAll(Function(x) x <> -1).ToList
            End While
            PrintLine(2, Trim((Table.Compute(String.Join("", Data.Select(Function(x) x.ToString)), Nothing))))
        Next
        FileClose()
        Close()
    End Sub
End Class