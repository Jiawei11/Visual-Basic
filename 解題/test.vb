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