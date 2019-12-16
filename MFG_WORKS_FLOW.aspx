<%@ Page Title="Manufacturing Work Flow" Language="VB" MasterPageFile="~/pagemodel.master" AutoEventWireup="false" CodeFile="MFG_WORKS_FLOW.aspx.vb" Inherits="MFG_WORKS_FLOW" %>

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
    <table>
           
            <tr>
                <td Style="padding-left:1200px;" >
                    
                      <%--  <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Generate PDF" />--%>
                    
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Document_Management/pdf2.jpg" Height="50" Width="50" OnClick="Button1_Click"/>

                </td>
            </tr>
           
        </table>
        
 <header>
            <div class="container">
                <h1 class="text-center" style="color:#4682B4;">MFG Work Flow</h1>
            </div>
        </header>
      

        <div class="container" style="margin-bottom: auto; margin-left: auto; margin-right: auto; margin-top: auto;">  <%--Main Container start Tag--%>
            <div class="row" style="padding-top:10px; width: 1200px;"> <%--1st Row Start Tag--%>
             
            <%--tag for 6 labels--%>

            
                <div class="col-xs-3 text-center">
                    <p class="lead btn btn-CreatWO btn-lg text-warning center-block">
                        <a href="REP_CREATE_WO_FROM_BACKLOG.ASPX" target="_blank">
                        <asp:Label ID="Label1" CssClass="lbfont6" runat="server" Text="Creating WO From Pegging" /></a></p>
                     <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatWOREO btn-lg text-warning center-block">
                        <a href="REP_BELOW_REORDER_POINT_MAKE.ASPX" target="_blank">
                        <asp:Label ID="Label2" CssClass="lbfont6" runat="server" Text="Create WO From ReorderPt" /></a></p>
                    <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-CreatWOLOT btn-lg text-warning center-block">
                        <a href="ITEMS.aspx?mid=ITEMS" target="_blank">
                            <asp:Label ID="Label3" CssClass="lbfont6" runat="server" Text="Create WO Lot for Lot" /></a></p>
                </div>
                <div class="col-xs-3 text-center">
                    <p class="lead text-center btn btn-CreatMPS btn-lg text-warning center-block">
                        <a href="REP_CREATE_WO_BASED_ON_MPS.aspx?mid=REP_CREATE_WO_BASED_ON_MPS" target="_blank">
                        <asp:Label ID="Label4" CssClass="lbfont6" runat="server" Text="Create WO from MPS" /></a></p>
                    <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
            <%--    <div class="row">
                    <div class="col-xs-3 text-center">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                    <div class="col-xs-3 text-center">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                    <div class="col-xs-3 text-center">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                    <div class="col-xs-3 text-center">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                </div>--%>



                
            </div> <%--1st Row END Tag--%>



                 <div class="row" style="padding-top: 10px; width: 1200px;"> <%-- 2nd Row Start tag--%>
                <div class="col-xs-12 text-center">
                    <p class="lead text-center btn btn-label4 btn-lg text-warning center-block">
                        <a href="WORK_ORDER.aspx?mid=WORK_ORDER" target="_blank">
                            <asp:Label ID="Label5" CssClass="lbfont6" runat="server" Text="Create WO Manual" /></a></p>
                </div>
                <div class="row">
                    <div class="col-xs-3 text-center">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                  <%--  <div class="col-xs-3 text-center">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>--%>
                    <div class="col-xs-3 text-center" style="margin-left:300px;">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                   <%-- <div class="col-xs-3 text-center">
                        <p class="btn">
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>--%>
                </div>
            </div>   <%--2nd Row End tag--%>

               
           <div class="row" style="padding-top: 10px; width: 1200px;"> <%--3rd Row Start Tag--%>
             
            <%--tag for 6 labels--%>

            
                <div class="col-xs-3 text-center">
                     <p class="lead btn btn-TIMECARD btn-lg text-warning center-block">
                        <a href="ATTENDANCE_AUTO_MAIN.aspx" target="_blank">
                        <asp:Label ID="Label6" CssClass="lbfont6" runat="server" Text="Time Card" /></a></p>
                     <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                    <p class="lead btn btn-WOTOBERELEASED btn-lg text-warning center-block">
                        <a href="" target="_blank">
                        <asp:Label ID="Label7" CssClass="lbfont6" runat="server" Text="WO to be Released" /></a></p>
                    <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
               <%-- <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-label3 btn-lg text-warning center-block">
                        <a href="" target="_blank">
                        <asp:Label ID="Label8" CssClass="lbfont6" runat="server" Text="WO to be Printed" /></a></p>--%>
                  <%--  <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                <%--</div>--%>
                <div class="col-xs-3 text-center" style="margin-left:300px;">
                    <p class="text-center btn btn-WOQA btn-lg text-warning center-block">
                        <a href="external_url.aspx?mid=REP_WORKORDER_IN_QA_HOLD&mtype=URL-OUTSIDE-APPLICATION&rptnm=EXCEPTION_UTILITY_DETAILS&vwnm=PURCHASE_VENDORS&sf=yes" target="_blank">
                            <asp:Label ID="Label9" CssClass="lbfont6" runat="server" Text="WO waiting For QA" /></a></p>
                     <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                    <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                     <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
               

               </div> <%--3rd Row END TAG--%>
          
       
          



              <div class="row" style="padding-top: 10px; width: 1200px;"> <%--4th Row Start Tag--%>
             
            <%--tag for 6 labels--%>

            
                <div class="col-xs-3 text-center">
                    
                    <p class="lead btn btn-ChildCompo btn-lg text-warning center-block">
                        <a href="REP_WO_SUB_ASSY_MADE_PARTS.aspx" target="_blank">
                        <asp:Label ID="Label10" CssClass="lbfont6" runat="server" Text="WOs Waiting For Material <br/>Child Components" /></a></p>
                     <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-WOSOSV btn-lg text-warning center-block">
                        <a href="external_url.aspx?mid=OSV_READY_SHIP_ALERT&mtype=URL-OUTSIDE-APPLICATION&rptnm=EXCEPTION_UTILITY_DETAILS&vwnm=REP_MOB_WO_ISSUE&sf=yes" target="_blank">
                        <asp:Label ID="Label11" CssClass="lbfont6" runat="server" Text="WOs requiring<br/>OSV Operations" /></a></p>
                    <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-PURCMATE btn-lg text-warning center-block">
                        <a href="REP_PO_DELAYING_WO_STARTS_NOW.ASPX" target="_blank">
                            <asp:Label ID="Label12" CssClass="lbfont6" runat="server" Text="WOs waiting<br/>For Purchased Materials" /></a></p>
                     <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
               

               </div> <%--4th Row END TAG--%>


               <div class="row" style="padding-top: 10px; width: 1200px;"> <%--5th Row Start Tag--%>
             
        

            
                <div class="col-xs-3 text-center">
                    
                    <p class="lead btn btn-MATISU btn-lg text-warning center-block">
                        <a href="EXP_UNCONFIRMED_ISSUES.aspx?mid=EXP_UNCONFIRMED_ISSUES" target="_blank">
                        <asp:Label ID="Label13" CssClass="lbfont6" runat="server" Text="WOs with unconfirmed<br/>material issues" /></a></p>
                     <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-OSVQA btn-lg text-warning center-block">
                        <a href="QA_HOLD_REPORT.aspx" target="_blank">
                        <asp:Label ID="Label14" CssClass="lbfont6" runat="server" Text="OSV on QA Hold" /></a></p>
                    <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>
                </div>
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-MATCONS btn-lg text-warning center-block">
                        <a href="R_THEORETICAL_VS_ISSUED_QTY.aspx" target="_blank">
                            <asp:Label ID="Label15" CssClass="lbfont6" runat="server" Text="WOs With Low<br/>Material Consumption" /></a></p>
                    <%-- <p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
               

               </div> <%--5th Row END TAG--%>



               <div class="row" style="padding-top: 10px; width: 1200px;"> <%--6th Row Start Tag--%>
             
        

            
                <div class="col-xs-3 text-center">
                    
                    <p class="lead btn btn-WOSPEND btn-lg text-warning center-block">
                        <a href="VENDORS.aspx" target="_blank">
                        <asp:Label ID="Label16" CssClass="lbfont6" runat="server" Text="WOs pending for Close" /></a></p>
                     <%--<p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
                <div class="col-xs-3 text-center">
                    <p class="text-center btn btn-WOSREADY btn-lg text-warning center-block">
                        <a href="VENDORS.aspx" target="_blank">
                        <asp:Label ID="Label17" CssClass="lbfont6" runat="server" Text="WOs ready to Ship" /></a></p>
                    <%--<p class="btn center-block">
                        <span class="glyphicon glyphicon-arrow-down"></span>
                    </p>--%>
                </div>
              
               

               </div> <%--6th Row END TAG--%>




        </div> <%-- Main Container End Tag--%>
</asp:Content>

