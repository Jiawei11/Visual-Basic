Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        For q = 1 To Val(LineInput(1))
            Dim List As List(Of String) = LineInput(1).Replace("+", " + ").Replace("-", " - ").Replace("*", " * ").Replace("/", " / ").Replace("(", " ( ").Replace(")", " ) ").Split({" "}, StringSplitOptions.RemoveEmptyEntries).ToList
            Dim result As New List(Of String)
            Dim Stack As New Stack(Of String)
            List.Reverse()
            For Each item In List
                If Asc(item) >= 65 And Asc(item) <= 90 Or Asc(item) >= 48 And Asc(item) <= 57 Or Asc(item) >= 97 And Asc(item) <= 122 Then
                    result.Add(item)
                ElseIf item = ")" Then
                    Stack.Push(item)
                ElseIf item = "(" Then
                    Do Until Stack.First = ")"
                        result.Add(Stack.Pop)
                    Loop
                    Stack.Pop()
                Else
                    If Stack.Count = 0 Then Stack.Push(item) : Continue For
                    If CalcOP(item) >= CalcOP(Stack.First) Then
                        Stack.Push(item)
                    Else
                        result.Add(Stack.Pop)
                        Stack.Push(item)
                    End If
                End If
            Next
            Do Until Stack.Count = 0
                result.Add(Stack.Pop)
            Loop
            result.Reverse()
            PrintLine(2, String.Join(" ", result.Select(Function(x) x.ToString)))
        Next
        FileClose()
        Close()
    End Sub
    Function CalcOP(ByVal OP As String)
        Select Case OP
            Case ")"
                Return -1
            Case "+", "-"
                Return 5
            Case "*", "/"
                Return 9
            Case Else
                Return 0
        End Select
    End Function
End Class