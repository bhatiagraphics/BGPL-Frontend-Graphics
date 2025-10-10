Public Class TallyItemMasterData

    Private _CompanyName As String
    Public Property CompanyName() As String
        Get
            Return _CompanyName
        End Get
        Set(ByVal value As String)
            _CompanyName = value
        End Set
    End Property

    Private _ItemName As String
    Public Property ItemName() As String
        Get
            Return _ItemName
        End Get
        Set(ByVal value As String)
            _ItemName = value
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

    Private _ParentGroupName As String
    Public Property ParentGroupName() As String
        Get
            Return _ParentGroupName
        End Get
        Set(ByVal value As String)
            _ParentGroupName = value
        End Set
    End Property

    Private _BaseUnit As String
    Public Property BaseUnit() As String
        Get
            Return _BaseUnit
        End Get
        Set(ByVal value As String)
            _BaseUnit = value
        End Set
    End Property
End Class