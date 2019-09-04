<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddItem
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.ComboBoxEdit2 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.ComboBoxEdit4 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComboBoxEdit3 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComboBoxEdit5 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.ComboBoxEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(5, 49)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.NullText = "Select Store"
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(158, 20)
        Me.ComboBoxEdit1.TabIndex = 0
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(12, 11)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.NullText = "Item description"
        Me.TextEdit1.Size = New System.Drawing.Size(237, 20)
        Me.TextEdit1.TabIndex = 1
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.ComboBoxEdit2)
        Me.GroupControl1.Controls.Add(Me.TextEdit3)
        Me.GroupControl1.Controls.Add(Me.TextEdit2)
        Me.GroupControl1.Controls.Add(Me.ComboBoxEdit1)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 37)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(175, 132)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Item Retail Data"
        '
        'ComboBoxEdit2
        '
        Me.ComboBoxEdit2.Location = New System.Drawing.Point(5, 101)
        Me.ComboBoxEdit2.Name = "ComboBoxEdit2"
        Me.ComboBoxEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit2.Properties.NullText = "Select Tax"
        Me.ComboBoxEdit2.Size = New System.Drawing.Size(158, 20)
        Me.ComboBoxEdit2.TabIndex = 6
        '
        'TextEdit3
        '
        Me.TextEdit3.Location = New System.Drawing.Point(5, 75)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.NullText = "0.00"
        Me.TextEdit3.Size = New System.Drawing.Size(158, 20)
        Me.TextEdit3.TabIndex = 5
        '
        'TextEdit2
        '
        Me.TextEdit2.Location = New System.Drawing.Point(5, 23)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.NullText = "Barcode"
        Me.TextEdit2.Size = New System.Drawing.Size(158, 20)
        Me.TextEdit2.TabIndex = 4
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.ComboBoxEdit4)
        Me.GroupControl2.Controls.Add(Me.ComboBoxEdit3)
        Me.GroupControl2.Location = New System.Drawing.Point(193, 37)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(174, 79)
        Me.GroupControl2.TabIndex = 3
        Me.GroupControl2.Text = "Item Categories"
        '
        'ComboBoxEdit4
        '
        Me.ComboBoxEdit4.Location = New System.Drawing.Point(5, 49)
        Me.ComboBoxEdit4.Name = "ComboBoxEdit4"
        Me.ComboBoxEdit4.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit4.Properties.NullText = "Select Sub Category"
        Me.ComboBoxEdit4.Size = New System.Drawing.Size(158, 20)
        Me.ComboBoxEdit4.TabIndex = 8
        '
        'ComboBoxEdit3
        '
        Me.ComboBoxEdit3.Location = New System.Drawing.Point(5, 23)
        Me.ComboBoxEdit3.Name = "ComboBoxEdit3"
        Me.ComboBoxEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit3.Properties.NullText = "Select Category"
        Me.ComboBoxEdit3.Size = New System.Drawing.Size(158, 20)
        Me.ComboBoxEdit3.TabIndex = 7
        '
        'ComboBoxEdit5
        '
        Me.ComboBoxEdit5.Location = New System.Drawing.Point(253, 122)
        Me.ComboBoxEdit5.Name = "ComboBoxEdit5"
        Me.ComboBoxEdit5.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit5.Properties.NullText = "Unit"
        Me.ComboBoxEdit5.Size = New System.Drawing.Size(114, 20)
        Me.ComboBoxEdit5.TabIndex = 9
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(284, 146)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(83, 23)
        Me.SimpleButton1.TabIndex = 10
        Me.SimpleButton1.Text = "Save"
        '
        'AddItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 178)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.ComboBoxEdit5)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.TextEdit1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddItem"
        Me.Text = "Add Item"
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.ComboBoxEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ComboBoxEdit2 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ComboBoxEdit4 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ComboBoxEdit3 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ComboBoxEdit5 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
