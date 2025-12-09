Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms ' Required for MessageBox

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
    ' 3. DATABASE METHODS
    ' ==========================================

    ' TEST CONNECTION

End Module