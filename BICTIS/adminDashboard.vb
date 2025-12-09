Imports System.Windows.Forms.DataVisualization.Charting

Public Class adminDashboard
    Private Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Administrator Control Panel"
        LoadStats()
        LoadIncidentChart()
    End Sub

    Private Sub LoadStats()
        lblTotalUsers.Text = Session.GetCount("SELECT COUNT(*) FROM tbl_Users WHERE Role='User'").ToString()
        Dim pending As Integer = Session.GetCount("SELECT COUNT(*) FROM tbl_Incidents WHERE Status='Pending'")
        lblPendingCases.Text = pending.ToString()

        If pending > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If
    End Sub

    Private Sub LoadIncidentChart()
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

    Private Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        Dim frm As New frmBlotter()
        frm.ShowDialog()
        LoadStats()
        LoadIncidentChart()
    End Sub

    Private Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        Dim frm As New frmManageResidents()
        frm.ShowDialog()
        LoadStats()
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