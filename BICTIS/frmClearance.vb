Imports System.Collections.Generic

Public Class frmRequestClearance
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' 1. SECURITY CHECK: Do they have a pending case?
        ' Assuming UserID matches RespondentID for simplicity in this demo
        Dim blocked As Boolean = Session.GetCount("SELECT COUNT(*) FROM tbl_Incidents WHERE RespondentID=" & Session.CurrentUserID & " AND Status='Pending'") > 0

        If blocked Then
            MessageBox.Show("BLOCKED: You have a pending case.", "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' 2. Submit
        MessageBox.Show("Clearance Request Submitted to Admin.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
End Class