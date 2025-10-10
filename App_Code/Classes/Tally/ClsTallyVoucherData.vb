Public Class TallyVoucherData
    Private _CompanyName As String
    Public Property CompanyName() As String
        Get
            Return _CompanyName
        End Get
        Set(ByVal value As String)
            _CompanyName = value
        End Set
    End Property

    Private _VoucherNo As String
    Public Property VoucherNo() As String
        Get
            Return _VoucherNo
        End Get
        Set(ByVal value As String)
            _VoucherNo = value
        End Set
    End Property

    Private _VoucherDate As String
    Public Property VoucherDate() As String
        Get
            Return _VoucherDate
        End Get
        Set(ByVal value As String)
            _VoucherDate = value
        End Set
    End Property

    Private _VoucherTypeName As String
    Public Property VoucherTypeName() As String
        Get
            Return _VoucherTypeName
        End Get
        Set(ByVal value As String)
            _VoucherTypeName = value
        End Set
    End Property

    Private _PartyName As String
    Public Property PartyName() As String
        Get
            Return _PartyName
        End Get
        Set(ByVal value As String)
            _PartyName = value
        End Set
    End Property

    Private _Narration As String
    Public Property Narration() As String
        Get
            Return _Narration
        End Get
        Set(ByVal value As String)
            _Narration = value
        End Set
    End Property

    Private _DebitLedgerName As String
    Public Property DebitLedgerName() As String
        Get
            Return _DebitLedgerName
        End Get
        Set(ByVal value As String)
            _DebitLedgerName = value
        End Set
    End Property

    Private _DebitAmount As String
    Public Property DebitAmount() As String
        Get
            Return _DebitAmount
        End Get
        Set(ByVal value As String)
            _DebitAmount = value
        End Set
    End Property

    Private _CreditLedgerName As String
    Public Property CreditLedgerName() As String
        Get
            Return _CreditLedgerName
        End Get
        Set(ByVal value As String)
            _CreditLedgerName = value
        End Set
    End Property


    Private _CreditAmount As String
    Public Property CreditAmount() As String
        Get
            Return _CreditAmount
        End Get
        Set(ByVal value As String)
            _CreditAmount = value
        End Set
    End Property

    Private _LedgerEntries As String
    Public Property LedgerEntries() As String
        Get
            Return _LedgerEntries
        End Get
        Set(ByVal value As String)
            _LedgerEntries = value
        End Set
    End Property

    Private _VoucherDetails As String
    Public Property VoucherDetails() As String
        Get
            Return _VoucherDetails
        End Get
        Set(ByVal value As String)
            _VoucherDetails = value
        End Set
    End Property

    Private _VoucherOtherDetails As String
    Public Property VoucherOtherDetails() As String
        Get
            Return _VoucherOtherDetails
        End Get
        Set(ByVal value As String)
            _VoucherOtherDetails = value
        End Set
    End Property


    Private _InventoryEntries As String
    Public Property InventoryEntries() As String
        Get
            Return _InventoryEntries
        End Get
        Set(ByVal value As String)
            _InventoryEntries = value
        End Set
    End Property

End Class