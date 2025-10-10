Imports System.Data
Imports System.Data.SqlClient
Imports FOODERPWEB.DAL
Imports Microsoft.VisualBasic
Imports FOODERPWEB.Class

Namespace FOODERPWEB.Class
    Public Class clsDispatchLanding
        Public Shared docno As String
        Private mjobid As String
        Private mjobcreatedt As String
        Private mstartdate As String
        Private mstarttime As String
        Private mjobname As String
        Private mprioirty As String
        Private mprintcd As String
        Private mcuscode As String
        Private mintcode As String
        Private mrevno As String
        Private massignedto_challan As String
        Private mticketno As String
        Private moriginaljobid As String
        Private mjobversion As String
        Private mattachment1filename As String
        Private mattachmentname1 As String
        Private mattachmentpath1 As String
        Private mattachment2filename As String
        Private mattachmentname2 As String
        Private mattachmentpath2 As String
        Private mattachment3filename As String
        Private mattachmentname3 As String
        Private mattachmentpath3 As String
        Private mattachment4filename As String
        Private mattachmentname4 As String
        Private mattachmentpath4 As String
        Private mattachment5filename As String
        Private mattachmentname5 As String
        Private mattachmentpath5 As String
        Private mattachment6filename As String
        Private mattachmentname6 As String
        Private mattachmentpath6 As String
        Private mattachment7filename As String
        Private mattachmentname7 As String
        Private mattachmentpath7 As String
        Private mattachment8filename As String
        Private mattachmentname8 As String
        Private mattachmentpath8 As String
        Private mattachment9filename As String
        Private mattachmentname9 As String
        Private mattachmentpath9 As String
        Private mattachment10filename As String
        Private mattachmentname10 As String
        Private mattachmentpath10 As String
        Private mlink1 As String
        Private mlink2 As String
        Private mlink3 As String
        Private mlink4 As String
        Private mlink5 As String
        Private mcustomerinstruction As String
        Private mthickcd As String
        Private mplatetypecd As String
        Private mnoofplates As String
        Private mopcode As String

        Private mlength_plate_cms As String
        Private mwidth_plate_cms As String
        Private mchlno As String
        Private mchldt As String
        'Private mbillno As String

        Private msendfor_dispatch_comments As String
        'Private mbilldate As String
        Private msendfor_dispatch_flag As String
        Private mprintercd As String
        Private mplate_processed_date As String

        Private mtranscd As String
        Private mcompcd As String


        Private mcrtuserid As String
        Private mcrtuserdt As String
        Private mmoduserid As String
        Private mmoduserdt As String

        Public Property compcd() As String
            Get
                Return mcompcd
            End Get
            Set(ByVal value As String)
                mcompcd = value
            End Set
        End Property

        Public Property transcd() As String
            Get
                Return mtranscd
            End Get
            Set(ByVal value As String)
                mtranscd = value
            End Set
        End Property

        Public Property plate_processed_date() As String
            Get
                Return mplate_processed_date
            End Get
            Set(ByVal value As String)
                mplate_processed_date = value
            End Set
        End Property

        Public Property printercd() As String
            Get
                Return mprintercd
            End Get
            Set(ByVal value As String)
                mprintercd = value
            End Set
        End Property

        Public Property sendfor_dispatch_flag() As String
            Get
                Return msendfor_dispatch_flag
            End Get
            Set(ByVal value As String)
                msendfor_dispatch_flag = value
            End Set
        End Property

        'Public Property billdate() As String
        '    Get
        '        Return mbilldate
        '    End Get
        '    Set(ByVal value As String)
        '        mbilldate = value
        '    End Set
        'End Property

        Public Property sendfor_dispatch_comments() As String
            Get
                Return msendfor_dispatch_comments
            End Get
            Set(ByVal value As String)
                msendfor_dispatch_comments = value
            End Set
        End Property

        Public Property length_plate_cms() As String
            Get
                Return mlength_plate_cms
            End Get
            Set(ByVal value As String)
                mlength_plate_cms = value
            End Set
        End Property

        Public Property width_plate_cms() As String
            Get
                Return mwidth_plate_cms
            End Get
            Set(ByVal value As String)
                mwidth_plate_cms = value
            End Set
        End Property

        Public Property chlno() As String
            Get
                Return mchlno
            End Get
            Set(ByVal value As String)
                mchlno = value
            End Set
        End Property

        Public Property chldt() As String
            Get
                Return mchldt
            End Get
            Set(ByVal value As String)
                mchldt = value
            End Set
        End Property

        'Public Property billno() As String
        '    Get
        '        Return mbillno
        '    End Get
        '    Set(ByVal value As String)
        '        mbillno = value
        '    End Set
        'End Property


        Public Property opcode() As String
            Get
                Return mopcode
            End Get
            Set(ByVal value As String)
                mopcode = value
            End Set
        End Property




        Public Property thickcd() As String
            Get
                Return mthickcd
            End Get
            Set(ByVal value As String)
                mthickcd = value
            End Set
        End Property

        Public Property platetypecd() As String
            Get
                Return mplatetypecd
            End Get
            Set(ByVal value As String)
                mplatetypecd = value
            End Set
        End Property

        Public Property noofplates() As String
            Get
                Return mnoofplates
            End Get
            Set(ByVal value As String)
                mnoofplates = value
            End Set
        End Property




        Public Property jobid() As String
            Get
                Return mjobid
            End Get
            Set(ByVal value As String)
                mjobid = value
            End Set
        End Property

        Public Property jobcreatedt() As String
            Get
                Return mjobcreatedt
            End Get
            Set(ByVal value As String)
                mjobcreatedt = value
            End Set
        End Property

        Public Property startdate() As String
            Get
                Return mstartdate
            End Get
            Set(ByVal value As String)
                mstartdate = value
            End Set
        End Property

        Public Property starttime() As String
            Get
                Return mstarttime
            End Get
            Set(ByVal value As String)
                mstarttime = value
            End Set
        End Property



        Public Property jobname() As String
            Get
                Return mjobname
            End Get
            Set(ByVal value As String)
                mjobname = value
            End Set
        End Property

        Public Property prioirty() As String
            Get
                Return mprioirty
            End Get
            Set(ByVal value As String)
                mprioirty = value
            End Set
        End Property

        Public Property printcd() As String
            Get
                Return mprintcd
            End Get
            Set(ByVal value As String)
                mprintcd = value
            End Set
        End Property

        Public Property cuscode() As String
            Get
                Return mcuscode
            End Get
            Set(ByVal value As String)
                mcuscode = value
            End Set
        End Property

        Public Property intcode() As String
            Get
                Return mintcode
            End Get
            Set(ByVal value As String)
                mintcode = value
            End Set
        End Property

        Public Property revno() As String
            Get
                Return mrevno
            End Get
            Set(ByVal value As String)
                mrevno = value
            End Set
        End Property


        Public Property assignedto_challan() As String
            Get
                Return massignedto_challan
            End Get
            Set(ByVal value As String)
                massignedto_challan = value
            End Set
        End Property

        Public Property ticketno() As String
            Get
                Return mticketno
            End Get
            Set(ByVal value As String)
                mticketno = value
            End Set
        End Property

        Public Property originaljobid() As String
            Get
                Return moriginaljobid
            End Get
            Set(ByVal value As String)
                moriginaljobid = value
            End Set
        End Property
        Public Property jobversion() As String
            Get
                Return mjobversion
            End Get
            Set(ByVal value As String)
                mjobversion = value
            End Set
        End Property

        Public Property attachment1filename() As String
            Get
                Return mattachment1filename
            End Get
            Set(ByVal value As String)
                mattachment1filename = value
            End Set
        End Property


        Public Property attachmentname1() As String
            Get
                Return mattachmentname1
            End Get
            Set(ByVal value As String)
                mattachmentname1 = value
            End Set
        End Property


        Public Property attachmentpath1() As String
            Get
                Return mattachmentpath1
            End Get
            Set(ByVal value As String)
                mattachmentpath1 = value
            End Set
        End Property



        Public Property attachment2filename() As String
            Get
                Return mattachment2filename
            End Get
            Set(ByVal value As String)
                mattachment2filename = value
            End Set
        End Property


        Public Property attachmentname2() As String
            Get
                Return mattachmentname2
            End Get
            Set(ByVal value As String)
                mattachmentname2 = value
            End Set
        End Property


        Public Property attachmentpath2() As String
            Get
                Return mattachmentpath2
            End Get
            Set(ByVal value As String)
                mattachmentpath2 = value
            End Set
        End Property


        Public Property attachment3filename() As String
            Get
                Return mattachment3filename
            End Get
            Set(ByVal value As String)
                mattachment3filename = value
            End Set
        End Property


        Public Property attachmentname3() As String
            Get
                Return mattachmentname3
            End Get
            Set(ByVal value As String)
                mattachmentname3 = value
            End Set
        End Property


        Public Property attachmentpath3() As String
            Get
                Return mattachmentpath3
            End Get
            Set(ByVal value As String)
                mattachmentpath3 = value
            End Set
        End Property


        Public Property attachment4filename() As String
            Get
                Return mattachment4filename
            End Get
            Set(ByVal value As String)
                mattachment4filename = value
            End Set
        End Property


        Public Property attachmentname4() As String
            Get
                Return mattachmentname4
            End Get
            Set(ByVal value As String)
                mattachmentname4 = value
            End Set
        End Property


        Public Property attachmentpath4() As String
            Get
                Return mattachmentpath4
            End Get
            Set(ByVal value As String)
                mattachmentpath4 = value
            End Set
        End Property


        Public Property attachment5filename() As String
            Get
                Return mattachment5filename
            End Get
            Set(ByVal value As String)
                mattachment5filename = value
            End Set
        End Property


        Public Property attachmentname5() As String
            Get
                Return mattachmentname5
            End Get
            Set(ByVal value As String)
                mattachmentname5 = value
            End Set
        End Property


        Public Property attachmentpath5() As String
            Get
                Return mattachmentpath5
            End Get
            Set(ByVal value As String)
                mattachmentpath5 = value
            End Set
        End Property



        Public Property attachment6filename() As String
            Get
                Return mattachment6filename
            End Get
            Set(ByVal value As String)
                mattachment6filename = value
            End Set
        End Property


        Public Property attachmentname6() As String
            Get
                Return mattachmentname6
            End Get
            Set(ByVal value As String)
                mattachmentname6 = value
            End Set
        End Property


        Public Property attachmentpath6() As String
            Get
                Return mattachmentpath6
            End Get
            Set(ByVal value As String)
                mattachmentpath6 = value
            End Set
        End Property


        Public Property attachment7filename() As String
            Get
                Return mattachment7filename
            End Get
            Set(ByVal value As String)
                mattachment7filename = value
            End Set
        End Property


        Public Property attachmentname7() As String
            Get
                Return mattachmentname7
            End Get
            Set(ByVal value As String)
                mattachmentname7 = value
            End Set
        End Property


        Public Property attachmentpath7() As String
            Get
                Return mattachmentpath7
            End Get
            Set(ByVal value As String)
                mattachmentpath7 = value
            End Set
        End Property



        Public Property attachment8filename() As String
            Get
                Return mattachment8filename
            End Get
            Set(ByVal value As String)
                mattachment8filename = value
            End Set
        End Property


        Public Property attachmentname8() As String
            Get
                Return mattachmentname8
            End Get
            Set(ByVal value As String)
                mattachmentname8 = value
            End Set
        End Property


        Public Property attachmentpath8() As String
            Get
                Return mattachmentpath8
            End Get
            Set(ByVal value As String)
                mattachmentpath8 = value
            End Set
        End Property


        Public Property attachment9filename() As String
            Get
                Return mattachment9filename
            End Get
            Set(ByVal value As String)
                mattachment9filename = value
            End Set
        End Property


        Public Property attachmentname9() As String
            Get
                Return mattachmentname9
            End Get
            Set(ByVal value As String)
                mattachmentname9 = value
            End Set
        End Property


        Public Property attachmentpath9() As String
            Get
                Return mattachmentpath9
            End Get
            Set(ByVal value As String)
                mattachmentpath9 = value
            End Set
        End Property


        Public Property attachment10filename() As String
            Get
                Return mattachment10filename
            End Get
            Set(ByVal value As String)
                mattachment10filename = value
            End Set
        End Property


        Public Property attachmentname10() As String
            Get
                Return mattachmentname10
            End Get
            Set(ByVal value As String)
                mattachmentname10 = value
            End Set
        End Property


        Public Property attachmentpath10() As String
            Get
                Return mattachmentpath10
            End Get
            Set(ByVal value As String)
                mattachmentpath10 = value
            End Set
        End Property


        Public Property link1() As String
            Get
                Return mlink1
            End Get
            Set(ByVal value As String)
                mlink1 = value
            End Set
        End Property

        Public Property link2() As String
            Get
                Return mlink2
            End Get
            Set(ByVal value As String)
                mlink2 = value
            End Set
        End Property


        Public Property link3() As String
            Get
                Return mlink3
            End Get
            Set(ByVal value As String)
                mlink3 = value
            End Set
        End Property

        Public Property link4() As String
            Get
                Return mlink4
            End Get
            Set(ByVal value As String)
                mlink4 = value
            End Set
        End Property

        Public Property link5() As String
            Get
                Return mlink5
            End Get
            Set(ByVal value As String)
                mlink5 = value
            End Set
        End Property

        Public Property customerinstruction() As String
            Get
                Return mcustomerinstruction
            End Get
            Set(ByVal value As String)
                mcustomerinstruction = value
            End Set
        End Property

        Public Property crtuserid() As String
            Get
                Return mcrtuserid
            End Get
            Set(ByVal value As String)
                mcrtuserid = value
            End Set
        End Property

        Public Property crtuserdt() As String
            Get
                Return mcrtuserdt
            End Get
            Set(ByVal value As String)
                mcrtuserdt = value
            End Set
        End Property

        Public Property moduserid() As String
            Get
                Return mmoduserid
            End Get
            Set(ByVal value As String)
                mmoduserid = value
            End Set
        End Property

        Public Property moduserdt() As String
            Get
                Return mmoduserdt
            End Get
            Set(ByVal value As String)
                mmoduserdt = value
            End Set
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConfigurationManager.ConnectionStrings("ConStrFood").ConnectionString)
        End Function

        Public Shared Function GetCommand() As SqlCommand
            Return New SqlCommand()
        End Function

        Public Shared Function FillData(ByVal jobid As String, ByVal Flag As String) As clsDispatchLanding
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@jobcreatedt", ""))
                db.Parameters.Add(New SqlParameter("@plate_processed_date", ""))
                db.Parameters.Add(New SqlParameter("@jobid", jobid))
                db.Parameters.Add(New SqlParameter("@jobname", ""))
                db.Parameters.Add(New SqlParameter("@intcode", ""))
                db.Parameters.Add(New SqlParameter("@prioirty", ""))
                db.Parameters.Add(New SqlParameter("@assignedto_challan", ""))
                db.Parameters.Add(New SqlParameter("@compcd", ""))
                db.Parameters.Add(New SqlParameter("@cuscode", ""))
                db.Parameters.Add(New SqlParameter("@shipto", ""))
                db.Parameters.Add(New SqlParameter("@transcd", ""))
                db.Parameters.Add(New SqlParameter("@ticketno", ""))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))
                db.Parameters.Add(New SqlParameter("@empcd", ""))
                db.Parameters.Add(New SqlParameter("@status", ""))

                Dim dt As DataTable = db.ExecuteDataTable("Sp_jobdispatchLanding_GetData")
                If dt.Rows.Count > 0 Then
                    Dim obj As clsDispatchLanding = New clsDispatchLanding
                    If Not IsDBNull(dt.Rows(0)("jobid")) Then
                        obj.jobid = dt.Rows(0)("jobid").ToString
                    End If
                    obj.jobcreatedt = dt.Rows(0)("jobcreatedt").ToString
                    obj.startdate = dt.Rows(0)("startdate").ToString
                    obj.starttime = dt.Rows(0)("starttime").ToString
                    obj.jobname = dt.Rows(0)("jobname").ToString
                    obj.prioirty = dt.Rows(0)("prioirty").ToString
                    obj.printcd = dt.Rows(0)("printcd").ToString
                    obj.cuscode = dt.Rows(0)("cuscode").ToString
                    obj.intcode = dt.Rows(0)("intcode").ToString
                    obj.revno = dt.Rows(0)("revno").ToString
                    obj.assignedto_challan = dt.Rows(0)("assignedto_challan").ToString
                    obj.ticketno = dt.Rows(0)("ticketno").ToString
                    obj.originaljobid = dt.Rows(0)("originaljobid").ToString
                    obj.jobversion = dt.Rows(0)("jobversion").ToString
                    obj.attachment1filename = dt.Rows(0)("attachment1filename").ToString
                    obj.attachmentname1 = dt.Rows(0)("attachmentname1").ToString
                    obj.attachmentpath1 = dt.Rows(0)("attachmentpath1").ToString
                    obj.attachment2filename = dt.Rows(0)("attachment2filename").ToString
                    obj.attachmentname2 = dt.Rows(0)("attachmentname2").ToString
                    obj.attachmentpath2 = dt.Rows(0)("attachmentpath2").ToString
                    obj.attachment3filename = dt.Rows(0)("attachment3filename").ToString
                    obj.attachmentname3 = dt.Rows(0)("attachmentname3").ToString
                    obj.attachmentpath3 = dt.Rows(0)("attachmentpath3").ToString
                    obj.attachment4filename = dt.Rows(0)("attachment4filename").ToString
                    obj.attachmentname4 = dt.Rows(0)("attachmentname4").ToString
                    obj.attachmentpath4 = dt.Rows(0)("attachmentpath4").ToString
                    obj.attachment5filename = dt.Rows(0)("attachment5filename").ToString
                    obj.attachmentname5 = dt.Rows(0)("attachmentname5").ToString
                    obj.attachmentpath5 = dt.Rows(0)("attachmentpath5").ToString
                    obj.attachment6filename = dt.Rows(0)("attachment6filename").ToString
                    obj.attachmentname6 = dt.Rows(0)("attachmentname6").ToString
                    obj.attachment7filename = dt.Rows(0)("attachment7filename").ToString
                    obj.attachmentname7 = dt.Rows(0)("attachmentname7").ToString
                    obj.attachmentpath7 = dt.Rows(0)("attachmentpath7").ToString
                    obj.attachment8filename = dt.Rows(0)("attachment8filename").ToString
                    obj.attachmentname8 = dt.Rows(0)("attachmentname8").ToString
                    obj.attachmentpath8 = dt.Rows(0)("attachmentpath8").ToString
                    obj.attachment9filename = dt.Rows(0)("attachment9filename").ToString
                    obj.attachmentname9 = dt.Rows(0)("attachmentname9").ToString
                    obj.attachmentpath9 = dt.Rows(0)("attachmentpath9").ToString
                    obj.attachment10filename = dt.Rows(0)("attachment10filename").ToString
                    obj.attachmentname10 = dt.Rows(0)("attachmentname10").ToString
                    obj.attachmentpath10 = dt.Rows(0)("attachmentpath10").ToString

                    obj.link1 = dt.Rows(0)("link1").ToString
                    obj.link2 = dt.Rows(0)("link2").ToString
                    obj.link3 = dt.Rows(0)("link3").ToString
                    obj.link4 = dt.Rows(0)("link4").ToString
                    obj.link5 = dt.Rows(0)("link5").ToString
                    obj.customerinstruction = dt.Rows(0)("customerinstruction").ToString


                    obj.thickcd = dt.Rows(0)("thickcd").ToString
                    obj.platetypecd = dt.Rows(0)("platetypecd").ToString
                    obj.noofplates = dt.Rows(0)("noofplates").ToString
                    obj.opcode = dt.Rows(0)("opcode").ToString
                    obj.length_plate_cms = dt.Rows(0)("length_plate_cms").ToString
                    obj.width_plate_cms = dt.Rows(0)("width_plate_cms").ToString
                    obj.chlno = dt.Rows(0)("chlno").ToString
                    obj.chldt = dt.Rows(0)("chldt").ToString
                    'obj.billno = dt.Rows(0)("billno").ToString
                    obj.sendfor_dispatch_comments = dt.Rows(0)("sendfor_dispatch_comments").ToString
                    'obj.billdate = dt.Rows(0)("billdate").ToString
                    obj.sendfor_dispatch_flag = dt.Rows(0)("sendfor_dispatch_flag").ToString
                    obj.printercd = dt.Rows(0)("printercd").ToString
                    obj.plate_processed_date = dt.Rows(0)("plate_processed_date").ToString
                    obj.transcd = dt.Rows(0)("transcd").ToString

                    obj.compcd = dt.Rows(0)("compcd").ToString


                    Return obj
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetDataAll(ByVal jobid As String, ByVal fromdt As String, ByVal todt As String, ByVal cuscode As String, ByVal Flag As String) As DataTable
            Try
                Dim db As DBAccess = New DBAccess
                db.Parameters.Add(New SqlParameter("@jobid", jobid))
                db.Parameters.Add(New SqlParameter("@fromdt", fromdt))
                db.Parameters.Add(New SqlParameter("@todt", todt))
                db.Parameters.Add(New SqlParameter("@cuscode", cuscode))
                db.Parameters.Add(New SqlParameter("@Flag", Flag))
                Dim dt As DataTable = db.ExecuteDataTable("Sp_jobdispatchLanding_GetData")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function



        Public Shared Function Fetch_Paramno(ByVal ccode As String) As Integer
            Dim con As SqlConnection
            Dim com As SqlCommand
            Dim DOCTYPE, DOCCODE As String
            Dim p As Int16


            con = GetConnection()
            com = GetCommand()

            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "select paramno from parameter "

            Try
                con.Open()
                p = com.ExecuteScalar
                If IsDBNull(p) Then
                    p = 0
                End If
                p = p + 1
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con = Nothing
            End Try

            Return p
        End Function

        Public Shared Function Generate_Docno(ByVal paramno As Integer, ByVal Doctype As String, ByVal ccode As String)
            Try
                Dim startyr, endyr, doccode As String
                Dim docsrno As String
                'ccode = DBAccess.CmpCode

                Call DBAccess.Find_company()
                startyr = Right(Trim(DBAccess.FinStart), 4)
                endyr = Right(Trim(DBAccess.FinEnd), 2)
                docsrno = DocumentSrno(paramno, 4)

                Generate_Docno = Trim(startyr) & "-" & Trim(endyr) & "_" & Trim(docsrno)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function DocumentSrno(ByVal p As Integer, ByVal strlen As Integer) As String
            If strlen > Len(CStr(p)) Then
                DocumentSrno = StrDup(strlen - Len(CStr(p)), "0") + CStr(p)
            Else
                DocumentSrno = CStr(p)
            End If
        End Function



        Public Shared Function Update_Data_Add(ByVal o As clsDispatchLanding, ByVal paramno As Integer, ByVal mode As String, ByVal ccode As String) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim dadet As New SqlDataAdapter
            Dim comdetold As SqlCommand
            Dim comdet As SqlCommand
            Dim cbdet As SqlCommandBuilder
            Dim Com1, Com2 As SqlCommand
            Dim Ssql1, Ssql2, Ssql3 As String
            Dim i As Integer
            Dim comparam As SqlCommand
            Dim DOCTYPE, doccode As String



            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure
            If o.jobid = "" Then
                Com1.Parameters.Add(New SqlParameter("@jobid", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@jobid", o.jobid))
            End If
            Com1.Parameters.Add(New SqlParameter("@jobcreatedt", o.jobcreatedt))
            Com1.Parameters.Add(New SqlParameter("@startdate", o.startdate))
            Com1.Parameters.Add(New SqlParameter("@starttime", o.starttime))
            Com1.Parameters.Add(New SqlParameter("@jobname", o.jobname))

            Com1.Parameters.Add(New SqlParameter("@prioirty", o.prioirty))
            Com1.Parameters.Add(New SqlParameter("@printcd", o.printcd))
            Com1.Parameters.Add(New SqlParameter("@cuscode", o.cuscode))
            Com1.Parameters.Add(New SqlParameter("@intcode", o.intcode))
            Com1.Parameters.Add(New SqlParameter("@revno", o.revno))
            Com1.Parameters.Add(New SqlParameter("@assignedto_appformgraphic", o.assignedto_challan))
            Com1.Parameters.Add(New SqlParameter("@ticketno", o.ticketno))
            Com1.Parameters.Add(New SqlParameter("@originaljobid", o.originaljobid))
            Com1.Parameters.Add(New SqlParameter("@jobversion", o.jobversion))
            Com1.Parameters.Add(New SqlParameter("@attachment1filename", o.attachment1filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname1", o.attachmentname1))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath1", o.attachmentpath1))
            Com1.Parameters.Add(New SqlParameter("@attachment2filename", o.attachment2filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname2", o.attachmentname2))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath2", o.attachmentpath2))
            Com1.Parameters.Add(New SqlParameter("@attachment3filename", o.attachment3filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname3", o.attachmentname3))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath3", o.attachmentpath3))
            Com1.Parameters.Add(New SqlParameter("@attachment4filename", o.attachment4filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname4", o.attachmentname4))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath4", o.attachmentpath4))
            Com1.Parameters.Add(New SqlParameter("@attachment5filename", o.attachment5filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname5", o.attachmentname5))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath5", o.attachmentpath5))
            Com1.Parameters.Add(New SqlParameter("@attachment6filename", o.attachment6filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname6", o.attachmentname6))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath6", o.attachmentpath6))
            Com1.Parameters.Add(New SqlParameter("@attachment7filename", o.attachment7filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname7", o.attachmentname7))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath7", o.attachmentpath7))
            Com1.Parameters.Add(New SqlParameter("@attachment8filename", o.attachment8filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname8", o.attachmentname8))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath8", o.attachmentpath8))
            Com1.Parameters.Add(New SqlParameter("@attachment9filename", o.attachment9filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname9", o.attachmentname9))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath9", o.attachmentpath9))
            Com1.Parameters.Add(New SqlParameter("@attachment10filename", o.attachment10filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname10", o.attachmentname10))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath10", o.attachmentpath10))
            Com1.Parameters.Add(New SqlParameter("@link1", o.link1))
            Com1.Parameters.Add(New SqlParameter("@link2", o.link2))
            Com1.Parameters.Add(New SqlParameter("@link3", o.link3))
            Com1.Parameters.Add(New SqlParameter("@link4", o.link4))
            Com1.Parameters.Add(New SqlParameter("@link5", o.link5))
            Com1.Parameters.Add(New SqlParameter("@customerinstruction", o.customerinstruction))
            Com1.Parameters.Add(New SqlParameter("@transcd", o.transcd))
            Com1.Parameters.Add(New SqlParameter("@compcd", o.compcd))

            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))
            Com1.Parameters.Add(New SqlParameter("@Flag", "A"))

            Ssql1 = "Sp_jobentryGRAPHCIS_AE"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

            comparam = New SqlCommand
            comparam.Connection = Con
            comparam.CommandType = CommandType.Text
            comparam.CommandText = "Update parameter Set [paramno]=" & Val(paramno) & " "
            comparam.Transaction = Trans

            Try
                comparam.ExecuteNonQuery()
                i = Com1.ExecuteNonQuery()
                Trans.Commit()
            Catch ex As Exception
                If (Not (Trans) Is Nothing) Then
                    Trans.Rollback()
                End If
                Throw ex
            Finally
                Com1 = Nothing
                Con.Close()
                Con = Nothing
                Trans = Nothing
            End Try
            Return i
        End Function

        Public Shared Function Update_Data_Edit(ByVal o As clsDispatchLanding, ByVal paramno As Integer, ByVal mode As String, ByVal ccode As String) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim dadet As New SqlDataAdapter
            Dim comdetold As SqlCommand
            Dim comdet As SqlCommand
            Dim cbdet As SqlCommandBuilder
            Dim Com1, Com2 As SqlCommand
            Dim Ssql1, Ssql2, Ssql3 As String
            Dim i As Integer
            Dim comparam As SqlCommand
            Dim doccode As String


            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction



            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure
            If o.jobid = "" Then
                Com1.Parameters.Add(New SqlParameter("@jobid", System.DBNull.Value))
            Else
                Com1.Parameters.Add(New SqlParameter("@jobid", o.jobid))
            End If
            Com1.Parameters.Add(New SqlParameter("@jobcreatedt", o.jobcreatedt))
            Com1.Parameters.Add(New SqlParameter("@startdate", o.startdate))
            Com1.Parameters.Add(New SqlParameter("@starttime", o.starttime))
            Com1.Parameters.Add(New SqlParameter("@jobname", o.jobname))

            Com1.Parameters.Add(New SqlParameter("@prioirty", o.prioirty))
            Com1.Parameters.Add(New SqlParameter("@printcd", o.printcd))
            Com1.Parameters.Add(New SqlParameter("@cuscode", o.cuscode))
            Com1.Parameters.Add(New SqlParameter("@intcode", o.intcode))
            Com1.Parameters.Add(New SqlParameter("@revno", o.revno))
            Com1.Parameters.Add(New SqlParameter("@assignedto_challan", o.assignedto_challan))
            Com1.Parameters.Add(New SqlParameter("@ticketno", o.ticketno))
            Com1.Parameters.Add(New SqlParameter("@originaljobid", o.originaljobid))
            Com1.Parameters.Add(New SqlParameter("@jobversion", o.jobversion))
            Com1.Parameters.Add(New SqlParameter("@attachment1filename", o.attachment1filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname1", o.attachmentname1))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath1", o.attachmentpath1))
            Com1.Parameters.Add(New SqlParameter("@attachment2filename", o.attachment2filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname2", o.attachmentname2))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath2", o.attachmentpath2))
            Com1.Parameters.Add(New SqlParameter("@attachment3filename", o.attachment3filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname3", o.attachmentname3))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath3", o.attachmentpath3))
            Com1.Parameters.Add(New SqlParameter("@attachment4filename", o.attachment4filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname4", o.attachmentname4))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath4", o.attachmentpath4))
            Com1.Parameters.Add(New SqlParameter("@attachment5filename", o.attachment5filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname5", o.attachmentname5))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath5", o.attachmentpath5))
            Com1.Parameters.Add(New SqlParameter("@attachment6filename", o.attachment6filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname6", o.attachmentname6))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath6", o.attachmentpath6))
            Com1.Parameters.Add(New SqlParameter("@attachment7filename", o.attachment7filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname7", o.attachmentname7))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath7", o.attachmentpath7))
            Com1.Parameters.Add(New SqlParameter("@attachment8filename", o.attachment8filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname8", o.attachmentname8))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath8", o.attachmentpath8))
            Com1.Parameters.Add(New SqlParameter("@attachment9filename", o.attachment9filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname9", o.attachmentname9))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath9", o.attachmentpath9))
            Com1.Parameters.Add(New SqlParameter("@attachment10filename", o.attachment10filename))
            Com1.Parameters.Add(New SqlParameter("@attachmentname10", o.attachmentname10))
            Com1.Parameters.Add(New SqlParameter("@attachmentpath10", o.attachmentpath10))
            Com1.Parameters.Add(New SqlParameter("@link1", o.link1))
            Com1.Parameters.Add(New SqlParameter("@link2", o.link2))
            Com1.Parameters.Add(New SqlParameter("@link3", o.link3))
            Com1.Parameters.Add(New SqlParameter("@link4", o.link4))
            Com1.Parameters.Add(New SqlParameter("@link5", o.link5))
            Com1.Parameters.Add(New SqlParameter("@customerinstruction", o.customerinstruction))
            Com1.Parameters.Add(New SqlParameter("@platetypecd", o.platetypecd))
            Com1.Parameters.Add(New SqlParameter("@noofplates", o.noofplates))
            Com1.Parameters.Add(New SqlParameter("@opcode", o.opcode))
            Com1.Parameters.Add(New SqlParameter("@length_plate_cms", o.length_plate_cms))
            Com1.Parameters.Add(New SqlParameter("@width_plate_cms", o.width_plate_cms))
            Com1.Parameters.Add(New SqlParameter("@chlno", o.chlno))
            Com1.Parameters.Add(New SqlParameter("@chldt", o.chldt))
            'Com1.Parameters.Add(New SqlParameter("@billno", o.billno))
            'Com1.Parameters.Add(New SqlParameter("@billdate", o.billdate))
            Com1.Parameters.Add(New SqlParameter("@sendfor_dispatch_comments", o.sendfor_dispatch_comments))
            Com1.Parameters.Add(New SqlParameter("@plate_processed_date", o.plate_processed_date))

            Com1.Parameters.Add(New SqlParameter("@transcd", o.transcd))
            Com1.Parameters.Add(New SqlParameter("@compcd", o.compcd))

            Com1.Parameters.Add(New SqlParameter("@crtuserid", o.crtuserid))
            Com1.Parameters.Add(New SqlParameter("@crtuserdt", o.crtuserdt))
            Com1.Parameters.Add(New SqlParameter("@moduserid", o.moduserid))
            Com1.Parameters.Add(New SqlParameter("@moduserdt", o.moduserdt))
            Com1.Parameters.Add(New SqlParameter("@Flag", "E"))

            Ssql1 = "Sp_jobChallan_AE"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

            Try
                i = Com1.ExecuteNonQuery()
                Trans.Commit()
            Catch ex As Exception
                If (Not (Trans) Is Nothing) Then
                    Trans.Rollback()
                End If
                Throw ex
            Finally
                Com1 = Nothing
                Con.Close()
                Con = Nothing
                Trans = Nothing
            End Try
            Return i
        End Function

        Public Shared Function Delete(ByVal o As clsDispatchLanding) As Integer
            Dim Con As SqlConnection
            Dim Trans As SqlTransaction
            Dim Com1 As SqlCommand
            Dim Ssql1 As String
            Dim i As Integer

            Con = GetConnection()
            Con.Open()
            Trans = Con.BeginTransaction

            Com1 = New SqlCommand
            Com1.Connection = Con
            Com1.CommandType = CommandType.StoredProcedure

            Com1.Parameters.Add(New SqlParameter("@jobid", o.jobid))

            Ssql1 = "Sp_jobentry_Delete"
            Com1.CommandText = Ssql1
            Com1.Transaction = Trans

            Try
                i = Com1.ExecuteNonQuery()
                Trans.Commit()
            Catch ex As Exception
                If (Not (Trans) Is Nothing) Then
                    Trans.Rollback()
                End If
                Throw ex
            Finally
                Com1 = Nothing
                Con.Close()
                Con = Nothing
                Trans = Nothing
            End Try
            Return i
        End Function


    End Class
End Namespace

