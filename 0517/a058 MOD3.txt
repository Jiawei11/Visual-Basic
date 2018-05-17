        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n As Integer = LineInput(1)
        Dim str As String
        Dim a, b, c As Integer
        For i = 1 To n
            Dim data As Integer = LineInput(1)
            If data Mod 3 = 0 Then
                a += 1
            ElseIf data Mod 3 = 1 Then
                b += 1
            ElseIf data Mod 3 = 2 Then
                c += 1
            End If
        Next
        str = a & Space(1) & b & Space(1) & c
        PrintLine(2, str)
        Close()