<%@ Page Language="VB"  AutoEventWireup="false"  CodeFile="MainDashBoard.aspx.vb" Inherits="MainDashBoard" %>





<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"
        name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">

    <!-- Theme style -->
<%--    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">--%>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <%-- <link href="Font%20Awesome/css/font-awesome.css" rel="stylesheet" />--%>
    <%-- <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">--%>
    <style>
        table th {
            position: sticky;
            top: 0;
            background: lightgray;
        }

        .content-header{
            padding: 15px 15px 15px 15px;
         background: lightgray;
         margin-bottom:15px;
        }
    </style>
    <script>

        
    </script>
</head>





<body class="fixed  hold-transition skin-blue sidebar-mini" style="background: #ecf0f5">
    <form id="Form1" runat="server">
        <div class="">
            <!-- Content Wrapper. Contains page content -->
            <div class="">
                <!-- Content Header (Page header) -->
                
                <!-- Main content -->
                <section class="content">

                    <section class="content-header">
          <h1>
            Dry Offset		
            
          </h1>
       
        </section>

  

          <!-- Small boxes (Stat box) -->
         <div id="Header" runat="server" class="row">
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblTotalJobs"></asp:Label></h3>
                  <p>Total Jobs</p>
                </div>
                  
               
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblPendingJobs"></asp:Label></h3>
                  <p>Pending Jobs</p>
                </div>
                    
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-yellow" style="left: 0px; top: 0px">
                <div class="inner">
                  <h3> <asp:Label runat="server" ID="lblSendToGraphics"></asp:Label></h3>
                  <p>Send To Graphics</p>
                </div>
              
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">              

                  <h3> <asp:Label runat="server" ID="lblSendToCustomer"></asp:Label></h3>
                  <p>Send To Customer</p>
                </div>
                
               
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->



         <div id="Div3" runat="server" class="row">
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblSendTOCustomerForApproval"></asp:Label></h3>
                  <p>Send To Customer For Approval</p>
                </div>
                  
               
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblSendToPrepress"></asp:Label></h3>
                  <p>Send To Prepress</p>
                </div>
                    
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3> <asp:Label runat="server" ID="lblSendToMaterialProduction"></asp:Label></h3>
                  <p>Send To Material Production</p>
                </div>
              
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">              

                  <h3> <asp:Label runat="server" ID="lblSendToQCCheck"></asp:Label></h3>
                  <p>Send To QC Check</p>
                </div>
                
               
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->


         <div id="Div4" runat="server" class="row">
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblSendToBilling"></asp:Label></h3>
                  <p>Send To Billing</p>
                </div>
                  
               
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblSendToDispatch"></asp:Label></h3>
                  <p>Send To Dispatch</p>
                </div>
                    
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3> <asp:Label runat="server" ID="lblDispatchedJobs"></asp:Label></h3>
                  <p>Dispatched Jobs</p>
                </div>
              
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">              

                  <h3> <asp:Label runat="server" ID="lblCancelledJobs"></asp:Label></h3>
                  <p>Cancelled Jobs</p>
                </div>
                
               
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->


       


                    


<%--        <div id="Div1" runat="server" class="row">

            <div class="col-sm-12">

           
          

              <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('2');">
              
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">Domestic Value<br />(In Cr.)		</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label2"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                

                 

                 <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('5');">
               
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px"> Export Value<br />(In Cr.)		</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label4"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                  

                 </div>

           
          </div>--%>


