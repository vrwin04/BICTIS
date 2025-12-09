<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class adminDashboard
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnBlotter = New System.Windows.Forms.Button()
        Me.pnlLogo = New System.Windows.Forms.Panel()
        Me.lblLogo = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblPageTitle = New System.Windows.Forms.Label()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.chartIncidents = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlCard2 = New System.Windows.Forms.Panel()
        Me.lblPendingCases = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlCard1 = New System.Windows.Forms.Panel()
        Me.lblTotalUsers = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlLogo.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContainer.SuspendLayout()
        CType(Me.chartIncidents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCard2.SuspendLayout()
        Me.pnlCard1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.btnBlotter)
        Me.pnlSidebar.Controls.Add(Me.pnlLogo)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(220, 600)
        Me.pnlSidebar.TabIndex = 0
        '
        'btnLogout
        '
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnLogout.ForeColor = System.Drawing.Color.IndianRed
        Me.btnLogout.Location = New System.Drawing.Point(0, 550)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(220, 50)
        Me.btnLogout.TabIndex = 5
        Me.btnLogout.Text = "Sign Out"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnBlotter
        '
        Me.btnBlotter.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnBlotter.FlatAppearance.BorderSize = 0
        Me.btnBlotter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBlotter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnBlotter.ForeColor = System.Drawing.Color.LightGray
        Me.btnBlotter.Location = New System.Drawing.Point(0, 80)
        Me.btnBlotter.Name = "btnBlotter"
        Me.btnBlotter.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.btnBlotter.Size = New System.Drawing.Size(220, 50)
        Me.btnBlotter.TabIndex = 2
        Me.btnBlotter.Text = "Manage Blotter"
        Me.btnBlotter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBlotter.UseVisualStyleBackColor = True
        '
        'pnlLogo
        '
        Me.pnlLogo.BackColor = System.Drawing.Color.FromArgb(34, 49, 63)
        Me.pnlLogo.Controls.Add(Me.lblLogo)
        Me.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLogo.Location = New System.Drawing.Point(0, 0)
        Me.pnlLogo.Name = "pnlLogo"
        Me.pnlLogo.Size = New System.Drawing.Size(220, 80)
        Me.pnlLogo.TabIndex = 0
        '
        'lblLogo
        '
        Me.lblLogo.AutoSize = True
        Me.lblLogo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblLogo.ForeColor = System.Drawing.Color.White
        Me.lblLogo.Location = New System.Drawing.Point(60, 25)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Text = "ADMIN"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblPageTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(220, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(780, 80)
        Me.pnlHeader.TabIndex = 1
        '
        'lblPageTitle
        '
        Me.lblPageTitle.AutoSize = True
        Me.lblPageTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular)
        Me.lblPageTitle.Location = New System.Drawing.Point(20, 25)
        Me.lblPageTitle.Name = "lblPageTitle"
        Me.lblPageTitle.Size = New System.Drawing.Size(157, 25)
        Me.lblPageTitle.TabIndex = 0
        Me.lblPageTitle.Text = "Analytics Overview"
        '
        'pnlContainer
        '
        Me.pnlContainer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlContainer.Controls.Add(Me.chartIncidents)
        Me.pnlContainer.Controls.Add(Me.pnlCard2)
        Me.pnlContainer.Controls.Add(Me.pnlCard1)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(220, 80)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(780, 520)
        Me.pnlContainer.TabIndex = 2
        '
        'chartIncidents
        '
        ChartArea1.Name = "ChartArea1"
        Me.chartIncidents.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chartIncidents.Legends.Add(Legend1)
        Me.chartIncidents.Location = New System.Drawing.Point(30, 180)
        Me.chartIncidents.Name = "chartIncidents"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chartIncidents.Series.Add(Series1)
        Me.chartIncidents.Size = New System.Drawing.Size(700, 300)
        Me.chartIncidents.TabIndex = 2
        Me.chartIncidents.Text = "Chart1"
        '
        'pnlCard2
        '
        Me.pnlCard2.BackColor = System.Drawing.Color.White
        Me.pnlCard2.Controls.Add(Me.lblPendingCases)
        Me.pnlCard2.Controls.Add(Me.Label3)
        Me.pnlCard2.Location = New System.Drawing.Point(280, 30)
        Me.pnlCard2.Name = "pnlCard2"
        Me.pnlCard2.Size = New System.Drawing.Size(220, 120)
        Me.pnlCard2.TabIndex = 1
        '
        'lblPendingCases
        '
        Me.lblPendingCases.AutoSize = True
        Me.lblPendingCases.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblPendingCases.ForeColor = System.Drawing.Color.Crimson
        Me.lblPendingCases.Location = New System.Drawing.Point(15, 45)
        Me.lblPendingCases.Name = "lblPendingCases"
        Me.lblPendingCases.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(15, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Text = "PENDING CASES"
        '
        'pnlCard1
        '
        Me.pnlCard1.BackColor = System.Drawing.Color.White
        Me.pnlCard1.Controls.Add(Me.lblTotalUsers)
        Me.pnlCard1.Controls.Add(Me.Label1)
        Me.pnlCard1.Location = New System.Drawing.Point(30, 30)
        Me.pnlCard1.Name = "pnlCard1"
        Me.pnlCard1.Size = New System.Drawing.Size(220, 120)
        Me.pnlCard1.TabIndex = 0
        '
        'lblTotalUsers
        '
        Me.lblTotalUsers.AutoSize = True
        Me.lblTotalUsers.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalUsers.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.lblTotalUsers.Location = New System.Drawing.Point(15, 45)
        Me.lblTotalUsers.Name = "lblTotalUsers"
        Me.lblTotalUsers.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Text = "TOTAL RESIDENTS"
        '
        'adminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlSidebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Name = "adminDashboard"
        Me.Text = "Admin Dashboard"
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlLogo.ResumeLayout(False)
        Me.pnlLogo.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContainer.ResumeLayout(False)
        CType(Me.chartIncidents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCard2.ResumeLayout(False)
        Me.pnlCard2.PerformLayout()
        Me.pnlCard1.ResumeLayout(False)
        Me.pnlCard1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlLogo As Panel
    Friend WithEvents lblLogo As Label
    Friend WithEvents btnBlotter As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblPageTitle As Label
    Friend WithEvents pnlContainer As Panel
    Friend WithEvents pnlCard1 As Panel
    Friend WithEvents lblTotalUsers As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlCard2 As Panel
    Friend WithEvents lblPendingCases As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents chartIncidents As System.Windows.Forms.DataVisualization.Charting.Chart
End Class