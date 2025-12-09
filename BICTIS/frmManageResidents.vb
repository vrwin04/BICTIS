Public Class frmManageResidents
    Private Sub frmManageResidents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadResidents("")
    End Sub

    Private Sub LoadResidents(search As String)
        ' Filters to show only Users (Residents), not Admins
        Dim query As String = "SELECT UserID, Username, FullName, Role FROM tbl_Users WHERE Role='User'"

        If search <> "" Then
            query &= " AND (FullName LIKE '%" & search & "%' OR Username LIKE '%" & search & "%')"
        End If

        dgvResidents.DataSource = Session.GetDataTable(query)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadResidents(txtSearch.Text)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvResidents.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim uid As Integer = Convert.ToInt32(dgvResidents.SelectedRows(0).Cells("UserID").Value)
        Dim name As String = dgvResidents.SelectedRows(0).Cells("FullName").Value.ToString()

        If MessageBox.Show("Delete " & name & "? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = DialogResult.Yes Then
            Session.ExecuteQuery("DELETE FROM tbl_Users WHERE UserID=" & uid)
            MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadResidents(txtSearch.Text)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class