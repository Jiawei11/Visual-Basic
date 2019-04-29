Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            For m = 1 To Val(LineInput(q))
                Dim NodeList As List(Of String) = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries).ToList
                Dim root(NodeList.Select(Function(x) x.Split(",").Select(Function(w) CInt(w)).Max).Max) As Integer
                root = root.Select(Function(x, y) y).ToArray
                Dim LoopEdge As New List(Of String)
                For i = 0 To NodeList.Count - 1
                    Dim Edge() As Integer = NodeList(i).Split({","}, StringSplitOptions.RemoveEmptyEntries).ToList.Select(Function(x) CInt(x)).ToArray
                    If findroot(root, Edge.First) = findroot(root, Edge.Last) Then LoopEdge.Add(NodeList(i)) : Continue For Else merge(root, Edge.First, Edge.Last)
                Next
                If String.Join(",", NodeList.Select(Function(x) x.ToString)).Split(",").Distinct.ToList.Count - 1 = NodeList.Count Then
                    PrintLine(3, "T")
                ElseIf LoopEdge.Count = 0 Then
                    PrintLine(3, "F")
                Else
                    PrintLine(3, String.Join(" ", From Edge In LoopEdge Select Edge))
                End If
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Function findroot(ByVal root() As Integer, ByVal current As Integer)
        If root(current) = current Then Return current
        root(current) = findroot(root, root(current))
        Return root(current)
    End Function
    Sub merge(ByVal root() As Integer, ByVal n1 As Integer, ByVal n2 As Integer)
        Dim x = findroot(root, n1)
        Dim y = findroot(root, n2)
        root(y) = x
    End Sub
End Class