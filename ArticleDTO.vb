Public Class ArticleDTO
    Private CodArt, DescArt, PrcVenta, PrcCompra, TipIva As String
    Public State As String
    Public Sub New(CodArt As String, DescArt As String, PrcVenta As String, PrcCompra As String, TipIva As String)
        Me.CodArt = CodArt
        Me.DescArt = DescArt
        Me.PrcVenta = PrcVenta
        Me.PrcCompra = PrcCompra
        Me.TipIva = TipIva
        State = "Waiting"
    End Sub

End Class
