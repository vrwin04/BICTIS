Imports System.Collections.Generic
Imports System.Windows.Forms.DataVisualization.Charting ' FIXES Error BC30451 & BC30002
Imports Microsoft.SqlServer

Public Class adminDashboard
    ' ERROR BC30506 (Handles Clause) happens if the buttons below don't exist in the Designer.
    ' Make sure you update the Designer.vb file in Step 2!

    Private Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Dashboard - " & Session.CurrentUserRole
        LoadStats()
        LoadChart()
    End Sub

    Private Sub LoadStats()
        ' Count Users (Residents)
        lblTotalUsers.Text = Session.GetCount("SELECT COUNT(*) FROM tbl_Users WHERE Role='User'").ToString()

        ' Count Pending Cases
        Dim pending As Integer = Session.GetCount("SELECT COUNT(*) FROM tbl_Incidents WHERE Status='Pending'")
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
        Dim query As String = "SELECT IncidentType, COUNT(*) as Count FROM tbl_Incidents GROUP BY IncidentType"
        Dim dt As DataTable = Session.GetDataTable(query)

        ' Clear previous data
        chartIncidents.Series.Clear()
        chartIncidents.Titles.Clear()

        ' Create Series
        Dim series As New Series("Incidents")
        series.ChartType = SeriesChartType.Column ' Fixes "SeriesChartType" error
        series.Color = Color.FromArgb(41, 128, 185)

        For Each row As DataRow In dt.Rows
            series.Points.AddXY(row("IncidentType").ToString(), row("Count"))
        Next

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
            Session.CurrentUserID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub
End Class