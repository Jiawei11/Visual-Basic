Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        FileOpen(3, "out.txt", OpenMode.Output)
        For q = 1 To 2
            For p = 1 To Val(LineInput(q))
                Dim NodeList As List(Of String) = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries).ToList
                Dim EdgeData(NodeList.Count - 1) As String
                Dim EdgeCost(NodeList.Count - 1) As Integer
                For i = 0 To NodeList.Count - 1
                    Dim Edge() As String = NodeList(i).Split({","}, StringSplitOptions.RemoveEmptyEntries).ToArray
                    EdgeData(i) = Edge(0) & "," & Edge(1)
                    EdgeCost(i) = Edge.Last
                Next
                Array.Sort(EdgeCost, EdgeData)
                Dim root(26) As Integer
                root = root.Select(Function(x, y) y).ToArray
                Dim result As Integer = 0
                For i = 0 To EdgeData.Length - 1
                    Dim Edge() As Integer = EdgeData(i).Split(",").Select(Function(x) Asc(x) - 65).ToArray
                    If findroot(root, Edge.First) = findroot(root, Edge.Last) Then
                        Continue For
                    Else
                        result += EdgeCost(i)
                        Merge(root, Edge.First, Edge.Last)
                    End If
                Next
                PrintLine(3, result.ToString)
            Next
            PrintLine(3)
        Next
        FileClose()
        Close()
    End Sub
    Function findroot(ByVal root() As Integer, ByVal value As Integer)
        If root(value) = value Then Return value
        root(value) = findroot(root, root(value))
        Return root(value)
    End Function
    Sub Merge(ByVal root() As Integer, ByVal value1 As Integer, ByVal value2 As Integer)
        Dim x = findroot(root, value1)
        Dim y = findroot(root, value2)
        root(y) = x
    End Sub
End Class