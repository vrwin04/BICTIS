Imports System.Collections.Generic

Public Class frmRegistration
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Or txtFullName.Text = "" Then
            MessageBox.Show("Please fill in all fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtPassword.Text <> txtConfirmPass.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Check Duplicate
        Dim checkParams As New Dictionary(Of String, Object)
        checkParams.Add("@user", txtUsername.Text)
        If Session.GetCount("SELECT COUNT(*) FROM tbl_Users WHERE Username=@user") > 0 Then
            MessageBox.Show("Username already taken.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' INSERT RESIDENT USER (Role='User')
        Dim query As String = "INSERT INTO tbl_Users (Username, [Password], Role, FullName) VALUES (@user, @pass, 'User', @full)"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@user", txtUsername.Text)
        params.Add("@pass", txtPassword.Text)
        params.Add("@full", txtFullName.Text)

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Account Created Successfully!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar
            txtConfirmPass.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "•"c
            txtConfirmPass.PasswordChar = "•"c
        End If
    End Sub

    Private Sub lblLoginLink_Click(sender As Object, e As EventArgs) Handles lblLoginLink.Click
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
End Class