Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Web.Hosting
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports Microsoft.Office.Interop.Excel
Partial Class MFG_WORKS_FLOW
    Inherits System.Web.UI.Page
    Protected adp As New OleDbDataAdapter
    Public cmd As New OleDbCommand
    Public conn As New Dbconn
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        adp.SelectCommand = New OleDbCommand
        adp.SelectCommand.Connection = conn.getconnection()
        Dim ds As New Data.DataSet


        adp.SelectCommand.CommandText = "SELECT count(*) FROM v_create_wo_from_backlog"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            'Label1.Text = "Creating WO From Pegging(" & ds.Tables(0).Rows(0)(0) & ")"
            Label1.Text = "Creating WO From Pegging<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If

        adp.SelectCommand.CommandText = "Select count(*) FROM v_item_below_reorder_point WHERE make_buy = 'M'  AND   ( nvl(total_required,0) + nvl(on_hand,0) ) < nvl(reorder_point,0)ORDER BY regexp_replace(item_no,'[[:digit:]]') NULLS FIRST, to_number(regexp_substr(item_no,'[[:digit:]]+') )"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            'Label2.Text = "Create WO From ReorderPt(" & ds.Tables(0).Rows(0)(0) & ")"
            Label2.Text = "Create WO From ReorderPt<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If


        'adp.SelectCommand.CommandText = "SELECT count(*) FROM V_CREATE_WO_BASED_ON_MPS"
        'ds.Clear()
        'adp.Fill(ds)
        'If (ds.Tables(0).Rows.Count > 0) Then
        '    Label4.Text = "Create WO from MPS(" & ds.Tables(0).Rows(0)(0) & ")"
        ' Label4.Text = "Create WO from MPS<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        'End If


        'adp.SelectCommand.CommandText = "SELECT count(1) FROM V_QA_DASHBOARD WHERE QA_SOURCE='WORK_ORDER' AND   NVL(QA_QTY_IN_BUOM,0)> NVL(DISPOSITION_QTY_IN_BUOM,0)"
        adp.SelectCommand.CommandText = "SELECT count(*) FROM V_QA_DASHBOARD WHERE QA_SOURCE='WORK_ORDER'AND NVL(QA_QTY_IN_BUOM,0)> NVL(DISPOSITION_QTY_IN_BUOM,0)"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            'Label9.Text = "WO waiting For QA(" & ds.Tables(0).Rows(0)(0) & ")"
            Label9.Text = "WO waiting For QA<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If



        adp.SelectCommand.CommandText = "SELECT count(*) FROM V_QA_DASHBOARD WHERE QA_SOURCE='WORK_ORDER'AND NVL(QA_QTY_IN_BUOM,0)> NVL(DISPOSITION_QTY_IN_BUOM,0)"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            'Label10.Text = "WOs Waiting For Material <br/>Child Components(" & ds.Tables(0).Rows(0)(0) & ")"
            Label10.Text = "WOs Waiting For Material <br/>Child Components<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If

        adp.SelectCommand.CommandText = "SELECT count(*) FROM VL_READY_SHIP_ALERT ORDER BY WORK_ORDER_NO, STEP_ID"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            'Label11.Text = "WOs requiring<br/>OSV Operations(" & ds.Tables(0).Rows(0)(0) & ")"
            Label11.Text = "WOs requiring<br/>OSV Operations<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If


        adp.SelectCommand.CommandText = "SELECT count(*) FROM V_PO_DELAYING_WO_STARTS_NOW"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            ' Label12.Text = "WOs waiting<br/>For Purchased Materials(" & ds.Tables(0).Rows(0)(0) & ")"
            Label12.Text = "WOs waiting<br/>For Purchased Materials<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If

        adp.SelectCommand.CommandText = "SELECT count(*) FROM V_UNCONFIRMED_ISSUES_REPORT"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            'Label13.Text = "WOs with unconfirmed<br/>material issues(" & ds.Tables(0).Rows(0)(0) & ")"
            Label13.Text = "WOs with unconfirmed<br/>material issues<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If





        adp.SelectCommand.CommandText = "SELECT count(*) FROM V_QA_HOLD_REPORT"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            'Label14.Text = "OSV on QA Hold(" & ds.Tables(0).Rows(0)(0) & ")"
            Label14.Text = "OSV on QA Hold<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If

        adp.SelectCommand.CommandText = "SELECT count(*) FROM v_theoretical_vs_issued_qty v WHERE entry_date BETWEEN  sysdate-30 and sysdate"
        ds.Clear()
        adp.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            'Label15.Text = "WOs With Low<br/>Material Consumption(" & ds.Tables(0).Rows(0)(0) & ")"
            Label15.Text = "WOs With Low<br/>Material Consumption<strong><font color ='#0000FF' size='3' face='Arial'>(" & ds.Tables(0).Rows(0)(0) & ")</font></strong>"
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim document As Document = New Document(PageSize.A4, 50, 50, 25, 25)
        'Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
        '    Dim writer As PdfWriter = PdfWriter.GetInstance(document, memoryStream)
        '    Dim cell As PdfPCell = Nothing
        '    Dim table As PdfPTable = Nothing
        '    document.Open()
        '    'header
        '    table = New PdfPTable(1)
        '    table.TotalWidth = 500.0F
        '    table.LockedWidth = True
        '    table.SetWidths(New Single() {4.0F})
        '    table.HorizontalAlignment = 0
        '    table.SpacingBefore = 20.0F
        '    table.SpacingAfter = 30.0F
        '    cell = New PdfPCell(New Phrase("MFG Works Flow", New iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 14)))

        '    cell.Colspan = 1

        '    cell.HorizontalAlignment = 1
        '    cell.Border = iTextSharp.text.Rectangle.NO_BORDER
        '    table.AddCell(cell)


        '    table.WriteSelectedRows(0, -1, document.Left, document.Top, writer.DirectContent)

        '    document.Add(cell)
        '    cell.Colspan = 3
        '    document.Add(table)




        '    'Creating WO From Pegging
        '    Dim pdfcell1 As PdfPCell = Nothing

        '    Dim table1 As PdfPTable = Nothing
        '    table1 = New PdfPTable(1)
        '    table1.TotalWidth = 120.0F
        '    table1.LockedWidth = True
        '    table.SetWidths(New Single() {4.0F})
        '    adp.SelectCommand = New OleDbCommand
        '    adp.SelectCommand.Connection = conn.getconnection()
        '    Dim ds As New Data.DataSet
        '    adp.SelectCommand.CommandText = "SELECT count(*) FROM v_create_wo_from_backlog"
        '    ds.Clear()
        '    adp.Fill(ds)
        '    If (ds.Tables(0).Rows.Count > 0) Then

        '        'table1.AddCell("Creating WO From Pegging (" & ds.Tables(0).Rows(0)(0) & ")")
        '        pdfcell1 = New PdfPCell(New Phrase("Creating WO From Pegging (" & ds.Tables(0).Rows(0)(0) & ")", New iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7)))

        '    End If





        '    pdfcell1.PaddingBottom = 10.0F
        '    ' pdfcell1.AddElement(New Chunk(pdfcell1, 50, 5))
        '    pdfcell1.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#A5D6A7"))
        '    pdfcell1.BorderColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#A5D6A7"))
        '    table1.HorizontalAlignment = 0
        '    table1.HorizontalAlignment = Element.ALIGN_LEFT
        '    table1.AddCell(pdfcell1)
        '    'document.Add(table1)


        '    s = Server.MapPath("Document_Management")
        '    Dim img1 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

        '    Dim imgpdfcell1 As PdfPCell = New PdfPCell(img1)
        '    img1.ScalePercent(3)
        '    imgpdfcell1.AddElement(New Chunk(img1, 50, 5))
        '    imgpdfcell1.HorizontalAlignment = 1
        '    imgpdfcell1.Border = iTextSharp.text.Rectangle.NO_BORDER
        '    table1.AddCell(imgpdfcell1)
        '    document.Add(table1)




        '    'Create WO From ReorderPt
        '    Dim pdfcell2 As PdfPCell = Nothing
        '    Dim table2 As PdfPTable = Nothing
        '    table2 = New PdfPTable(1)
        '    table2.TotalWidth = 120.0F
        '    table2.LockedWidth = True
        '    'table2.SetWidths(New Single() {4.0F})
        '    adp.SelectCommand = New OleDbCommand
        '    adp.SelectCommand.Connection = conn.getconnection()

        '    adp.SelectCommand.CommandText = "Select count(*) FROM v_item_below_reorder_point WHERE make_buy = 'M'  AND   ( nvl(total_required,0) + nvl(on_hand,0) ) < nvl(reorder_point,0)ORDER BY regexp_replace(item_no,'[[:digit:]]') NULLS FIRST, to_number(regexp_substr(item_no,'[[:digit:]]+') )"
        '    ds.Clear()
        '    adp.Fill(ds)
        '    If (ds.Tables(0).Rows.Count > 0) Then

        '        pdfcell2 = New PdfPCell(New Phrase("Create WO From ReorderPt (" & ds.Tables(0).Rows(0)(0) & ")", New iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7)))
        '    End If
        '    pdfcell2.Colspan = 1
        '    pdfcell2.PaddingBottom = 10.0F

        '    pdfcell2.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))
        '    pdfcell2.BorderColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))

        '    Dim cb As PdfContentByte = writer.DirectContent




        '    table2.WriteSelectedRows(0, 0, 0, 0, cb)

        '    table2.AddCell(pdfcell2)
        '    'document.Add(table2)


        '    s = Server.MapPath("Document_Management")
        '    Dim img2 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

        '    Dim imgpdfcell2 As PdfPCell = New PdfPCell(img2)
        '    img2.ScalePercent(3)
        '    imgpdfcell2.AddElement(New Chunk(img1, 50, 5))
        '    imgpdfcell2.HorizontalAlignment = 1
        '    imgpdfcell2.Border = iTextSharp.text.Rectangle.NO_BORDER
        '    table2.AddCell(imgpdfcell2)
        '    'paragraphTable2.Add(table2)
        '    document.Add(table2)











        '    document.Close()
        '    Dim bytes As Byte() = memoryStream.ToArray()
        '    memoryStream.Close()
        '    Response.Clear()
        '    Response.ContentType = "application/pdf"
        '    Response.AddHeader("Content-Disposition", "attachment; filename=MFGworksflow.pdf")
        '    Response.ContentType = "application/pdf"
        '    Response.Buffer = True
        '    Response.Cache.SetCacheability(HttpCacheability.NoCache)
        '    Response.BinaryWrite(bytes)
        '    Response.End()
        '    Response.Close()









        'End Using


        Dim document As Document = New Document(PageSize.A4.Rotate())
        Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, memoryStream)

            Dim table As PdfPTable = New PdfPTable(7)

            document.Open()
            table.TotalWidth = 600.0F
            table.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table.LockedWidth = True
            Dim pdfcell As PdfPCell = New PdfPCell(New Phrase("MFG Works Flow", New iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 20)))
            'pdfcell.f = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2")
            pdfcell.PaddingBottom = 50.0F
            pdfcell.Colspan = 8
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.Border = iTextSharp.text.Rectangle.NO_BORDER

            table.AddCell(pdfcell)





            adp.SelectCommand = New OleDbCommand
            adp.SelectCommand.Connection = conn.getconnection()
            Dim ds As New Data.DataSet
            adp.SelectCommand.CommandText = "SELECT count(*) FROM v_create_wo_from_backlog"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#A5D6A7"))

                table.DefaultCell.HorizontalAlignment = 1
                table.DefaultCell.PaddingLeft = 10.0F

                table.AddCell("Creating WO From Pegging (" & ds.Tables(0).Rows(0)(0) & ")")
                'table.DefaultCell.HorizontalAlignment = Element.ALIGN_MIDDLE





            End If

            'table.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            'table.LockedWidth = True


            table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table.AddCell(" ")
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER


            'table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))
            'table.AddCell("Row 2, Col 1")
            'table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '2.Create WO From ReorderPt

            adp.SelectCommand.CommandText = "Select count(*) FROM v_item_below_reorder_point WHERE make_buy = 'M'  AND   ( nvl(total_required,0) + nvl(on_hand,0) ) < nvl(reorder_point,0)ORDER BY regexp_replace(item_no,'[[:digit:]]') NULLS FIRST, to_number(regexp_substr(item_no,'[[:digit:]]+') )"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))
                table.AddCell("Create WO From ReorderPt(" & ds.Tables(0).Rows(0)(0) & ")")

            End If



            table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table.AddCell("")
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER




            '3.Create WO Lot for Lot
            table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#CCCC66"))
            table.AddCell("Create WO Lot for Lot")
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER





            table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))

            table.AddCell("")
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '4.Create WO from MPS
            table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#E6B0AA"))
            table.AddCell("Create WO from MPS")
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            document.Add(table)

            'table 10



            Dim table10 As PdfPTable = New PdfPTable(7)
            table10.TotalWidth = 600.0F
            table10.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table10.LockedWidth = True


            s = Server.MapPath("Document_Management")
            Dim img10 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell10 As PdfPCell = New PdfPCell(img10)
            img10.ScalePercent(3)
            cell10.AddElement(New Chunk(img10, 50, 5))
            cell10.HorizontalAlignment = 1
            cell10.Border = iTextSharp.text.Rectangle.NO_BORDER
            table10.AddCell(cell10)


            s = Server.MapPath("Document_Management")
            Dim img101 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell101 As PdfPCell = New PdfPCell(img101)
            img101.ScalePercent(3)
            cell101.AddElement(New Chunk(img101, 50, 5))
            cell101.HorizontalAlignment = 1
            cell101.Border = iTextSharp.text.Rectangle.NO_BORDER
            table10.AddCell(cell101)


            s = Server.MapPath("Document_Management")
            Dim img102 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell102 As PdfPCell = New PdfPCell(img102)
            img102.ScalePercent(3)
            cell102.AddElement(New Chunk(img102, 420, 5))
            cell102.HorizontalAlignment = 1
            cell102.Border = iTextSharp.text.Rectangle.NO_BORDER
            table10.AddCell(cell102)

            table10.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table10.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table10.AddCell("")


            table10.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table10.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table10.AddCell("")


            table10.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table10.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table10.AddCell("")


            table10.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table10.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table10.AddCell("")

            table10.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table10.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table10.AddCell("")


            document.Add(table10)



            '2nd row



            'Dim cell1 As PdfPCell = Nothing
            'Dim table1 As PdfPTable = Nothing

            'table1 = New PdfPTable(3)
            'table1.TotalWidth = 600.0F
            'table1.LockedWidth = True
            ''table1.SetWidths(New Single() {4.0F, 4.0F, 4.0F})
            'table1.HorizontalAlignment = 0
            'table1.SpacingBefore = 20.0F
            'table1.SpacingAfter = 30.0F






            'cell1 = New PdfPCell(New Phrase("Create WO Manual", New iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 10)))



            'cell1.Colspan = 3
            'cell1.PaddingBottom = 10.0F
            ''cell.Rowspan = 3
            '' cell.BackgroundColor = New BaseColor(System.Drawing.Color.Red)


            'cell1.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#5bc0de"))
            'cell1.BorderColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#5bc0de"))



            'cell1.HorizontalAlignment = 1
            'table1.AddCell(cell1)


            's = Server.MapPath("Document_Management")
            'Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            'Dim cell2 As PdfPCell = New PdfPCell(img)
            'img.ScalePercent(3)
            'cell2.AddElement(New Chunk(img, 300, 5))
            'cell2.HorizontalAlignment = 1
            'cell2.Border = iTextSharp.text.Rectangle.NO_BORDER
            'table1.AddCell(cell2)


            'document.Add(table1)

            'table14

            Dim table14 As PdfPTable = New PdfPTable(1)


            table14.TotalWidth = 650.0F
            table14.SetTotalWidth(New Single() {650.0F})
            table14.LockedWidth = True




            table14.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#5ac3ca"))
            table14.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            table14.DefaultCell.HorizontalAlignment = 1
            table14.DefaultCell.PaddingBottom = 10.0F
            table14.AddCell("Create WO Manual")





            document.Add(table14)


            'table11



            Dim table11 As PdfPTable = New PdfPTable(7)
            table11.TotalWidth = 600.0F
            table11.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table11.LockedWidth = True


            s = Server.MapPath("Document_Management")
            Dim img11 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell11 As PdfPCell = New PdfPCell(img11)
            img11.ScalePercent(3)
            cell11.AddElement(New Chunk(img11, 50, 5))
            cell11.HorizontalAlignment = 1
            cell11.Border = iTextSharp.text.Rectangle.NO_BORDER
            table11.AddCell(cell11)


            s = Server.MapPath("Document_Management")
            Dim img111 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell111 As PdfPCell = New PdfPCell(img111)
            img111.ScalePercent(3)
            cell111.AddElement(New Chunk(img111, 240, 5))
            cell111.HorizontalAlignment = 1
            cell111.Border = iTextSharp.text.Rectangle.NO_BORDER
            table11.AddCell(cell111)


            table11.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table11.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table11.AddCell("")


            table11.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table11.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table11.AddCell("")


            table11.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table11.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table11.AddCell("")


            table11.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table11.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table11.AddCell("")


            table11.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table11.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table11.AddCell("")

            table11.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table11.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table11.AddCell("")


            document.Add(table11)


            '3rd row



            Dim table3 As PdfPTable = New PdfPTable(7)


            table3.TotalWidth = 600.0F
            table3.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table3.LockedWidth = True
            'Dim pdfcell3 As PdfPCell = New PdfPCell(New Phrase("MFG Works Flow", New iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 14)))
            ''pdfcell.f = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))
            'pdfcell3.Colspan = 8
            'pdfcell3.HorizontalAlignment = Element.ALIGN_CENTER
            'pdfcell3.Border = iTextSharp.text.Rectangle.NO_BORDER

            'table.AddCell(pdfcell3)



            table3.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFAB91"))
            table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table3.DefaultCell.PaddingBottom = 10.0F
            table3.DefaultCell.HorizontalAlignment = 1
            table3.DefaultCell.PaddingBottom = 10.0F
            table3.AddCell("Time Card")



            'table.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            'table.LockedWidth = True


            table3.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table3.AddCell(" ")
            table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER




            table3.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table3.AddCell(" ")
            table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER



            table3.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table3.AddCell("")
            table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER




            '3.Create WO Lot for Lot
            adp.SelectCommand.CommandText = "SELECT count(*) FROM V_QA_DASHBOARD WHERE QA_SOURCE='WORK_ORDER'AND NVL(QA_QTY_IN_BUOM,0)> NVL(DISPOSITION_QTY_IN_BUOM,0)"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table3.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))
                table3.DefaultCell.HorizontalAlignment = 1
                table3.DefaultCell.PaddingBottom = 10.0F
                table3.DefaultCell.PaddingBottom = 10.0F
                table3.AddCell("WO waiting For QA(" & ds.Tables(0).Rows(0)(0) & ")")



            End If





            table3.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))

            table3.AddCell("")
            table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '4.Create WO from MPS
            table3.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))

            table3.AddCell("")
            table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER


            document.Add(table3)





            'table12



            Dim table12 As PdfPTable = New PdfPTable(7)
            table12.TotalWidth = 600.0F
            table12.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table12.LockedWidth = True


            s = Server.MapPath("Document_Management")
            Dim img12 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell12 As PdfPCell = New PdfPCell(img12)
            img12.ScalePercent(3)
            cell12.AddElement(New Chunk(img12, 50, 5))
            cell12.HorizontalAlignment = 1
            cell12.Border = iTextSharp.text.Rectangle.NO_BORDER
            table12.AddCell(cell12)


            s = Server.MapPath("Document_Management")
            Dim img1121 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell121 As PdfPCell = New PdfPCell(img111)
            img1121.ScalePercent(3)
            cell121.AddElement(New Chunk(img1121, 240, 5))
            cell121.HorizontalAlignment = 1
            cell121.Border = iTextSharp.text.Rectangle.NO_BORDER
            table12.AddCell(cell121)


            table12.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table12.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table12.AddCell("")


            table12.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table12.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table12.AddCell("")


            table12.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table12.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table12.AddCell("")


            table12.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table12.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table12.AddCell("")


            table12.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table12.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table12.AddCell("")

            table12.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table12.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table12.AddCell("")


            document.Add(table12)



            '4th row



            Dim table4 As PdfPTable = New PdfPTable(7)


            table4.TotalWidth = 600.0F
            table4.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table4.LockedWidth = True




            table4.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFA500"))
            table4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table4.DefaultCell.HorizontalAlignment = 1
            table4.DefaultCell.PaddingBottom = 10.0F
            table4.DefaultCell.PaddingBottom = 10.0F
            table4.AddCell("WO to be Released")




            'table.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            'table.LockedWidth = True


            table4.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table4.AddCell(" ")
            table4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER




            table4.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table4.AddCell(" ")
            table4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER



            'table4.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            'table4.AddCell("")
            'table4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER


            s = Server.MapPath("Document_Management")
            Dim img41 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cel141 As PdfPCell = New PdfPCell(img41)
            img41.ScalePercent(3)
            cel141.AddElement(New Chunk(img41, 75, 5))
            cel141.HorizontalAlignment = 1
            cel141.Border = iTextSharp.text.Rectangle.NO_BORDER
            table4.AddCell(cel141)



            '3.Create WO Lot for Lot
            table4.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table4.AddCell("")
            table4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER





            table4.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))

            table4.AddCell("")
            table4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '4.Create WO from MPS
            table4.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))

            table4.AddCell("")
            table4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER


            document.Add(table4)




            'table12



            Dim table13 As PdfPTable = New PdfPTable(7)
            table13.TotalWidth = 600.0F
            table13.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table13.LockedWidth = True


            's = Server.MapPath("Document_Management")
            'Dim img51 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            'Dim cell51 As PdfPCell = New PdfPCell(img51)
            'img51.ScalePercent(3)
            'cell51.AddElement(New Chunk(img51, 50, 5))
            'cell51.HorizontalAlignment = 1
            'cell51.Border = iTextSharp.text.Rectangle.NO_BORDER
            'table13.AddCell(cell51)

            table13.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table13.AddCell("")



            table13.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table13.AddCell("")


            table13.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table13.AddCell("")


            table13.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table13.AddCell("")


            table13.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table13.AddCell("")


            table13.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table13.AddCell("")

            table13.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table13.AddCell("")


            document.Add(table13)





            'row 5


            Dim table5 As PdfPTable = New PdfPTable(7)


            table5.TotalWidth = 600.0F
            table5.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table5.LockedWidth = True






            adp.SelectCommand = New OleDbCommand
            adp.SelectCommand.Connection = conn.getconnection()
            'Dim ds As New Data.DataSet
            adp.SelectCommand.CommandText = "SELECT count(*) FROM V_QA_DASHBOARD WHERE QA_SOURCE='WORK_ORDER'AND NVL(QA_QTY_IN_BUOM,0)> NVL(DISPOSITION_QTY_IN_BUOM,0)"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table5.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#F8BBD0"))
                table5.DefaultCell.HorizontalAlignment = 1
                table5.DefaultCell.PaddingBottom = 10.0F
                table5.DefaultCell.PaddingBottom = 10.0F
                table5.AddCell("WOs Waiting For Material Child Components (" & ds.Tables(0).Rows(0)(0) & ")")



            End If

            'table.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            'table.LockedWidth = True


            table5.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table5.AddCell(" ")
            table5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER


            'table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))
            'table.AddCell("Row 2, Col 1")
            'table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '2.Create WO From ReorderPt

            adp.SelectCommand.CommandText = "SELECT count(*) FROM VL_READY_SHIP_ALERT ORDER BY WORK_ORDER_NO, STEP_ID"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table5.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8E6C9"))
                table5.AddCell("WOs requiring OSV Operations(" & ds.Tables(0).Rows(0)(0) & ")")

            End If



            table5.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table5.AddCell("")
            table5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER




            '3.Create WO Lot for Lot
            adp.SelectCommand.CommandText = "SELECT count(*) FROM V_PO_DELAYING_WO_STARTS_NOW"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table5.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#D98880"))
                table5.AddCell("WOs waiting For Purchased Materials(" & ds.Tables(0).Rows(0)(0) & ")")

            End If





            table5.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))

            table5.AddCell("")
            table5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '4.Create WO from MPS
            table5.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table5.AddCell("")
            table5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER






            document.Add(table5)




            'table 9



            Dim table9 As PdfPTable = New PdfPTable(7)
            table9.TotalWidth = 600.0F
            table9.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table9.LockedWidth = True


            s = Server.MapPath("Document_Management")
            Dim img9 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell9 As PdfPCell = New PdfPCell(img9)
            img9.ScalePercent(3)
            cell9.AddElement(New Chunk(img9, 50, 5))
            cell9.HorizontalAlignment = 1
            cell9.Border = iTextSharp.text.Rectangle.NO_BORDER
            table9.AddCell(cell9)


            s = Server.MapPath("Document_Management")
            Dim img91 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell91 As PdfPCell = New PdfPCell(img91)
            img91.ScalePercent(3)
            cell91.AddElement(New Chunk(img91, 50, 5))
            cell91.HorizontalAlignment = 1
            cell91.Border = iTextSharp.text.Rectangle.NO_BORDER
            table9.AddCell(cell91)


            s = Server.MapPath("Document_Management")
            Dim img92 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell92 As PdfPCell = New PdfPCell(img92)
            img92.ScalePercent(3)
            cell92.AddElement(New Chunk(img92, 220, 5))
            cell92.HorizontalAlignment = 1
            cell92.Border = iTextSharp.text.Rectangle.NO_BORDER
            table9.AddCell(cell92)

            table9.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table9.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table9.AddCell("")


            table9.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table9.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table9.AddCell("")


            table9.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table9.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table9.AddCell("")


            table9.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table9.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table9.AddCell("")

            table9.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table9.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table9.AddCell("")


            document.Add(table9)




            '6th row




            Dim table6 As PdfPTable = New PdfPTable(7)


            table6.TotalWidth = 600.0F
            table6.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table6.LockedWidth = True






            adp.SelectCommand = New OleDbCommand
            adp.SelectCommand.Connection = conn.getconnection()
            'Dim ds As New Data.DataSet
            adp.SelectCommand.CommandText = "SELECT count(*) FROM V_UNCONFIRMED_ISSUES_REPORT"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table6.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#52BE80"))
                table6.DefaultCell.HorizontalAlignment = 1
                table6.DefaultCell.PaddingBottom = 10.0F
                table6.DefaultCell.PaddingBottom = 10.0F
                table6.AddCell("WOs with unconfirmed material issues (" & ds.Tables(0).Rows(0)(0) & ")")



            End If

            'table.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            'table.LockedWidth = True


            table6.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table6.AddCell(" ")
            table6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER


            'table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))
            'table.AddCell("Row 2, Col 1")
            'table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '2.Create WO From ReorderPt

            adp.SelectCommand.CommandText = "SELECT count(*) FROM V_QA_HOLD_REPORT"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table6.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#999966"))
                table6.AddCell("OSV on QA Hold(" & ds.Tables(0).Rows(0)(0) & ")")

            End If



            table6.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table6.AddCell("")
            table6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER




            '3.Create WO Lot for Lot
            adp.SelectCommand.CommandText = "SELECT count(*) FROM v_theoretical_vs_issued_qty v WHERE entry_date BETWEEN  sysdate-30 and sysdate"
            ds.Clear()
            adp.Fill(ds)
            If (ds.Tables(0).Rows.Count > 0) Then
                table6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                table6.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#DCE775"))
                table6.AddCell("WOs With Low Material Consumption(" & ds.Tables(0).Rows(0)(0) & ")")

            End If





            table6.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))

            table6.AddCell("")
            table6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '4.Create WO from MPS
            table6.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table6.AddCell("")
            table6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER






            document.Add(table6)

            'table8

            Dim table8 As PdfPTable = New PdfPTable(7)
            table8.TotalWidth = 600.0F
            table8.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table8.LockedWidth = True


            s = Server.MapPath("Document_Management")
            Dim img6 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell7 As PdfPCell = New PdfPCell(img6)
            img6.ScalePercent(3)
            cell7.AddElement(New Chunk(img6, 50, 5))
            cell7.HorizontalAlignment = 1
            cell7.Border = iTextSharp.text.Rectangle.NO_BORDER
            table8.AddCell(cell7)


            s = Server.MapPath("Document_Management")
            Dim img7 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(s & "/arrowdown.png")

            Dim cell8 As PdfPCell = New PdfPCell(img7)
            img6.ScalePercent(3)
            cell8.AddElement(New Chunk(img6, 50, 5))
            cell8.HorizontalAlignment = 1
            cell8.Border = iTextSharp.text.Rectangle.NO_BORDER
            table8.AddCell(cell8)


            table8.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table8.AddCell("")


            table8.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table8.AddCell("")


            table8.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table8.AddCell("")


            table8.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table8.AddCell("")


            table8.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table8.AddCell("")

            table8.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table8.AddCell("")


            document.Add(table8)


            '7th row




            Dim table7 As PdfPTable = New PdfPTable(7)


            table7.TotalWidth = 600.0F
            table7.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            table7.LockedWidth = True








            table7.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#7FB3D5"))
            table7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table7.DefaultCell.PaddingBottom = 10.0F
            table7.DefaultCell.HorizontalAlignment = 1
            table7.DefaultCell.PaddingBottom = 10.0F
            table7.AddCell("WOs pending for Close")



            'table.SetTotalWidth(New Single() {150.0F, 15.0F, 150.0F, 15.0F, 150.0F, 15.0F, 150.0F})
            'table.LockedWidth = True


            table7.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table7.AddCell(" ")
            table7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER


            'table.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#FFE0B2"))
            'table.AddCell("Row 2, Col 1")
            'table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '2.Create WO From ReorderPt



            table7.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#20B2AA"))
            table7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            table7.AddCell("WOs ready to Ship")



            table7.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table7.AddCell("")
            table7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER




            '3.Create WO Lot for Lot

            table7.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table7.AddCell("")
            table7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER





            table7.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))

            table7.AddCell("")
            table7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER

            '4.Create WO from MPS
            table7.DefaultCell.BackgroundColor = New BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))
            table7.AddCell("")
            table7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER






            document.Add(table7)












            document.Close()
            Dim bytes As Byte() = memoryStream.ToArray()
            memoryStream.Close()
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=MFGworksflow.pdf")
            Response.ContentType = "application/pdf"
            Response.Buffer = True
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.BinaryWrite(bytes)
            Response.End()
            Response.Close()

        End Using











    End Sub
End Class
