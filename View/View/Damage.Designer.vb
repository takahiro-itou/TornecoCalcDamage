<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Damage
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
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.grdDamage = New System.Windows.Forms.DataGridView()
        Me.fraStatus = New System.Windows.Forms.GroupBox()
        Me.lblAttack = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.updShield = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.updWeapon = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.updPower = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.updLevel = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fraMode = New System.Windows.Forms.GroupBox()
        Me.cmbEnemy = New System.Windows.Forms.ComboBox()
        Me.optMode2 = New System.Windows.Forms.RadioButton()
        Me.optMode1 = New System.Windows.Forms.RadioButton()
        Me.optMode0 = New System.Windows.Forms.RadioButton()
        Me.fraSort = New System.Windows.Forms.GroupBox()
        Me.cmbColSort = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbRowSort = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.grdDamage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraStatus.SuspendLayout()
        CType(Me.updShield, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.updWeapon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.updPower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.updLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraMode.SuspendLayout()
        Me.fraSort.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(842, 16)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 32)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "計算(&C)"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Location = New System.Drawing.Point(842, 64)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 32)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "終了(&X)"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'grdDamage
        '
        Me.grdDamage.AllowUserToAddRows = False
        Me.grdDamage.AllowUserToDeleteRows = False
        Me.grdDamage.AllowUserToResizeColumns = False
        Me.grdDamage.AllowUserToResizeRows = False
        Me.grdDamage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdDamage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDamage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdDamage.Location = New System.Drawing.Point(8, 128)
        Me.grdDamage.Name = "grdDamage"
        Me.grdDamage.ReadOnly = True
        Me.grdDamage.RowTemplate.Height = 21
        Me.grdDamage.Size = New System.Drawing.Size(914, 568)
        Me.grdDamage.TabIndex = 2
        '
        'fraStatus
        '
        Me.fraStatus.Controls.Add(Me.lblAttack)
        Me.fraStatus.Controls.Add(Me.Label5)
        Me.fraStatus.Controls.Add(Me.updShield)
        Me.fraStatus.Controls.Add(Me.Label4)
        Me.fraStatus.Controls.Add(Me.updWeapon)
        Me.fraStatus.Controls.Add(Me.Label3)
        Me.fraStatus.Controls.Add(Me.updPower)
        Me.fraStatus.Controls.Add(Me.Label2)
        Me.fraStatus.Controls.Add(Me.updLevel)
        Me.fraStatus.Controls.Add(Me.Label1)
        Me.fraStatus.Location = New System.Drawing.Point(8, 0)
        Me.fraStatus.Name = "fraStatus"
        Me.fraStatus.Size = New System.Drawing.Size(457, 120)
        Me.fraStatus.TabIndex = 3
        Me.fraStatus.TabStop = False
        Me.fraStatus.Text = "トルネコのステータス"
        '
        'lblAttack
        '
        Me.lblAttack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAttack.Location = New System.Drawing.Point(336, 88)
        Me.lblAttack.Name = "lblAttack"
        Me.lblAttack.Size = New System.Drawing.Size(113, 19)
        Me.lblAttack.TabIndex = 13
        Me.lblAttack.Text = "0"
        Me.lblAttack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(232, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "攻撃力："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'updShield
        '
        Me.updShield.Location = New System.Drawing.Point(336, 56)
        Me.updShield.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.updShield.Name = "updShield"
        Me.updShield.Size = New System.Drawing.Size(113, 19)
        Me.updShield.TabIndex = 11
        Me.updShield.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Location = New System.Drawing.Point(232, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "盾の強さ："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'updWeapon
        '
        Me.updWeapon.Location = New System.Drawing.Point(112, 56)
        Me.updWeapon.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.updWeapon.Name = "updWeapon"
        Me.updWeapon.Size = New System.Drawing.Size(113, 19)
        Me.updWeapon.TabIndex = 9
        Me.updWeapon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "剣の強さ："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'updPower
        '
        Me.updPower.Location = New System.Drawing.Point(336, 24)
        Me.updPower.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.updPower.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.updPower.Name = "updPower"
        Me.updPower.Size = New System.Drawing.Size(113, 19)
        Me.updPower.TabIndex = 7
        Me.updPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.updPower.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(232, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ちから(&P)："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'updLevel
        '
        Me.updLevel.Location = New System.Drawing.Point(111, 24)
        Me.updLevel.Maximum = New Decimal(New Integer() {37, 0, 0, 0})
        Me.updLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.updLevel.Name = "updLevel"
        Me.updLevel.Size = New System.Drawing.Size(113, 19)
        Me.updLevel.TabIndex = 5
        Me.updLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.updLevel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "レベル(&L)："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fraMode
        '
        Me.fraMode.Controls.Add(Me.cmbEnemy)
        Me.fraMode.Controls.Add(Me.optMode2)
        Me.fraMode.Controls.Add(Me.optMode1)
        Me.fraMode.Controls.Add(Me.optMode0)
        Me.fraMode.Location = New System.Drawing.Point(480, 0)
        Me.fraMode.Name = "fraMode"
        Me.fraMode.Size = New System.Drawing.Size(233, 120)
        Me.fraMode.TabIndex = 14
        Me.fraMode.TabStop = False
        Me.fraMode.Text = "表示する内容"
        '
        'cmbEnemy
        '
        Me.cmbEnemy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEnemy.FormattingEnabled = True
        Me.cmbEnemy.Location = New System.Drawing.Point(8, 88)
        Me.cmbEnemy.Name = "cmbEnemy"
        Me.cmbEnemy.Size = New System.Drawing.Size(217, 20)
        Me.cmbEnemy.TabIndex = 18
        '
        'optMode2
        '
        Me.optMode2.BackColor = System.Drawing.Color.White
        Me.optMode2.Location = New System.Drawing.Point(8, 64)
        Me.optMode2.Name = "optMode2"
        Me.optMode2.Size = New System.Drawing.Size(217, 17)
        Me.optMode2.TabIndex = 17
        Me.optMode2.TabStop = True
        Me.optMode2.Text = "特定の敵との戦闘"
        Me.optMode2.UseVisualStyleBackColor = False
        '
        'optMode1
        '
        Me.optMode1.BackColor = System.Drawing.Color.White
        Me.optMode1.Location = New System.Drawing.Point(8, 40)
        Me.optMode1.Name = "optMode1"
        Me.optMode1.Size = New System.Drawing.Size(217, 17)
        Me.optMode1.TabIndex = 16
        Me.optMode1.TabStop = True
        Me.optMode1.Text = "敵から受けるダメージ"
        Me.optMode1.UseVisualStyleBackColor = False
        '
        'optMode0
        '
        Me.optMode0.BackColor = System.Drawing.Color.White
        Me.optMode0.Location = New System.Drawing.Point(8, 16)
        Me.optMode0.Name = "optMode0"
        Me.optMode0.Size = New System.Drawing.Size(217, 17)
        Me.optMode0.TabIndex = 15
        Me.optMode0.TabStop = True
        Me.optMode0.Text = "敵を攻撃した時のダメージ"
        Me.optMode0.UseVisualStyleBackColor = False
        '
        'fraSort
        '
        Me.fraSort.Controls.Add(Me.cmbColSort)
        Me.fraSort.Controls.Add(Me.Label7)
        Me.fraSort.Controls.Add(Me.cmbRowSort)
        Me.fraSort.Controls.Add(Me.Label6)
        Me.fraSort.Location = New System.Drawing.Point(722, 0)
        Me.fraSort.Name = "fraSort"
        Me.fraSort.Size = New System.Drawing.Size(112, 120)
        Me.fraSort.TabIndex = 15
        Me.fraSort.TabStop = False
        Me.fraSort.Text = "ソート"
        '
        'cmbColSort
        '
        Me.cmbColSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColSort.FormattingEnabled = True
        Me.cmbColSort.Items.AddRange(New Object() {"なし", "降順", "昇順"})
        Me.cmbColSort.Location = New System.Drawing.Point(8, 88)
        Me.cmbColSort.Name = "cmbColSort"
        Me.cmbColSort.Size = New System.Drawing.Size(96, 20)
        Me.cmbColSort.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 16)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "モンスターのソート"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmbRowSort
        '
        Me.cmbRowSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRowSort.FormattingEnabled = True
        Me.cmbRowSort.Items.AddRange(New Object() {"降順", "昇順"})
        Me.cmbRowSort.Location = New System.Drawing.Point(8, 40)
        Me.cmbRowSort.Name = "cmbRowSort"
        Me.cmbRowSort.Size = New System.Drawing.Size(96, 20)
        Me.cmbRowSort.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "行のソート"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Damage
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(930, 709)
        Me.Controls.Add(Me.fraSort)
        Me.Controls.Add(Me.fraMode)
        Me.Controls.Add(Me.fraStatus)
        Me.Controls.Add(Me.grdDamage)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdOK)
        Me.Location = New System.Drawing.Point(0, 56)
        Me.MinimumSize = New System.Drawing.Size(945, 748)
        Me.Name = "Damage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "トルネコの大冒険　戦闘ダメージ計算"
        CType(Me.grdDamage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraStatus.ResumeLayout(False)
        CType(Me.updShield, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.updWeapon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.updPower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.updLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraMode.ResumeLayout(False)
        Me.fraSort.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents grdDamage As System.Windows.Forms.DataGridView
    Friend WithEvents fraStatus As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents updLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents updPower As System.Windows.Forms.NumericUpDown
    Friend WithEvents updWeapon As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents updShield As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAttack As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents fraMode As System.Windows.Forms.GroupBox
    Friend WithEvents optMode1 As System.Windows.Forms.RadioButton
    Friend WithEvents optMode0 As System.Windows.Forms.RadioButton
    Friend WithEvents optMode2 As System.Windows.Forms.RadioButton
    Friend WithEvents cmbEnemy As System.Windows.Forms.ComboBox
    Friend WithEvents fraSort As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbRowSort As System.Windows.Forms.ComboBox
    Friend WithEvents cmbColSort As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
