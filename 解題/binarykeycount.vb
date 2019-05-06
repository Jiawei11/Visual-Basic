Public Class Form1
    Class Tree
        Public Left, Right As Tree
        Public Data As Integer
    End Class
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        For i = 1 To Val(LineInput(1))
            Dim n As Integer = LineInput(1)
            Dim NodeList As List(Of Integer) = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) CInt(x)).ToList
            Dim Tree As Tree = Nothing
            For Each node In NodeList
                CreateTree(Tree, node)
            Next
            For j = 1 To n
                PrintLine(2, Trim(findnode(Tree, LineInput(1), 0)))
            Next
            PrintLine(2)
        Next
        FileClose()
        Close()
    End Sub
    Sub CreateTree(ByRef Tree As Tree, ByVal current As Integer)
        If Tree Is Nothing Then Tree = New Tree With {.Data = current} : Return
        If current > Tree.Data Then 
            CreateTree(Tree.Right, current)
        Else CreateTree(Tree.Left, current)
    End Sub
    Function findnode(ByVal Tree As Tree, ByVal current As Integer, ByRef hight As Integer)
        If Tree Is Nothing Then Return -1
        If Tree.Data = current Then Return hight
        Return findnode(If(Tree.Data > current, Tree.Left, Tree.Right), current, hight + 1)
    End Function
End Class