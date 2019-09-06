<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoiceView
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
        Me.TextEditInvoiceNumber = New DevExpress.XtraEditors.TextEdit()
        Me.ComboBoxEditSearch = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GroupControlInvoiceItems = New DevExpress.XtraEditors.GroupControl()
        Me.GridControlInvoiceItems = New DevExpress.XtraGrid.GridControl()
        Me.GridViewInvoiceItems = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateEditInvoiceDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControlTax = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControlSubTotal = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControlTotal = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControlUsername = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButtonSaveInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEditSubTotal = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditTax = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditTotal = New DevExpress.XtraEditors.TextEdit()
        Me.LookUpEditStore = New DevExpress.XtraEditors.LookUpEdit()
        Me.ToggleSwitchSearch = New DevExpress.XtraEditors.ToggleSwitch()
        CType(Me.TextEditInvoiceNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEditSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlInvoiceItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlInvoiceItems.SuspendLayout()
        CType(Me.GridControlInvoiceItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewInvoiceItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditInvoiceDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditInvoiceDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditSubTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToggleSwitchSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextEditInvoiceNumber
        '
        Me.TextEditInvoiceNumber.Location = New System.Drawing.Point(12, 12)
        Me.TextEditInvoiceNumber.Name = "TextEditInvoiceNumber"
        Me.TextEditInvoiceNumber.Properties.NullText = "Invoice Number"
        Me.TextEditInvoiceNumber.Size = New System.Drawing.Size(100, 20)
        Me.TextEditInvoiceNumber.TabIndex = 0
        '
        'ComboBoxEditSearch
        '
        Me.ComboBoxEditSearch.Location = New System.Drawing.Point(12, 38)
        Me.ComboBoxEditSearch.Name = "ComboBoxEditSearch"
        Me.ComboBoxEditSearch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEditSearch.Properties.NullText = "Scan product barcode / Search by product name"
        Me.ComboBoxEditSearch.Size = New System.Drawing.Size(360, 20)
        Me.ComboBoxEditSearch.TabIndex = 2
        '
        'GroupControlInvoiceItems
        '
        Me.GroupControlInvoiceItems.Controls.Add(Me.GridControlInvoiceItems)
        Me.GroupControlInvoiceItems.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControlInvoiceItems.Location = New System.Drawing.Point(12, 64)
        Me.GroupControlInvoiceItems.Name = "GroupControlInvoiceItems"
        Me.GroupControlInvoiceItems.Size = New System.Drawing.Size(518, 191)
        Me.GroupControlInvoiceItems.TabIndex = 5
        Me.GroupControlInvoiceItems.Text = "Invoice Items"
        '
        'GridControlInvoiceItems
        '
        Me.GridControlInvoiceItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlInvoiceItems.Location = New System.Drawing.Point(2, 20)
        Me.GridControlInvoiceItems.MainView = Me.GridViewInvoiceItems
        Me.GridControlInvoiceItems.Name = "GridControlInvoiceItems"
        Me.GridControlInvoiceItems.Size = New System.Drawing.Size(514, 169)
        Me.GridControlInvoiceItems.TabIndex = 0
        Me.GridControlInvoiceItems.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewInvoiceItems})
        '
        'GridViewInvoiceItems
        '
        Me.GridViewInvoiceItems.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnDescription, Me.GridColumnQuantity, Me.GridColumnUnit, Me.GridColumnPrice, Me.GridColumnTax, Me.GridColumnAmount})
        Me.GridViewInvoiceItems.GridControl = Me.GridControlInvoiceItems
        Me.GridViewInvoiceItems.Name = "GridViewInvoiceItems"
        Me.GridViewInvoiceItems.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.GridViewInvoiceItems.OptionsView.EnableAppearanceEvenRow = True
        Me.GridViewInvoiceItems.OptionsView.ShowGroupPanel = False
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.FieldName = "Description"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 0
        '
        'GridColumnQuantity
        '
        Me.GridColumnQuantity.Caption = "Quantity"
        Me.GridColumnQuantity.FieldName = "Quantity"
        Me.GridColumnQuantity.Name = "GridColumnQuantity"
        Me.GridColumnQuantity.Visible = True
        Me.GridColumnQuantity.VisibleIndex = 1
        '
        'GridColumnUnit
        '
        Me.GridColumnUnit.Caption = "Unit"
        Me.GridColumnUnit.FieldName = "Unit"
        Me.GridColumnUnit.Name = "GridColumnUnit"
        Me.GridColumnUnit.Visible = True
        Me.GridColumnUnit.VisibleIndex = 2
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.FieldName = "Price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 3
        '
        'GridColumnTax
        '
        Me.GridColumnTax.Caption = "Tax"
        Me.GridColumnTax.FieldName = "Tax"
        Me.GridColumnTax.Name = "GridColumnTax"
        Me.GridColumnTax.Visible = True
        Me.GridColumnTax.VisibleIndex = 4
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.FieldName = "Amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 5
        '
        'DateEditInvoiceDate
        '
        Me.DateEditInvoiceDate.EditValue = Nothing
        Me.DateEditInvoiceDate.Location = New System.Drawing.Point(12, 261)
        Me.DateEditInvoiceDate.Name = "DateEditInvoiceDate"
        Me.DateEditInvoiceDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditInvoiceDate.Properties.Mask.EditMask = "t"
        Me.DateEditInvoiceDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.DateEditInvoiceDate.Size = New System.Drawing.Size(100, 20)
        Me.DateEditInvoiceDate.TabIndex = 6
        '
        'LabelControlTax
        '
        Me.LabelControlTax.Location = New System.Drawing.Point(422, 288)
        Me.LabelControlTax.Name = "LabelControlTax"
        Me.LabelControlTax.Size = New System.Drawing.Size(17, 13)
        Me.LabelControlTax.TabIndex = 10
        Me.LabelControlTax.Text = "Tax"
        '
        'LabelControlSubTotal
        '
        Me.LabelControlSubTotal.Location = New System.Drawing.Point(390, 262)
        Me.LabelControlSubTotal.Name = "LabelControlSubTotal"
        Me.LabelControlSubTotal.Size = New System.Drawing.Size(49, 13)
        Me.LabelControlSubTotal.TabIndex = 11
        Me.LabelControlSubTotal.Text = "Sub Total"
        '
        'LabelControlTotal
        '
        Me.LabelControlTotal.Location = New System.Drawing.Point(413, 314)
        Me.LabelControlTotal.Name = "LabelControlTotal"
        Me.LabelControlTotal.Size = New System.Drawing.Size(26, 13)
        Me.LabelControlTotal.TabIndex = 12
        Me.LabelControlTotal.Text = "Total"
        '
        'LabelControlUsername
        '
        Me.LabelControlUsername.Location = New System.Drawing.Point(12, 314)
        Me.LabelControlUsername.Name = "LabelControlUsername"
        Me.LabelControlUsername.Size = New System.Drawing.Size(151, 13)
        Me.LabelControlUsername.TabIndex = 13
        Me.LabelControlUsername.Text = "Logged In Username (User Id)"
        '
        'SimpleButtonSaveInvoice
        '
        Me.SimpleButtonSaveInvoice.Location = New System.Drawing.Point(185, 309)
        Me.SimpleButtonSaveInvoice.Name = "SimpleButtonSaveInvoice"
        Me.SimpleButtonSaveInvoice.Size = New System.Drawing.Size(187, 23)
        Me.SimpleButtonSaveInvoice.TabIndex = 14
        Me.SimpleButtonSaveInvoice.Text = "Save Invoice"
        '
        'TextEditSubTotal
        '
        Me.TextEditSubTotal.Location = New System.Drawing.Point(447, 259)
        Me.TextEditSubTotal.Name = "TextEditSubTotal"
        Me.TextEditSubTotal.Properties.Mask.EditMask = "n"
        Me.TextEditSubTotal.Properties.NullText = "0.00"
        Me.TextEditSubTotal.Properties.ReadOnly = True
        Me.TextEditSubTotal.Size = New System.Drawing.Size(83, 20)
        Me.TextEditSubTotal.TabIndex = 15
        '
        'TextEditTax
        '
        Me.TextEditTax.Location = New System.Drawing.Point(447, 286)
        Me.TextEditTax.Name = "TextEditTax"
        Me.TextEditTax.Properties.Mask.EditMask = "n"
        Me.TextEditTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TextEditTax.Properties.NullText = "0.00"
        Me.TextEditTax.Properties.ReadOnly = True
        Me.TextEditTax.Size = New System.Drawing.Size(83, 20)
        Me.TextEditTax.TabIndex = 16
        '
        'TextEditTotal
        '
        Me.TextEditTotal.Location = New System.Drawing.Point(447, 312)
        Me.TextEditTotal.Name = "TextEditTotal"
        Me.TextEditTotal.Properties.Mask.EditMask = "n"
        Me.TextEditTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TextEditTotal.Properties.NullText = "0.00"
        Me.TextEditTotal.Size = New System.Drawing.Size(83, 20)
        Me.TextEditTotal.TabIndex = 18
        '
        'LookUpEditStore
        '
        Me.LookUpEditStore.Location = New System.Drawing.Point(118, 261)
        Me.LookUpEditStore.Name = "LookUpEditStore"
        Me.LookUpEditStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditStore.Properties.NullText = "Select Store"
        Me.LookUpEditStore.Size = New System.Drawing.Size(152, 20)
        Me.LookUpEditStore.TabIndex = 19
        '
        'ToggleSwitchSearch
        '
        Me.ToggleSwitchSearch.Location = New System.Drawing.Point(378, 35)
        Me.ToggleSwitchSearch.Name = "ToggleSwitchSearch"
        Me.ToggleSwitchSearch.Properties.OffText = "Description"
        Me.ToggleSwitchSearch.Properties.OnText = "Barcode"
        Me.ToggleSwitchSearch.Size = New System.Drawing.Size(146, 25)
        Me.ToggleSwitchSearch.TabIndex = 20
        '
        'InvoiceView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 338)
        Me.Controls.Add(Me.ToggleSwitchSearch)
        Me.Controls.Add(Me.LookUpEditStore)
        Me.Controls.Add(Me.TextEditTotal)
        Me.Controls.Add(Me.TextEditTax)
        Me.Controls.Add(Me.TextEditSubTotal)
        Me.Controls.Add(Me.SimpleButtonSaveInvoice)
        Me.Controls.Add(Me.LabelControlUsername)
        Me.Controls.Add(Me.LabelControlTotal)
        Me.Controls.Add(Me.LabelControlSubTotal)
        Me.Controls.Add(Me.LabelControlTax)
        Me.Controls.Add(Me.DateEditInvoiceDate)
        Me.Controls.Add(Me.GroupControlInvoiceItems)
        Me.Controls.Add(Me.ComboBoxEditSearch)
        Me.Controls.Add(Me.TextEditInvoiceNumber)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InvoiceView"
        Me.Text = "Invoice: #InvoiceNumber"
        CType(Me.TextEditInvoiceNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEditSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlInvoiceItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlInvoiceItems.ResumeLayout(False)
        CType(Me.GridControlInvoiceItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewInvoiceItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditInvoiceDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditInvoiceDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditSubTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToggleSwitchSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextEditInvoiceNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ComboBoxEditSearch As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents GroupControlInvoiceItems As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControlInvoiceItems As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewInvoiceItems As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DateEditInvoiceDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControlTax As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControlSubTotal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControlTotal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControlUsername As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButtonSaveInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextEditSubTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditTax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LookUpEditStore As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ToggleSwitchSearch As DevExpress.XtraEditors.ToggleSwitch
End Class
