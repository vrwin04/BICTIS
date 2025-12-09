<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegistration
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
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.lblLoginLink = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConfirmPass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlLeft.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLeft (The Blue Side)
        '
        Me.pnlLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.pnlLeft.Controls.Add(Me.lblWelcome)
        Me.pnlLeft.Controls.Add(Me.lblBrand)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(300, 550)
        Me.pnlLeft.TabIndex = 0
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblBrand.ForeColor = System.Drawing.Color.White
        Me.lblBrand.Location = New System.Drawing.Point(40, 150)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(120, 45)
        Me.lblBrand.TabIndex = 0
        Me.lblBrand.Text = "BICTIS"
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblWelcome.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblWelcome.Location = New System.Drawing.Point(45, 200)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(200, 42)
        Me.lblWelcome.TabIndex = 1
        Me.lblWelcome.Text = "Join the community service" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "portal today."
        '
        'pnlRight (The Form Side)
        '
        Me.pnlRight.BackColor = System.Drawing.Color.White
        Me.pnlRight.Controls.Add(Me.btnClose)
        Me.pnlRight.Controls.Add(Me.lblLoginLink)
        Me.pnlRight.Controls.Add(Me.Label5)
        Me.pnlRight.Controls.Add(Me.btnRegister)
        Me.pnlRight.Controls.Add(Me.txtFullName)
        Me.pnlRight.Controls.Add(Me.Label4)
        Me.pnlRight.Controls.Add(Me.txtConfirmPass)
        Me.pnlRight.Controls.Add(Me.Label3)
        Me.pnlRight.Controls.Add(Me.txtPassword)
        Me.pnlRight.Controls.Add(Me.Label2)
        Me.pnlRight.Controls.Add(Me.txtUsername)
        Me.pnlRight.Controls.Add(Me.Label1)
        Me.pnlRight.Controls.Add(Me.lblTitle)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(300, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(450, 550)
        Me.pnlRight.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.Gray
        Me.btnClose.Location = New System.Drawing.Point(410, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(40, 40)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(236, 37)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Create Account"
        '
        'Label1 (Username Label)
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(45, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Text = "Username"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtUsername.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Location = New System.Drawing.Point(49, 125)
        Me.txtUsername.Multiline = True
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(350, 30)
        Me.txtUsername.TabIndex = 1
        '
        'Label2 (Password Label)
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(45, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Location = New System.Drawing.Point(49, 195)
        Me.txtPassword.Multiline = True
        Me.txtPassword.PasswordChar = "*"
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(350, 30)
        Me.txtPassword.TabIndex = 2
        '
        'Label3 (Confirm Pass)
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(45, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Text = "Confirm Password"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtConfirmPass.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConfirmPass.Location = New System.Drawing.Point(49, 265)
        Me.txtConfirmPass.Multiline = True
        Me.txtConfirmPass.PasswordChar = "*"
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.Size = New System.Drawing.Size(350, 30)
        Me.txtConfirmPass.TabIndex = 3
        '
        'Label4 (Full Name)
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(45, 310)
        Me.Label4.Name = "Label4"
        Me.Label4.Text = "Full Name"
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtFullName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFullName.Location = New System.Drawing.Point(49, 335)
        Me.txtFullName.Multiline = True
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(350, 30)
        Me.txtFullName.TabIndex = 4
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRegister.ForeColor = System.Drawing.Color.White
        Me.btnRegister.Location = New System.Drawing.Point(49, 400)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(350, 45)
        Me.btnRegister.TabIndex = 5
        Me.btnRegister.Text = "CREATE ACCOUNT"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(90, 470)
        Me.Label5.Name = "Label5"
        Me.Label5.Text = "Already have an account?"
        '
        'lblLoginLink
        '
        Me.lblLoginLink.AutoSize = True
        Me.lblLoginLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLoginLink.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLoginLink.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblLoginLink.Location = New System.Drawing.Point(235, 470)
        Me.lblLoginLink.Name = "lblLoginLink"
        Me.lblLoginLink.Text = "Login Here"
        '
        'frmRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(750, 550)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.pnlLeft)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRegistration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registration"
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeft.PerformLayout()
        Me.pnlRight.ResumeLayout(False)
        Me.pnlRight.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents pnlRight As Panel
    Friend WithEvents lblBrand As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtConfirmPass As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblLoginLink As Label
    Friend WithEvents btnClose As Button
End Class