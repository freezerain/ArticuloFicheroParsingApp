Imports ClosedXML.Excel
''-This class is responsable for parsing raw EXCEL file to List of Strings
'' As well as validating file formating
''-ClosedXML 3-d party library is used to be independent from MS Office installation 
Public Class ExcelParser
    Public CodArtCol, DescArtCol, PrcVentaCol, PrcCompraCol, TipIvaCol As List(Of String)
    Public Sub New(FilePath As String)
        ValidateFile(FilePath)
    End Sub
    Private Sub ValidateFile(FilePath As String)
        Dim wb = New XLWorkbook(FilePath)
        Dim ws = wb.Worksheets.First
        Dim cols = ws.Columns().ToList()
        For i As Integer = 0 To cols.Count - 1
            Dim ColHeader = cols(i).FirstCell.Value.ToString
            Select Case ColHeader
                Case "CODART"
                    CodArtCol = cols(i).Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
                Case "DESCART"
                    DescArtCol = cols(i).Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
                Case "PRCVENTA"
                    PrcVentaCol = cols(i).Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
                    ''In case of Optional values column parsed as whole to get empty cells
                    ''This leading to very huge array, possible optimization needed
                Case "PRCCOMPRA"
                    PrcCompraCol = cols(i).AsRange.Cells().Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
                Case "TIPIVA"
                    TipIvaCol = cols(i).AsRange.Cells.Select(Of String)(Function(c) c.Value.ToString).Skip(1).ToList
            End Select
        Next
        ''As for previous comment
        ''Huge array should be trimmed to size of main column (CodArtColumn)
        PrcCompraCol = PrcCompraCol.Take(CodArtCol.Count).ToList
        TipIvaCol = TipIvaCol.Take(CodArtCol.Count).ToList
        ''Validating column existence 
        If CodArtCol Is Nothing Or
            DescArtCol Is Nothing Or
            PrcVentaCol Is Nothing Or
            PrcCompraCol Is Nothing Or
            TipIvaCol Is Nothing Then
            Throw New ArgumentException("Cant find column")
        End If
        ''Validating column size
        If CodArtCol.Count <> TipIvaCol.Count Or
        DescArtCol.Count <> TipIvaCol.Count Or
        PrcVentaCol.Count <> TipIvaCol.Count Or
        PrcCompraCol.Count <> TipIvaCol.Count Then
            Throw New ArgumentException("Column sizes are different")
        End If
    End Sub

End Class
