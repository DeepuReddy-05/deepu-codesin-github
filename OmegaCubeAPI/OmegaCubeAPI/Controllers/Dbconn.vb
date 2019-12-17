Namespace Controllers
    Public Class Dbconn
        Public Dbconn As String = CType(ConfigurationManager.AppSettings("dbconn.ConnectionString"), String)
        Public Function getconnection() As Data.OleDb.OleDbConnection

            Dim Dbconn As String
            Dim conn As New Data.OleDb.OleDbConnection
            Try

                Dbconn = CType(ConfigurationManager.AppSettings("dbconn.ConnectionString"), String)

                Dbconn = Dbconn
                conn.ConnectionString = Dbconn
            Catch ex As Exception
                Throw
            End Try

            Try
                conn.Open()
            Catch ex As Exception
                Throw
            End Try

            Return (conn)
        End Function
    End Class
End Namespace
