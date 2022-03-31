Public Class Form1
    Private Sub SelectFileButton_Click(sender As Object, e As EventArgs) Handles SelectFileButton.Click
        If MyOpenFileDialog.ShowDialog <> DialogResult.Cancel Then
            Try
                SetValidatinState()
                Dim Parser As ExcelParser = New ExcelParser(MyOpenFileDialog.FileName)
                SetParsingState()
                Dim ArticleArr = Parser.GetArticleDTO()
            Catch ex As Exception
                SetStartState()
                MsgBox("Can't load file" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub SetStartState()
        Me.FilePathText.Text = "Please select file"
        Me.StatusText.Text = "Waiting for file"
        Me.SelectFileButton.Text = "Select File"
        Me.ResultDataGridView.Rows.Clear()
    End Sub

    Private Sub SetValidatinState()

    End Sub

    Private Sub SetParsingState()

    End Sub

    Private Sub SetUpdatingState()

    End Sub

    Private Sub SetFinishState()

    End Sub
End Class
