Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms ' Required for MessageBox
Imports System.Collections.Generic ' Required for Dictionary

Public Module Session
    ' ==========================================
    ' 1. DATABASE CONFIGURATION
    ' ==========================================
    ' This finds the database in your bin/Debug folder automatically
    Public dbFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BICTIS_DB.accdb")
    Private ReadOnly connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbFile & ";Persist Security Info=False;"

    ' ==========================================
    ' 2. USER SESSION STATE
    ' ==========================================
    Public CurrentUserID As Integer = 0
    Public CurrentUserRole As String = ""
    Public CurrentUserName As String = ""

    ' ==========================================
    ' 3. DATABASE METHODS (These were missing!)
    ' ==========================================

    ' TEST CONNECTION
    Public Function CheckConnection() As Boolean
        Using conn As New OleDbConnection(connectionString)
            Try
                conn.Open()
                Return True
            Catch ex As Exception
                MessageBox.Show("Database Connection Failed!" & vbCrLf & "Error: " & ex.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    ' READ DATA (For Login and Grids)
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
                    MessageBox.Show("Error Reading Data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
        Return dt
    End Function

    ' WRITE DATA (Insert, Update, Delete)
    Public Function ExecuteQuery(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Boolean
        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                    Next
                End If
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MessageBox.Show("Error Saving Data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using
    End Function

    ' GET COUNT (For Dashboard Statistics)
    Public Function GetCount(query As String) As Integer
        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                Try
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso IsNumeric(result) Then
                        Return Convert.ToInt32(result)
                    Else
                        Return 0
                    End If
                Catch ex As Exception
                    Return 0
                End Try
            End Using
        End Using
    End Function

End Module