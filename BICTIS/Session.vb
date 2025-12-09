Imports System.Data.OleDb
Imports System.IO

Public Class Session
    ' DYNAMIC CONNECTION STRING
    ' This automatically finds the database in your project folder, so it works on any computer.
    Public Shared dbFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BICTIS_DB.accdb")
    Private ReadOnly connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbFile & ";Persist Security Info=False;"

    ' TEST CONNECTION FUNCTION
    Public Function CheckConnection() As Boolean
        Using conn As New OleDbConnection(connectionString)
            Try
                conn.Open()
                Return True
            Catch ex As Exception
                MessageBox.Show("Connection Error: " & ex.Message & vbCrLf & "Looking for DB at: " & dbFile)
                Return False
            End Try
        End Using
    End Function

    ' GET DATA (For Login and Grids)
    Public Function GetDataTable(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim dt As New DataTable()
        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                    Next
                End If
                Try
                    conn.Open()
                    Dim adapter As New OleDbDataAdapter(cmd)
                    adapter.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("Database Error: " & ex.Message)
                End Try
            End Using
        End Using
        Return dt
    End Function
End Class