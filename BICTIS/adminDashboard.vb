' 1. Use this Alias to stop the "Ambiguous" error
Imports SysChart = System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms ' Standard Forms
Imports System.Data ' For DataTable

Public Class adminDashboard
    Private Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Dashboard - " & Session.CurrentUserRole

        ' Add Safety Try-Catch to prevent crashes on load
        Try
            LoadStats()
            LoadChart()
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadStats()
        ' Count Users (Residents)
        Dim userCount As Integer = Session.GetCount("SELECT COUNT(*) FROM tblResidents WHERE Role='User'")
        lblTotalUsers.Text = userCount.ToString()

        ' Count Pending Cases
        Dim pending As Integer = Session.GetCount("SELECT COUNT(*) FROM tblIncidents WHERE Status='Pending'")
        lblPendingCases.Text = pending.ToString()

        ' Visual Alert
        If pending > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If
    End Sub

    Private Sub LoadChart()
        ' Graph: Incidents by Type
        ' Ensure table name matches your Access DB (tblIncidents)
        Dim query As String = "SELECT IncidentType, COUNT(*) as Count FROM tblIncidents GROUP BY IncidentType"
        Dim dt As DataTable = Session.GetDataTable(query)

        ' Safety check for Chart Control
        If chartIncidents Is Nothing Then Exit Sub

        chartIncidents.Series.Clear()
        chartIncidents.Titles.Clear()

        ' 2. USE THE ALIAS 'SysChart' HERE
        Dim series As New SysChart.Series("Incidents")
        series.ChartType = SysChart.SeriesChartType.Column ' or Pie
        series.IsValueShownAsLabel = True
        series.Color = Color.FromArgb(41, 128, 185)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                ' Handle DBNulls safely
                Dim iType As String = If(IsDBNull(row("IncidentType")), "Unknown", row("IncidentType").ToString())
                Dim iCount As Integer = Convert.ToInt32(row("Count"))
                series.Points.AddXY(iType, iCount)
            Next
        End If

        chartIncidents.Series.Add(series)
        chartIncidents.Titles.Add("Incident Distribution")
    End Sub

    ' NAVIGATION
    Private Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        Dim frm As New frmManageResidents()
        frm.ShowDialog()
        LoadStats()
    End Sub

    Private Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        Dim frm As New frmBlotter()
        frm.ShowDialog()
        LoadStats()
        LoadChart()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Sign out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.CurrentResidentID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub
End Class