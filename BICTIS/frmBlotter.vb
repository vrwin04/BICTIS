Imports System.Collections.Generic

Public Class frmBlotter
    Private Sub frmBlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadIncidents()
    End Sub

    Private Sub LoadIncidents()
        ' In a real app, join with tbl_Users to get Names instead of IDs
        dgvIncidents.DataSource = Session.GetDataTable("SELECT * FROM tbl_Incidents")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Add Case Logic
        Dim query As String = "INSERT INTO tbl_Incidents (IncidentType, Status, IncidentDate) VALUES (@type, 'Pending', @date)"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@type", txtType.Text)
        params.Add("@date", DateTime.Now.ToString())

        Session.ExecuteQuery(query, params)
        LoadIncidents()
    End Sub
End Class