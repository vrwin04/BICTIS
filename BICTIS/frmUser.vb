Imports System.Collections.Generic

Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
    End Sub

    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        ' 1. Check for Pending Case
        Dim checkSql As String = "SELECT COUNT(*) FROM tblIncidents WHERE RespondentID = @uid AND Status = 'Pending'"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@uid", Session.CurrentResidentID)

        Dim activeCases As Integer = Session.GetCount(checkSql, params)

        If activeCases > 0 Then
            MessageBox.Show("ACCESS DENIED." & vbCrLf & "You have " & activeCases & " pending case(s).", "Clearance Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        ' 2. Submit Request
        Dim query As String = "INSERT INTO tblClearances (ResidentID, Purpose, DateIssued, Status) VALUES (@uid, 'General', @date, 'Requested')"
        Dim insertParams As New Dictionary(Of String, Object)
        insertParams.Add("@uid", Session.CurrentResidentID)
        insertParams.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, insertParams) Then
            MessageBox.Show("Request Submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim dt As DataTable = Session.GetDataTable("SELECT * FROM tblClearances WHERE ResidentID=" & Session.CurrentResidentID)
        MessageBox.Show("You have " & dt.Rows.Count & " past records.", "Info")
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.CurrentResidentID = 0
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub
End Class