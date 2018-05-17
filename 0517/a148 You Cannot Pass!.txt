        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Do Until EOF(1)
            Dim data() As String = LineInput(1).Split(" ")
            Dim score As Integer = 0
            Dim max As Integer = 0
            Dim str As String = ""
            Dim ans As Integer = 0
            For i = 1 To Val(data(0))
                max = data(0) * 100
                score += data(i)
                ans = score / Val(data(0))
            Next
            If ans >= 60 Then
                str = "no"
            Else
                str = "yes"
            End If
            PrintLine(2, str)
        Loop
        Close()