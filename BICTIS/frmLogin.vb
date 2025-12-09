Imports System.Data.OleDb
Imports System.Collections.Generic

Public Class frmLogin
    ' NOTE: We removed "Dim db As New Session" because Session is now a Module.

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' A. Validation
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' B. Secure Login Query
        Dim query As String = "SELECT * FROM tbl_Users WHERE Username=@user AND Password=@pass"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@user", txtUsername.Text)
        params.Add("@pass", txtPassword.Text)

        ' CALL SESSION DIRECTLY
        Dim dt As DataTable = Session.GetDataTable(query, params)

        If dt.Rows.Count > 0 Then
            ' C. SUCCESS
            Session.CurrentUserID = Convert.ToInt32(dt.Rows(0)("UserID"))
            Session.CurrentUserRole = dt.Rows(0)("Role").ToString()
            Session.CurrentUserName = dt.Rows(0)("Username").ToString()

            MessageBox.Show("Welcome, " & Session.CurrentUserName & "!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim dash As New frmDashboard()
            dash.Show()
            Me.Hide()
        Else
            ' E. FAILURE
            MessageBox.Show("Invalid Username or Password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub
End Class