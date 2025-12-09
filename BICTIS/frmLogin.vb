Imports System.Collections.Generic

Public Class frmLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please fill in all fields.", "Missing Credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "SELECT * FROM tbl_Users WHERE Username=@user AND Password=@pass"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@user", txtUsername.Text)
        params.Add("@pass", txtPassword.Text)

        Dim dt As DataTable = Session.GetDataTable(query, params)

        If dt.Rows.Count > 0 Then
            Session.CurrentUserID = Convert.ToInt32(dt.Rows(0)("UserID"))
            Session.CurrentUserRole = dt.Rows(0)("Role").ToString()
            Session.CurrentUserName = dt.Rows(0)("Username").ToString()

            MessageBox.Show("Welcome back, " & Session.CurrentUserName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If Session.CurrentUserRole = "Admin" Or Session.CurrentUserRole = "Secretary" Then
                Dim admin As New adminDashboard()
                admin.Show()
            Else
                Dim user As New frmUser()
                user.Show()
            End If
            Me.Hide()
        Else
            MessageBox.Show("Incorrect Username or Password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "•"c
        End If
    End Sub

    Private Sub lblRegisterLink_Click(sender As Object, e As EventArgs) Handles lblRegisterLink.Click
        Dim reg As New frmRegistration()
        reg.Show()
        Me.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
End Class