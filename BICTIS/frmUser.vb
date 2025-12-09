Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
    End Sub

    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        ' 1. SECURITY CHECK: Does this user have a pending case?
        Dim checkSql As String = "SELECT COUNT(*) FROM tbl_Incidents WHERE RespondentID = @uid AND Status = 'Pending'"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@uid", Session.CurrentUserID)

        Dim activeCases As Integer = Session.GetCount(checkSql, params)

        If activeCases > 0 Then
            ' 2. BLOCK THE REQUEST
            MessageBox.Show("ACCESS DENIED." & vbCrLf & vbCrLf &
                            "You have " & activeCases & " pending administrative case(s)." & vbCrLf &
                            "Please report to the Barangay Hall to resolve this.",
                            "Clearance Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        ' 3. ALLOW REQUEST (If no cases)
        ' Ideally, open a 'frmRequestDetails' form here.
        ' For now, we simulate the request submission.

        Dim insertSql As String = "INSERT INTO tbl_Clearances (ResidentID, Purpose, DateIssued, Status) VALUES (@uid, 'General Purpose', @date, 'Requested')"
        Dim insertParams As New Dictionary(Of String, Object)
        insertParams.Add("@uid", Session.CurrentUserID)
        insertParams.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(insertSql, insertParams) Then
            MessageBox.Show("Clearance Request Submitted Successfully!" & vbCrLf & "Please wait for Admin approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        ' Show their past clearances
        Dim sql As String = "SELECT DateIssued, Purpose, Status FROM tbl_Clearances WHERE ResidentID = " & Session.CurrentUserID
        Dim dt As DataTable = Session.GetDataTable(sql)

        ' Ideally show this in a Grid, but for now we summarize
        If dt.Rows.Count > 0 Then
            MessageBox.Show("You have " & dt.Rows.Count & " past requests.", "History", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No history found.", "History", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.CurrentUserID = 0
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub
End Class