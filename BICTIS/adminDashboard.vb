Imports System.Windows.Forms.DataVisualization.Charting

Public Class adminDashboard
    Private Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Dashboard - " & Session.CurrentUserRole
        LoadStats()
        LoadChart()
    End Sub

    Private Sub LoadStats()
        ' FIX: tblResidents
        lblTotalUsers.Text = Session.GetCount("SELECT COUNT(*) FROM tblResidents WHERE Role='User'").ToString()

        ' FIX: tblIncidents
        Dim pending As Integer = Session.GetCount("SELECT COUNT(*) FROM tblIncidents WHERE Status='Pending'")
        lblPendingCases.Text = pending.ToString()

        If pending > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If
    End Sub

    Private Sub LoadChart()
        ' FIX: Changed alias 'Count' to 'ICount' to avoid reserved word error
        Dim query As String = "SELECT IncidentType, COUNT(*) as [ICount] FROM tblIncidents GROUP BY IncidentType"
        Dim dt As DataTable = Session.GetDataTable(query)

        chartIncidents.Series.Clear()
        Dim series As New Series("Incidents")
        series.ChartType = SeriesChartType.Pie
        series.IsValueShownAsLabel = True

        For Each row As DataRow In dt.Rows
            series.Points.AddXY(row("IncidentType").ToString(), row("ICount"))
        Next

        chartIncidents.Series.Add(series)
        chartIncidents.Titles.Clear()
        chartIncidents.Titles.Add("Case Distribution")
    End Sub

    Private Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        Dim frm As New frmBlotter()
        frm.ShowDialog()
        LoadStats()
        LoadChart()
    End Sub

    Private Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        Dim frm As New frmManageResidents()
        frm.ShowDialog()
        LoadStats()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.CurrentResidentID = 0
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub
End Class