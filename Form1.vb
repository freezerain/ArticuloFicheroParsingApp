Public Class Form1
    Public vWorker = New ValidatingWorker(Me)
    Public pWorker = New ParsingWorker(Me)
    Public uWorker = New UpdatingWorker(Me)
    ''Entry point
    Public Sub New()
        InitializeComponent()
        SetStartState()
    End Sub
    ''Events
    Private Sub SelectFileEvent(sender As Object, e As EventArgs)
        If MyOpenFileDialog.ShowDialog <> DialogResult.Cancel Then
            SetWorkingState(MyOpenFileDialog.FileName)
            StartValidating(MyOpenFileDialog.FileName)
        End If
    End Sub

    Private Sub StopEvent(sender As Object, e As EventArgs)
        If vWorker.WorkerInstance.IsBusy Then
            vWorker.WorkerInstance.CancelAsync()
        ElseIf pWorker.WorkerInstance.IsBusy Then
            pWorker.WorkerInstance.CancelAsync()
        ElseIf uWorker.WorkerInstance.IsBusy Then
            uWorker.WorkerInstance.CancelAsync()
        End If
    End Sub
    ''UI states
    Public Sub SetStartState()
        Me.FilePathText.Text = "Please select a excel table"
        Me.StatusText.Text = "Waiting for file..."
        Me.MainButton.Text = "Select File"
        Me.MainButton.Enabled = True
        RemoveHandler MainButton.Click, AddressOf StopEvent
        AddHandler MainButton.Click, AddressOf SelectFileEvent
        Me.ResultDataGridView.Rows.Clear()
    End Sub

    Public Sub SetWorkingState(FilePath As String)
        Me.FilePathText.Text = FilePath
        Me.StatusText.Text = "Waiting for validation to complete..."
        Me.MainButton.Text = "Stop"
        AddHandler MainButton.Click, AddressOf StopEvent
        RemoveHandler MainButton.Click, AddressOf SelectFileEvent
    End Sub

    Public Sub SetFinishState(articleCreated As Integer, articleUpdated As Integer, articleFailed As Integer)
        RemoveHandler MainButton.Click, AddressOf StopEvent
        AddHandler MainButton.Click, AddressOf SelectFileEvent
        Me.MainButton.Text = "Select File"
        Me.StatusText.Text = "Parsing finished."
        MsgBox("Parsing finished" & vbCrLf &
               "Created: " & articleCreated & vbCrLf &
               "Updated: " & articleUpdated & vbCrLf &
               "Failed: " & articleFailed)
    End Sub
    ''Actions
    Public Sub StartValidating(FilePath As String)
        vWorker.WorkerInstance.RunWorkerAsync(New ValidatingWorker.ValidatingArguments(FilePath))
    End Sub

    Public Sub StartParsing(parser As ExcelParser)
        Me.StatusText.Text = "Parsing started..."
        pWorker.WorkerInstance.RunWorkerAsync(New ParsingWorker.ParsingArguments(parser))
    End Sub

    Public Sub StartUpdatingDB(ArticleArr As ArticleDTO())
        Me.StatusText.Text = "Connecting to DB... Please select DB in new opened window"
        Me.ResultDataGridView.Rows.Clear()
        uWorker.WorkerInstance.RunWorkerAsync(New UpdatingWorker.UpdateArguments(ArticleArr))
    End Sub

    Public Sub FinishParsing(ArticleArr As ArticleDTO())
        Dim created As Integer = 0
        Dim updated As Integer = 0
        Dim failed As Integer = 0
        For i As Integer = 0 To ArticleArr.Length - 1
            Dim state As ArticleDTO.ArticleStateEnum = ArticleArr(i).State
            If state = ArticleDTO.ArticleStateEnum.CREATED Then
                created = created + 1
            ElseIf state = ArticleDTO.ArticleStateEnum.UPDATED Then
                updated = updated + 1
            ElseIf state = ArticleDTO.ArticleStateEnum.FAILED Then
                failed = failed + 1
            End If
        Next
        SetFinishState(created, updated, failed)
    End Sub
    ''Progress update events
    Public Sub UpdateDBProgress(progress As Integer, Article As ArticleDTO)
        Me.StatusText.Text = "Updating DB: " & progress & "%"
        ''TODO Update Data Grid Views
        Me.ResultDataGridView.Rows.Add(New String() {Article.CodArt, Article.DescArt,
                                       Article.PrcVenta, Article.PrcCompra, Article.TipIva, Article.State.ToString})
    End Sub

    Public Sub UpdateParsingProgress(progress As Integer, Article As ArticleDTO)
        Me.StatusText.Text = "Parsing data: " & progress & "%"
        Me.ResultDataGridView.Rows.Add(New String() {Article.CodArt, Article.DescArt,
                                       Article.PrcVenta, Article.PrcCompra, Article.TipIva, Article.State.ToString})
    End Sub

End Class
