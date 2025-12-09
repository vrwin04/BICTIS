Imports System.Collections.Generic

Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
    End Sub

    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        Dim checkSql As String = "SELECT COUNT(*) FROM tbl_Incidents WHERE RespondentID = @uid AND Status = 'Pending'"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@uid", Session.CurrentUserID)

        If Session.GetCount(checkSql, params) > 0 Then
            MessageBox.Show("ACCESS DENIED. You have pending cases.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim query As String = "INSERT INTO tbl_Clearances (ResidentID, Purpose, DateIssued, Status) VALUES (@uid, 'General', @date, 'Requested')"
        Dim insertParams As New Dictionary(Of String, Object)
        insertParams.Add("@uid", Session.CurrentUserID)
        insertParams.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, insertParams) Then
            MessageBox.Show("Request Submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim dt As DataTable = Session.GetDataTable("SELECT * FROM tbl_Clearances WHERE ResidentID=" & Session.CurrentUserID)
        MessageBox.Show("You have " & dt.Rows.Count & " past records.", "Info")
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.CurrentUserID = 0
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub
End Class