<%--                      <section class="content-header">
          <h1>
           Advance Licence Summary		
            
          </h1>
       
        </section>
                    
                    
                    <div id="Div2" runat="server" class="row">

            <div class="col-sm-12">

           
            <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px;">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('1');">
               
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">Licence No 1</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label5"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

              <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('2');">
               
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">To Be Export</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label6"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                

                  <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('4');">
                
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">Licence No 2</span>
                  <span class="info-box-number"> <asp:Label runat="server" ID="Label7"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                 <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('5');">
                
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">To Be Export</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label8"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>



                       <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('4');">
                
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">Licence No 3</span>
                  <span class="info-box-number"> <asp:Label runat="server" ID="Label1"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                 <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('5');">
                
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">To Be Export</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label3"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>


                  

                 </div>

           
          </div>--%>

        


          <!-- Main row -->

                    
          
        <!-- /.row (main row) -->
        </section>
                <!-- /.content -->
            </div>

        </div>


        <div class="">
            <!-- Content Wrapper. Contains page content -->
            <div class="">
                <!-- Content Header (Page header) -->
                
                <!-- Main content -->
                <section class="content">

                    <section class="content-header">
          <h1>
            Letter Press / Flexo		
            
          </h1>
       
        </section>

  

          <!-- Small boxes (Stat box) -->
         <div id="Div1" runat="server" class="row">
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblTotalJobslpf"></asp:Label></h3>
                  <p>Total Jobs</p>
                </div>
                  
               
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblPendingJobslpf"></asp:Label></h3>
                  <p>Pending Jobs</p>
                </div>
                    
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-yellow" style="left: 0px; top: 0px">
                <div class="inner">
                  <h3> <asp:Label runat="server" ID="lblSendToGraphicslpf"></asp:Label></h3>
                  <p>Send To Graphics</p>
                </div>
              
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">              

                  <h3> <asp:Label runat="server" ID="lblSendToCustomerlpf"></asp:Label></h3>
                  <p>Send To Customer</p>
                </div>
                
               
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->



         <div id="Div2" runat="server" class="row">
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblSendTOCustomerForApprovallpf"></asp:Label></h3>
                  <p>Send To Customer For Approval</p>
                </div>
                  
               
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblSendToPrepresslpf"></asp:Label></h3>
                  <p>Send To Prepress</p>
                </div>
                    
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3> <asp:Label runat="server" ID="lblSendToMaterialProductionlpf"></asp:Label></h3>
                  <p>Send To Material Production</p>
                </div>
              
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">              

                  <h3> <asp:Label runat="server" ID="lblSendToQCChecklpf"></asp:Label></h3>
                  <p>Send To QC Check</p>
                </div>
                
               
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->


         <div id="Div5" runat="server" class="row">
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblSendToBillinglpf"></asp:Label></h3>
                  <p>Send To Billing</p>
                </div>
                  
               
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="lblSendToDispatchlpf"></asp:Label></h3>
                  <p>Send To Dispatch</p>
                </div>
                    
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3> <asp:Label runat="server" ID="lblDispatchedJobslpf"></asp:Label></h3>
                  <p>Dispatched Jobs</p>
                </div>
              
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-3">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">              

                  <h3> <asp:Label runat="server" ID="lblCancelledJobslpf"></asp:Label></h3>
                  <p>Cancelled Jobs</p>
                </div>
                
               
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->


       


                    


<%--        <div id="Div1" runat="server" class="row">

            <div class="col-sm-12">

           
          

              <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('2');">
              
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">Domestic Value<br />(In Cr.)		</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label2"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                

                 

                 <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('5');">
               
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px"> Export Value<br />(In Cr.)		</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label4"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                  

                 </div>

           
          </div>--%>


<%--                      <section class="content-header">
          <h1>
           Advance Licence Summary		
            
          </h1>
       
        </section>
                    
                    
                    <div id="Div2" runat="server" class="row">

            <div class="col-sm-12">

           
            <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px;">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('1');">
               
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">Licence No 1</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label5"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

              <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('2');">
               
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">To Be Export</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label6"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                

                  <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('4');">
                
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">Licence No 2</span>
                  <span class="info-box-number"> <asp:Label runat="server" ID="Label7"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                 <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('5');">
                
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">To Be Export</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label8"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>



                       <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('4');">
                
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">Licence No 3</span>
                  <span class="info-box-number"> <asp:Label runat="server" ID="Label1"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>

                 <div class="" style="cursor:pointer; width: 25%; float: left; position: relative; min-height: 1px; padding-right: 15px; padding-left: 15px">
              <div class="info-box" style="min-height:57px;border-radius: 0px 40px 40px 0px;" onclick="open_url('5');">
                
                <div class="info-box-content" style="margin-left:18px">
                  <span class="info-box-text" style="text-transform: none;font-size:15px">To Be Export</span>
                  <span class="info-box-number"><asp:Label runat="server" ID="Label3"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div>


                  

                 </div>

           
          </div>--%>

        


          <!-- Main row -->

                    
          
        <!-- /.row (main row) -->
        </section>
                <!-- /.content -->
            </div>

        </div>




        <!-- ./wrapper -->
    </form>
    <!-- jQuery 2.1.4 -->
    <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <!-- Morris.js charts -->





</body>
</html>
