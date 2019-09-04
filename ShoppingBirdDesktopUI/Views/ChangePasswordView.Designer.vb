<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChangePasswordView
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(12, 12)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.NullText = "Username"
        Me.TextEdit1.Size = New System.Drawing.Size(211, 20)
        Me.TextEdit1.TabIndex = 1
        '
        'TextEdit2
        '
        Me.TextEdit2.Location = New System.Drawing.Point(12, 38)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.NullText = "Password"
        Me.TextEdit2.Properties.UseSystemPasswordChar = True
        Me.TextEdit2.Size = New System.Drawing.Size(211, 20)
        Me.TextEdit2.TabIndex = 2
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(50, 96)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(123, 23)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "Change Password"
        '
        'TextEdit3
        '
        Me.TextEdit3.Location = New System.Drawing.Point(10, 70)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.NullText = "Password"
        Me.TextEdit3.Properties.UseSystemPasswordChar = True
        Me.TextEdit3.Size = New System.Drawing.Size(211, 20)
        Me.TextEdit3.TabIndex = 4
        '
        'ChangePasswordView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(230, 128)
        Me.Controls.Add(Me.TextEdit3)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.TextEdit2)
        Me.Controls.Add(Me.TextEdit1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangePasswordView"
        Me.Text = "Change Password"
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
End Class
