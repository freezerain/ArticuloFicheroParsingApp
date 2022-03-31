Imports ClosedXML.Excel
Public Class ExcelParser
    Private CodArtCol, DescArtCol, PrcVentaCol, PrcCompraCol, TipIvaCol As List(Of String)
    Public Sub New(FilePath As String)
        ValidateFile(FilePath)
    End Sub

    Private Sub ValidateFile(FilePath As String)
        Dim wb = New XLWorkbook(FilePath)
        Dim ws = wb.Worksheets.First
        Dim cols = ws.Columns().ToList()
        Threading.Thread.Sleep(3000)
        For i As Integer = 0 To cols.Count - 1
            Dim ColHeader = cols(i).FirstCell.Value.ToString
            Select Case ColHeader
                Case "CODART"
                    CodArtCol = cols(i).Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
                Case "DESCART"
                    DescArtCol = cols(i).Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
                Case "PRCVENTA"
                    PrcVentaCol = cols(i).Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
                Case "PRCCOMPRA"
                    PrcCompraCol = cols(i).Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
                Case "TIPIVA"
                    TipIvaCol = cols(i).Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
            End Select
        Next
        If CodArtCol Is Nothing Or
            DescArtCol Is Nothing Or
            PrcVentaCol Is Nothing Or
            PrcCompraCol Is Nothing Or
            TipIvaCol Is Nothing Then
            Throw New ArgumentException("Cant find column")
        End If
        If CodArtCol.Count <> TipIvaCol.Count Or
        DescArtCol.Count <> TipIvaCol.Count Or
        PrcVentaCol.Count <> TipIvaCol.Count Or
        PrcCompraCol.Count <> TipIvaCol.Count Then
            Throw New ArgumentException("Column sizes are different")
        End If
    End Sub

    Public Function GetArticleDTO() As ArticleDTO()
        Dim ArticleArr = New ArticleDTO(CodArtCol.Count) {}
        For i As Integer = 0 To CodArtCol.Count
            ArticleArr(i) = New ArticleDTO(CodArtCol(i), DescArtCol(i), PrcVentaCol(i), PrcCompraCol(i), TipIvaCol(i))
        Next
        Return ArticleArr
    End Function
End Class
