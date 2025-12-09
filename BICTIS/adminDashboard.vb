Imports System.Windows.Forms.DataVisualization.Charting

Public Class adminDashboard
    Private Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Administrator Control Panel"
        LoadStatistics()
        LoadIncidentChart()
    End Sub

    Private Sub LoadStatistics()
        ' 1. Total Residents (Users)
        Dim totalUsers As Integer = Session.GetCount("SELECT COUNT(*) FROM tbl_Users WHERE Role='User'")
        lblTotalUsers.Text = totalUsers.ToString()

        ' 2. Pending Cases (Critical for blocking clearances)
        Dim pendingCases As Integer = Session.GetCount("SELECT COUNT(*) FROM tbl_Incidents WHERE Status='Pending'")
        lblPendingCases.Text = pendingCases.ToString()

        ' Visual Alert Logic
        If pendingCases > 0 Then
            pnlCard2.BackColor = Color.MistyRose
            lblPendingCases.ForeColor = Color.DarkRed
        Else
            pnlCard2.BackColor = Color.White
            lblPendingCases.ForeColor = Color.Green
        End If
    End Sub

    Private Sub LoadIncidentChart()
        ' Graph: Incidents by Type
        Dim query As String = "SELECT IncidentType, COUNT(*) as Count FROM tbl_Incidents GROUP BY IncidentType"
        Dim dt As DataTable = Session.GetDataTable(query)

        chartIncidents.Series.Clear()
        Dim series As New Series("Incidents")
        series.ChartType = SeriesChartType.Pie
        series.IsValueShownAsLabel = True

        For Each row As DataRow In dt.Rows
            series.Points.AddXY(row("IncidentType").ToString(), row("Count"))
        Next

        chartIncidents.Series.Add(series)
        chartIncidents.Titles.Clear()
        chartIncidents.Titles.Add("Case Distribution")
    End Sub

    ' --- NAVIGATION ---

    Private Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        ' Open the Incident Manager
        Dim frm As New frmBlotter()
        frm.ShowDialog()
        LoadStatistics() ' Refresh data when they return
        LoadIncidentChart()
    End Sub

    Private Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        ' OPEN THE RESIDENT MANAGER FORM
        Dim frm As New frmManageResidents()
        frm.ShowDialog()

        LoadStatistics()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to sign out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.CurrentUserID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub
End Class