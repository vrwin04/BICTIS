Imports System.Collections.Generic

Public Class frmRegistration
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' 1. Validate
        If txtUsername.Text = "" Or txtPassword.Text = "" Or txtFullName.Text = "" Then
            MessageBox.Show("All fields are required.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtPassword.Text <> txtConfirmPass.Text Then
            MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. Check Duplicates
        Dim checkParams As New Dictionary(Of String, Object)
        checkParams.Add("@user", txtUsername.Text)
        If Session.GetCount("SELECT COUNT(*) FROM tbl_Users WHERE Username=@user", checkParams) > 0 Then
            MessageBox.Show("This Username is already taken.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        ' 3. Create Account (Always Role = 'User')
        Dim query As String = "INSERT INTO tbl_Users (Username, [Password], FullName, Role, IsActive) VALUES (@user, @pass, @full, 'User', True)"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@user", txtUsername.Text)
        params.Add("@pass", txtPassword.Text)
        params.Add("@full", txtFullName.Text)

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Account successfully created! Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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