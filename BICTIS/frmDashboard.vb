Public Class frmDashboard
    Dim db As New Session()

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Load User Info in Title
        lblPageTitle.Text = "Dashboard Overview - " & Session.CurrentUserRole

        ' 2. Load Statistics
        LoadDashboardStats()
    End Sub

    Private Sub LoadDashboardStats()
        ' KPI 1: Total Residents (Active)
        Dim countRes As Integer = db.GetCount("SELECT COUNT(*) FROM tbl_Residents WHERE IsActive=True")
        lblTotalRes.Text = countRes.ToString()

        ' KPI 2: Pending Cases (The Critical Alert)
        Dim countCases As Integer = db.GetCount("SELECT COUNT(*) FROM tbl_Incidents WHERE Status='Pending'")
        lblPendingCases.Text = countCases.ToString()

        ' Visual Alert: Turn text RED if there are pending cases
        If countCases > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If
    End Sub

    ' NAVIGATION BUTTONS
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.CurrentUserID = 0 ' Clear Session
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub

    ' Placeholder for Residents Button (We will build this form next)
    Private Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        MessageBox.Show("Resident Profiling Module coming next!", "Under Construction", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Dim frm As New frmResidents()
        ' frm.ShowDialog()
        ' LoadDashboardStats() ' Refresh stats when returning
    End Sub

    ' Placeholder for Blotter Button
    Private Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        MessageBox.Show("Blotter & Incident Module coming next!", "Under Construction", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class