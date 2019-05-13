Public Class Form1
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            Dim n As Integer = LineInput(q)
            For i = 1 To n
                Dim Data As List(Of Integer) = LineInput(q).Split(",").Select(Function(x) CInt(x)).ToList
                Dim NodeList, NodeCount As New List(Of List(Of Integer))
                For j = 1 To Data(1)
                    NodeList.Add(New List(Of Integer))
                    NodeCount.Add(New List(Of Integer))
                Next
                Dim Child As New List(Of Integer)
                For j = 1 To Data.First
                    Dim Node() As Integer = LineInput(q) _
                                            .Split({" "}, StringSplitOptions.RemoveEmptyEntries) _
                                            .Select(Function(x) CInt(x)).ToArray
                    Child.Add(Node.First)
                    For k = 0 To NodeList.Count - 1
                        NodeList(k).Add(Node(k + 1))
                    Next
                Next
                Dim Root As Integer = NodeList(1).IndexOf(999)
                For j = 0 To NodeList.Count - 1
                    Dim SearchNode As Integer = Data.Last
                    Do Until SearchNode = Root
                        NodeCount(j).Add(SearchNode)
                        SearchNode = NodeList(j)(Child.IndexOf(SearchNode))
                    Loop
                Next
                PrintLine(3, String.Join(",", NodeCount.Select(Function(x) x.Count.ToString)))
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
End Class