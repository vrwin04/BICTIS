Public Class adminDashboard
    Private Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Hello " & Session.CurrentUserName & " (Administrator)"
        RefreshStats()
    End Sub

    Private Sub RefreshStats()
        ' Count Users with 'User' Role as Residents
        lblTotalUsers.Text = Session.GetCount("SELECT COUNT(*) FROM tbl_Users WHERE Role='User'").ToString()

        ' Count Pending Cases
        Dim pending As Integer = Session.GetCount("SELECT COUNT(*) FROM tbl_Incidents WHERE Status='Pending'")
        lblPendingCases.Text = pending.ToString()

        If pending > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If
    End Sub

    Private Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        MessageBox.Show("Incident Management Module (Under Construction)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Sign out?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Session.CurrentUserID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub
End Class