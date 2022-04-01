''This worker responsable for invoking I/O actions with excel file
Public Class ValidatingWorker
    Private Form As Form1
    Public WithEvents WorkerInstance As New System.ComponentModel.BackgroundWorker
    Public Sub New(Form As Form1)
        Me.Form = Form
        WorkerInstance.WorkerSupportsCancellation = True
    End Sub

    Private Sub DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WorkerInstance.DoWork
        Dim LocalWorker As System.ComponentModel.BackgroundWorker = sender
        Dim args As ValidatingArguments = e.Argument
        If LocalWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Dim Parser As ExcelParser = New ExcelParser(args.FilePath)
        If LocalWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        e.Result = Parser
    End Sub
    ''Worker handlers
    Private Sub ValidateCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerInstance.RunWorkerCompleted
        If e.Cancelled Then
            Form.SetStartState()
        ElseIf e.Error IsNot Nothing Then
            Form.SetStartState()
            MsgBox("Can't load file" & vbCrLf & e.Error.Message & vbCrLf & e.Error.StackTrace)
        Else
            Form.StartParsing(e.Result)
        End If
    End Sub
    ''Wrapper around arguments for this worker
    Public Class ValidatingArguments
        Public FilePath As String
        Public Sub New(FilePath As String)
            Me.FilePath = FilePath
        End Sub
    End Class

End Class
