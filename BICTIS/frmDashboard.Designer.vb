<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.btnResidents = New System.Windows.Forms.Button()
        Me.btnBlotter = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblPageTitle = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.PanelKPI1 = New System.Windows.Forms.Panel()
        Me.lblTotalRes = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelKPI2 = New System.Windows.Forms.Panel()
        Me.lblPendingCases = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.btnBlotter)
        Me.pnlSidebar.Controls.Add(Me.btnResidents)
        Me.pnlSidebar.Controls.Add(Me.lblBrand)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(200, 500)
        Me.pnlSidebar.TabIndex = 0
        '
        'lblBrand
        '
        Me.lblBrand.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBrand.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblBrand.ForeColor = System.Drawing.Color.White
        Me.lblBrand.Location = New System.Drawing.Point(0, 0)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(200, 60)
        Me.lblBrand.TabIndex = 0
        Me.lblBrand.Text = "TARTARIA BICTIS"
        Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnResidents
        '
        Me.btnResidents.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnResidents.FlatAppearance.BorderSize = 0
        Me.btnResidents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResidents.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnResidents.ForeColor = System.Drawing.Color.LightGray
        Me.btnResidents.Location = New System.Drawing.Point(0, 60)
        Me.btnResidents.Name = "btnResidents"
        Me.btnResidents.Size = New System.Drawing.Size(200, 50)
        Me.btnResidents.TabIndex = 1
        Me.btnResidents.Text = "Resident Profiling"
        Me.btnResidents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResidents.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.btnResidents.UseVisualStyleBackColor = True
        '
        'btnBlotter
        '
        Me.btnBlotter.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnBlotter.FlatAppearance.BorderSize = 0
        Me.btnBlotter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBlotter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnBlotter.ForeColor = System.Drawing.Color.LightGray
        Me.btnBlotter.Location = New System.Drawing.Point(0, 110)
        Me.btnBlotter.Name = "btnBlotter"
        Me.btnBlotter.Size = New System.Drawing.Size(200, 50)
        Me.btnBlotter.TabIndex = 2
        Me.btnBlotter.Text = "Blotter / Incidents"
        Me.btnBlotter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBlotter.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.btnBlotter.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnLogout.ForeColor = System.Drawing.Color.Salmon
        Me.btnLogout.Location = New System.Drawing.Point(0, 450)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(200, 50)
        Me.btnLogout.TabIndex = 5
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblPageTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(200, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(600, 60)
        Me.pnlHeader.TabIndex = 1
        '
        'lblPageTitle
        '
        Me.lblPageTitle.AutoSize = True
        Me.lblPageTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular)
        Me.lblPageTitle.Location = New System.Drawing.Point(20, 18)
        Me.lblPageTitle.Name = "lblPageTitle"
        Me.lblPageTitle.Size = New System.Drawing.Size(190, 25)
        Me.lblPageTitle.TabIndex = 0
        Me.lblPageTitle.Text = "Dashboard Overview"
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlContent.Controls.Add(Me.PanelKPI2)
        Me.pnlContent.Controls.Add(Me.PanelKPI1)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(200, 60)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(600, 440)
        Me.pnlContent.TabIndex = 2
        '
        'PanelKPI1
        '
        Me.PanelKPI1.BackColor = System.Drawing.Color.White
        Me.PanelKPI1.Controls.Add(Me.lblTotalRes)
        Me.PanelKPI1.Controls.Add(Me.Label1)
        Me.PanelKPI1.Location = New System.Drawing.Point(25, 25)
        Me.PanelKPI1.Name = "PanelKPI1"
        Me.PanelKPI1.Size = New System.Drawing.Size(200, 100)
        Me.PanelKPI1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Text = "TOTAL RESIDENTS"
        '
        'lblTotalRes
        '
        Me.lblTotalRes.AutoSize = True
        Me.lblTotalRes.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalRes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTotalRes.Location = New System.Drawing.Point(10, 35)
        Me.lblTotalRes.Name = "lblTotalRes"
        Me.lblTotalRes.Text = "0"
        '
        'PanelKPI2
        '
        Me.PanelKPI2.BackColor = System.Drawing.Color.White
        Me.PanelKPI2.Controls.Add(Me.lblPendingCases)
        Me.PanelKPI2.Controls.Add(Me.Label2)
        Me.PanelKPI2.Location = New System.Drawing.Point(245, 25)
        Me.PanelKPI2.Name = "PanelKPI2"
        Me.PanelKPI2.Size = New System.Drawing.Size(200, 100)
        Me.PanelKPI2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(10, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Text = "PENDING CASES"
        '
        'lblPendingCases
        '
        Me.lblPendingCases.AutoSize = True
        Me.lblPendingCases.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblPendingCases.ForeColor = System.Drawing.Color.Crimson
        Me.lblPendingCases.Location = New System.Drawing.Point(10, 35)
        Me.lblPendingCases.Name = "lblPendingCases"
        Me.lblPendingCases.Text = "0"
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 500)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barangay System Dashboard"
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.PanelKPI1.ResumeLayout(False)
        Me.PanelKPI1.PerformLayout()
        Me.PanelKPI2.ResumeLayout(False)
        Me.PanelKPI2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnResidents As Button
    Friend WithEvents btnBlotter As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblBrand As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblPageTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents PanelKPI1 As Panel
    Friend WithEvents lblTotalRes As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelKPI2 As Panel
    Friend WithEvents lblPendingCases As Label
    Friend WithEvents Label2 As Label
End Class