        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Do Until EOF(1)
            Dim data As Integer = LineInput(1)
            Dim str As String = ""
            For i = 1 To data - 1
                If i Mod 7 <> 0 Then
                    str += Space(1) & i & Space(1)
                End If
            Next
            PrintLine(2, str)
        Loop
        Close()