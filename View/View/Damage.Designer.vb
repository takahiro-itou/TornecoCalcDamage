<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Damage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Damage))

        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.grdDamage = New System.Windows.Forms.DataGridView()

        Me.fraStatus = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.updLevel = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.updPower = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.updWeapon = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.updShield = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAttack = New System.Windows.Forms.Label()

        Me.fraMode = New System.Windows.Forms.GroupBox()
        Me.optMode0 = New System.Windows.Forms.RadioButton()
        Me.optMode1 = New System.Windows.Forms.RadioButton()
        Me.optMode2 = New System.Windows.Forms.RadioButton()
        Me.cmbEnemy = New System.Windows.Forms.ComboBox()

        Me.fraSort = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbRowSort = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbColSort = New System.Windows.Forms.ComboBox()

        CType(Me.grdDamage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraStatus.SuspendLayout()
        CType(Me.updLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.updPower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.updWeapon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.updShield, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraMode.SuspendLayout()
        Me.fraSort.SuspendLayout()
        Me.SuspendLayout()

        '
        ' cmdOK
        '
        resources.ApplyResources(Me.cmdOK, "cmdOK")
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        ' cmdExit
        '
        resources.ApplyResources(Me.cmdExit, "cmdExit")
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        ' grdDamage
        '
        resources.ApplyResources(Me.grdDamage, "grdDamage")
        Me.grdDamage.AllowUserToAddRows = False
        Me.grdDamage.AllowUserToDeleteRows = False
        Me.grdDamage.AllowUserToResizeColumns = False
        Me.grdDamage.AllowUserToResizeRows = False
        Me.grdDamage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdDamage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDamage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdDamage.Name = "grdDamage"
        Me.grdDamage.ReadOnly = True
        Me.grdDamage.RowTemplate.Height = 21

        '
        ' fraStatus
        '
        Me.fraStatus.Controls.Add(Me.Label1)
        Me.fraStatus.Controls.Add(Me.updLevel)
        Me.fraStatus.Controls.Add(Me.Label2)
        Me.fraStatus.Controls.Add(Me.updPower)
        Me.fraStatus.Controls.Add(Me.Label3)
        Me.fraStatus.Controls.Add(Me.updWeapon)
        Me.fraStatus.Controls.Add(Me.Label4)
        Me.fraStatus.Controls.Add(Me.updShield)
        Me.fraStatus.Controls.Add(Me.Label5)
        Me.fraStatus.Controls.Add(Me.lblAttack)
        resources.ApplyResources(Me.fraStatus, "fraStatus")
        Me.fraStatus.Name = "fraStatus"
        '
        ' Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        ' updLevel
        '
        resources.ApplyResources(Me.updLevel, "updLevel")
        Me.updLevel.Maximum = New Decimal(New Integer() {37, 0, 0, 0})
        Me.updLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.updLevel.Name = "updLevel"
        Me.updLevel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        ' Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        ' updPower
        '
        resources.ApplyResources(Me.updPower, "updPower")
        Me.updPower.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.updPower.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.updPower.Name = "updPower"
        Me.updPower.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        ' Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        ' updWeapon
        '
        resources.ApplyResources(Me.updWeapon, "updWeapon")
        Me.updWeapon.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.updWeapon.Name = "updWeapon"
        Me.updWeapon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        ' Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        ' updShield
        '
        resources.ApplyResources(Me.updShield, "updShield")
        Me.updShield.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.updShield.Name = "updShield"
        Me.updShield.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        ' Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        ' lblAttack
        '
        Me.lblAttack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.lblAttack, "lblAttack")
        Me.lblAttack.Name = "lblAttack"
        ' Me.lblAttack.Text = "0"
        '
        ' fraMode
        '
        Me.fraMode.Controls.Add(Me.optMode0)
        Me.fraMode.Controls.Add(Me.optMode1)
        Me.fraMode.Controls.Add(Me.optMode2)
        Me.fraMode.Controls.Add(Me.cmbEnemy)
        resources.ApplyResources(Me.fraMode, "fraMode")
        Me.fraMode.Name = "fraMode"
        Me.fraMode.TabStop = False
        '
        ' optMode0
        '
        resources.ApplyResources(Me.optMode0, "optMode0")
        Me.optMode0.BackColor = System.Drawing.Color.White
        Me.optMode0.Name = "optMode0"
        Me.optMode0.TabStop = True
        ' Me.optMode0.Text = "敵を攻撃した時のダメージ"
        Me.optMode0.UseVisualStyleBackColor = False
        '
        ' optMode1
        '
        resources.ApplyResources(Me.optMode1, "optMode1")
        Me.optMode1.BackColor = System.Drawing.Color.White
        Me.optMode1.Name = "optMode1"
        Me.optMode1.TabStop = True
        ' Me.optMode1.Text = "敵から受けるダメージ"
        Me.optMode1.UseVisualStyleBackColor = False
        '
        ' optMode2
        '
        resources.ApplyResources(Me.optMode2, "optMode2")
        Me.optMode2.BackColor = System.Drawing.Color.White
        Me.optMode2.Name = "optMode2"
        Me.optMode2.TabStop = True
        ' Me.optMode2.Text = "特定の敵との戦闘"
        Me.optMode2.UseVisualStyleBackColor = False
        '
        ' cmbEnemy
        '
        resources.ApplyResources(Me.cmbEnemy, "cmbEnemy")
        Me.cmbEnemy.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbEnemy.FormattingEnabled = True
        Me.cmbEnemy.Name = "cmbEnemy"

        '
        ' fraSort
        '
        Me.fraSort.Controls.Add(Me.Label6)
        Me.fraSort.Controls.Add(Me.cmbRowSort)
        Me.fraSort.Controls.Add(Me.Label7)
        Me.fraSort.Controls.Add(Me.cmbColSort)
        resources.ApplyResources(Me.fraSort, "fraSort")
        Me.fraSort.Name = "fraSort"
        Me.fraSort.TabStop = False
        '
        ' Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        ' Me.Label6.Text = "行のソート"
        '
        ' cmbRowSort
        '
        resources.ApplyResources(Me.cmbRowSort, "cmbRowSort")
        Me.cmbRowSort.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbRowSort.FormattingEnabled = True
        Me.cmbRowSort.Items.AddRange(New Object() {"降順", "昇順"})
        Me.cmbRowSort.Name = "cmbRowSort"
        '
        ' Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        ' Me.Label7.Text = "モンスターのソート"
        '
        ' cmbColSort
        '
        resources.ApplyResources(Me.cmbColSort, "cmbColSort")
        Me.cmbColSort.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbColSort.FormattingEnabled = True
        Me.cmbColSort.Items.AddRange(New Object() {"なし", "降順", "昇順"})
        Me.cmbColSort.Name = "cmbColSort"

        '
        ' Damage
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents updWeapon As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents updShield As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblAttack As System.Windows.Forms.Label

    Friend WithEvents fraMode As System.Windows.Forms.GroupBox
    Friend WithEvents optMode0 As System.Windows.Forms.RadioButton
    Friend WithEvents optMode1 As System.Windows.Forms.RadioButton
    Friend WithEvents optMode2 As System.Windows.Forms.RadioButton
    Friend WithEvents cmbEnemy As System.Windows.Forms.ComboBox

    Friend WithEvents fraSort As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbRowSort As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbColSort As System.Windows.Forms.ComboBox

End Class
