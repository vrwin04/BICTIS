Public Class frmDashboard
    ' NOTE: We removed "Dim db As New Session"

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Dashboard Overview - " & Session.CurrentUserRole
        LoadDashboardStats()
    End Sub

    Private Sub LoadDashboardStats()
        ' CALL SESSION DIRECTLY
        Dim countRes As Integer = Session.GetCount("SELECT COUNT(*) FROM tbl_Residents WHERE IsActive=True")
        lblTotalRes.Text = countRes.ToString()

        Dim countCases As Integer = Session.GetCount("SELECT COUNT(*) FROM tbl_Incidents WHERE Status='Pending'")
        lblPendingCases.Text = countCases.ToString()

        If countCases > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.CurrentUserID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        MessageBox.Show("Resident Profiling Module coming next!", "Under Construction", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        MessageBox.Show("Blotter & Incident Module coming next!", "Under Construction", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class