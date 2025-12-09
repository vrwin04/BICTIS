Imports System.Data.OleDb
Imports System.Collections.Generic

Public Class frmLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Logic remains the same, just attached to the new Button
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please enter credentials.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            Dim dash As New adminDashboard()
            dash.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid Username or Password.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


        If Session.CurrentUserRole = "Admin" Or Session.CurrentUserRole = "Secretary" Then
            Dim adminDash As New adminDashboard()
            adminDash.Show()
        Else
            Dim userDash As New frmUser()
            userDash.Show()
        End If

    End Sub

    ' Link to open Registration Form
    Private Sub lblRegisterLink_Click(sender As Object, e As EventArgs) Handles lblRegisterLink.Click
        Dim reg As New frmRegistration()
        reg.Show()
        Me.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar ' Show Text
        Else
            txtPassword.PasswordChar = "•"c ' Hide Text (bullet character)
        End If
    End Sub
End Class