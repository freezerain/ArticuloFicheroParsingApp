Public Class ParsingWorker
    Private Form As Form1
    Public WithEvents WorkerInstance As New System.ComponentModel.BackgroundWorker
    Public Sub New(Form As Form1)
        Me.Form = Form
        WorkerInstance.WorkerSupportsCancellation = True
        WorkerInstance.WorkerReportsProgress = True
    End Sub

    Private Sub DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WorkerInstance.DoWork
        Dim LocalWorker As System.ComponentModel.BackgroundWorker = sender
        Dim args As ParsingArguments = e.Argument
        Dim Parser As ExcelParser = args.Parser
        Dim ArticleArr = New ArticleDTO(Parser.CodArtCol.Count - 1) {}
        For i As Integer = 0 To Parser.CodArtCol.Count - 1
            If LocalWorker.CancellationPending Then
                e.Cancel = True
                Return
            End If
            Dim nextArticle As ArticleDTO = New ArticleDTO(Parser.CodArtCol(i), Parser.DescArtCol(i),
                                           Parser.PrcVentaCol(i), Parser.PrcCompraCol(i), Parser.TipIvaCol(i))
            ArticleArr(i) = nextArticle
            LocalWorker.ReportProgress(CInt(100 * i / Parser.CodArtCol.Count), nextArticle)
        Next

        e.Result = ArticleArr
    End Sub

    Private Sub ValidateCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerInstance.RunWorkerCompleted
        If e.Cancelled Then
            Form.SetStartState()
        ElseIf e.Error IsNot Nothing Then
            Form.SetStartState()
            MsgBox("Can't parse raw data to Object" & vbCrLf & e.Error.Message & vbCrLf & e.Error.StackTrace)
        Else
            Form.StartUpdatingDB(e.Result)
        End If
    End Sub

    Private Sub UpdateHandler(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles WorkerInstance.ProgressChanged
        Form.UpdateParsingProgress(e.ProgressPercentage, e.UserState)
    End Sub

    Public Class ParsingArguments
        Public Parser As ExcelParser
        Public Sub New(Parser As ExcelParser)
            Me.Parser = Parser
        End Sub
    End Class
End Class
