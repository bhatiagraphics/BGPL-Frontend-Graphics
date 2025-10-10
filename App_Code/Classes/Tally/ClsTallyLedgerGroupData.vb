Public Class TallyLedgerGroupMasterData

    Private _CompanyName As String
    Public Property CompanyName() As String
        Get
            Return _CompanyName
        End Get
        Set(ByVal value As String)
            _CompanyName = value
        End Set
    End Property

    Private _GroupName As String
    Public Property GroupName() As String
        Get
            Return _GroupName
        End Get
        Set(ByVal value As String)
            _GroupName = value
        End Set
    End Property

    Private _OldGroupName As String
    Public Property OldGroupName() As String
        Get
            Return _OldGroupName
        End Get
        Set(ByVal value As String)
            _OldGroupName = value
        End Set
    End Property

    Private _ParentGroupName As String
    Public Property ParentGroupName() As String
        Get
            Return _ParentGroupName
        End Get
        Set(ByVal value As String)
            _ParentGroupName = value
        End Set
    End Property


    Private _NatureOfGroup As String
    Public Property NatureOfGroup() As String
        Get
            Return _NatureOfGroup
        End Get
        Set(ByVal value As String)
            _NatureOfGroup = value
        End Set
    End Property
End Class