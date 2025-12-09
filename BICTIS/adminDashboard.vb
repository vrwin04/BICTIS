Imports System.Windows.Forms.DataVisualization.Charting

Public Class adminDashboard
    Private Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Dashboard - " & Session.CurrentUserRole
        LoadStats()
        LoadChart()
    End Sub

    Private Sub LoadStats()
        lblTotalUsers.Text = Session.GetCount("SELECT COUNT(*) FROM tbl_Users WHERE Role='User'").ToString()
        lblPendingCases.Text = Session.GetCount("SELECT COUNT(*) FROM tbl_Incidents WHERE Status='Pending'").ToString()
    End Sub

    Private Sub LoadChart()
        ' Fetch Data: Count incidents by TYPE (e.g., Noise, Theft)
        Dim query As String = "SELECT IncidentType, COUNT(*) as Count FROM tbl_Incidents GROUP BY IncidentType"
        Dim dt As DataTable = Session.GetDataTable(query)

        chartIncidents.Series.Clear()
        Dim series As New Series("Incidents")
        series.ChartType = SeriesChartType.Column ' Bar Chart
        series.Color = Color.FromArgb(41, 128, 185)

        For Each row As DataRow In dt.Rows
            series.Points.AddXY(row("IncidentType").ToString(), row("Count"))
        Next

        chartIncidents.Series.Add(series)
        chartIncidents.Titles.Clear()
        chartIncidents.Titles.Add("Case Distribution by Type")
    End Sub

    Private Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        Dim frm As New frmBlotter()
        frm.ShowDialog()
        LoadStats() ' Refresh when they come back
        LoadChart()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.CurrentUserID = 0
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub
End Class