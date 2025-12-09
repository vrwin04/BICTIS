Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms ' Required for MessageBox

Public Module Session

    Public dbFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BICTIS_DB.accdb")
    Private ReadOnly connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbFile & ";Persist Security Info=False;"

    Public CurrentUserID As Integer = 0
    Public CurrentUserRole As String = ""
    Public CurrentUserName As String = ""

End Module