Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n() As Integer = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
        Dim Maps(n(0)) As Integer
        Dim WaitCheck As New List(Of Integer)
        For i = 2 To n.First
            Maps(i) = Integer.MaxValue
            WaitCheck.Add(i)
        Next

        Dim DataTemp As New List(Of String)
        For i = 1 To n.Last
            Dim Data As List(Of Integer) = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToList
            DataTemp.Add(String.Join(" ", Data.Select(Function(x) x.ToString)))
            If Data.First = 1 Then Maps(Data(1)) = Data.Last
        Next

        Do Until WaitCheck.Count = 0
            Dim Minvalue As Integer = Integer.MaxValue
            For i = 0 To WaitCheck.Count - 1
                If Maps(WaitCheck(i)) < Minvalue Then Minvalue = Maps(WaitCheck(i))
            Next
            Minvalue = Array.IndexOf(Maps, Minvalue)
            WaitCheck.Remove(Minvalue)
            Dim Target As New List(Of String)
            For i = 0 To DataTemp.Count - 1
                If DataTemp(i).First = Minvalue.ToString Then Target.Add(DataTemp(i))
            Next
            Do Until Target.Count = 0
                Dim EdgeCost() As Integer = Target(0).Split({" "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToArray
                Maps(EdgeCost(1)) = Math.Min(Maps(EdgeCost(1)), Maps(EdgeCost(0)) + EdgeCost(2))
                Target.RemoveAt(0)
            Loop
        Loop
        Dim str As String = String.Join(" ", Maps.Select(Function(x) x.ToString))
        PrintLine(2, Mid(str, 3, str.Count))
        FileClose()
        Close()
    End Sub
End Class