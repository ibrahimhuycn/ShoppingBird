Public Class Settings
    Private _addItem As AddItemViewModel
    Public Sub New(addItem As AddItemViewModel)
        InitializeComponent()
        _addItem = addItem
    End Sub
End Class