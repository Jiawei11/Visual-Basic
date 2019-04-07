Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Do Until EOF(1)
            Dim Data As String = LineInput(1)
            Dim Count As List(Of Integer) = Enumerable.Range(1, Data.Length).ToList.Select(Function(x) Math.Log(x, 2)).ToList.Select(Function(x, y) If(x.ToString.Contains(".") = False Or x.ToString.Split(".").Last = "0", y + 1, -1)).ToList.FindAll(Function(x) x <> -1).ToList
            Dim DataList As List(Of String) = Data.Select(Function(x) x.ToString).ToList.Select(Function(x, y) If(x = 0, "0", Convert.ToString(CInt(y + 1), 2))).ToList.Select(Function(x) If(x.Length < Count.Count, (Space(Count.Count - x.Length) & x).Replace(" ", "0"), x)).ToList
            Dim CalcCount(Count.Count - 1) As Integer
            For i = 0 To DataList.Count - 1
                For j = 1 To DataList(i).Length
                    If Mid(DataList(i), j, 1) = "1" Then CalcCount(j - 1) += 1
                Next
            Next
            CalcCount = CalcCount.Select(Function(x) If(x Mod 2 = 0, 0, 1)).ToArray
            Dim Search As String = String.Join("", CalcCount.Select(Function(x) x.ToString))
            Dim result As Integer = DataList.Select(Function(x, y) If(x = Search, y + 1, -1)).ToList.FindAll(Function(x) x <> -1).ToList.First
            PrintLine(2, result.ToString)
        Loop
        FileClose()
        Close()
    End Sub
End Class