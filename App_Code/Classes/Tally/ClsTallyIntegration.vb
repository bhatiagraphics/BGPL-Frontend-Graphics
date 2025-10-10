Imports System.Net
Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports System.Security.Authentication
Imports System.Xml
Imports System.Diagnostics
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports DevExpress.Xpf.Core.Native

Public Class ClsTallyIntegration
    Private ConnStr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
    Private TallyURL As String = ConfigurationManager.AppSettings("TallyRUL")
    Public TallyCompanyName As String = ""
    Public TallyResponse As String = ""
    Public TallyLineError As String = ""
    Public TallyLastVchId As String = ""
    Public TallyMasterId As String = ""
    Public TallyVoucherNo As String = ""
    Public TallyVoucherDate As String = ""
    Public TallyVoucherType As String = ""
    Public TallyGUID As String = ""
    Public TallyRemoteID As String = ""
    Public TallyError As Boolean = False
    Public TallyCreated As Boolean = False
    Public TallyDeleted As Boolean = False
    Public TallyEdited As Boolean = False
    Public TallyResponseError As Boolean = False
    Public TallyResponseSuccess As Boolean = False


    Public Function GetDataset(ByVal SQL As String, ByVal sqlConnstring As String) As DataSet
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataSet = Nothing
        Try
            Using sqlConn As New SqlConnection(sqlConnstring)
                Dim cmd1 As New SqlClient.SqlCommand(SQL, sqlConn)
                da = New SqlDataAdapter()
                cmd1.CommandText = SQL
                da.SelectCommand = cmd1
                dt = New DataSet()
                da.Fill(dt)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function

    Public Function ExecuteSQL(ByVal SQL As String, ByVal sqlConnstring As String) As Integer
        Dim i As Integer = 0
        Try
            Using sqlConn As New SqlConnection(sqlConnstring)
                sqlConn.Open()
                Dim Cmd1 As New SqlCommand(SQL, sqlConn)
                i = Cmd1.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return i
    End Function
    Public Function IsTallyRunning() As Boolean
        Try
            'Dim url As String = ConfigurationManager.AppSettings("TallyRUL")
            Dim request As HttpWebRequest = CType(WebRequest.Create(TallyURL), HttpWebRequest)
            request.Method = "GET"
            request.Timeout = 2000 ' 2 seconds timeout
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                If response.StatusCode = HttpStatusCode.OK Then
                    ' Optional: Read response content to validate if it's from Tally
                    Using reader As New StreamReader(response.GetResponseStream())
                        Dim result As String = reader.ReadToEnd()
                        If result.Contains("Server is Running") Then
                            Return True ' Tally is responding
                        End If
                    End Using
                End If
            End Using
        Catch ex As WebException
            ' Tally might not be running or unreachable
            Return False
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function IsCompanyLoaded() As Boolean
        Dim IsCompanyfound As Boolean = False
        Try

            Dim set1 As DataSet = New DataSet("Company")
            set1 = GetDataset("Select fldvalue as CompanyName from Tally_Setup where fldcode='CompanyName' ", ConnStr)
            If Not IsNothing(set1.Tables(0)) Then
                If set1.Tables(0).Rows.Count > 0 Then
                    TallyCompanyName = set1.Tables(0).Rows(0)("CompanyName")
                End If
            End If

            Dim xmlRequest As New StringBuilder()
            xmlRequest.AppendLine("<ENVELOPE>")
            xmlRequest.AppendLine("     <HEADER>")
            xmlRequest.AppendLine("         <VERSION>1</VERSION>")
            xmlRequest.AppendLine("         <TALLYREQUEST>Export</TALLYREQUEST>")
            xmlRequest.AppendLine("         <TYPE>Collection</TYPE>")
            xmlRequest.AppendLine("         <ID>List of Companies</ID>")
            xmlRequest.AppendLine("     </HEADER>")
            xmlRequest.AppendLine("     <BODY>")
            xmlRequest.AppendLine("         <DESC/>")
            xmlRequest.AppendLine("     </BODY>")
            xmlRequest.AppendLine("</ENVELOPE>")

            xmlRequest = xmlRequest.Replace("{CompanyName}", Trim(TallyCompanyName))
            Dim StrXmlRequest As String = xmlRequest.ToString()
            Dim strresponse As String = SendRequestToTally_WebRequest(StrXmlRequest)

            If TallyResponseSuccess = True AndAlso Trim(strresponse) <> "" Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.LoadXml(strresponse)
                Dim CompanyNodesList As XmlNodeList = xmlDoc.SelectSingleNode("//DATA/COLLECTION").SelectNodes("COMPANY")
                If CompanyNodesList IsNot Nothing Then
                    For Each Companynode As XmlNode In CompanyNodesList
                        If Companynode.Attributes("NAME") IsNot Nothing Then
                            Dim CompanyName As String = Trim(Companynode.Attributes("NAME").Value)
                            If UCase(Trim(CompanyName)) = UCase(Trim(TallyCompanyName)) Then
                                IsCompanyfound = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            'Throw ex
            IsCompanyfound = False
        End Try

        Return IsCompanyfound

    End Function
    Public Function CreateDeliveryNoteInTally(ByVal InvoiceNo As String, ByVal mode As String) As String
        Try

            Dim data As New TallyVoucherData()
            Dim set1 As DataSet = New DataSet("Challan")
            set1 = GetDataset("Tally_get_DeliveryNote_sp '" & Trim(InvoiceNo) & "'", ConnStr)

            Dim XMlSpacing As String = "                     "

            If Not IsNothing(set1.Tables(0)) Then
                If set1.Tables(0).Rows.Count > 0 Then
                    With set1.Tables(0)
                        data.CompanyName = .Rows(0)("company").ToString().Trim()
                        data.VoucherTypeName = .Rows(0)("voucher_type").ToString().Trim()
                        data.VoucherDate = .Rows(0)("voucher_date").ToString().Trim()
                        data.VoucherNo = .Rows(0)("voucher_no").ToString().Trim()
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<PARTYLEDGERNAME>" & .Rows(0)("party_ledger").ToString().Trim() & "</PARTYLEDGERNAME>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<NARRATION>" & .Rows(0)("narration").ToString().Trim() & "</NARRATION>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<STATENAME>" & .Rows(0)("statename").ToString().Trim() & "</STATENAME>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<COUNTRYOFRESIDENCE>" & .Rows(0)("country").ToString().Trim() & "</COUNTRYOFRESIDENCE>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<PARTYGSTIN>" & .Rows(0)("partygstin").ToString().Trim() & "</PARTYGSTIN>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<PLACEOFSUPPLY>" & .Rows(0)("placeofsupply").ToString().Trim() & "</PLACEOFSUPPLY>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<CONSIGNEEGSTIN>" & .Rows(0)("consigneegstin").ToString().Trim() & "</CONSIGNEEGSTIN>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<CONSIGNEEPINCODE>" & .Rows(0)("consigneepinnumber").ToString().Trim() & "</CONSIGNEEPINCODE>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<CONSIGNEESTATENAME>" & .Rows(0)("consigneestatename").ToString().Trim() & "</CONSIGNEESTATENAME>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<BASICSHIPPEDBY>" & .Rows(0)("basicshippedby").ToString().Trim() & "</BASICSHIPPEDBY>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<BASICSHIPDOCUMENTNO>" & .Rows(0)("basicshipdocumentno").ToString().Trim() & "</BASICSHIPDOCUMENTNO>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<BASICFINALDESTINATION>" & .Rows(0)("basicfinaldestination").ToString().Trim() & "</BASICFINALDESTINATION>"
                        data.VoucherDetails += vbNewLine + XMlSpacing + "<BASICORDERREF>" & .Rows(0)("basicorderref").ToString().Trim() & "</BASICORDERREF>"

                    End With
                End If
            End If

            'If Not IsNothing(set1.Tables(1)) Then
            '    If set1.Tables(1).Rows.Count > 0 Then
            '        With set1.Tables(1)
            '            data.VoucherOtherDetails += vbNewLine + "<ADDRESS.LIST TYPE='String'>"
            '            data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & .Rows(0)("add1").ToString().Trim() & "</ADDRESS>"
            '            data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & .Rows(0)("add2").ToString().Trim() & "</ADDRESS>"
            '            data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & .Rows(0)("add3").ToString().Trim() & "</ADDRESS>"
            '            data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & .Rows(0)("add4").ToString().Trim() & "</ADDRESS>"
            '            data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & .Rows(0)("add5").ToString().Trim() & "</ADDRESS>"
            '            data.VoucherOtherDetails += vbNewLine + "</ADDRESS.LIST>"
            '        End With
            '    End If
            'End If

            If Not IsNothing(set1.Tables(2)) Then
                If set1.Tables(2).Rows.Count > 0 Then
                    With set1.Tables(2)
                        For Each dtrow In .Rows
                            data.LedgerEntries += vbNewLine + XMlSpacing + "<LEDGERENTRIES.LIST>"
                            data.LedgerEntries += vbNewLine + XMlSpacing + " <LEDGERNAME>" & dtrow("ledger").ToString().Trim() & "</LEDGERNAME>"
                            data.LedgerEntries += vbNewLine + XMlSpacing + " <ISPARTYLEDGER>" & dtrow("is_party_ledger").ToString().Trim() & "</ISPARTYLEDGER>"
                            data.LedgerEntries += vbNewLine + XMlSpacing + " <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.LedgerEntries += vbNewLine + XMlSpacing + " <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.LedgerEntries += vbNewLine + XMlSpacing + "</LEDGERENTRIES.LIST>"
                        Next
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(3)) Then
                If set1.Tables(3).Rows.Count > 0 Then
                    With set1.Tables(3)
                        For Each dtrow In .Rows
                            data.InventoryEntries += vbNewLine + XMlSpacing + "<ALLINVENTORYENTRIES.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <STOCKITEMNAME>" & dtrow("item_name").ToString().Trim() & "</STOCKITEMNAME>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <RATE>" & dtrow("rate").ToString().Trim() & "</RATE>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <ACTUALQTY>" & dtrow("actual_qty").ToString().Trim() & "</ACTUALQTY>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <BILLEDQTY>" & dtrow("billed_qty").ToString().Trim() & "</BILLEDQTY>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <BATCHALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <GODOWNNAME>" & dtrow("godown").ToString().Trim() & "</GODOWNNAME>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <BATCHNAME>" & dtrow("batch").ToString().Trim() & "</BATCHNAME>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <ORDERNO>" & dtrow("orderno").ToString().Trim() & "</ORDERNO>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <ACTUALQTY>" & dtrow("actual_qty").ToString().Trim() & "</ACTUALQTY>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <BILLEDQTY>" & dtrow("billed_qty").ToString().Trim() & "</BILLEDQTY>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <UDF:AWTNOOFPLATES.LIST DESC='AWTNoOfPlates' ISLIST='YES' TYPE='Number' INDEX='51001'>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "          <UDF:AWTNOOFPLATES DESC='AWTNoOfPlates'>" & dtrow("noofplates").ToString().Trim() & "</UDF:AWTNOOFPLATES>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      </UDF:AWTNOOFPLATES.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <UDF:AWTLENGTH.LIST DESC='AWTLength' ISLIST='YES' TYPE='Number' INDEX='51002'>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "          <UDF:AWTLENGTH DESC='AWTLength'>" & dtrow("ItemLength").ToString().Trim() & "</UDF:AWTLENGTH>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      </UDF:AWTLENGTH.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <UDF:AWTWIDTH.LIST DESC='AWTWidth' ISLIST='YES' TYPE='Number' INDEX='51003'>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "          <UDF:AWTWIDTH DESC='AWTWidth'>" & dtrow("ItemWidth").ToString().Trim() & "</UDF:AWTWIDTH>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      </UDF:AWTWIDTH.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <UDF:AWTJOBCODE.LIST DESC='AWTJobCode' ISLIST='YES' TYPE='String' INDEX='51002'>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "          <UDF:AWTJOBCODE DESC='AWTJobCode'>" & dtrow("JobCode").ToString().Trim() & "</UDF:AWTJOBCODE>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      </UDF:AWTJOBCODE.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  </BATCHALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <ACCOUNTINGALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <LEDGERNAME>" & dtrow("stock_account_ledger").ToString().Trim() & "</LEDGERNAME>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <ISPARTYLEDGER>" & dtrow("Is_Party_Ledger").ToString().Trim() & "</ISPARTYLEDGER>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  </ACCOUNTINGALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <UDF:AWTNOOFPLATES.LIST DESC='AWTNoOfPlates' ISLIST='YES' TYPE='Number' INDEX='51001'>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "        <UDF:AWTNOOFPLATES DESC='AWTNoOfPlates'>" & dtrow("noofplates").ToString().Trim() & "</UDF:AWTNOOFPLATES>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  </UDF:AWTNOOFPLATES.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <UDF:AWTLENGTH.LIST DESC='AWTLength' ISLIST='YES' TYPE='Number' INDEX='51002'>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <UDF:AWTLENGTH DESC='AWTLength'>" & dtrow("ItemLength").ToString().Trim() & "</UDF:AWTLENGTH>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  </UDF:AWTLENGTH.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <UDF:AWTWIDTH.LIST DESC='AWTWidth' ISLIST='YES' TYPE='Number' INDEX='51003'>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <UDF:AWTWIDTH DESC='AWTWidth'>" & dtrow("ItemWidth").ToString().Trim() & "</UDF:AWTWIDTH>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  </UDF:AWTWIDTH.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  <UDF:AWTJOBCODE.LIST DESC='AWTJobCode' ISLIST='YES' TYPE='String' INDEX='51002'>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "      <UDF:AWTJOBCODE DESC='AWTJobCode'>" & dtrow("JobCode").ToString().Trim() & "</UDF:AWTJOBCODE>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "  </UDF:AWTJOBCODE.LIST>"
                            data.InventoryEntries += vbNewLine + XMlSpacing + "</ALLINVENTORYENTRIES.LIST>"
                        Next
                    End With
                End If
            End If

            Dim resp As String = SendTallyDeliveryNoteXML(data, mode, InvoiceNo)
            Return resp

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SendTallyDeliveryNoteXML(data As TallyVoucherData, ByVal Mode As String, ByVal InvoiceNo As String) As String
        Dim resp As String = ""
        Try
            Dim xmlRequest As New StringBuilder()

            xmlRequest.AppendLine("<?xml version='1.0' encoding='UTF-8'?>")
            xmlRequest.AppendLine("<ENVELOPE>")
            xmlRequest.AppendLine("     <HEADER>")
            xmlRequest.AppendLine("         <TALLYREQUEST>Import Data</TALLYREQUEST>")
            xmlRequest.AppendLine("     </HEADER>")
            xmlRequest.AppendLine("     <BODY>")
            xmlRequest.AppendLine("         <IMPORTDATA>")
            xmlRequest.AppendLine("             <REQUESTDESC>")
            xmlRequest.AppendLine("                 <REPORTNAME>Vouchers</REPORTNAME>")
            xmlRequest.AppendLine("                 <STATICVARIABLES>")
            xmlRequest.AppendLine("                     <SVCURRENTCOMPANY>{XmlCompanyName}</SVCURRENTCOMPANY>")
            xmlRequest.AppendLine("                 </STATICVARIABLES>")
            xmlRequest.AppendLine("             </REQUESTDESC>")
            xmlRequest.AppendLine("             <REQUESTDATA>")
            xmlRequest.AppendLine("                 <TALLYMESSAGE xmlns:UDF='TallyUDF'>")
            If Mode = "Create" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Create' VCHTYPE='{XmlVoucherType}' >")
            ElseIf Mode = "Alter" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Alter' VCHTYPE='{XmlVoucherType}' REMOTEID='{XmlRemoteId}' >")
            ElseIf Mode = "Delete" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Delete' VCHTYPE='{XmlVoucherType}' REMOTEID='{XmlRemoteId}' >")
            End If
            'If Mode = "Alter" Then
            '    xmlRequest.AppendLine("                         <GUID>{XmlGUID}</GUID>")
            '    xmlRequest.AppendLine("                         <MASTERID>{XmlMasterId}</MASTERID>")
            'End If
            xmlRequest.AppendLine("                         <DATE>{XmlVoucherDate}</DATE>")
            xmlRequest.AppendLine("                         <VOUCHERNUMBER>{XmlVoucherNo}</VOUCHERNUMBER>")
            xmlRequest.AppendLine("                         <VOUCHERTYPENAME>{XmlVoucherType}</VOUCHERTYPENAME>")
            xmlRequest.AppendLine("                         <PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>")
            xmlRequest.AppendLine("                         <OBJVIEW>Invoice Voucher View</OBJVIEW>")
            xmlRequest.AppendLine("                         <ISINVOICE>No</ISINVOICE>")
            xmlRequest.AppendLine("                         <ISOPTIONAL>No</ISOPTIONAL>")
            xmlRequest.AppendLine("                         {VoucherDetails}")
            'xmlRequest.AppendLine("                         {VoucherOtherDetails}")
            xmlRequest.AppendLine("                         {LEDGERENTRIES.LIST}")
            xmlRequest.AppendLine("                         {ALLINVENTORYENTRIES.LIST}")
            xmlRequest.AppendLine("                     </VOUCHER>")
            xmlRequest.AppendLine("                 </TALLYMESSAGE>")
            xmlRequest.AppendLine("             </REQUESTDATA>")
            xmlRequest.AppendLine("         </IMPORTDATA>")
            xmlRequest.AppendLine("     </BODY>")
            xmlRequest.AppendLine("</ENVELOPE>")

            xmlRequest = xmlRequest.Replace("{XmlCompanyName}", Trim(data.CompanyName))
            xmlRequest = xmlRequest.Replace("{XmlVoucherDate}", Trim(data.VoucherDate))
            xmlRequest = xmlRequest.Replace("{XmlVoucherNo}", Trim(data.VoucherNo))
            xmlRequest = xmlRequest.Replace("{XmlRemoteId}", Trim(TallyRemoteID))
            xmlRequest = xmlRequest.Replace("{XmlMasterId}", Trim(TallyMasterId))
            xmlRequest = xmlRequest.Replace("{XmlGUID}", Trim(TallyGUID))
            xmlRequest = xmlRequest.Replace("{XmlVoucherType}", Trim(data.VoucherTypeName))
            xmlRequest = xmlRequest.Replace("{VoucherDetails}", Trim(data.VoucherDetails))
            xmlRequest = xmlRequest.Replace("{VoucherOtherDetails}", Trim(data.VoucherOtherDetails))
            xmlRequest = xmlRequest.Replace("{LEDGERENTRIES.LIST}", Trim(data.LedgerEntries))
            xmlRequest = xmlRequest.Replace("{ALLINVENTORYENTRIES.LIST}", Trim(data.InventoryEntries))

            Dim strxmlrequest = xmlRequest.ToString()
            Dim Web_Response As String = SendRequestToTally_WebRequest(strxmlrequest)
            resp = HandleTallyResponse(Web_Response)

            Dim strlog As String = "insert into tally_log(module,mod_desc,response,logdt) values('Delivery Note','JobId-" & Trim(InvoiceNo) & "','" & Trim(resp) & "',getdate())"
            ExecuteSQL(strlog, ConnStr)

            If TallyResponseSuccess = True Then

                If TallyCreated = True Then
                    If GetVoucherDetailsByMasterID(TallyLastVchId) = True Then
                        Dim parsedDate As DateTime = DateTime.ParseExact(TallyVoucherDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                        Dim formattedDateString As String = parsedDate.ToString("yyyy-MM-dd")
                        Dim strqty As String = "insert into TallyVoucherMasterIDMapping(VoucherNo,VoucherDate,VoucherType,TallyMasterId,JobId,CreatedDate) " _
                                & "values('" & Trim(TallyVoucherNo) & "','" & formattedDateString & "','" & Trim(TallyVoucherType) & "'," & Val(TallyMasterId) & ",'" & Trim(InvoiceNo) & "',getdate())"
                        ExecuteSQL(strqty, ConnStr)
                    End If
                End If

                If TallyEdited = True Then
                    If GetVoucherDetailsByMasterID(TallyLastVchId) = True Then
                        Dim parsedDate As DateTime = DateTime.ParseExact(TallyVoucherDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                        Dim formattedDateString As String = parsedDate.ToString("yyyy-MM-dd")
                        Dim strqty As String = "Update TallyVoucherMasterIDMapping set VoucherNo='" & Trim(TallyVoucherNo) & "',VoucherDate = '" & Trim(formattedDateString) & "',VoucherType='" & Trim(TallyVoucherType) & "'," _
                                    & "TallyMasterId ='" & Trim(TallyMasterId) & "',CreatedDate=getdate() where JobId= '" & Trim(InvoiceNo) & "'"
                        ExecuteSQL(strqty, ConnStr)
                    End If

                End If

                If TallyDeleted = True Then
                    Dim strqty As String = "delete from TallyVoucherMasterIDMapping where JobId='" & Trim(InvoiceNo) & "' and VoucherNo ='" & Trim(TallyVoucherNo) & "' and TallyMasterId=" & Val(TallyMasterId)
                    ExecuteSQL(strqty, ConnStr)
                End If

            End If


        Catch ex As Exception
            'Throw ex
            resp = "Unexpected Error:" & ex.Message
        End Try

        Return resp

    End Function

    Public Function CreateSalesInvoiceInTally(ByVal InvoiceNo As String, ByVal mode As String) As String
        Try

            Dim data As New TallyVoucherData()
            Dim set1 As DataSet = New DataSet("sales")
            set1 = GetDataset("Tally_get_Saleinvoice_sp '" & Trim(InvoiceNo) & "'", ConnStr)

            If Not IsNothing(set1.Tables(0)) Then
                If set1.Tables(0).Rows.Count > 0 Then
                    With set1.Tables(0)
                        data.CompanyName = .Rows(0)("company").ToString().Trim()
                        data.VoucherTypeName = .Rows(0)("voucher_type").ToString().Trim()
                        data.VoucherDate = .Rows(0)("voucher_date").ToString().Trim()
                        data.VoucherNo = .Rows(0)("voucher_no").ToString().Trim()
                        data.VoucherDetails += vbNewLine + "<PARTYLEDGERNAME>" & WebUtility.HtmlEncode(.Rows(0)("party_ledger").ToString().Trim()) & "</PARTYLEDGERNAME>"
                        data.VoucherDetails += vbNewLine + "<STATENAME>" & .Rows(0)("statename").ToString().Trim() & "</STATENAME>"
                        data.VoucherDetails += vbNewLine + "<COUNTRYOFRESIDENCE>" & .Rows(0)("country").ToString().Trim() & "</COUNTRYOFRESIDENCE>"
                        data.VoucherDetails += vbNewLine + "<PARTYGSTIN>" & .Rows(0)("partygstin").ToString().Trim() & "</PARTYGSTIN>"
                        data.VoucherDetails += vbNewLine + "<PLACEOFSUPPLY>" & .Rows(0)("placeofsupply").ToString().Trim() & "</PLACEOFSUPPLY>"
                        data.VoucherDetails += vbNewLine + "<CONSIGNEEGSTIN>" & .Rows(0)("consigneegstin").ToString().Trim() & "</CONSIGNEEGSTIN>"
                        data.VoucherDetails += vbNewLine + "<CONSIGNEEPINCODE>" & .Rows(0)("consigneepinnumber").ToString().Trim() & "</CONSIGNEEPINCODE>"
                        data.VoucherDetails += vbNewLine + "<CONSIGNEESTATENAME>" & .Rows(0)("consigneestatename").ToString().Trim() & "</CONSIGNEESTATENAME>"
                        data.VoucherDetails += vbNewLine + "<NARRATION>" & WebUtility.HtmlEncode(.Rows(0)("narration").ToString().Trim()) & "</NARRATION>"
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(1)) Then
                If set1.Tables(1).Rows.Count > 0 Then
                    With set1.Tables(1)
                        data.VoucherOtherDetails += vbNewLine + "<ADDRESS.LIST TYPE='String'>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("add1").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("add2").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("add3").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("add4").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("address").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "</ADDRESS.LIST>"
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(2)) Then
                If set1.Tables(2).Rows.Count > 0 Then
                    With set1.Tables(2)
                        For Each dtrow In .Rows
                            data.LedgerEntries += vbNewLine + "<LEDGERENTRIES.LIST>"
                            data.LedgerEntries += vbNewLine + " <LEDGERNAME>" & WebUtility.HtmlEncode(dtrow("ledger").ToString().Trim()) & "</LEDGERNAME>"
                            data.LedgerEntries += vbNewLine + " <ISPARTYLEDGER>" & dtrow("is_party_ledger").ToString().Trim() & "</ISPARTYLEDGER>"
                            data.LedgerEntries += vbNewLine + " <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            'data.LedgerEntries += vbNewLine + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE>"
                            data.LedgerEntries += vbNewLine + " <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.LedgerEntries += vbNewLine + " <BILLALLOCATIONS.LIST>"
                            data.LedgerEntries += vbNewLine + "     <NAME>1</NAME>"
                            data.LedgerEntries += vbNewLine + "     <BILLTYPE>New Ref</BILLTYPE>"
                            data.LedgerEntries += vbNewLine + "     <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.LedgerEntries += vbNewLine + " </BILLALLOCATIONS.LIST>"
                            data.LedgerEntries += vbNewLine + "</LEDGERENTRIES.LIST>"
                        Next
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(3)) Then
                If set1.Tables(3).Rows.Count > 0 Then
                    With set1.Tables(3)
                        For Each dtrow In .Rows
                            data.InventoryEntries += vbNewLine + "<ALLINVENTORYENTRIES.LIST>"
                            data.InventoryEntries += vbNewLine + "  <STOCKITEMNAME>" & WebUtility.HtmlEncode(dtrow("item_name").ToString().Trim()) & "</STOCKITEMNAME>"
                            data.InventoryEntries += vbNewLine + "  <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.InventoryEntries += vbNewLine + "  <RATE>" & dtrow("rate").ToString().Trim() & "</RATE>"
                            data.InventoryEntries += vbNewLine + "  <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + "  <ACTUALQTY>" & dtrow("actual_qty").ToString().Trim() & "</ACTUALQTY>"
                            data.InventoryEntries += vbNewLine + "  <BILLEDQTY>" & dtrow("billed_qty").ToString().Trim() & "</BILLEDQTY>"
                            data.InventoryEntries += vbNewLine + "  <BATCHALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + "      <GODOWNNAME>" & dtrow("godown").ToString().Trim() & "</GODOWNNAME>"
                            data.InventoryEntries += vbNewLine + "      <BATCHNAME>" & dtrow("batch").ToString().Trim() & "</BATCHNAME>"
                            data.InventoryEntries += vbNewLine + "      <ORDERNO>" & dtrow("orderno").ToString().Trim() & "</ORDERNO>"
                            data.InventoryEntries += vbNewLine + "      <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + "      <ACTUALQTY>" & dtrow("actual_qty").ToString().Trim() & "</ACTUALQTY>"
                            data.InventoryEntries += vbNewLine + "      <BILLEDQTY>" & dtrow("billed_qty").ToString().Trim() & "</BILLEDQTY>"
                            data.InventoryEntries += vbNewLine + "  </BATCHALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + "  <ACCOUNTINGALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + "      <LEDGERNAME>" & WebUtility.HtmlEncode(dtrow("stock_account_ledger").ToString().Trim()) & "</LEDGERNAME>"
                            data.InventoryEntries += vbNewLine + "      <ISPARTYLEDGER>" & dtrow("is_party_ledger").ToString().Trim() & "</ISPARTYLEDGER>"
                            data.InventoryEntries += vbNewLine + "      <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.InventoryEntries += vbNewLine + "      <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + "  </ACCOUNTINGALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + "</ALLINVENTORYENTRIES.LIST>"
                        Next
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(4)) Then
                If set1.Tables(4).Rows.Count > 0 Then
                    With set1.Tables(4)
                        For Each dtrow In .Rows
                            data.LedgerEntries += vbNewLine + "<LEDGERENTRIES.LIST>"
                            data.LedgerEntries += vbNewLine + " <LEDGERNAME>" & WebUtility.HtmlEncode(dtrow("ledger").ToString().Trim()) & "</LEDGERNAME>"
                            data.LedgerEntries += vbNewLine + " <ISPARTYLEDGER>" & dtrow("is_party_ledger").ToString().Trim() & "</ISPARTYLEDGER>"
                            data.LedgerEntries += vbNewLine + " <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.LedgerEntries += vbNewLine + " <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.LedgerEntries += vbNewLine + "</LEDGERENTRIES.LIST>"
                        Next

                    End With
                End If
            End If


            Dim resp As String = SendTallySalesInvoiceXML(data, mode)

            Dim strlog As String = "insert into tally_log(module,mod_desc,response,logdt) values('Sales-Invoice','Invoice No-" & Trim(data.VoucherNo) & "','" & Trim(resp).Replace("'", "") & "',getdate())"
            ExecuteSQL(strlog, ConnStr)

            Return resp

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SendTallySalesInvoiceXML(data As TallyVoucherData, ByVal Mode As String) As String
        Dim TallyResponse As String = ""
        Try
            Dim xmlRequest As New StringBuilder()

            xmlRequest.AppendLine("<?xml version='1.0' encoding='UTF-8'?>")
            xmlRequest.AppendLine("<ENVELOPE>")
            xmlRequest.AppendLine("     <HEADER>")
            xmlRequest.AppendLine("         <TALLYREQUEST>Import Data</TALLYREQUEST>")
            xmlRequest.AppendLine("     </HEADER>")
            xmlRequest.AppendLine("     <BODY>")
            xmlRequest.AppendLine("         <IMPORTDATA>")
            xmlRequest.AppendLine("             <REQUESTDESC>")
            xmlRequest.AppendLine("                 <REPORTNAME>Vouchers</REPORTNAME>")
            xmlRequest.AppendLine("                 <STATICVARIABLES>")
            xmlRequest.AppendLine("                     <SVCURRENTCOMPANY>{XmlCompanyName}</SVCURRENTCOMPANY>")
            xmlRequest.AppendLine("                 </STATICVARIABLES>")
            xmlRequest.AppendLine("             </REQUESTDESC>")
            xmlRequest.AppendLine("             <REQUESTDATA>")
            xmlRequest.AppendLine("                 <TALLYMESSAGE xmlns:UDF='TallyUDF'>")
            If Mode = "Create" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Create' VCHTYPE='Sales' OBJVIEW='Invoice Voucher View' >")
            ElseIf Mode = "Alter" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Alter' VCHTYPE='Sales' OBJVIEW='Invoice Voucher View' REMOTEID='{XmlVoucherRemoteId}' >")
            ElseIf Mode = "Delete" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Delete' VCHTYPE='Sales' OBJVIEW='Invoice Voucher View' REMOTEID='{XmlVoucherRemoteId}' >")
            End If
            xmlRequest.AppendLine("                         <DATE>{XmlVoucherDate}</DATE>")
            xmlRequest.AppendLine("                         <VOUCHERNUMBER>{XmlVoucherNo}</VOUCHERNUMBER>")
            xmlRequest.AppendLine("                         <VOUCHERTYPENAME>{XmlVoucherTypeName}</VOUCHERTYPENAME>")
            xmlRequest.AppendLine("                         <PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>")
            xmlRequest.AppendLine("                         <OBJVIEW>Invoice Voucher View</OBJVIEW>")
            xmlRequest.AppendLine("                         <ISINVOICE>Yes</ISINVOICE>")
            xmlRequest.AppendLine("                         {XmlVoucherDetails}")
            xmlRequest.AppendLine("                         {XmlVoucherOtherDetails}")
            xmlRequest.AppendLine("                         {XmlLedgerEntries.List}")
            xmlRequest.AppendLine("                         {XmlAllInventotyEntries.List}")
            xmlRequest.AppendLine("                     </VOUCHER>")
            xmlRequest.AppendLine("                 </TALLYMESSAGE>")
            xmlRequest.AppendLine("             </REQUESTDATA>")
            xmlRequest.AppendLine("         </IMPORTDATA>")
            xmlRequest.AppendLine("     </BODY>")
            xmlRequest.AppendLine("</ENVELOPE>")

            xmlRequest = xmlRequest.Replace("{XmlCompanyName}", WebUtility.HtmlEncode(Trim(data.CompanyName)))
            xmlRequest = xmlRequest.Replace("{XmlVoucherDate}", Trim(data.VoucherDate))
            xmlRequest = xmlRequest.Replace("{XmlVoucherNo}", WebUtility.HtmlEncode(Trim(data.VoucherNo)))
            xmlRequest = xmlRequest.Replace("{xmlVoucherRemoteId}", Trim(TallyRemoteID))
            xmlRequest = xmlRequest.Replace("{XmlVoucherTypeName}", Trim(data.VoucherTypeName))
            xmlRequest = xmlRequest.Replace("{XmlVoucherDetails}", Trim(data.VoucherDetails))
            xmlRequest = xmlRequest.Replace("{XmlVoucherOtherDetails}", Trim(data.VoucherOtherDetails))
            xmlRequest = xmlRequest.Replace("{XmlLedgerEntries.List}", Trim(data.LedgerEntries))
            xmlRequest = xmlRequest.Replace("{XmlAllInventotyEntries.List}", Trim(data.InventoryEntries))

            Dim strxmlrequest = xmlRequest.ToString()
            Dim Web_Response As String = SendRequestToTally_WebRequest(strxmlrequest)
            If TallyResponseSuccess Then
                TallyResponse = HandleTallyResponse(Web_Response)

                If TallyCreated = True Then
                    Dim strqty As String = "insert into TallyVoucherMasterIDMapping(VoucherNo,VoucherType,TallyMasterId,CreatedDate) " _
                            & "values('" & Trim(data.VoucherNo) & "','" & Trim(data.VoucherTypeName) & "'," & Val(TallyMasterId) & ",getdate())"
                    ExecuteSQL(strqty, ConnStr)
                End If

                If TallyDeleted = True Then
                    Dim strqty As String = "delete from TallyVoucherMasterIDMapping where VoucherNo ='" & Trim(data.VoucherNo) & "' and TallyMasterId=" & Val(TallyMasterId)
                    ExecuteSQL(strqty, ConnStr)
                End If

            Else
                TallyResponse = Web_Response
            End If


        Catch ex As Exception
            'Throw ex
            TallyResponse = "Unexpected Error:" & ex.Message
        End Try

        Return TallyResponse

    End Function

    Public Function CreatePurcahseVoucherInTally(ByVal VoucherNo As String, ByVal Mode As String) As String
        Try

            Dim data As New TallyVoucherData()
            Dim set1 As DataSet = New DataSet("purchase")
            set1 = GetDataset("Tally_get_PurchaseInvoice_sp'" & Trim(VoucherNo) & "'", ConnStr)

            If Not IsNothing(set1.Tables(0)) Then
                If set1.Tables(0).Rows.Count > 0 Then
                    With set1.Tables(0)
                        data.CompanyName = .Rows(0)("company").ToString().Trim()
                        data.VoucherDate = .Rows(0)("voucher_date").ToString().Trim()
                        data.VoucherTypeName = .Rows(0)("voucher_type").ToString().Trim()
                        data.VoucherNo = .Rows(0)("voucher_no").ToString().Trim()
                        data.VoucherDetails += vbNewLine + "<PARTYLEDGERNAME>" & WebUtility.HtmlEncode(.Rows(0)("party_ledger").ToString().Trim()) & "</PARTYLEDGERNAME>"
                        data.VoucherDetails += vbNewLine + "<STATENAME>" & .Rows(0)("statename").ToString().Trim() & "</STATENAME>"
                        data.VoucherDetails += vbNewLine + "<COUNTRYOFRESIDENCE>" & .Rows(0)("country").ToString().Trim() & "</COUNTRYOFRESIDENCE>"
                        data.VoucherDetails += vbNewLine + "<PARTYGSTIN>" & .Rows(0)("partygstin").ToString().Trim() & "</PARTYGSTIN>"
                        data.VoucherDetails += vbNewLine + "<PLACEOFSUPPLY>" & .Rows(0)("placeofsupply").ToString().Trim() & "</PLACEOFSUPPLY>"
                        data.VoucherDetails += vbNewLine + "<CONSIGNEEGSTIN>" & .Rows(0)("consigneegstin").ToString().Trim() & "</CONSIGNEEGSTIN>"
                        data.VoucherDetails += vbNewLine + "<CONSIGNEEPINCODE>" & .Rows(0)("consigneepinnumber").ToString().Trim() & "</CONSIGNEEPINCODE>"
                        data.VoucherDetails += vbNewLine + "<CONSIGNEESTATENAME>" & .Rows(0)("consigneestatename").ToString().Trim() & "</CONSIGNEESTATENAME>"
                        data.VoucherDetails += vbNewLine + "<NARRATION>" & WebUtility.HtmlEncode(.Rows(0)("narration").ToString().Trim()) & "</NARRATION>"
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(1)) Then
                If set1.Tables(1).Rows.Count > 0 Then
                    With set1.Tables(1)
                        data.VoucherOtherDetails += vbNewLine + "<ADDRESS.LIST TYPE='String'>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("add1").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("add2").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("add3").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("add4").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "   <ADDRESS>" & WebUtility.HtmlEncode(.Rows(0)("address").ToString().Trim()) & "</ADDRESS>"
                        data.VoucherOtherDetails += vbNewLine + "</ADDRESS.LIST>"
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(2)) Then
                If set1.Tables(2).Rows.Count > 0 Then
                    With set1.Tables(2)
                        For Each dtrow In .Rows
                            data.LedgerEntries += vbNewLine + "<LEDGERENTRIES.LIST>"
                            data.LedgerEntries += vbNewLine + " <LEDGERNAME>" & WebUtility.HtmlEncode(dtrow("ledger").ToString().Trim()) & "</LEDGERNAME>"
                            data.LedgerEntries += vbNewLine + " <ISPARTYLEDGER>" & dtrow("is_party_ledger").ToString().Trim() & "</ISPARTYLEDGER>"
                            data.LedgerEntries += vbNewLine + " <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            'data.LedgerEntries += vbNewLine + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE>"
                            data.LedgerEntries += vbNewLine + " <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.LedgerEntries += vbNewLine + " <BILLALLOCATIONS.LIST>"
                            data.LedgerEntries += vbNewLine + "     <NAME>1</NAME>"
                            data.LedgerEntries += vbNewLine + "     <BILLTYPE>New Ref</BILLTYPE>"
                            data.LedgerEntries += vbNewLine + "     <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.LedgerEntries += vbNewLine + " </BILLALLOCATIONS.LIST>"
                            data.LedgerEntries += vbNewLine + "</LEDGERENTRIES.LIST>"
                        Next
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(3)) Then
                If set1.Tables(3).Rows.Count > 0 Then
                    With set1.Tables(3)
                        For Each dtrow In .Rows
                            data.InventoryEntries += vbNewLine + "<ALLINVENTORYENTRIES.LIST>"
                            data.InventoryEntries += vbNewLine + "  <STOCKITEMNAME>" & WebUtility.HtmlEncode(dtrow("item_name").ToString().Trim()) & "</STOCKITEMNAME>"
                            data.InventoryEntries += vbNewLine + "  <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.InventoryEntries += vbNewLine + "  <RATE>" & dtrow("rate").ToString().Trim() & "</RATE>"
                            data.InventoryEntries += vbNewLine + "  <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + "  <ACTUALQTY>" & dtrow("actual_qty").ToString().Trim() & "</ACTUALQTY>"
                            data.InventoryEntries += vbNewLine + "  <BILLEDQTY>" & dtrow("billed_qty").ToString().Trim() & "</BILLEDQTY>"
                            data.InventoryEntries += vbNewLine + "  <BATCHALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + "      <GODOWNNAME>" & dtrow("godown").ToString().Trim() & "</GODOWNNAME>"
                            data.InventoryEntries += vbNewLine + "      <BATCHNAME>" & dtrow("batch").ToString().Trim() & "</BATCHNAME>"
                            data.InventoryEntries += vbNewLine + "      <ORDERNO>" & dtrow("orderno").ToString().Trim() & "</ORDERNO>"
                            data.InventoryEntries += vbNewLine + "      <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + "      <ACTUALQTY>" & dtrow("actual_qty").ToString().Trim() & "</ACTUALQTY>"
                            data.InventoryEntries += vbNewLine + "      <BILLEDQTY>" & dtrow("billed_qty").ToString().Trim() & "</BILLEDQTY>"
                            data.InventoryEntries += vbNewLine + "  </BATCHALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + "  <ACCOUNTINGALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + "      <LEDGERNAME>" & WebUtility.HtmlEncode(dtrow("stock_account_ledger").ToString().Trim()) & "</LEDGERNAME>"
                            data.InventoryEntries += vbNewLine + "      <ISPARTYLEDGER>" & dtrow("is_party_ledger").ToString().Trim() & "</ISPARTYLEDGER>"
                            data.InventoryEntries += vbNewLine + "      <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.InventoryEntries += vbNewLine + "      <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.InventoryEntries += vbNewLine + "  </ACCOUNTINGALLOCATIONS.LIST>"
                            data.InventoryEntries += vbNewLine + "</ALLINVENTORYENTRIES.LIST>"
                        Next
                    End With
                End If
            End If

            If Not IsNothing(set1.Tables(4)) Then
                If set1.Tables(4).Rows.Count > 0 Then
                    With set1.Tables(4)
                        For Each dtrow In .Rows
                            data.LedgerEntries += vbNewLine + "<LEDGERENTRIES.LIST>"
                            data.LedgerEntries += vbNewLine + " <LEDGERNAME>" & WebUtility.HtmlEncode(dtrow("ledger").ToString().Trim()) & "</LEDGERNAME>"
                            data.LedgerEntries += vbNewLine + " <ISPARTYLEDGER>" & dtrow("is_party_ledger").ToString().Trim() & "</ISPARTYLEDGER>"
                            data.LedgerEntries += vbNewLine + " <ISDEEMEDPOSITIVE>" & dtrow("Is_Deemed_Positive").ToString().Trim() & "</ISDEEMEDPOSITIVE>"
                            data.LedgerEntries += vbNewLine + " <AMOUNT>" & dtrow("amount").ToString().Trim() & "</AMOUNT>"
                            data.LedgerEntries += vbNewLine + "</LEDGERENTRIES.LIST>"
                        Next

                    End With
                End If
            End If


            Dim resp As String = SendTallyPurchaseXML(data, Mode)
            Dim strlog As String = "insert into tally_log(module,mod_desc,response,logdt) values('Purchase-Voucher','Voucher No-" & Trim(data.VoucherNo) & "','" & Trim(resp).Replace("'", "") & "',getdate())"
            ExecuteSQL(strlog, ConnStr)

            Return resp

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SendTallyPurchaseXML(data As TallyVoucherData, ByVal Mode As String) As String
        Dim TallyResponse As String = ""
        Try
            Dim xmlRequest As New StringBuilder()
            xmlRequest.AppendLine("<?xml version='1.0' encoding='UTF-8'?>")
            xmlRequest.AppendLine("<ENVELOPE>")
            xmlRequest.AppendLine("     <HEADER>")
            xmlRequest.AppendLine("         <TALLYREQUEST>Import Data</TALLYREQUEST>")
            xmlRequest.AppendLine("     </HEADER>")
            xmlRequest.AppendLine("     <BODY>")
            xmlRequest.AppendLine("         <IMPORTDATA>")
            xmlRequest.AppendLine("             <REQUESTDESC>")
            xmlRequest.AppendLine("                 <REPORTNAME>Vouchers</REPORTNAME>")
            xmlRequest.AppendLine("                 <STATICVARIABLES>")
            xmlRequest.AppendLine("                     <SVCURRENTCOMPANY>{XmlCompanyName}</SVCURRENTCOMPANY>")
            xmlRequest.AppendLine("                 </STATICVARIABLES>")
            xmlRequest.AppendLine("             </REQUESTDESC>")
            xmlRequest.AppendLine("             <REQUESTDATA>")
            xmlRequest.AppendLine("                 <TALLYMESSAGE xmlns:UDF='TallyUDF'>")
            If Mode = "Create" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Create' VCHTYPE='Purchase' OBJVIEW='Invoice Voucher View'>")
            ElseIf Mode = "Alter" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Alter' VCHTYPE='Purchase' OBJVIEW='Invoice Voucher View' REMOTEID='{XmlVoucherRemoteId}'>")
            ElseIf Mode = "Delete" Then
                xmlRequest.AppendLine("                     <VOUCHER ACTION='Delete' VCHTYPE='Purchase' OBJVIEW='Invoice Voucher View' REMOTEID='{VoucherRemoteId}'>")
            End If
            xmlRequest.AppendLine("                         <DATE>{XmlVoucherDate}</DATE>")
            xmlRequest.AppendLine("                         <VOUCHERTYPENAME>{XmlVoucherTypeName}</VOUCHERTYPENAME>")
            xmlRequest.AppendLine("                         <VOUCHERNUMBER>{XmlVoucherNo}</VOUCHERNUMBER>")
            xmlRequest.AppendLine("                         <PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>")
            xmlRequest.AppendLine("                         <ISINVOICE>Yes</ISINVOICE>")
            xmlRequest.AppendLine("                         <OBJVIEW>Invoice Voucher View</OBJVIEW>")
            xmlRequest.AppendLine("                         {XmlVoucherDetails}")
            xmlRequest.AppendLine("                         {XmlVoucherOtherDetails}")
            xmlRequest.AppendLine("                         {XmlLedgerEntries.List}")
            xmlRequest.AppendLine("                         {XmlAllInventotyEntries.List}")
            xmlRequest.AppendLine("                     </VOUCHER>")
            xmlRequest.AppendLine("                 </TALLYMESSAGE>")
            xmlRequest.AppendLine("             </REQUESTDATA>")
            xmlRequest.AppendLine("         </IMPORTDATA>")
            xmlRequest.AppendLine("     </BODY>")
            xmlRequest.AppendLine("</ENVELOPE>")

            xmlRequest = xmlRequest.Replace("{XmlCompanyName}", WebUtility.HtmlEncode(Trim(data.CompanyName)))
            xmlRequest = xmlRequest.Replace("{XmlVoucherDate}", Trim(data.VoucherDate))
            xmlRequest = xmlRequest.Replace("{XmlVoucherNo}", WebUtility.HtmlEncode(Trim(data.VoucherNo)))
            xmlRequest = xmlRequest.Replace("{XmlVoucherRemoteId}", Trim(TallyRemoteID))
            xmlRequest = xmlRequest.Replace("{XmlVoucherTypeName}", Trim(data.VoucherTypeName))
            xmlRequest = xmlRequest.Replace("{XmlVoucherDetails}", Trim(data.VoucherDetails))
            xmlRequest = xmlRequest.Replace("{XmlVoucherOtherDetails}", Trim(data.VoucherOtherDetails))
            xmlRequest = xmlRequest.Replace("{XmlLedgerEntries.List}", Trim(data.LedgerEntries))
            xmlRequest = xmlRequest.Replace("{XmlAllInventotyEntries.List}", Trim(data.InventoryEntries))

            Dim strxmlrequest = xmlRequest.ToString()
            Dim Web_Response As String = SendRequestToTally_WebRequest(strxmlrequest)
            If TallyResponseSuccess = True Then
                TallyResponse = HandleTallyResponse(Web_Response)

                If TallyCreated = True Then
                    Dim strqty As String = "insert into TallyVoucherMasterIDMapping(VoucherNo,VoucherType,TallyMasterId,CreatedDate) " _
                            & "values('" & Trim(data.VoucherNo) & "','" & Trim(data.VoucherTypeName) & "'," & Val(TallyMasterId) & ",getdate())"
                    ExecuteSQL(strqty, ConnStr)
                End If

                If TallyDeleted = True Then
                    Dim strqty As String = "delete from TallyVoucherMasterIDMapping where VoucherNo ='" & Trim(data.VoucherNo) & "' and TallyMasterId=" & Val(TallyMasterId)
                    ExecuteSQL(strqty, ConnStr)
                End If
            Else
                TallyResponse = Web_Response
            End If


        Catch ex As Exception
            'Throw ex
            TallyResponse = "Unexpected Error:" & ex.Message

        End Try
        Return TallyResponse
    End Function

    Public Function VoucherExistInTally(ByVal VoucherNumber As String) As Boolean
        Dim VchExist As Boolean = False
        Dim MasterId As Integer
        Dim CompanyName As String = ""
        Dim VoucherTypeName As String = ""

        Dim data As New TallyVoucherData()
        Dim set1 As DataSet = New DataSet("Voucher")
        set1 = GetDataset("Tally_Check_Existing_Voucher_sp '" & Trim(VoucherNumber) & "'", ConnStr)

        If Not IsNothing(set1.Tables(0)) AndAlso set1.Tables(0).Rows.Count = 0 Then
            Return VchExist
        End If

        CompanyName = set1.Tables(0).Rows(0)("Company")
        VoucherTypeName = set1.Tables(0).Rows(0)("VoucherType")
        MasterId = Convert.ToInt16(set1.Tables(0).Rows(0)("TallyMasterId"))

        Dim xmlRequest As New StringBuilder()
        xmlRequest.AppendLine("<?xml version='1.0' encoding='UTF-8'?>")
        xmlRequest.AppendLine("<ENVELOPE>")
        xmlRequest.AppendLine("     <HEADER>")
        xmlRequest.AppendLine("         <VERSION>1</VERSION>")
        xmlRequest.AppendLine("         <TALLYREQUEST>Export</TALLYREQUEST>")
        xmlRequest.AppendLine("         <TYPE>Collection</TYPE>")
        xmlRequest.AppendLine("         <ID>GetVoucherByMasterID</ID>")
        xmlRequest.AppendLine("     </HEADER>")
        xmlRequest.AppendLine("     <BODY>")
        xmlRequest.AppendLine("         <DESC>")
        xmlRequest.AppendLine("             <STATICVARIABLES>")
        xmlRequest.AppendLine("                 <SVCURRENTCOMPANY>{XmlCompanyName}</SVCURRENTCOMPANY>")
        xmlRequest.AppendLine("             </STATICVARIABLES>")
        xmlRequest.AppendLine("             <TDL>")
        xmlRequest.AppendLine("                 <TDLMESSAGE>")
        xmlRequest.AppendLine("                     <COLLECTION NAME='GetVoucherByMasterID' ISMODIFY='No'>")
        xmlRequest.AppendLine("                         <TYPE>Voucher</TYPE>")
        xmlRequest.AppendLine("                         <FILTERS>VoucherTypeAndMasterId</FILTERS>")
        xmlRequest.AppendLine("                         <FETCH>DATE,VOUCHERTYPENAME,VOUCHERNUMBER,PARTYLEDGERNAME,GUID,MASTERID</FETCH>")
        xmlRequest.AppendLine("                     </COLLECTION>")
        xmlRequest.AppendLine("                     <SYSTEM TYPE='Formulae' NAME='VoucherTypeAndMasterId'>")
        xmlRequest.AppendLine("                         $VoucherTypeName = '{XmlVoucherType}' and $MASTERID={XmlMasterID}")
        xmlRequest.AppendLine("                     </SYSTEM>")
        xmlRequest.AppendLine("                 </TDLMESSAGE>")
        xmlRequest.AppendLine("             </TDL>")
        xmlRequest.AppendLine("         </DESC>")
        xmlRequest.AppendLine("     </BODY>")
        xmlRequest.AppendLine("</ENVELOPE>")

        xmlRequest = xmlRequest.Replace("{XmlCompanyName}", CompanyName)
        xmlRequest = xmlRequest.Replace("{XmlVoucherType}", VoucherTypeName)
        xmlRequest = xmlRequest.Replace("{XmlMasterID}", MasterId.ToString())

        Dim StrXmlRequest = xmlRequest.ToString()
        Dim Web_Response As String = SendRequestToTally_WebRequest(StrXmlRequest)

        If TallyResponseSuccess = True Then

            Dim xmlDoc As New XmlDocument()
            xmlDoc.LoadXml(Web_Response)
            Dim masteridnode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/MASTERID")
            If masteridnode IsNot Nothing Then
                TallyMasterId = Trim(masteridnode.InnerText)
            End If

            Dim guidnode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/GUID")
            If guidnode IsNot Nothing Then
                TallyGUID = Trim(guidnode.InnerText)
            End If

            Dim vouchernonode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/VOUCHERNUMBER")
            If guidnode IsNot Nothing Then
                TallyVoucherNo = Trim(vouchernonode.InnerText)
            End If

            Dim voucherdateNode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/DATE")
            If voucherdateNode IsNot Nothing Then
                TallyVoucherDate = Trim(voucherdateNode.InnerText)
            End If

            Dim vouchertypeNode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/VOUCHERTYPENAME")
            If vouchertypeNode IsNot Nothing Then
                TallyVoucherType = Trim(vouchertypeNode.InnerText)
            End If

            Dim VoucherNode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER")
            If VoucherNode IsNot Nothing Then
                If VoucherNode.Attributes("REMOTEID") IsNot Nothing Then
                    TallyRemoteID = Trim(VoucherNode.Attributes("REMOTEID").Value)
                End If
            End If

            If String.IsNullOrWhiteSpace(TallyMasterId) Then
                TallyMasterId = 0
            End If

            If CInt(Trim(TallyMasterId)) = CInt(Trim(MasterId)) Then
                VchExist = True
            End If

        End If

        Return VchExist
    End Function

    Public Function GetVoucherDetailsByMasterID(ByVal MasterId As Integer) As Boolean
        Dim TallyCompanyName As String = ""
        Dim vchExist As Boolean = False

        Dim set1 As DataSet = New DataSet("Company")
        set1 = GetDataset("Select fldvalue as CompanyName from Tally_Setup where fldcode='CompanyName' ", ConnStr)
        If Not IsNothing(set1.Tables(0)) Then
            If set1.Tables(0).Rows.Count > 0 Then
                TallyCompanyName = set1.Tables(0).Rows(0)("CompanyName")
            End If
        End If

        ' CompanyName = set1.Tables(0).Rows(0)("Company")
        ' VoucherTypeName = set1.Tables(0).Rows(0)("VoucherType")

        Dim xmlRequest As New StringBuilder()
        xmlRequest.AppendLine("<?xml version='1.0' encoding='UTF-8'?>")
        xmlRequest.AppendLine("<ENVELOPE>")
        xmlRequest.AppendLine("     <HEADER>")
        xmlRequest.AppendLine("         <VERSION>1</VERSION>")
        xmlRequest.AppendLine("         <TALLYREQUEST>Export</TALLYREQUEST>")
        xmlRequest.AppendLine("         <TYPE>Collection</TYPE>")
        xmlRequest.AppendLine("         <ID>GetVoucherByMasterID</ID>")
        xmlRequest.AppendLine("     </HEADER>")
        xmlRequest.AppendLine("     <BODY>")
        xmlRequest.AppendLine("         <DESC>")
        xmlRequest.AppendLine("             <STATICVARIABLES>")
        xmlRequest.AppendLine("                 <SVCURRENTCOMPANY>{XmlCompanyName}</SVCURRENTCOMPANY>")
        xmlRequest.AppendLine("             </STATICVARIABLES>")
        xmlRequest.AppendLine("             <TDL>")
        xmlRequest.AppendLine("                 <TDLMESSAGE>")
        xmlRequest.AppendLine("                     <COLLECTION NAME='GetVoucherByMasterID' ISMODIFY='No'>")
        xmlRequest.AppendLine("                         <TYPE>Voucher</TYPE>")
        xmlRequest.AppendLine("                         <FILTERS>ByMasterId</FILTERS>")
        xmlRequest.AppendLine("                         <FETCH>GUID,MASTERID,VOUCHERNUMBER,VOUCHERTYPENAME,DATE,PARTYLEDGERNAME</FETCH>")
        xmlRequest.AppendLine("                     </COLLECTION>")
        xmlRequest.AppendLine("                     <SYSTEM TYPE='Formulae' NAME='ByMasterId'>")
        xmlRequest.AppendLine("                         $MASTERID={XmlMasterID}")
        xmlRequest.AppendLine("                     </SYSTEM>")
        xmlRequest.AppendLine("                 </TDLMESSAGE>")
        xmlRequest.AppendLine("             </TDL>")
        xmlRequest.AppendLine("         </DESC>")
        xmlRequest.AppendLine("     </BODY>")
        xmlRequest.AppendLine("</ENVELOPE>")

        xmlRequest = xmlRequest.Replace("{XmlCompanyName}", TallyCompanyName)
        ' xmlRequest = xmlRequest.Replace("{XmlVoucherType}", VoucherTypeName)
        xmlRequest = xmlRequest.Replace("{XmlMasterID}", MasterId.ToString())

        Dim StrXmlRequest = xmlRequest.ToString()
        Dim Web_Response As String = SendRequestToTally_WebRequest(StrXmlRequest)

        If TallyResponseSuccess = True Then

            Dim xmlDoc As New XmlDocument()
            xmlDoc.LoadXml(Web_Response)
            Dim masteridnode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/MASTERID")
            If masteridnode IsNot Nothing Then
                TallyMasterId = Trim(masteridnode.InnerText)
            End If

            Dim guidnode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/GUID")
            If guidnode IsNot Nothing Then
                TallyGUID = Trim(guidnode.InnerText)
            End If

            Dim vouchernonode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/VOUCHERNUMBER")
            If guidnode IsNot Nothing Then
                TallyVoucherNo = Trim(vouchernonode.InnerText)
            End If

            Dim voucherdateNode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/DATE")
            If voucherdateNode IsNot Nothing Then
                TallyVoucherDate = Trim(voucherdateNode.InnerText)
            End If

            Dim vouchertypeNode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER/VOUCHERTYPENAME")
            If vouchertypeNode IsNot Nothing Then
                TallyVoucherType = Trim(vouchertypeNode.InnerText)
            End If

            Dim VoucherNode As XmlNode = xmlDoc.SelectSingleNode("//DATA/COLLECTION/VOUCHER")
            If VoucherNode IsNot Nothing Then
                If VoucherNode.Attributes("REMOTEID") IsNot Nothing Then
                    TallyRemoteID = Trim(VoucherNode.Attributes("REMOTEID").Value)
                End If
            End If

            If Int(TallyMasterId) = Int(MasterId) Then
                vchExist = True
            Else
                vchExist = False
            End If

        End If

        Return vchExist
    End Function
    Public Function CleanTallyString(input As String) As String
        If String.IsNullOrEmpty(input) Then
            Return String.Empty
        End If

        ' 1. Remove all non-printable ASCII chars (control chars 0x00–0x1F and 0x7F)
        Dim cleaned As String = Regex.Replace(input, "[^\u0020-\u007E]", "")

        ' 2. Trim spaces (sometimes junk hides as trailing spaces)
        cleaned = cleaned.Trim()

        ' 3. Remove Byte Order Mark (BOM) if present
        cleaned = cleaned.Replace(ChrW(&HFEFF), "")

        Return cleaned
    End Function

    Public Function EncodeToXML(ByVal inputvalue As String) As String
        Dim retvalue As String = ""
        retvalue = inputvalue.Replace("&", "&amp;")
        retvalue = retvalue.Replace("<", "&lt;")
        retvalue = retvalue.Replace(">", "&gt;")
        retvalue = retvalue.Replace("""", "&quot;")
        retvalue = retvalue.Replace("'", "&apos;")
        Return retvalue
    End Function


    Public Function SendRequestToTally_WebRequest(ByVal RequestXML As String) As String
        Dim data As String = RequestXML
        Dim TallyResponse As String = ""
        Dim responseContent As String = ""
        TallyResponseSuccess = False
        TallyResponseError = False

        'Dim url As String = "http://localhost:9000"
        'Dim url As String = ConfigurationManager.AppSettings("TallyRUL")
        Try
            Dim myRequest As HttpWebRequest = WebRequest.Create(TallyURL)
            Dim encoding As New UnicodeEncoding
            Dim buffer() As Byte = encoding.GetBytes(data)
            myRequest.AllowWriteStreamBuffering = False
            myRequest.Method = "POST"
            myRequest.ContentType = "UTF-16"
            myRequest.ContentLength = buffer.Length

            Using post As Stream = myRequest.GetRequestStream
                post.Write(buffer, 0, buffer.Length)
            End Using

            Using myResponse As HttpWebResponse = CType(myRequest.GetResponse(), HttpWebResponse)
                If myResponse.StatusCode = HttpStatusCode.OK Then
                    Using responseStream As Stream = myResponse.GetResponseStream
                        Using responsereader As StreamReader = New StreamReader(responseStream, System.Text.Encoding.Unicode, True)
                            responseContent = responsereader.ReadToEnd
                        End Using
                    End Using
                    TallyResponseSuccess = True
                    TallyResponse = responseContent
                Else
                    TallyResponseError = True
                    TallyResponse = "Error: " & myResponse.StatusCode
                End If
            End Using

        Catch ex As Exception
            TallyResponseError = True
            'TallyResponse = $"Unexpected error: {ex.Message}"
            TallyResponse = "Unexpected Error:" & ex.Message
            'Throw ex
        End Try

        Return TallyResponse

    End Function

    Public Function HandleTallyResponse(responseXml As String) As String
        Dim Response As String = ""
        Try

            If TallyResponseError = True Then
                Response = responseXml
                Exit Function
            End If

            Dim xmlDoc As New XmlDocument()
            xmlDoc.LoadXml(responseXml)

            'Validate the XML 
            Dim envelopeNode As XmlNode = xmlDoc.SelectSingleNode("/RESPONSE")
            If envelopeNode Is Nothing Then
                Response = "No Response from Tally"
                Exit Function
            End If

            ' Check for specific error messages or codes
            Dim errorNode As XmlNode = xmlDoc.SelectSingleNode("/RESPONSE/ERRORS")
            If errorNode IsNot Nothing Then
                If Trim(errorNode.InnerText) = "1" Then
                    Dim lineerrorNode As XmlNode = xmlDoc.SelectSingleNode("/RESPONSE/LINEERROR")
                    If lineerrorNode IsNot Nothing Then
                        'Response = $"{lineerrorNode.InnerText}"
                        TallyError = True
                        TallyLineError = Trim(lineerrorNode.InnerText)
                        Response = "Error:" + TallyLineError
                    Else
                        TallyError = True
                        TallyLineError = ""
                        Response = "Error occured in Tally"
                    End If
                End If
            End If

            Dim lineerrorNode1 As XmlNode = xmlDoc.SelectSingleNode("/RESPONSE/LINEERROR")
            If lineerrorNode1 IsNot Nothing Then
                'Response = $"{lineerrorNode.InnerText}"
                TallyError = True
                TallyLineError = Trim(lineerrorNode1.InnerText)
                Response = "Error:" + TallyLineError
                'Else
                '    TallyError = True
                '    TallyLineError = ""
                '    Response = "Error occured in Tally"
            End If

            ' Process the valid response
            Dim createdData As XmlNode = xmlDoc.SelectSingleNode("/RESPONSE/CREATED")
            If createdData IsNot Nothing Then
                If Trim(createdData.InnerText) = "1" Then
                    'Response = $"Data Inserted Successfully"
                    TallyCreated = True
                    Response = "Data Inserted Successfully"
                End If
            End If

            ' Process the valid response
            Dim alterData As XmlNode = xmlDoc.SelectSingleNode("/RESPONSE/ALTERED")
            If alterData IsNot Nothing Then
                If Trim(alterData.InnerText) = "1" Then
                    'Response = $"Data Modified Successfully"
                    TallyEdited = True
                    Response = "Data Modified Successfully"
                End If
            End If

            Dim deleteData As XmlNode = xmlDoc.SelectSingleNode("/RESPONSE/DELETED")
            If deleteData IsNot Nothing Then
                If Trim(deleteData.InnerText) = "1" Then
                    'Response = $"Data Deleted Successfully"
                    TallyDeleted = True
                    Response = "Data Deleted Successfully"
                End If
            End If

            Dim MasterIdNode As XmlNode = xmlDoc.SelectSingleNode("/RESPONSE/LASTVCHID")
            If MasterIdNode IsNot Nothing Then
                If Trim(MasterIdNode.InnerText) <> "" Then
                    TallyLastVchId = MasterIdNode.InnerText
                Else
                    TallyLastVchId = ""
                End If
            End If

        Catch ex As XmlException
            'Response = $"XML parsing error: {ex.Message}"
            Response = "XML parsing error:" & ex.Message
        Catch ex As Exception
            'Response = $"Unexpected error: {ex.Message}"
            Response = "Unexpected error:" & ex.Message
        End Try

        Return Response

    End Function
End Class










