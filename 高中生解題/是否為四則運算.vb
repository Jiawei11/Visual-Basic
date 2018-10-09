	FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n As Integer = LineInput(1)
        Dim a As Integer = 1
        For i = 1 To n
            Dim data As String = LineInput(1)
            Dim len As Integer = data.Length
            Dim arr(len - 1) As String
            Dim str As String = ""
            Dim ascc As Integer = 0
            Dim r As String = Strings.Right(data, 1)
            Dim l As String = Strings.Left(data, 1)
            For j = 0 To len - 1
                If r = "+" Or r = "-" Or r = "*" Or r = "/" Then
                    str = "F"
                    Exit For
                ElseIf l = "+" Or l = "-" Or l = "*" Or l = "/" Then
                    str = "F"
                    Exit For
                End If
                arr(j) = Mid(data, j + 1, 1)
                ascc = Asc(arr(j))
                If a = 1 Then
                    If ascc = 42 Or ascc = 43 Or ascc = 45 Or ascc = 47 Then
                        a = 0
                        Continue For
                    End If
                End If
                If a = 0 Then
                    If ascc >= 48 And ascc <= 57 Then
                        str = "T"
                        a = 1
                        Continue For
                    Else
                        str = "F"
                        Exit For
                    End If
                End If
            Next
            PrintLine(2, Trim(str))
        Next
        Close()