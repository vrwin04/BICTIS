Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome back, " & Session.CurrentUserName
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Log out?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Session.CurrentUserID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        MessageBox.Show("Clearance Request Form coming soon.", "Feature", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class