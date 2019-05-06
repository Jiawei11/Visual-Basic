Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        For q = 1 To Val(LineInput(1))
            Dim Edge() As String = LineInput(1).Split(",")
            Dim SearchTarget As String = LineInput(1)
            Dim Parent, Child As New List(Of String)
            For Each node In Edge
                Dim edgedata() As String = node.Split(" ")
                Parent.Add(edgedata.Last) : Child.Add(edgedata.First)
            Next
            Dim Record As New Dictionary(Of Integer, List(Of String))
            Dim root As String = Parent.Find(Function(x) Child.Contains(x) <> True)
            TreeTraversal(Parent, Child, root, 0, Record)
            Dim ans As List(Of String) = Record.ToList.FindAll(Function(x) x.Value.Contains(SearchTarget)).ToList(0).Value
            ans.Sort()
            PrintLine(2, String.Join(",", ans.Select(Function(x) x.ToString)))
        Next
        FileClose()
        Close()
    End Sub
    Sub TreeTraversal(ByVal Parent As List(Of String), ByVal child As List(Of String), ByVal current As String, ByVal ht As Integer, ByVal record As Dictionary(Of Integer, List(Of String)))
        If Not record.ContainsKey(ht) Then record.Add(ht, New List(Of String)) : record(ht).Add(current)
        For i = 0 To Parent.Count - 1
            If Parent(i) = current Then
                TreeTraversal(Parent, child, child(i), ht + 1, record)
            End If
        Next
    End Sub
End Class