Public Class Damage

    ' ステータステーブル
    Private mlngTableAttack() As Integer    ' 基本攻撃力
    Private mlngTableEnemyA() As Integer    ' 敵の攻撃力
    Private mlngTableEnemyD() As Integer    ' 敵の守備力
    Private mstrEnemyName() As String       ' 敵の名前

    ' 与えるダメージ／受けるダメージ
    Private mlngAtkDamage(,) As Integer
    Private mlngDefDamage(,) As Integer

    ' イベントチェーンの抑制フラグ
    Private mblnFlagEvent As Boolean

    ' 定数
    Private Const GRID_HEADER_COL_RAND As Integer = 0
    Private Const NUM_FIXED_COLUMNS As Integer = 1
    Private Const NUM_MONSTERS As Integer = 32

    Private Const GRID_EXTRA_ROW_STATUS As Integer = 0
    Private Const GRID_EXTRA_ROW_MAX As Integer = 1
    Private Const GRID_EXTRA_ROW_MIN As Integer = 2
    Private Const GRID_EXTRA_ROW_AVERAGE As Integer = 3
    Private Const NUM_HEADER_ROWS As Integer = 4

    Private Const NUM_RAND_RANGES As Integer = 32
    Private Const TABLE_EXTRA_INDEX_SUM As Integer = NUM_RAND_RANGES

    Private Const RAND_RANGE_MIN As Integer = 112

    '------------------------------------------------------------------------------
    ' 攻撃力と守備力、及び乱数から、ダメージを計算する
    '------------------------------------------------------------------------------
    Private Function CalcDamage(ByVal nAttack As Integer, ByVal nDefense As Integer,
                                ByVal nRand As Integer) As Integer
        Dim i As Integer
        Dim lngValue As Integer

        lngValue = nAttack * nRand
        For i = 1 To nDefense
            lngValue = lngValue - Int(lngValue \ 16)
        Next

        CalcDamage = Int(lngValue \ 128)
    End Function

    '------------------------------------------------------------------------------
    ' ダメージを計算する
    '------------------------------------------------------------------------------
    Private Sub CalcDamageTable(ByVal nLevel As Integer, ByVal nPower As Integer, _
                                ByVal nWeapon As Integer, ByVal nShield As Integer)
        Dim lngAttack As Integer
        Dim lngAdjust As Integer
        Dim lngEnemy As Integer
        Dim lngRand As Integer
        Dim lngDamage As Integer
        Dim lngAtkTotal As Integer
        Dim lngDefTotal As Integer

        ' トルネコの攻撃力を計算する
        lngAttack = mlngTableAttack(nLevel)
        lngAdjust = nPower + nWeapon - 8
        lngAdjust = Int(lngAttack * lngAdjust / 16 + 0.5)
        If (lngAdjust <= -255) Then lngAdjust = -255

        lngAttack = lngAttack + lngAdjust
        If (lngAttack < 0) Then lngAttack = lngAttack + 256
        If (lngAttack >= 255) Then lngAttack = 255

        ' 攻撃力を表示する
        lblAttack.Text = mlngTableAttack(nLevel) & "+" & lngAdjust & "=" & lngAttack

        ' 各ダメージを計算し、テーブルに記録する
        ReDim mlngAtkDamage(0 To NUM_MONSTERS - 1, 0 To NUM_RAND_RANGES)
        ReDim mlngDefDamage(0 To NUM_MONSTERS - 1, 0 To NUM_RAND_RANGES)

        For lngEnemy = 0 To NUM_MONSTERS - 1
            lngAtkTotal = 0
            lngDefTotal = 0

            For lngRand = 0 To NUM_RAND_RANGES - 1
                ' 敵を攻撃した時に与えるダメージ
                lngDamage = CalcDamage( _
                        lngAttack, mlngTableEnemyD(lngEnemy), _
                        lngRand + RAND_RANGE_MIN)
                mlngAtkDamage(lngEnemy, lngRand) = lngDamage
                lngAtkTotal = lngAtkTotal + lngDamage

                ' 敵から受けるダメージ
                lngDamage = CalcDamage( _
                        mlngTableEnemyA(lngEnemy), nShield, _
                        lngRand + RAND_RANGE_MIN)
                mlngDefDamage(lngEnemy, lngRand) = lngDamage
                lngDefTotal = lngDefTotal + lngDamage
            Next lngRand

            mlngAtkDamage(lngEnemy, TABLE_EXTRA_INDEX_SUM) = lngAtkTotal
            mlngDefDamage(lngEnemy, TABLE_EXTRA_INDEX_SUM) = lngDefTotal
        Next lngEnemy
    End Sub

    '------------------------------------------------------------------------------
    ' 計算を行う
    '------------------------------------------------------------------------------
    Private Sub RunCalcButtonHandler()
        Dim lngMode As Integer

        If mblnFlagEvent = False Then Exit Sub

        ' ダメージテーブルを計算する
        CalcDamageTable(updLevel.Value, updPower.Value, updWeapon.Value, updShield.Value)

        ' 表示する
        If optMode0.Checked = True Then
            lngMode = 0
        ElseIf optMode1.Checked = True Then
            lngMode = 1
        ElseIf optMode2.Checked = True Then
            lngMode = 2
        End If
        UpdateDamageTable(lngMode, cmbEnemy.SelectedIndex)
    End Sub

    '------------------------------------------------------------------------------
    ' データを表示する
    '------------------------------------------------------------------------------
    Private Sub ShowEnemyDamageTableData(ByRef lpData(,) As Integer, _
                              ByRef lpStatus() As Integer, _
                              ByVal strStatus As String)
        Dim X As Integer, Y As Integer
        Dim lngSort() As Integer
        Dim lngIndex As Integer
        Dim lngSumValue As Integer

        ' 敵側のステータス順にソートする
        ReDim lngSort(0 To 31)
        SortList(lngSort, lpStatus, 0, NUM_MONSTERS - 1)

        With grdDamage
            With .Rows(GRID_EXTRA_ROW_STATUS)
                .Cells(GRID_EXTRA_ROW_STATUS).Value = strStatus
            End With

            ' 表示する
            For X = 0 To NUM_MONSTERS - 1
                lngIndex = lngSort(X)
                .Columns(X + 1).Width = 40
                .Columns(X + 1).HeaderText = mstrEnemyName(lngIndex)

                For Y = 0 To NUM_RAND_RANGES - 1
                    .Rows(Y + NUM_HEADER_ROWS).Cells(X + 1).Value = lpData(lngIndex, Y)
                Next Y

                With .Rows(GRID_EXTRA_ROW_STATUS)
                    .Cells(X + 1).Value = lpStatus(lngIndex)
                    .Cells(X + 1).Style.BackColor = Color.LightGray
                End With
                With .Rows(GRID_EXTRA_ROW_MAX)
                    .Cells(X + 1).Value = lpData(lngIndex, NUM_RAND_RANGES - 1)
                    .Cells(X + 1).Style.BackColor = Color.LightYellow
                End With
                With .Rows(GRID_EXTRA_ROW_MIN)
                    .Cells(X + 1).Value = lpData(lngIndex, 0)
                    .Cells(X + 1).Style.BackColor = Color.LightYellow
                End With
                With .Rows(GRID_EXTRA_ROW_AVERAGE)
                    lngSumValue = lpData(lngIndex, TABLE_EXTRA_INDEX_SUM)
                    .Cells(X + 1).Value = Format$( _
                            lngSumValue / NUM_RAND_RANGES, "#0.0")
                    .Cells(X + 1).Style.BackColor = Color.LightYellow
                End With
            Next X
        End With

    End Sub

    '------------------------------------------------------------------------------
    ' データ順にソートする
    '------------------------------------------------------------------------------
    Private Sub SortList(ByRef lpSortResult() As Integer, ByRef lpData() As Integer, _
                         ByVal nStart As Integer, ByVal nEnd As Integer)
        Dim i As Integer, j As Integer
        Dim blnUsed() As Boolean
        Dim lngMinIndex As Integer
        Dim lngMinValue As Integer

        ReDim lpSortResult(nEnd)
        ReDim blnUsed(nEnd)
        For i = 0 To nEnd
            blnUsed(i) = False
        Next

        For i = nStart To nEnd
            lngMinValue = 99999999
            lngMinIndex = -1
            For j = nStart To nEnd
                If (blnUsed(j) = False) Then
                    If (lpData(j) < lngMinValue) Then
                        lngMinIndex = j
                        lngMinValue = lpData(j)
                    End If
                End If
            Next j

            lpSortResult(i) = lngMinIndex
            blnUsed(lngMinIndex) = True
        Next i

    End Sub

    '------------------------------------------------------------------------------
    ' ダメージのリストを表示する
    '------------------------------------------------------------------------------
    Private Sub UpdateDamageTable(ByVal nMode As Long, ByVal nEnemy As Long)
        Dim Y As Integer
        Dim lngSumValue As Integer

        With grdDamage
            .RowCount = NUM_RAND_RANGES + NUM_HEADER_ROWS
            If (nMode = 2) Then
                .ColumnCount = 3
            Else
                .ColumnCount = NUM_MONSTERS + NUM_FIXED_COLUMNS
            End If
            With .Columns(GRID_HEADER_COL_RAND)
                .HeaderText = "乱数"
                .Width = 48
                .Frozen = True
            End With
            With .Rows(NUM_HEADER_ROWS - 1)
                .Frozen = True
            End With

            For Y = 0 To NUM_RAND_RANGES - 1
                With .Rows(Y + NUM_HEADER_ROWS)
                    With .Cells(GRID_HEADER_COL_RAND)
                        .Value = Y + RAND_RANGE_MIN
                        .Style.BackColor = Color.LightGray
                    End With
                End With
            Next Y
            With .Rows(GRID_EXTRA_ROW_MAX)
                With .Cells(GRID_HEADER_COL_RAND)
                    .Value = "最大"
                    .Style.BackColor = Color.LightGray
                End With
            End With
            With .Rows(GRID_EXTRA_ROW_MIN)
                With .Cells(GRID_HEADER_COL_RAND)
                    .Value = "最小"
                    .Style.BackColor = Color.LightGray
                End With
            End With
            With .Rows(GRID_EXTRA_ROW_AVERAGE)
                With .Cells(GRID_HEADER_COL_RAND)
                    .Value = "平均"
                    .Style.BackColor = Color.LightGray
                End With
            End With
        End With

        If (nMode = 0) Then
            ' 敵を攻撃した時のダメージ
            ShowEnemyDamageTableData(mlngAtkDamage, mlngTableEnemyD, "守備力")
            Exit Sub
        ElseIf (nMode = 1) Then
            ' 敵の攻撃を受けた時のダメージ
            ShowEnemyDamageTableData(mlngDefDamage, mlngTableEnemyA, "攻撃力")
            Exit Sub
        End If

        With grdDamage
            ' 特定の敵との戦闘
            With .Columns(1)
                .Width = 48
                .HeaderText = "敵への攻撃"
            End With
            With .Columns(2)
                .Width = 48
                .HeaderText = "敵からの攻撃"
            End With
            .Rows(33).Cells(0).Value = "攻／守"

            For Y = 0 To NUM_RAND_RANGES - 1
                With .Rows(Y + NUM_HEADER_ROWS)
                    .Cells(1).Value = mlngAtkDamage(nEnemy, Y)
                    .Cells(2).Value = mlngDefDamage(nEnemy, Y)
                End With
            Next Y

            With .Rows(GRID_EXTRA_ROW_STATUS)
                .Cells(0).Value = "攻／守"
                .Cells(1).Value = mlngTableEnemyA(nEnemy)
                .Cells(2).Value = mlngTableEnemyD(nEnemy)
            End With
            With .Rows(GRID_EXTRA_ROW_AVERAGE)
                .Cells(0).Value = "平均"
                lngSumValue = mlngAtkDamage(nEnemy, TABLE_EXTRA_INDEX_SUM)
                .Cells(1).Value = Format$(lngSumValue / NUM_RAND_RANGES, "#0.0##")
                lngSumValue = mlngDefDamage(nEnemy, TABLE_EXTRA_INDEX_SUM)
                .Cells(2).Value = Format$(lngSumValue / NUM_RAND_RANGES, "#0.0##")
            End With
        End With

    End Sub

    '------------------------------------------------------------------------------
    ' 「終了」ボタンのクリックイベントハンドラ
    '------------------------------------------------------------------------------
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    '------------------------------------------------------------------------------
    ' 「計算」ボタンのクリックイベントハンドラ
    '------------------------------------------------------------------------------
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        RunCalcButtonHandler()
    End Sub

    '------------------------------------------------------------------------------
    ' フォームのロードイベントハンドラ
    '------------------------------------------------------------------------------
    Private Sub Damage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim strData As String

        ' 初期化中のイベントの処理を無効化しておく
        mblnFlagEvent = False

        ' 基本攻撃力
        ReDim mlngTableAttack(37)
        strData = "  5,  7,  9, 11, 13, 16, 19, 22, 25, 29, 33, 37, 41, 46, 51, 56, 61, 65, 71," & _
                  " 74, 77, 80, 83, 86, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99,100,100"
        For i = 1 To 37
            mlngTableAttack(i) = Val(Mid$(strData, i * 4 - 3, 3))
        Next i

        ' 敵の名前
        ReDim mstrEnemyName(0 To 31)
        mstrEnemyName(0) = ("スライム")
        mstrEnemyName(1) = ("ゴースト")
        mstrEnemyName(2) = ("ドラキー")
        mstrEnemyName(3) = ("おおなめくじ")
        mstrEnemyName(4) = ("ももんじゃ")
        mstrEnemyName(5) = ("リリパット")
        mstrEnemyName(6) = ("おばけキノコ")
        mstrEnemyName(7) = ("スモールグール")
        mstrEnemyName(8) = ("わらいぶくろ")
        mstrEnemyName(9) = ("イエティ")
        mstrEnemyName(10) = ("まどうし")
        mstrEnemyName(11) = ("ミイラおとこ")
        mstrEnemyName(12) = ("きめんどうし")
        mstrEnemyName(13) = ("ベビーサタン")
        mstrEnemyName(14) = ("マネマネ")
        mstrEnemyName(15) = ("キメラ")
        mstrEnemyName(16) = ("くさったしたい")
        mstrEnemyName(17) = ("ミミック")
        mstrEnemyName(18) = ("ばくだんいわ")
        mstrEnemyName(19) = ("どろにんぎょう")
        mstrEnemyName(20) = ("さまようよろい")
        mstrEnemyName(21) = ("マドハンド")
        mstrEnemyName(22) = ("うごくせきぞう")
        mstrEnemyName(23) = ("シャドー")
        mstrEnemyName(24) = ("ミステリードール")
        mstrEnemyName(25) = ("ゴーレム")
        mstrEnemyName(26) = ("おおめだま")
        mstrEnemyName(27) = ("ギガンテス")
        mstrEnemyName(28) = ("はぐれメタル")
        mstrEnemyName(29) = ("シルバーデビル")
        mstrEnemyName(30) = ("アークデーモン")
        mstrEnemyName(31) = ("ドラゴン")

        With cmbEnemy
            With .Items
                .Clear()
                For i = 0 To 31
                    .Add(mstrEnemyName(i))
                Next i
            End With

            .SelectedIndex = 0
            .Enabled = False
        End With

        ' 敵の攻撃力
        ReDim mlngTableEnemyA(0 To 31)
        strData = "  2,  3,  3,  2,  4,  4,  6,  4,  0, 11,  6, 10, 10,  0,  9, 22" & _
          "  0, 24, 12, 13, 15,  7, 18, 17, 17, 32, 31, 51, 30, 26, 51, 68"
        For i = 0 To 31
            mlngTableEnemyA(i) = Val(Mid$(strData, i * 4 + 1, 3))
        Next

        ' 敵の守備力
        ReDim mlngTableEnemyD(0 To 31)
        strData = "  1,  9,  1,  4,  9, 15,  8, 15, 16,  3, 11, 19, 16, 17, 14, 16" & _
          " 19, 24, 23, 23, 26, 23, 27, 27, 24, 27, 27, 27, 49, 25, 29, 30"
        For i = 0 To 31
            mlngTableEnemyD(i) = Val(Mid$(strData, i * 4 + 1, 3))
        Next

        ' コントロールの初期化
        updLevel.Value = 1
        updPower.Value = 8
        updWeapon.Value = 0
        updShield.Value = 0
        optMode1.Checked = True

        mblnFlagEvent = True
        RunCalcButtonHandler()
    End Sub

    Private Sub Damage_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If mblnFlagEvent = False Then Exit Sub

        With grdDamage
            .Width = Me.Width - 32
            .Height = Me.Height - 180
        End With
    End Sub

    Private Sub updLevel_ValueChanged(sender As Object, e As EventArgs) Handles updLevel.ValueChanged
        If mblnFlagEvent = False Then Exit Sub
        RunCalcButtonHandler()
    End Sub

    Private Sub updPower_ValueChanged(sender As Object, e As EventArgs) Handles updPower.ValueChanged
        If mblnFlagEvent = False Then Exit Sub
        RunCalcButtonHandler()
    End Sub

    Private Sub updShield_ValueChanged(sender As Object, e As EventArgs) Handles updShield.ValueChanged
        If mblnFlagEvent = False Then Exit Sub
        RunCalcButtonHandler()
    End Sub

    Private Sub updWeapon_ValueChanged(sender As Object, e As EventArgs) Handles updWeapon.ValueChanged
        If mblnFlagEvent = False Then Exit Sub
        RunCalcButtonHandler()
    End Sub

    Private Sub optMode_CheckedChanged(sender As Object, e As EventArgs) _
            Handles optMode0.CheckedChanged, optMode1.CheckedChanged, optMode2.CheckedChanged

        If mblnFlagEvent = False Then Exit Sub

        cmbEnemy.Enabled = optMode2.Checked
        RunCalcButtonHandler()
    End Sub

End Class
