<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MyOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MainButton = New System.Windows.Forms.Button()
        Me.ResultDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FilePathText = New System.Windows.Forms.Label()
        Me.StatusText = New System.Windows.Forms.Label()
        Me.ValidateBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.ParsingBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.UpdateDBBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.CODART = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCART = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRCVENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRCCOMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPIVA_ORD21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ResultDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyOpenFileDialog
        '
        Me.MyOpenFileDialog.FileName = "MyOpenFileDialogFileName"
        '
        'MainButton
        '
        Me.MainButton.Location = New System.Drawing.Point(12, 12)
        Me.MainButton.Name = "MainButton"
        Me.MainButton.Size = New System.Drawing.Size(94, 61)
        Me.MainButton.TabIndex = 0
        Me.MainButton.Text = "Select File"
        Me.MainButton.UseVisualStyleBackColor = True
        '
        'ResultDataGridView
        '
        Me.ResultDataGridView.AllowUserToAddRows = False
        Me.ResultDataGridView.AllowUserToDeleteRows = False
        Me.ResultDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ResultDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODART, Me.DESCART, Me.PRCVENTA, Me.PRCCOMPRA, Me.TIPIVA_ORD21, Me.Action})
        Me.ResultDataGridView.Location = New System.Drawing.Point(12, 83)
        Me.ResultDataGridView.MultiSelect = False
        Me.ResultDataGridView.Name = "ResultDataGridView"
        Me.ResultDataGridView.ReadOnly = True
        Me.ResultDataGridView.RowHeadersWidth = 51
        Me.ResultDataGridView.RowTemplate.Height = 29
        Me.ResultDataGridView.Size = New System.Drawing.Size(1067, 450)
        Me.ResultDataGridView.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(1448, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(8, 8)
        Me.Panel1.TabIndex = 2
        '
        'FilePathText
        '
        Me.FilePathText.AutoSize = True
        Me.FilePathText.Location = New System.Drawing.Point(112, 12)
        Me.FilePathText.Name = "FilePathText"
        Me.FilePathText.Size = New System.Drawing.Size(64, 20)
        Me.FilePathText.TabIndex = 3
        Me.FilePathText.Text = "File Path"
        '
        'StatusText
        '
        Me.StatusText.AutoSize = True
        Me.StatusText.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.StatusText.Location = New System.Drawing.Point(112, 45)
        Me.StatusText.Name = "StatusText"
        Me.StatusText.Size = New System.Drawing.Size(231, 28)
        Me.StatusText.TabIndex = 5
        Me.StatusText.Text = "Process Status: Select File"
        '
        'ValidateBackgroundWorker
        '
        Me.ValidateBackgroundWorker.WorkerSupportsCancellation = True
        '
        'ParsingBackgroundWorker
        '
        Me.ParsingBackgroundWorker.WorkerReportsProgress = True
        Me.ParsingBackgroundWorker.WorkerSupportsCancellation = True
        '
        'UpdateDBBackgroundWorker
        '
        Me.UpdateDBBackgroundWorker.WorkerReportsProgress = True
        Me.UpdateDBBackgroundWorker.WorkerSupportsCancellation = True
        '
        'CODART
        '
        Me.CODART.HeaderText = "Codigo(CODART)"
        Me.CODART.MinimumWidth = 6
        Me.CODART.Name = "CODART"
        Me.CODART.ReadOnly = True
        '
        'DESCART
        '
        Me.DESCART.HeaderText = "Descripción(DESCART)"
        Me.DESCART.MinimumWidth = 6
        Me.DESCART.Name = "DESCART"
        Me.DESCART.ReadOnly = True
        '
        'PRCVENTA
        '
        Me.PRCVENTA.HeaderText = "Precio Venta (PRCVENTA)"
        Me.PRCVENTA.MinimumWidth = 6
        Me.PRCVENTA.Name = "PRCVENTA"
        Me.PRCVENTA.ReadOnly = True
        '
        'PRCCOMPRA
        '
        Me.PRCCOMPRA.HeaderText = "Precio Compra (PRCCOMPRA - OPCIONAL)"
        Me.PRCCOMPRA.MinimumWidth = 6
        Me.PRCCOMPRA.Name = "PRCCOMPRA"
        Me.PRCCOMPRA.ReadOnly = True
        '
        'TIPIVA_ORD21
        '
        Me.TIPIVA_ORD21.HeaderText = "Tipo Iva (TIPIVA - OPCIONAL)"
        Me.TIPIVA_ORD21.MinimumWidth = 6
        Me.TIPIVA_ORD21.Name = "TIPIVA_ORD21"
        Me.TIPIVA_ORD21.ReadOnly = True
        '
        'Action
        '
        Me.Action.HeaderText = "Action Mode"
        Me.Action.MinimumWidth = 6
        Me.Action.Name = "Action"
        Me.Action.ReadOnly = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 545)
        Me.Controls.Add(Me.StatusText)
        Me.Controls.Add(Me.FilePathText)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ResultDataGridView)
        Me.Controls.Add(Me.MainButton)
        Me.Name = "Form1"
        Me.Text = "File To Article Parsing"
        CType(Me.ResultDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MyOpenFileDialog As OpenFileDialog
    Friend WithEvents MainButton As Button
    Friend WithEvents ResultDataGridView As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FilePathText As Label
    Friend WithEvents StatusText As Label
    Friend WithEvents ValidateBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ParsingBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents UpdateDBBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents CODART As DataGridViewTextBoxColumn
    Friend WithEvents DESCART As DataGridViewTextBoxColumn
    Friend WithEvents PRCVENTA As DataGridViewTextBoxColumn
    Friend WithEvents PRCCOMPRA As DataGridViewTextBoxColumn
    Friend WithEvents TIPIVA_ORD21 As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewTextBoxColumn
End Class
