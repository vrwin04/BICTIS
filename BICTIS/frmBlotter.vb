Imports System.Collections.Generic

Public Class frmBlotter
    Private Sub frmBlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        LoadUsers()
    End Sub

    Private Sub LoadData()
        ' Displays readable names instead of IDs
        Dim sql As String = "SELECT i.IncidentID, u1.FullName as Complainant, u2.FullName as Respondent, i.IncidentType, i.Status " &
                            "FROM (tbl_Incidents i " &
                            "LEFT JOIN tbl_Users u1 ON i.ComplainantID = u1.UserID) " &
                            "LEFT JOIN tbl_Users u2 ON i.RespondentID = u2.UserID"
        dgvCases.DataSource = Session.GetDataTable(sql)
    End Sub

    Private Sub LoadUsers()
        ' Populate ComboBoxes for selecting people
        Dim dt As DataTable = Session.GetDataTable("SELECT UserID, FullName FROM tbl_Users WHERE Role='User'")

        cbComplainant.DataSource = dt.Copy()
        cbComplainant.DisplayMember = "FullName"
        cbComplainant.ValueMember = "UserID"

        cbRespondent.DataSource = dt.Copy()
        cbRespondent.DisplayMember = "FullName"
        cbRespondent.ValueMember = "UserID"
    End Sub

    Private Sub btnFileCase_Click(sender As Object, e As EventArgs) Handles btnFileCase.Click
        ' Validation
        If cbComplainant.SelectedValue = cbRespondent.SelectedValue Then
            MessageBox.Show("Complainant and Respondent cannot be the same person.", "Error")
            Exit Sub
        End If

        ' File the Case
        Dim query As String = "INSERT INTO tbl_Incidents (ComplainantID, RespondentID, IncidentType, Narrative, Status, IncidentDate) " &
                              "VALUES (@comp, @resp, @type, @narr, 'Pending', @date)"

        Dim params As New Dictionary(Of String, Object)
        params.Add("@comp", cbComplainant.SelectedValue)
        params.Add("@resp", cbRespondent.SelectedValue)
        params.Add("@type", txtType.Text) ' e.g. "Noise"
        params.Add("@narr", txtNarrative.Text)
        params.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Case Filed! The Respondent is now BLOCKED from clearances.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LoadData()
        End If
    End Sub

    Private Sub btnResolve_Click(sender As Object, e As EventArgs) Handles btnResolve.Click
        ' Mark selected case as Resolved
        If dgvCases.SelectedRows.Count = 0 Then Exit Sub

        Dim caseID As Integer = Convert.ToInt32(dgvCases.SelectedRows(0).Cells(0).Value)
        Dim query As String = "UPDATE tbl_Incidents SET Status='Resolved' WHERE IncidentID=" & caseID

        Session.ExecuteQuery(query)
        LoadData()
        MessageBox.Show("Case Resolved. Clearance block lifted.", "Updated")
    End Sub
End Class