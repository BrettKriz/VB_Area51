<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PlayingField = New System.Windows.Forms.PictureBox()
        Me.HealthBar = New System.Windows.Forms.ProgressBar()
        Me.Think_Game = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PlayingField, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'PlayingField
        '
        Me.PlayingField.BackColor = System.Drawing.Color.LightGray
        Me.PlayingField.BackgroundImage = CType(resources.GetObject("PlayingField.BackgroundImage"), System.Drawing.Image)
        Me.PlayingField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PlayingField.Cursor = System.Windows.Forms.Cursors.Cross
        Me.PlayingField.Location = New System.Drawing.Point(0, 0)
        Me.PlayingField.Name = "PlayingField"
        Me.PlayingField.Size = New System.Drawing.Size(600, 450)
        Me.PlayingField.TabIndex = 1
        Me.PlayingField.TabStop = False
        '
        'HealthBar
        '
        Me.HealthBar.ForeColor = System.Drawing.Color.Red
        Me.HealthBar.Location = New System.Drawing.Point(12, 456)
        Me.HealthBar.Name = "HealthBar"
        Me.HealthBar.Size = New System.Drawing.Size(180, 25)
        Me.HealthBar.TabIndex = 3
        '
        'Think_Game
        '
        Me.Think_Game.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Imprint MT Shadow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(459, 458)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "MAGAZINE"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 514)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HealthBar)
        Me.Controls.Add(Me.PlayingField)
        Me.Name = "Form1"
        Me.Text = "Area 51"
        CType(Me.PlayingField, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PlayingField As System.Windows.Forms.PictureBox
    Friend WithEvents HealthBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Think_Game As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
