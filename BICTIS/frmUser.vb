Imports System.Collections.Generic

Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
    End Sub

    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        ' 1. SECURITY CHECK: Do they have a pending case?
        Dim checkSql As String = "SELECT COUNT(*) FROM tbl_Incidents WHERE RespondentID = @uid AND Status = 'Pending'"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@uid", Session.CurrentUserID)

        Dim activeCases As Integer = Session.GetCount(checkSql, params)

        If activeCases > 0 Then
            MessageBox.Show("ACCESS DENIED." & vbCrLf & "You have " & activeCases & " pending case(s).", "Clearance Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        ' 2. Submit Request
        Dim query As String = "INSERT INTO tbl_Clearances (ResidentID, Purpose, DateIssued, Status) VALUES (@uid, 'General Purpose', @date, 'Requested')"
        Dim insertParams As New Dictionary(Of String, Object)
        insertParams.Add("@uid", Session.CurrentUserID)
        insertParams.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, insertParams) Then
            MessageBox.Show("Request Submitted! Wait for Admin approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim sql As String = "SELECT DateIssued, Purpose, Status FROM tbl_Clearances WHERE ResidentID = " & Session.CurrentUserID
        Dim dt As DataTable = Session.GetDataTable(sql)
        MessageBox.Show("You have " & dt.Rows.Count & " request(s) on record.", "My History", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.CurrentUserID = 0
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub
End Class