<%@ Page Title="Engineering Workflow" Language="VB" MasterPageFile="~/pagemodel.master" AutoEventWireup="false" CodeFile="ENGINEERING_WORK_FLOW.aspx.vb" Inherits="ENGINEERING_WORK_FLOW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
  <style>
      
         
            .btn-label1 {
    background-color: #92C7C7;}

          .btn-label2 {
   background-color: #AFDCEC;}
           .btn-label3 {

   background-color: #8ee8d8;}

              .btn-label4 {
   background-color: #5ac3ca;}

                   .btn-label5 {
   background-color: #CCFFFF;}

                     .btn-label6 {
   background-color: #99ccff;}

                     
              .btn-label7 {

   background-color: #20B2AA;}

               .btn-label8 {
   background-color: #7BCCB5;}

                 .btn-label9 {
   background-color: #92C7C7;}

                    .btn-label10 {

   background-color: #20B2AA;}

                    

               .btn-label11 {
   background-color: #AFDCEC;}

                .btn-label12 {
   background-color: #8ee8d8;}
                    .btn-label13 {
   background-color: #CCFFFF;}

                    
             .btn-label14 {
   background-color: #7BCCB5;}

                  .btn-label16 {
   background-color: #99ccff;}
            .btn-label17 {

   background-color: #20B2AA;}

               .btn-label18 {
   background-color: #AFDCEC;}

               
            .btn-label19 {
   background-color: #99ccff;}
                   .btn-label20 {

   background-color: #20B2AA;}


          .btn-label21 {
   background-color: #AFDCEC;}
                .btn-label22 {

   background-color: #20B2AA;}


       
           .btn-label23 {
   background-color: #5F9EA0;}

 .btn-label24 {

   background-color: #8ee8d8;}



 .btn-WOTOBERELEASED{
      background-color: #FFA500;
 }




 .btn-TIMECARD{
      background-color: #FFAB91 ;
 }




 
 .btn-WOQA{
      background-color: #D2B4DE;
 }




 .btn-CreatWO{
      background-color: #A5D6A7;
 }


  .btn-CreatWOREO{
      background-color: #FFE0B2 ;
 }



  .btn-CreatWOLOT{
      background-color: #CCCC66;
 }

  .btn-CreatMPS{
      background-color: #E6B0AA ;
 }

  
  .btn-ChildCompo{
      background-color:#F8BBD0;
 }

    .btn-WOSOSV{
      background-color:#C8E6C9;
 }


       .btn-PURCMATE{
      background-color:#D98880;
 }


             .btn-MATISU{
      background-color:#52BE80;
 }





                         .btn-OSVQA{
      background-color:#999966;
 }




                               .btn-MATCONS{
      background-color:#DCE775;
 }



                                     .btn-WOSPEND{
      background-color:#7FB3D5;
 }

  .btn-WOSREADY{
      background-color:#20B2AA;
 }


  </style>

    
    <header>
            <div class="container">
                <h1 class="text-center" style="color:#4682B4;">Engineering Workflow</h1>
            </div>
        </header>
       <div class="container" style="margin-bottom: auto; margin-left: auto; margin-right: auto; margin-top: auto;">  <%--Main Container start Tag--%>

               <div class="row" style="padding-top:10px;width: 1200px; "> <%--1st Row Start Tag--%>
<%--                    <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatWOLOT btn-lg text-warning center-block">
                        <a href="REP_PRJ_DRAFTING_SCHEDULE.aspx?mid=REP_PRJ_DRAFTING_SCHEDULE" target="_blank">
                        <asp:Label ID="Label5" CssClass="lbfont6" runat="server" Text="Drafting<br/>Schedule" /></a></p>
               

                </div>--%>

                    <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatWOLOT btn-lg text-warning center-block">
                        <a href="PROJECT_MASTER.ASPX?mid=PROJECT_DETAIL" target="_blank">
                        <asp:Label ID="Label5" CssClass="lbfont6" runat="server" Text="Create <br/> Project" /></a></p>
               

                </div>





                   <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatWOLOT btn-lg text-warning center-block">
                        <a href="" target="_blank">
                        <asp:Label ID="Label13" CssClass="lbfont6" runat="server" Text="Request From Parts<br/>For Create BOM" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>

                </div>


                     </div> <%--1st Row END Tag--%>


           <br />

            <div class="row" style="padding-top:10px;width: 1200px; "> <%--2nd Row Start Tag--%>
                    <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-MATISU btn-lg text-warning center-block">
                        <a href="REP_PRJ_DRAFTING_SCHEDULE.aspx?mid=REP_PRJ_DRAFTING_SCHEDULE" target="_blank">
                        <asp:Label ID="Label16" CssClass="lbfont6" runat="server" Text="Submittal<br/>Scheduled" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>

            
                <div class="col-xs-3 text-center">
                    <p class="lead btn btn-MATISU btn-lg text-warning center-block" >
                        <a href="REP_PRJ_DRAFTING_SCHEDULE.aspx?mid=REP_PRJ_DRAFTING_SCHEDULE" target="_blank">
                        <asp:Label ID="Label17" CssClass="lbfont6" runat="server" Text="Approved<br/>Submittal" /></a></p>
                   <%--  <p class="btn center-block" style="margin-left:0px;">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
            
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-MATISU btn-lg text-warning center-block">
                        <a href="REP_PROJ_ENGG_SCHEDULE.ASPX?mid=REP_PROJ_ENGG_SCHEDULE&mtype=LIST-REPORT&rptnm=&vwnm=&sf=yes&rptprint=N&rptpreview=Y&rptcopies=1" target="_blank">
                        <asp:Label ID="Label18" CssClass="lbfont6" runat="server" Text="Resubmit<br/> Submittal" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
               
             <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-MATISU btn-lg text-warning center-block">
                        <a href="REP_PROJ_ENGG_SCHEDULE.ASPX?mid=REP_PROJ_ENGG_SCHEDULE&mtype=LIST-REPORT&rptnm=&vwnm=&sf=yes&rptprint=N&rptpreview=Y&rptcopies=1" target="_blank">
                        <asp:Label ID="Label19" CssClass="lbfont6" runat="server" Text="Send to<br/>Purchasing" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>

                    </div> <%--2nd Row END Tag--%>

           <br />
           <div class="row" style="padding-top:10px;width: 1200px; "> <%--3rd Row Start Tag--%>

               <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-WOQA btn-lg text-warning center-block">
                        <a href="" target="_blank">
                        <asp:Label ID="Label21" CssClass="lbfont6" runat="server" Text="Engineering<br/>Design Group" /></a></p>
                 
                </div>

            
                <div class="col-xs-3 text-center">
                    <p class="lead btn btn-WOQA btn-lg text-warning center-block" >
                        <a href="" target="_blank">
                        <asp:Label ID="Label22" CssClass="lbfont6" runat="server" Text="Electrical<br/>Group" /></a></p>
                  
                </div>
            
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-WOQA btn-lg text-warning center-block">
                        <a href="" target="_blank">
                        <asp:Label ID="Label23" CssClass="lbfont6" runat="server" Text="Vendor Submittal<br/>Package" /></a></p>
                 
                </div>

                </div> <%--3rd Row END Tag--%>

           <br />

              <div class="row" style="padding-top:10px;width: 1200px; "> <%--4th Row Start Tag--%>
                    <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-label4 btn-lg text-warning center-block">
                        <a href="ITEMS.aspx?mid=ITEMS" target="_blank">
                        <asp:Label ID="Label1" CssClass="lbfont6" runat="server" Text="Create/Modify Item" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>

            
                <div class="col-xs-3 text-center">
                    <p class="lead btn btn-label4 btn-lg text-warning center-block" >
                        <a href="BOM_ROUTING_MASTER.aspx?mid=BOM_ROUTING_MASTER" target="_blank">
                        <asp:Label ID="Label2" CssClass="lbfont6" runat="server" Text="Create/Edit BOM" /></a></p>
                   <%--  <p class="btn center-block" style="margin-left:0px;">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
            
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-label4 btn-lg text-warning center-block">
                        <a href="BOM_EXPORT_EXCEL.aspx?mid=BOM_EXPORT" target="_blank">
                        <asp:Label ID="Label3" CssClass="lbfont6" runat="server" Text="Import BOM" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
               
             <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-label4 btn-lg text-warning center-block">
                        <a href="REP_REPORT_TIME.aspx?mid=REP_REPORT_TIME" target="_blank">
                        <asp:Label ID="Label4" CssClass="lbfont6" runat="server" Text="Report Time" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>

                    </div> <%--4th Row END Tag--%>

           <br />
              <div class="row" style="padding-top:10px;width: 1200px; "> <%--5th Row Start Tag--%>
                   
            
                <div class="col-xs-3 text-center">
                    <p class="lead btn btn-CreatWOREO btn-lg text-warning center-block" >
                        <a href="REP_PROCESS_PART_FROM_ORDER_ENG.aspx?mid=REP_PROCESS_PART_FROM_ORDER_ENG" target="_blank">
                        <asp:Label ID="Label6" CssClass="lbfont6" runat="server" Text="Review PO Creation<br/> for Parts Order " /></a></p>
                   <%--  <p class="btn center-block" style="margin-left:0px;">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
            
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatWOREO btn-lg text-warning center-block">
                        <a href="REP_PROCESS_PROJECT_FROM_ORDER_ENG.aspx?mid=REP_PROCESS_PROJECT_FROM_ORDER_ENG" target="_blank">
                        <asp:Label ID="Label7" CssClass="lbfont6" runat="server" Text="Review PO Creation<br/> for Project Orders" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
               
              <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatWOREO btn-lg text-warning center-block">
                        <a href="" target="_blank">
                        <asp:Label ID="Label9" CssClass="lbfont6" runat="server" Text="Equipments Pending for<br/>BOM Creation" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>

                    </div> <%--3rd Row END Tag--%>

           <br />
            <div class="row" style="padding-top:10px;width: 1200px; "> <%--4th Row Start Tag--%>

                   <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatMPS btn-lg text-warning center-block">
                        <a href="REP_PRJ_DRAFTING_SCHEDULE.aspx?mid=REP_PRJ_DRAFTING_SCHEDULE" target="_blank">
                        <asp:Label ID="Label20" CssClass="lbfont6" runat="server" Text="Drafting<br/>Schedule" /></a></p>
               

                </div>

                  <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatMPS btn-lg text-warning center-block">
                        <a href="SHIPPING_SCHEDULE.aspx?mid=SHIPPING_SCHEDULE" target="_blank">
                        <asp:Label ID="Label8" CssClass="lbfont6" runat="server" Text="Shipping<br/>Schedule" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>

                 

            
                <div class="col-xs-2 text-center">
                    <p class="lead btn btn-CreatMPS btn-lg text-warning center-block" >
                        <a href="REP_PROJ_ENGG_SCHEDULE.ASPX?mid=REP_PROJ_ENGG_SCHEDULE&mtype=LIST-REPORT&rptnm=&vwnm=&sf=yes&rptprint=N&rptpreview=Y&rptcopies=1" target="_blank">
                        <asp:Label ID="Label10" CssClass="lbfont6" runat="server" Text="Engineering<br/>Schedule" /></a></p>
                   <%--  <p class="btn center-block" style="margin-left:0px;">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
            
                <div class="col-xs-2 text-center">
                    <p class="text-center btn btn-CreatMPS btn-lg text-warning center-block">
                        <a href="REP_MY_REPORTED_TIME.aspx?mid=REP_MY_REPORTED_TIME" target="_blank">
                        <asp:Label ID="Label11" CssClass="lbfont6" runat="server" Text="My Reported<br/>Time" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
               
             <div class="col-xs-2 text-center">
                    <p class="text-center btn btn-CreatMPS btn-lg text-warning center-block">
                        <a href="REP_REPORTED_TIME.aspx?mid=REP_REPORTED_TIME&sssid=1" target="_blank">
                        <asp:Label ID="Label12" CssClass="lbfont6" runat="server" Text="Reported<br/>Time" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>

                    </div> <%--5th Row END Tag--%>



            <div class="row" style="padding-top:10px;width: 1200px; "> <%--6th Row Start Tag--%>
                    <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-MATCONS btn-lg text-warning center-block">
                        <a href="REP_OPEN_PROJECT_STATUS.aspx?mid=REP_OPEN_PROJECT_STATUS" target="_blank">
                        <asp:Label ID="Label14" CssClass="lbfont6" runat="server" Text="Open Order<br/> Status Worksheet" /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>

                </div>





                   <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-MATCONS btn-lg text-warning center-block">
                        <a href="REP_PRODUCT_CONFIGURATOR.aspx?mid=REP_PRODUCT_CONFIGURATOR" target="_blank">
                        <asp:Label ID="Label15" CssClass="lbfont6" runat="server" Text="Part Configurator<br/> Items " /></a></p>
                   <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>

                </div>


                     </div> <%--6th Row END Tag--%>






              </div> <%--Main Container END Tag--%>

</asp:Content>

