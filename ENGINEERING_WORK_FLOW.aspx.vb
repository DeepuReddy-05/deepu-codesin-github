Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Web.Hosting
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports Microsoft.Office.Interop.Excel
Partial Class ENGINEERING_WORK_FLOW
    Inherits System.Web.UI.Page
    Protected adp As New OleDbDataAdapter
    Public cmd As New OleDbCommand
    Public conn As New Dbconn
    Dim s As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        adp.SelectCommand = New OleDbCommand
        adp.SelectCommand.Connection = conn.getconnection()
        Dim ds As New Data.DataSet

        'Drafting<br/>Schedule
        adp.SelectCommand.CommandText = "select count(*) from (SELECT DRAWING_SCHEDULE_WEEK,ENG_COMPLETED,ENG_CHECKED,JOB_NAME,SO_NUMBER,TOT_EQP_COST,APPROVAL_SUBMITTED_DATE,RELEASED_TO_PURCHASING ,'Report Time' As REPORT_TIME FROM V_PRJ_DRAFTING_SCHEDULE)"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then

            Label20.Text = "Drafting<br/>Schedule<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If


        'Review PO Creation<br/> for Parts Order
        adp.SelectCommand.CommandText = "select count(*) from (SELECT VENDOR_NO,order_no,LINE_NO,ITEM_NO,DESCRIPTION,CUSTOMER_NO,NAME,QTY,ORIGINAL_ORDER_NO,CODE FROM V_PROCESS_PARTS_ORDER)"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then

            Label6.Text = "Review PO Creation<br/> for Parts Order<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If




        'Review PO Creation<br/> for Project Orders
        adp.SelectCommand.CommandText = "select count(*) from (SELECT VENDOR_NO,order_no,LINE_NO,ITEM_NO,DESCRIPTION,CUSTOMER_NO,NAME,QTY,ORIGINAL_ORDER_NO,CODE FROM V_PROCESS_PROJECT_ORDER)"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then

            Label7.Text = "Review PO Creation<br/> for Project Orders<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If




        'Shipping<br/>Schedule 
        adp.SelectCommand.CommandText = "select count(*) from(SELECT B_BE_ITEMS_SHIPPED, SHIP_DATE, ORDER_NO, CITY, STATE_CODE, QTY, EQUIPMENTS , CONTROLS_RECEIVED, SHIPPING_DIRECT_TO_JOBSITE, nvl(PROJECTED_SHIP_DATE,SHIP_DATE) PROJECTED_SHIP_DATE, ACTUAL_SHIP_DATE, NOTES, LOAD, PO_AND_BOM, DWGS, IN_SHOP, DAYS_TO_FAB, LEC_APPROVAL_DATE, APP_VS_RECEIVED, LEC_PO_SHIP_DATE, LEC_PO_VS_RECEIVED, LEC_PO_VS_ACTUAL, LEC_AMOUNT FROM V_SHIPPING_SCHEDULE)"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then

            Label8.Text = "Shipping<br/>Schedule <strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If


        'Open Order<br/> Status Worksheet
        adp.SelectCommand.CommandText = "select count(*) from(SELECT SO_NUMBER,JOB_NAME,JOB_STATUS,PO_CREATED_DATE,TOT_EQP_COST,ACTUAL_MAT_COST,ACTUAL_FREIGHT_COST FROM V_OPEN_ORDER_STATUS_SUMMARY)"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then

            Label14.Text = "Open Order<br/> Status Worksheet<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If

        'Part Configurator<br/> Items
        adp.SelectCommand.CommandText = "select count(*) from(SELECT ITEM_NO,ITEM_DESCRIPTION,ITEM_TYPE,SALES_DESCRIPTION,PREFERRED_VENDOR,MANUFACTURER_NO,MANUFACTURER_ITEM_NO,ALLOY,PRODUCTS,HP,PHASE,MOUNTING,ENCLOSURE,VOLTAGE,MANUFACTURED,DEVICE,CODE,SIZE_,CONTROL_PANEL_TYPE,NEMA_CLASS,THREAD_TYPE,FITTINGS,GENDER,CLASS,CONNECTION_STYLE,THREADING,PIPE_SIZE,WEATHER_PROTECTION_TYPE,VALVES_TYPE,DRAWING_PART,RFQ_NO,INACTIVE FROM V_PRODUCT_CONFIGURATOR_ITEMS)"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then

            Label15.Text = "Part Configurator<br/> Items<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If

    End Sub


End Class
