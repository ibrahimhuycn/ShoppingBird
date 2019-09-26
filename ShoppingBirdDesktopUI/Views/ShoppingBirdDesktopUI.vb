Imports AutoMapper
Imports DevExpress.Skins
Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.Models

Partial Public Class ShoppingBirdDesktopUI
    Private _mapper As Mapper
    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
    End Sub
    Public Sub New()
        InitializeComponent()
        SkinManager.EnableFormSkins()
        SkinManager.EnableMdiFormSkins()
        InitialiseAutoMapper()
    End Sub
    Private Sub InitialiseAutoMapper()
        Dim Config = New MapperConfiguration(Sub(cfg)
                                                 cfg.CreateMap(Of Models.Units, Unit)()
                                                 cfg.CreateMap(Of Models.ItemCategory, ItemCategory)()
                                                 cfg.CreateMap(Of Models.Store, Store)()
                                                 cfg.CreateMap(Of Models.Tax, Tax)()
                                                 cfg.CreateMap(Of Store, Models.Store)()
                                                 cfg.CreateMap(Of Tax, Models.Tax)()
                                                 cfg.CreateMap(Of ItemCategory, Models.ItemCategory)()
                                                 cfg.CreateMap(Of Unit, Models.Units)()
                                             End Sub)
        Config.AssertConfigurationIsValid()
        _mapper = CType(Config.CreateMapper(), Mapper)
    End Sub
    Private Sub BarButtonItemInvoice_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemInvoice.ItemClick
        Dim invoice As New InvoiceView With {.MdiParent = Me,
            .StartPosition = FormStartPosition.CenterParent
        }
        invoice.Show()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim settings As New Settings(New AddItemViewModel(New CategoriesIO,
                                         _mapper,
                                         New UnitsIO,
                                         New StoreIO,
                                         New TaxIO,
                                         New ItemIO),
                            _mapper,
                            New ItemInsertUserSelectedStaticData) With {.MdiParent = Me,
            .StartPosition = FormStartPosition.CenterParent}
        settings.Show()

        '  Dim a As IItemInsertUserSelectedStaticData = New ItemInsertUserSelectedStaticData()
    End Sub
End Class
