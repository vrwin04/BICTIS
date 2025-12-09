Imports System.Collections.Generic

Public Class frmRegistration
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' 1. Validation
        If txtUsername.Text = "" Or txtPassword.Text = "" Or txtFullName.Text = "" Then
            MessageBox.Show("Please fill in all fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtPassword.Text <> txtConfirmPass.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. Check if Username Exists
        Dim checkQuery As String = "SELECT COUNT(*) FROM tbl_Users WHERE Username=@user"
        Dim checkParams As New Dictionary(Of String, Object)
        checkParams.Add("@user", txtUsername.Text)

        Dim dt As DataTable = Session.GetDataTable(checkQuery, checkParams)
        If dt.Rows.Count > 0 AndAlso Convert.ToInt32(dt.Rows(0)(0)) > 0 Then
            MessageBox.Show("Username already taken.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 3. SECURE INSERT: Force Role to be 'User'
        ' We do NOT allow the user to pick a role. We hardcode 'User' in the SQL.
        Dim insertQuery As String = "INSERT INTO tbl_Users (Username, [Password], Role, FullName) VALUES (@user, @pass, 'User', @full)"

        Dim insertParams As New Dictionary(Of String, Object)
        insertParams.Add("@user", txtUsername.Text)
        insertParams.Add("@pass", txtPassword.Text)
        insertParams.Add("@full", txtFullName.Text)

        If Session.ExecuteQuery(insertQuery, insertParams) Then
            MessageBox.Show("Resident Account Created! You may now login.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Redirect to Login
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
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