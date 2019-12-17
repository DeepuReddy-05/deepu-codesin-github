Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http

Namespace Controllers
    Public Class PageInfoController
        Inherits ApiController
        Protected dbad As New OleDbDataAdapter
        Public conn As New Dbconn
        ' GET: api/Foods/5 
        Public Function GetDetails(ByVal Page_ID As String, ByVal Doc_No As String) As HttpResponseMessage
            Try
                If Page_ID <> "" And Doc_No <> "" Then
                    Dim ds, ds_Tables As New Data.DataSet
                    Dim dt_Table As DataTable
                    ds.Clear()
                    'Will get list table
                    ds = Return_record_set("SELECT ENTITY_NAME,TABLE_NAME,PRIMARY_KEY1 FROM SYS_PAGE_ENTITY WHERE PAGE_ID='" & Page_ID & "' AND PARENT_ENTITY_NAME IS NULL")
                    If ds.Tables(0).Rows.Count > 0 Then
                        For Each dr In ds.Tables(0).Rows
                            Dim WhereCond, PK_val, Table_Name As String
                            If Not (Equals(dr("PRIMARY_KEY1"), System.DBNull.Value)) Then
                                PK_val = dr("PRIMARY_KEY1").ToString
                            Else
                                PK_val = String.Empty
                            End If
                            If Not (Equals(dr("TABLE_NAME"), System.DBNull.Value)) Then
                                Table_Name = dr("TABLE_NAME").ToString
                            Else
                                Table_Name = String.Empty
                            End If
                            If PK_val <> "" And Table_Name <> "" Then
                                WhereCond = " WHERE UPPER(" & PK_val & ")=UPPER('" & Doc_No & "')"

                                Dim ds_Header As New Data.DataSet
                                ds_Header.Clear()
                                ds_Header = Return_record_set("SELECT * FROM " & Table_Name & WhereCond)

                                If ds_Header.Tables(0).Rows.Count > 0 Then
                                    dt_Table = New DataTable()
                                    dt_Table = ds_Header.Tables(0).Copy
                                    dt_Table.TableName = Table_Name
                                    ds_Tables.Tables.Add(dt_Table)
                                End If

                            End If

                            'Detail table Code
                            ds = Return_record_set(" SELECT ENTITY_NAME,TABLE_NAME,PRIMARY_KEY1 FROM SYS_PAGE_ENTITY WHERE PAGE_ID='" & Page_ID & "' AND PARENT_TABLE_NAME='" & Table_Name & "' ORDER BY CREATED_DATE")
                            If ds.Tables(0).Rows.Count > 0 Then
                                For Each dr1 In ds.Tables(0).Rows
                                    Dim WhereCond1, PK_val1, Table_Name1 As String
                                    If Not (Equals(dr1("PRIMARY_KEY1"), System.DBNull.Value)) Then
                                        PK_val1 = dr1("PRIMARY_KEY1").ToString
                                    Else
                                        PK_val1 = String.Empty
                                    End If
                                    If Not (Equals(dr1("TABLE_NAME"), System.DBNull.Value)) Then
                                        Table_Name1 = dr1("TABLE_NAME").ToString
                                    Else
                                        Table_Name1 = String.Empty
                                    End If
                                    If PK_val1 <> "" And Table_Name1 <> "" Then
                                        WhereCond1 = " WHERE UPPER(" & PK_val1 & ")=UPPER('" & Doc_No & "')"

                                        Dim ds_Header As New Data.DataSet
                                        ds_Header.Clear()
                                        ds_Header = Return_record_set("SELECT * FROM " & Table_Name1 & WhereCond1)

                                        If ds_Header.Tables(0).Rows.Count > 0 Then
                                            dt_Table = New DataTable()
                                            dt_Table = ds_Header.Tables(0).Copy
                                            dt_Table.TableName = Table_Name1
                                            ds_Tables.Tables.Add(dt_Table)
                                        End If

                                    End If

                                    'creating xml path
                                    'Dim strConString As String = "Provider=OraOLEDB.Oracle;Data Source=" + strServerName + ";User Id=" + strUserName + ";Password=" + strPassWord + ";"
                                    'dbad.SelectCommand = New OleDbCommand
                                    'If Not Directory.Exists(XML_Path) Then
                                    '    Directory.CreateDirectory(XML_Path)
                                    'End If
                                    'If Directory.Exists(XML_Path) Then
                                    '    Dim fileName As String = "OMEGACUBEAPI"
                                    '    If File.Exists(XML_Path & "\" & fileName.ToUpper & ".XML") Then
                                    '        File.Delete(XML_Path & "\" & fileName.ToUpper & ".XML")
                                    '    End If
                                    '    ds_Tables.WriteXml(XML_Path & "\" & fileName.ToUpper & ".XML", XmlWriteMode.WriteSchema)
                                    'End If

                                Next
                            End If
                        Next
                        Return Request.CreateResponse(HttpStatusCode.OK, ds_Tables)
                    End If
                    Return Request.CreateResponse(HttpStatusCode.BadRequest, "No Data")
                End If




                'Need to send error


            Catch ex As Exception
                Call insert_sys_log("Exception while creating Get Details page", ex.Message)
            End Try
        End Function
        'Private Sub GenerateXML(strServerName As String, strUserName As String, strPassWord As String, XML_Path As String)
        '    creating Xml path
        '    Dim strConString As String = "Provider=OraOLEDB.Oracle;Data Source=" + strServerName + ";User Id=" + strUserName + ";Password=" + strPassWord + ";"
        '    dbad.SelectCommand = New OleDbCommand
        '    Dim ds_Tables As New Data.DataSet
        '    LogExceptions(strLogFilePath, Nothing, "Directory Path: " & XML_Path)
        '    If Not Directory.Exists(XML_Path) Then
        '        Directory.CreateDirectory(XML_Path)
        '    End If
        '    If Directory.Exists(XML_Path) Then
        '        Dim fileName As String = "OMEGACUBEAPI"
        '        LogExceptions(strLogFilePath, Nothing, "File Path: " & XML_Path & "\" & fileName.ToUpper & ".XML")
        '        If File.Exists(XML_Path & "\" & fileName.ToUpper & ".XML") Then
        '            File.Move(physicalPath & "\" & fileName.ToUpper & ".XML", physicalPath & "/" & strDateTime & "/" & fileName.ToUpper & ".XML")
        '            File.Delete(XML_Path & "\" & fileName.ToUpper & ".XML")
        '            ds_Tables.WriteXml(XML_Path & "\" & fileName.ToUpper & ".XML", XmlWriteMode.WriteSchema)
        '        End If
        '    End If
        'End Sub

        Public Sub Update_query(ByVal str_update As String)
            Try
                dbad.UpdateCommand = New OleDbCommand
                dbad.UpdateCommand.Connection = conn.getconnection()
                dbad.UpdateCommand.CommandText = str_update
                dbad.UpdateCommand.ExecuteNonQuery()
                dbad.UpdateCommand.Connection.Close()
            Catch ex As Exception
                Call insert_sys_log("Update_query", ex.Message)
            End Try
        End Sub
        Public Sub Insert_query(ByVal str_insert As String)
            Try
                dbad.InsertCommand = New OleDbCommand
                dbad.InsertCommand.Connection = conn.getconnection()
                dbad.InsertCommand.CommandText = str_insert
                dbad.InsertCommand.ExecuteNonQuery()
                dbad.InsertCommand.Connection.Close()
            Catch ex As Exception
                Call insert_sys_log("Insert_query", ex.Message)
            End Try
        End Sub
        Public Sub Delete_query(ByVal str_delete As String)
            Try
                dbad.DeleteCommand = New OleDbCommand
                dbad.DeleteCommand.Connection = conn.getconnection()
                dbad.DeleteCommand.CommandText = str_delete
                dbad.DeleteCommand.ExecuteNonQuery()
                dbad.DeleteCommand.Connection.Close()
            Catch ex As Exception
                Call insert_sys_log("Delete_query", ex.Message)
            End Try
        End Sub
        Public Function Return_record_count(ByVal str_select As String) As Integer
            Try
                Dim ds_new As New Data.DataSet
                dbad.SelectCommand = New OleDbCommand
                dbad.SelectCommand.Connection = conn.getconnection()
                dbad.SelectCommand.CommandText = str_select
                dbad.Fill(ds_new)
                dbad.SelectCommand.Connection.Close()
                If (ds_new.Tables(0).Rows.Count > 0) Then
                    Return 1
                Else
                    Return 0
                End If
                Return 0
            Catch ex As Exception
                Call insert_sys_log("Return_record_count", ex.Message)
            End Try
        End Function
        Public Function Return_record_set(ByVal str_select As String) As Data.DataSet
            Try
                Dim ds_new As New Data.DataSet
                dbad.SelectCommand = New OleDbCommand
                dbad.SelectCommand.Connection = conn.getconnection()
                dbad.SelectCommand.CommandText = str_select
                dbad.Fill(ds_new)
                dbad.SelectCommand.Connection.Close()
                Return ds_new
            Catch ex As Exception
                Call insert_sys_log("Return_record_set", ex.Message)
            End Try
        End Function
        Public Sub insert_sys_log(ByVal str1 As String, ByVal message As String)
            Dim sterr1, sterr2, sterr3, sterr4, sterr As String
            sterr = Replace(message, "'", "''")
            If (Len(sterr) > 4000) Then
                sterr1 = Mid(sterr, 1, 4000)
                If (Len(sterr) > 8000) Then
                    sterr2 = Mid(sterr, 4000, 8000)
                    If (Len(sterr) > 12000) Then
                        sterr3 = Mid(sterr, 8000, 12000)
                        If (Len(sterr) > 16000) Then
                            sterr4 = Mid(sterr, 12000, 16000)
                        Else
                            sterr4 = Mid(sterr, 12000, Len(sterr))
                        End If
                    Else
                        sterr3 = Mid(sterr, 8000, Len(sterr))
                        sterr4 = ""
                    End If
                Else
                    sterr2 = Mid(sterr, 4000, Len(sterr))
                    sterr3 = ""
                    sterr3 = ""
                    sterr4 = ""
                End If
            Else
                sterr1 = sterr
                sterr2 = ""
                sterr3 = ""
                sterr4 = ""
            End If
            Try
                dbad.InsertCommand.Connection = conn.getconnection()
                If (dbad.InsertCommand.Connection.State = Data.ConnectionState.Closed) Then
                    dbad.InsertCommand.Connection.Open()
                End If
                dbad.InsertCommand.CommandText = "Insert into SYS_ACTIVATE_STATUS_LOG (LINE_NO, CHANGE_REQUEST_NO,  OBJECT_TYPE, OBJECT_NAME, ERROR_TEXT, STATUS,LOG_DATE,ERROR_TEXT1, ERROR_TEXT2, ERROR_TEXT3) values ((select nvl(max(to_number(line_no)),0)+1 from SYS_ACTIVATE_STATUS_LOG),'','OmegaCubeAPI','" & str1 & "','" & sterr1 & "','N',sysdate,'" & sterr2 & "','" & sterr3 & "','" & sterr4 & "')"
                dbad.InsertCommand.ExecuteNonQuery()
                dbad.InsertCommand.Connection.Close()
            Catch ex As Exception
            End Try
        End Sub




    End Class
End Namespace