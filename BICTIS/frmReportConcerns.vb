Imports System.Collections.Generic

Public Class frmReportConcern
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtType.Text = "" Or txtNarrative.Text = "" Then
            MessageBox.Show("Please fill details.", "Warning")
            Exit Sub
        End If

        ' User is Complainant. Respondent is NULL (Unknown/General) for now.
        Dim query As String = "INSERT INTO tblIncidents (ComplainantID, RespondentID, IncidentType, Narrative, Status, IncidentDate) VALUES (@uid, 0, @type, @narr, 'Pending', @date)"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@uid", Session.CurrentResidentID)
        params.Add("@type", txtType.Text)
        params.Add("@narr", txtNarrative.Text)
        params.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Report Submitted to Barangay.", "Success")
            Me.Close()
        End If
    End Sub
End Class