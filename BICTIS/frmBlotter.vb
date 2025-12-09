Imports System.Collections.Generic

Public Class frmBlotter
    Private Sub frmBlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDropdowns()
        LoadIncidents()
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadDropdowns()
        ' 1. SETUP RESPONDENTS (The Residents being accused)
        ' We load ONLY 'User' roles from the database
        Dim dt As DataTable = Session.GetDataTable("SELECT UserID, FullName FROM tbl_Users WHERE Role='User'")
        cbRespondent.DataSource = dt
        cbRespondent.DisplayMember = "FullName"
        cbRespondent.ValueMember = "UserID"

        ' 2. SETUP COMPLAINANTS (The Departments filing the case)
        ' Instead of loading people, we load LGU Departments/Units
        cbComplainant.DataSource = Nothing
        cbComplainant.Items.Clear()
        cbComplainant.Items.Add("Peace and Order Committee")
        cbComplainant.Items.Add("Lupon Tagapamayapa")
        cbComplainant.Items.Add("Barangay Health Office")
        cbComplainant.Items.Add("Violence Against Women (VAWC) Desk")
        cbComplainant.Items.Add("Barangay Tanod / Security")
        cbComplainant.Items.Add("Office of the Barangay Captain")
        cbComplainant.SelectedIndex = 0 ' Default selection
    End Sub

    Private Sub LoadIncidents()
        ' Display the list. Note: We use the Admin's name or Dept in display if needed.
        ' For simplicity, we just show the Incident Type and Respondent.
        Dim sql As String = "SELECT i.IncidentID, i.IncidentType, u2.FullName AS Respondent, i.Status, i.IncidentDate, i.Narrative " &
                            "FROM tbl_Incidents i " &
                            "LEFT JOIN tbl_Users u2 ON i.RespondentID = u2.UserID " &
                            "ORDER BY i.IncidentID DESC"
        dgvCases.DataSource = Session.GetDataTable(sql)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation
        If cbRespondent.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a Resident (Respondent).", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtType.Text = "" Then
            MessageBox.Show("Please enter the Type of Incident (e.g. Curfew, Noise).", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' FILE THE CASE
        ' Logic: 
        ' - ComplainantID = The Current Logged-in Admin (since they are encoding it)
        ' - Narrative = We prepend the Department Name so we know who filed it.

        Dim department As String = cbComplainant.Text
        Dim finalNarrative As String = "[Filed by: " & department & "] " & txtNarrative.Text

        Dim query As String = "INSERT INTO tbl_Incidents (ComplainantID, RespondentID, IncidentType, Narrative, Status, IncidentDate) " &
                              "VALUES (@comp, @resp, @type, @narr, @stat, @date)"

        Dim params As New Dictionary(Of String, Object)
        params.Add("@comp", Session.CurrentUserID) ' The Admin encoding this
        params.Add("@resp", cbRespondent.SelectedValue)
        params.Add("@type", txtType.Text)
        params.Add("@narr", finalNarrative)
        params.Add("@stat", cbStatus.Text)
        params.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Blotter Case Filed Successfully!" & vbCrLf &
                            "Respondent: " & cbRespondent.Text & vbCrLf &
                            "Department: " & department & vbCrLf &
                            "Status: " & cbStatus.Text,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh List and Clear Fields
            LoadIncidents()
            txtType.Clear()
            txtNarrative.Clear()
        End If
    End Sub

    Private Sub btnResolve_Click(sender As Object, e As EventArgs) Handles btnResolve.Click
        If dgvCases.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a case from the list to resolve.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim id As Integer = Convert.ToInt32(dgvCases.SelectedRows(0).Cells("IncidentID").Value)
        Dim respondentName As String = dgvCases.SelectedRows(0).Cells("Respondent").Value.ToString()

        If MessageBox.Show("Are you sure you want to mark this case as RESOLVED?" & vbCrLf & vbCrLf &
                           "This will remove the block on " & respondentName & " for clearances.",
                           "Confirm Resolution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Session.ExecuteQuery("UPDATE tbl_Incidents SET Status='Resolved' WHERE IncidentID=" & id)
            LoadIncidents()
            MessageBox.Show("Case Closed. The resident is now cleared.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class