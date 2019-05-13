Public Class Form1
    Public Class User
        Public UserKey As Integer
        Public USerName As String
        Public UserSkillName As Integer
    End Class
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "out.txt", OpenMode.Output)
        Dim n As List(Of Integer) = LineInput(1).Split({","}, StringSplitOptions.RemoveEmptyEntries).ToList.Select(Function(x) CInt(x)).ToList
        Dim DB As New List(Of User)
        For i = 1 To n.First
            Dim Data() As String = LineInput(1).Split({","}, StringSplitOptions.RemoveEmptyEntries).ToArray
            Dim Temp As New User With {.UserKey = Data.First, .USerName = Data(1), .UserSkillName = Data.Last} : DB.Add(Temp)
        Next
        Dim SkillName As New List(Of String)
        For i = 1 To n.Last
            SkillName.Add(LineInput(1).Split({","}, StringSplitOptions.RemoveEmptyEntries).ToList.Last)
        Next

        Dim UserSkill
        Do Until EOF(1)
            Dim Key As String = LineInput(1)
            UserSkill = From Data In DB
        Where Data.UserKey = Key
        Select Data.UserKey, Data.USerName, Data.UserSkillName

        Loop

        Dim str As String = ""
        For Each result In UserSkill
            str &= result.UserKey & " => " & result.USerName & " => " & SkillName(result.userskillname - 1) & vbCrLf
        Next
        PrintLine(2, str)
        FileClose()
        Close()
    End Sub
End Class