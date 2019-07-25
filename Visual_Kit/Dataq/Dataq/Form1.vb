Public Class Form1
    Class DataFrame
        Private Columns As New List(Of String)
        Private Items As New List(Of IEnumerable(Of String))

        Default Property Item(ByVal index As String) As IEnumerable(Of String)
            Get
                Return Me.Items(Me.Columns.IndexOf(index))
            End Get
            Set(ByVal value As IEnumerable(Of String))
                If Me.Columns.Contains(index) = False Then
                    Me.Columns.Add(index)
                    Me.Items.Add(value)
                Else
                    Me.Items(Me.Columns.IndexOf(index)) = value
                End If
            End Set
        End Property

        Default Property Item(ByVal index As Integer)
            Get
                Return Me(Me.Columns(index))
            End Get
            Set(ByVal value)
                Me(Me.Columns(index)) = value
            End Set
        End Property

        Shared Operator +(ByVal Data As DataFrame, ByVal value As Integer)
            Dim Output = Data.Items.Select(Function(x) x.Select(Function(y) (y + value).ToString).AsEnumerable).ToList
            Return New DataFrame(Output, Data.Columns)
        End Operator

        Shared Operator -(ByVal Data As DataFrame, ByVal value As Integer)
            Dim Output = Data.Items.Select(Function(x) x.Select(Function(y) (y - value).ToString).AsEnumerable).ToList
            Return New DataFrame(Output, Data.Columns)
        End Operator

        Shared Operator *(ByVal a As DataFrame, ByVal b As Integer)
            Dim Output = a.Items.Select(Function(x) x.Select(Function(y) (y * b).ToString).AsEnumerable).ToList
            Return New DataFrame(Output, a.Columns)
        End Operator

        Shared Operator /(ByVal a As DataFrame, ByVal b As Integer)
            Dim Output = a.Items.Select(Function(x) x.Select(Function(y) (Int(y / b)).ToString).AsEnumerable).ToList
            Return New DataFrame(Output, a.Columns)
        End Operator

        Sub New(ByVal a As List(Of IEnumerable(Of String)), ByVal Columns As List(Of String))
            Me.Items = a
            Me.Columns = Columns
        End Sub

        Sub New()

        End Sub
    End Class

    Class JSON
        Shared Function parse(ByVal obj As String)
            Dim Dict As New Dictionary(Of String, String)
            For Each item In obj.Split({","}, StringSplitOptions.RemoveEmptyEntries).ToList
                Dim Data As List(Of String) = item.Split({"="}, StringSplitOptions.RemoveEmptyEntries).ToList
                Dict.Add(Data.First, Data.Last)
            Next

            Return Dict
        End Function

        Shared Function parse(ByVal obj As User)
            Dim Dict As New List(Of Dictionary(Of String, String))

            For Each item In obj.GetType().GetFields().ToArray
                Dict.Add(New Dictionary(Of String, String))
                Dict.Last.Add(item.Name.ToString, obj.GetType().GetField(item.Name.ToString).GetValue(obj))
            Next

            Return Dict
        End Function

        Shared Function stringify(ByVal obj As User)
            Return String.Join(",", obj.GetType().GetFields().Select(Function(x) x.Name & "=" & obj.GetType().GetField(x.Name).GetValue(obj)).Select(Function(x) x))
        End Function
    End Class

    Class User
        Public User As String
        Public Password As String
        Public Permission As String

        Sub New(ByVal Username As String, ByVal Password As String, Optional ByVal Permission As String = "一般使用者")
            Me.User = Username
            Me.Password = Password
            Me.Permission = Permission
        End Sub

        Sub ModifyPassword(ByVal oldpwd As String, ByVal newpwd As String)
            If MsgBox("確定要更改密碼嗎?") = MsgBoxResult.Yes Then
                Password = newpwd
            End If
        End Sub
    End Class

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Data As New User("admin", "1234", "管理者")

        Dim b = JSON.parse(JSON.stringify(Data))

        Dim DF As New DataFrame
        DF("A") = {1, 2, 3, 4}
        DF("B") = {5, 6, 7, 8}

        Dim A = DF("A")

        DF("A") = {1, 3, 5, 7}

        Dim DF2 = DF * 2

        Dim A0 = DF(0)
    End Sub
End Class
