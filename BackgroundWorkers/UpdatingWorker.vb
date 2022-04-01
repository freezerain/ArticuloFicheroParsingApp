Imports a3ERPActiveX
Public Class UpdatingWorker
    Private Form As Form1
    Public WithEvents WorkerInstance As New System.ComponentModel.BackgroundWorker
    Private enlaceInstance As Enlace
    Public Sub New(Form As Form1)
        Me.Form = Form
        WorkerInstance.WorkerSupportsCancellation = True
        WorkerInstance.WorkerReportsProgress = True
    End Sub

    Private Sub DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WorkerInstance.DoWork
        enlaceInstance = New Enlace()
        ''enlaceInstance.Iniciar("TestSandbox", "")
        enlaceInstance.SelecEmpresa()
        Dim LocalWorker As System.ComponentModel.BackgroundWorker = sender
        Dim args As UpdateArguments = e.Argument
        Dim ArticleArr = args.ArticleArr
        For i As Integer = 0 To ArticleArr.Length - 1
            If LocalWorker.CancellationPending Then
                e.Cancel = True
                Return
            End If
            Dim CurrentArticle = ArticleArr(i)
            CurrentArticle.State = ArticleDTO.ArticleStateEnum.FAILED
            Dim ArticleMaestro As Maestro = New Maestro
            ArticleMaestro.Iniciar("Articulo")
            Dim isPresent = ArticleMaestro.Buscar(CurrentArticle.CodArt)
            If isPresent Then
                ArticleMaestro.Edita()
            Else
                ArticleMaestro.Nuevo()
            End If
            ArticleMaestro.AsString("CodArt") = CurrentArticle.CodArt
            ArticleMaestro.AsString("DescArt") = CurrentArticle.DescArt
            ArticleMaestro.AsString("PrcVenta") = CurrentArticle.PrcVenta
            If Not String.IsNullOrEmpty(CurrentArticle.PrcCompra) Then
                ArticleMaestro.AsString("PrcCompra") = CurrentArticle.PrcCompra
            End If
            If String.IsNullOrEmpty(CurrentArticle.TipIva) Then
                ArticleMaestro.AsString("TipIva") = "ORD21"
            Else ArticleMaestro.AsString("TipIva") = CurrentArticle.TipIva
            End If
            ArticleMaestro.Guarda(True)
            ArticleMaestro.Acabar()
            CurrentArticle.State = If(isPresent, ArticleDTO.ArticleStateEnum.UPDATED, ArticleDTO.ArticleStateEnum.CREATED)
            LocalWorker.ReportProgress(CInt(100 * i / ArticleArr.Length), CurrentArticle)
        Next
        e.Result = ArticleArr
    End Sub

    Private Sub ValidateCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerInstance.RunWorkerCompleted
        If enlaceInstance IsNot Nothing Then
            enlaceInstance.Acabar()
            enlaceInstance = Nothing
        End If
        If e.Cancelled Then
            Form.SetStartState()
        ElseIf e.Error IsNot Nothing Then
            Form.SetStartState()
            MsgBox("Can't update DB " & vbCrLf & e.Error.Message & vbCrLf & e.Error.StackTrace)
        Else
            Form.FinishParsing(e.Result)
        End If
    End Sub

    Private Sub UpdateHandler(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles WorkerInstance.ProgressChanged
        Form.UpdateDBProgress(e.ProgressPercentage, e.UserState)
    End Sub

    Public Class UpdateArguments
        Public ArticleArr As ArticleDTO()
        Public Sub New(ArticleArr As ArticleDTO())
            Me.ArticleArr = ArticleArr
        End Sub
    End Class
End Class
