Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            For w = 1 To Val(LineInput(q))
                Dim NodeList As List(Of Integer) = LineInput(q).Split(",").Select(Function(x) CInt(x)).ToList
                Dim CopyNode As List(Of Integer) = NodeList.GetRange(0, NodeList.Count)
                Dim Parent, Child, Count, AnsCount As New List(Of Integer)
                Do Until NodeList.Count = 1
                    For i = 1 To 2
                        Child.Add(NodeList.Min) : Count.Add(NodeList.Min) : NodeList.Remove(NodeList.Min)
                    Next
                    Parent.Add(Count.First + Count.Last)
                    Parent.Add(Count.First + Count.Last)
                    NodeList.Add(Count.First + Count.Last)
                    Count = New List(Of Integer)
                Loop
                For Each node In CopyNode
                    Dim Search As Integer = node
                    Dim NodeCount As Integer = 0
                    Do Until Search = NodeList.First
                        NodeCount += 1
                        Search = Parent(Child.IndexOf(Search))
                    Loop
                    AnsCount.Add(NodeCount)
                Next
                PrintLine(3, String.Join(",", AnsCount.Select(Function(x) x.ToString)))
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
End Class