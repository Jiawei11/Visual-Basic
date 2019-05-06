Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim m As Integer = LineInput(1)
        For w = 1 To m
            Dim firstNode As String = "A"
            Dim data() As String = LineInput(1).Split
            Dim Graph As New Dictionary(Of String, List(Of String))
            For Each edge In data
                Dim node() As String = edge.Split(",")
                If Graph.ContainsKey(node.First) = False Then Graph.Add(node.First, New List(Of String))
                If Graph.ContainsKey(node.Last) = False Then Graph.Add(node.Last, New List(Of String))
                Graph(node.First).Add(node.Last) : Graph(node.Last).Add(node.First)
            Next
            Dim record As New List(Of String)
            traversal(Graph, firstNode, record)
            PrintLine(2, String.Join(",", record.Select(Function(x) x.ToString)))
        Next
        FileClose()
        Close()
    End Sub
    Sub traversal(ByVal Graph As Dictionary(Of String, List(Of String)), ByVal current As String, ByVal record As List(Of String))
        record.Add(current)
        For Each node In Graph(current)
            If record.Contains(node) = False Then traversal(Graph, node, record)
        Next
    End Sub
End Class