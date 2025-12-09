Imports System.Collections.Generic

Public Class frmBlotter
    Private Sub frmBlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        LoadIncidents()
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadUsers()
        ' Get list of residents (Role = User)
        Dim dt As DataTable = Session.GetDataTable("SELECT UserID, FullName FROM tbl_Users WHERE Role='User'")

        cbComplainant.DataSource = dt.Copy()
        cbComplainant.DisplayMember = "FullName"
        cbComplainant.ValueMember = "UserID"

        cbRespondent.DataSource = dt.Copy()
        cbRespondent.DisplayMember = "FullName"
        cbRespondent.ValueMember = "UserID"
    End Sub

    Private Sub LoadIncidents()
        ' Join tables to show Names instead of ID numbers
        Dim sql As String = "SELECT i.IncidentID, i.IncidentType, u1.FullName AS Complainant, u2.FullName AS Respondent, i.Status, i.IncidentDate " &
                            "FROM (tbl_Incidents i " &
                            "LEFT JOIN tbl_Users u1 ON i.ComplainantID = u1.UserID) " &
                            "LEFT JOIN tbl_Users u2 ON i.RespondentID = u2.UserID ORDER BY i.IncidentID DESC"
        dgvCases.DataSource = Session.GetDataTable(sql)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbComplainant.SelectedValue Is Nothing Or cbRespondent.SelectedValue Is Nothing Then
            MessageBox.Show("Please select both parties.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cbComplainant.SelectedValue.ToString() = cbRespondent.SelectedValue.ToString() Then
            MessageBox.Show("Complainant cannot be the Respondent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "INSERT INTO tbl_Incidents (ComplainantID, RespondentID, IncidentType, Narrative, Status, IncidentDate) " &
                              "VALUES (@comp, @resp, @type, @narr, @stat, @date)"

        Dim params As New Dictionary(Of String, Object)
        params.Add("@comp", cbComplainant.SelectedValue)
        params.Add("@resp", cbRespondent.SelectedValue)
        params.Add("@type", txtType.Text)
        params.Add("@narr", txtNarrative.Text)
        params.Add("@stat", cbStatus.Text)
        params.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Incident Filed! Respondent is now blocked from clearances.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadIncidents()
            txtType.Clear()
            txtNarrative.Clear()
        End If
    End Sub

    Private Sub btnResolve_Click(sender As Object, e As EventArgs) Handles btnResolve.Click
        If dgvCases.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a case to resolve.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim id As Integer = Convert.ToInt32(dgvCases.SelectedRows(0).Cells("IncidentID").Value)

        If MessageBox.Show("Mark this case as RESOLVED? This will unblock the resident.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.ExecuteQuery("UPDATE tbl_Incidents SET Status='Resolved' WHERE IncidentID=" & id)
            LoadIncidents()
            MessageBox.Show("Case Closed.", "Success")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class