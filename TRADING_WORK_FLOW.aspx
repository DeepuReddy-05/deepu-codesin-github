<%@ Page Title="" Language="VB" MasterPageFile="~/pagemodel.master" AutoEventWireup="false" CodeFile="TRADING_WORK_FLOW.aspx.vb" Inherits="TRADING_WORK_FLOW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .text-wrap {
                white-space: normal;
            }


            
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
                <h1 class="text-center" style="color:#4682B4;">Trading Workflow</h1>
            </div>
        </header>
    <div class="container" style="margin-bottom: auto; margin-left: auto; margin-right: auto; margin-top: auto;">  <%--Main Container start Tag--%>
          <div class="row" style="padding-top: 10px; width: 1100px;"> <%-- 1st Row Start tag--%>
                <div class="col-xs-12 text-center">
                    <p class="lead text-center btn btn-label4 btn-lg text-warning center-block">
                        <a href="REP_TRADING_CONSOLE.ASPX" target="_blank">
                            <asp:Label ID="Label5" CssClass="lbfont6" runat="server" Text="Trading Console<br/>(Inventory Available by Item)" /></a></p>
                </div>
                <div class="row">
                    <div class="col-xs-4 text-center" style="margin-left:0px;">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                    <div class="col-xs-4 text-center" style="margin-left:0px;">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                    <div class="col-xs-4 text-center" style="margin-left:0px;">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                  <%--  <div class="col-xs-3 text-center">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>--%>
                </div>
            </div>   <%--1st Row End tag--%>




          <div class="row" style="padding-top:10px; width: 1100px;"> <%--2nd Row Start Tag--%>
             
            <%--tag for 6 labels--%>

            
                <div class="col-xs-4 text-center">
                    <p class="lead btn btn-CreatWO btn-lg text-warning center-block">
                        <a href="" target="_blank">
                        <asp:Label ID="Label1" CssClass="lbfont6" runat="server" Text="Available Inventory" /></a></p>
                     <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                <div class="col-xs-4 text-center">
                    <p class="text-center btn btn-CreatWOREO btn-lg text-warning center-block">
                        <a href="REP_PO_ALLOCATED_LIST_ALL.aspx" target="_blank">
                        <asp:Label ID="Label2" CssClass="lbfont6" runat="server" Text="Assigned PO's" /></a></p>
                    <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                <div class="col-xs-4 text-center">
                    <p class="text-center btn btn-CreatWOLOT btn-lg text-warning center-block">
                        <a href="REP_PO_AVAILABLE_LIST_ALL.aspx" target="_blank">
                            <asp:Label ID="Label3" CssClass="lbfont6" runat="server" Text="Open PO's" /></a></p>
                    <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                    



                
            </div> <%--2nd Row END Tag--%>



         <div class="row" style="padding-top: 10px; width: 1100px;"> <%-- 3rd Row Start tag--%>
                <div class="col-xs-12 text-center">
                    <p class="lead text-center btn btn-TIMECARD btn-lg text-warning center-block">
                        <a href="REP_ITEM_ORDER_HISTORY_ALL.aspx" target="_blank">
                            <asp:Label ID="Label4" CssClass="lbfont6" runat="server" Text="Item Review For Previous Customers" /></a></p>
                </div>
                <div class="row">
                    <div class="col-xs-4 text-center" style="margin-left:410px;">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
              
                 
                </div>
            </div>   <%--3rd Row End tag--%>


         <div class="row" style="padding-top: 10px; width: 1100px;"> <%-- 4th Row Start tag--%>
                <div class="col-xs-12 text-center">
                    <p class="lead text-center btn btn-WOSPEND btn-lg text-warning center-block">
                        <a href="SIMPLE_SEARCH.aspx?mid=SIMPLE_SEARCH" target="_blank">
                            <asp:Label ID="Label6" CssClass="lbfont6" runat="server" Text="Review Customers" /></a></p>
                </div>
                <div class="row">
                    <div class="col-xs-4 text-center" style="margin-left:410px;">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                  
                </div>
            </div>   <%--4th Row End tag--%>



         <div class="row" style="padding-top: 10px; width: 1100px;"> <%-- 5th Row Start tag--%>
                <div class="col-xs-12 text-center">
                    <p class="lead text-center btn btn-WOQA btn-lg text-warning center-block">
                        <a href="SALES_ORDER.aspx" target="_blank">
                            <asp:Label ID="Label7" CssClass="lbfont6" runat="server" Text="Create Customer Sales Order" /></a></p>
                </div>
               
            </div>   <%--5th Row End tag--%>






        </div><%--Main Container End Tag--%>
</asp:Content>

