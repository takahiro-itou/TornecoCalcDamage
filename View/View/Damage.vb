Public Class Damage

' データのソート順序
Enum SortOrder
    SORT_ORDER_NONE = 0                 ' ソートなし
    SORT_ORDER_DESCENDING = 1           ' 降順
    SORT_ORDER_ASCENDING = 2            ' 昇順
End Enum

' データの色分けの基準
Enum ColoringMode
    COLOR_MODE_NONE = 0
    COLOR_MODE_ATK_DAMAGE = 1
    COLOR_MODE_DEF_DAMAGE = 2
End Enum

' ステータステーブル
Private mlngTableAttack() As Integer    ' 基本攻撃力
Private mlngTableEnemyA() As Integer    ' 敵の攻撃力
Private mlngTableEnemyD() As Integer    ' 敵の守備力
Private mlngTableEnemyHP() As Integer   ' 敵のヒットポイント
Private mstrEnemyName() As String       ' 敵の名前

' 与えるダメージ／受けるダメージ
Private mlngAtkDamage(,) As Integer
Private mlngDefDamage(,) As Integer

' 行の表示順序
Private mRowSortOrder As SortOrder
Private mColSortOrder As SortOrder

' イベントチェーンの抑制フラグ
Private mblnFlagEvent As Boolean

' 定数
Private Const GRID_HEADER_COL_RAND As Integer = 0
Private Const GRID_COL_ATK As Integer = 1
Private Const GRID_COL_DEF As Integer = 2

Private Const NUM_FIXED_COLUMNS As Integer = 1
Private Const NUM_MONSTERS As Integer = 32

Private Const GRID_EXTRA_ROW_STATUS As Integer = 0
Private Const GRID_EXTRA_ROW_MAX As Integer = 1
Private Const GRID_EXTRA_ROW_MIN As Integer = 2
Private Const GRID_EXTRA_ROW_AVERAGE As Integer = 3
Private Const GRID_EXTRA_ROW_HP As Integer = 4

Private Const NUM_HEADER_ROWS As Integer = 5

Private Const NUM_RAND_RANGES As Integer = 32
Private Const TABLE_EXTRA_INDEX_SUM As Integer = NUM_RAND_RANGES

Private Const RAND_RANGE_MIN As Integer = 112

''========================================================================
Private Function CalcDamage(
        ByVal nAttack As Integer, ByVal nDefense As Integer,
        ByVal nRand As Integer) As Integer
''--------------------------------------------------------------------
''    攻撃力と守備力、及び乱数から、ダメージを計算する
''--------------------------------------------------------------------
    Dim i As Integer
    Dim lngValue As Integer

    lngValue = nAttack * nRand
    For i = 1 To nDefense
        lngValue = lngValue - Int(lngValue \ 16)
    Next

    CalcDamage = Int(lngValue \ 128)
End Function

''========================================================================
Private Sub CalcDamageTable(
        ByVal nLevel As Integer, ByVal nPower As Integer,
        ByVal nWeapon As Integer, ByVal nShield As Integer)
''--------------------------------------------------------------------
''    ダメージを計算する
''--------------------------------------------------------------------

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

''========================================================================
Private Function DetermineBackColor(
        ByVal flagColor As ColoringMode,
        ByVal lngDamage As Integer,
        ByVal lngEnemyHP As Integer,
        ByVal lngEnemyA As Integer,
        ByVal defaultColor As Color) As Color
''--------------------------------------------------------------------
''    背景色を決定する
''--------------------------------------------------------------------

    Dim bgColor As Color

    bgColor = defaultColor
    Select Case flagColor
        Case ColoringMode.COLOR_MODE_ATK_DAMAGE
            If (lngEnemyHP <= lngDamage) Then
                bgColor = Color.Cyan
            ElseIf (lngEnemyHP <= lngDamage * 2) Then
                bgColor = Color.LightGreen
            Else
                bgColor = defaultColor
            End If

        Case ColoringMode.COLOR_MODE_DEF_DAMAGE
            If (lngDamage = 0) Then
                bgColor = Color.Cyan
            ElseIf (lngDamage <= 2) Then
                bgColor = Color.LightGreen
            ElseIf (lngEnemyA >= 15) Then
                If (lngDamage <= 10) Then
                    bgColor = Color.LightGreen
                Else
                    bgColor = defaultColor
                End If
            ElseIf (lngDamage < lngEnemyA / 2) Then
                bgColor = Color.LightGreen
            Else
                bgColor = defaultColor
            End If

        Case Else
            bgColor = defaultColor
    End Select

    DetermineBackColor = bgColor
End Function

''========================================================================
Private Function LoadTableData() As Boolean
''--------------------------------------------------------------------
''    データをロードする
''--------------------------------------------------------------------

    ' 基本攻撃力
    mlngTableAttack = New Integer(37) {
        0, 5, 7, 9, 11, 13, 16, 19, 22, 25, 29,
        33, 37, 41, 46, 51, 56, 61, 65, 71, 74,
        77, 80, 83, 86, 89, 90, 91, 92, 93, 94,
        95, 96, 97, 98, 99, 100, 100
    }

    ' 敵の名前
    mstrEnemyName = New String(0 To NUM_MONSTERS - 1) {
        "スライム", "ゴースト", "ドラキー", "おおなめくじ",
        "ももんじゃ", "リリパット", "おばけキノコ", "スモールグール",
        "わらいぶくろ", "イエティ", "まどうし", "ミイラおとこ",
        "きめんどうし", "ベビーサタン", "マネマネ", "キメラ",
        "くさったしたい", "ミミック", "ばくだんいわ", "どろ人形",
        "さまようよろい", "マドハンド", "うごくせきぞう", "シャドー",
        "ミステリードール", "ゴーレム", "おおめだま", "ギガンテス",
        "はぐれメタル", "シルバーデビル", "アークデーモン", "ドラゴン"
    }

    ' 敵のヒットポイント
    mlngTableEnemyHP = New Integer(0 To NUM_MONSTERS - 1) {
        5, 5, 7, 7, 8, 9, 17, 10,
        20, 60, 16, 16, 23, 40, 80, 27,
        30, 50, 70, 36, 35, 72, 45, 60,
        70, 52, 62, 51, 3, 78, 75, 100
    }

    ' 敵の攻撃力
    mlngTableEnemyA = New Integer(0 To NUM_MONSTERS - 1) {
        2, 3, 3, 2, 4, 4, 6, 4,
        0, 11, 6, 10, 10, 0, 9, 22,
        0, 24, 12, 13, 15, 7, 18, 17,
        17, 32, 31, 51, 30, 26, 51, 68
    }

    ' 敵の守備力
    mlngTableEnemyD = New Integer(0 To NUM_MONSTERS - 1) {
        1, 9, 1, 4, 9, 15, 8, 15,
        16, 3, 11, 19, 16, 17, 14, 16,
        19, 24, 23, 23, 26, 23, 27, 27,
        24, 27, 27, 27, 49, 25, 29, 30
    }

    LoadTableData = True
End Function

''========================================================================
Private Sub RunCalcButtonHandler()
''--------------------------------------------------------------------
''    計算を行う
''--------------------------------------------------------------------
    Dim lngMode As Integer

    If mblnFlagEvent = False Then Exit Sub

    ' ソート順序を決定する
    Select Case (cmbRowSort.SelectedIndex)
        Case 1
            mRowSortOrder = SortOrder.SORT_ORDER_ASCENDING
        Case Else
            mRowSortOrder = SortOrder.SORT_ORDER_DESCENDING
    End Select

    mColSortOrder = cmbColSort.SelectedIndex

    ' ダメージテーブルを計算する
    CalcDamageTable(
            updLevel.Value, updPower.Value, updWeapon.Value, updShield.Value)

    ' 表示する
    If optMode0.Checked = True Then
        lngMode = 0
    ElseIf optMode1.Checked = True Then
        lngMode = 1
    ElseIf optMode2.Checked = True Then
        lngMode = 2
    End If
    UpdateDamageTable(
            lngMode, cmbEnemy.SelectedIndex, mColSortOrder, mRowSortOrder)
End Sub

''========================================================================
Private Sub ShowEnemiesDamageTableData(
        ByRef lpData(,) As Integer,
        ByRef lpStatus() As Integer,
        ByVal strStatus As String,
        ByVal eColSortOrder As SortOrder,
        ByVal eRowSortOrder As SortOrder,
        ByVal flagColor As ColoringMode)
''--------------------------------------------------------------------
''    データを表示する
''--------------------------------------------------------------------

    Dim X As Integer, Y As Integer
    Dim lngDamage As Integer
    Dim lngRand As Integer
    Dim lngSort() As Integer
    Dim lngIndex As Integer
    Dim lngSumValue As Integer
    Dim lngEnemyHP As Integer
    Dim lngEnemyAtk As Integer

    ' 敵側のステータス順にソートする
    ReDim lngSort(0 To 31)
    SortList(lngSort, lpStatus, 0, NUM_MONSTERS - 1, eColSortOrder)

    With grdDamage
        With .Rows(GRID_EXTRA_ROW_STATUS)
            With .Cells(GRID_EXTRA_ROW_STATUS)
                .Value = strStatus
                .Style.BackColor = Color.LightGray
            End With
        End With

        ' 表示する
        For X = 0 To NUM_MONSTERS - 1
            lngIndex = lngSort(X)
            lngEnemyAtk = mlngTableEnemyA(lngIndex)
            lngEnemyHP = mlngTableEnemyHP(lngIndex)

            With .Columns(X + 1)
                .HeaderText = mstrEnemyName(lngIndex)
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 40
            End With

            For lngRand = 0 To NUM_RAND_RANGES - 1
                If (eRowSortOrder = SortOrder.SORT_ORDER_DESCENDING) Then
                    Y = NUM_RAND_RANGES - 1 - lngRand
                Else
                    Y = lngRand
                End If
                With .Rows(Y + NUM_HEADER_ROWS).Cells(X + 1)
                    lngDamage = lpData(lngIndex, lngRand)
                    .Style.BackColor = DetermineBackColor(
                            flagColor, lngDamage, lngEnemyHP,
                            lngEnemyAtk, Color.White)
                    .Value = lngDamage
                End With
            Next lngRand

            With .Rows(GRID_EXTRA_ROW_STATUS).Cells(X + 1)
                .Value = lpStatus(lngIndex)
                .Style.BackColor = Color.LightGray
            End With
            With .Rows(GRID_EXTRA_ROW_MAX).Cells(X + 1)
                lngDamage = lpData(lngIndex, NUM_RAND_RANGES - 1)
                .Style.BackColor = DetermineBackColor(
                        flagColor, lngDamage, lngEnemyHP,
                        lngEnemyAtk, Color.LightYellow)
                .Value = lngDamage
            End With
            With .Rows(GRID_EXTRA_ROW_MIN).Cells(X + 1)
                lngDamage = lpData(lngIndex, 0)
                .Style.BackColor = DetermineBackColor(
                        flagColor, lngDamage, lngEnemyHP,
                        lngEnemyAtk, Color.LightYellow)
                .Value = lngDamage
            End With
            With .Rows(GRID_EXTRA_ROW_AVERAGE).Cells(X + 1)
                lngSumValue = lpData(lngIndex, TABLE_EXTRA_INDEX_SUM)
                lngDamage = Int(lngSumValue / NUM_RAND_RANGES)
                .Style.BackColor = DetermineBackColor(
                        flagColor, lngDamage, lngEnemyHP,
                        lngEnemyAtk, Color.LightYellow)
                .Value = Format$(lngSumValue / NUM_RAND_RANGES, "#0.0")
            End With
            With .Rows(GRID_EXTRA_ROW_HP).Cells(X + 1)
                .Value = lngEnemyHP
                .Style.BackColor = Color.LightGray
            End With

        Next X
    End With

End Sub

''========================================================================
Private Sub ShowOneEnemyDamageTableData(
        ByVal nEnemy As Integer, ByVal eRowSortOrder As SortOrder)
''--------------------------------------------------------------------
''    データを表示する
''--------------------------------------------------------------------

    Dim lngRand As Integer
    Dim Y As Integer
    Dim lngDamage As Integer
    Dim lngSumValue As Integer
    Dim lngEnemyHP As Integer
    Dim lngEnemyAtk As Integer

    lngEnemyHP = mlngTableEnemyHP(nEnemy)
    lngEnemyAtk = mlngTableEnemyA(nEnemy)

    With grdDamage
        ' 特定の敵との戦闘
        With .Columns(GRID_COL_ATK)
            .HeaderText = "敵への攻撃"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 48
        End With
        With .Columns(GRID_COL_DEF)
            .HeaderText = "敵からの攻撃"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 48
        End With

        For lngRand = 0 To NUM_RAND_RANGES - 1
            If (eRowSortOrder = SortOrder.SORT_ORDER_DESCENDING) Then
                Y = NUM_RAND_RANGES - 1 - lngRand
            Else
                Y = lngRand
            End If
            With .Rows(Y + NUM_HEADER_ROWS)
                With .Cells(GRID_COL_ATK)
                    lngDamage = mlngAtkDamage(nEnemy, lngRand)
                    .Style.BackColor = DetermineBackColor(
                            ColoringMode.COLOR_MODE_ATK_DAMAGE, lngDamage,
                            lngEnemyHP, lngEnemyAtk, Color.White)
                    .Value = lngDamage
                End With
                With .Cells(GRID_COL_DEF)
                    lngDamage = mlngDefDamage(nEnemy, lngRand)
                    .Style.BackColor = DetermineBackColor(
                            ColoringMode.COLOR_MODE_DEF_DAMAGE, lngDamage,
                            lngEnemyHP, lngEnemyAtk, Color.White)
                    .Value = lngDamage
                End With
            End With
        Next lngRand

        With .Rows(GRID_EXTRA_ROW_STATUS)
            .Cells(GRID_HEADER_COL_RAND).Value = "守／攻"
            With .Cells(GRID_COL_ATK)
                .Value = mlngTableEnemyD(nEnemy)
            End With
            With .Cells(GRID_COL_DEF)
                .Value = mlngTableEnemyA(nEnemy)
            End With
        End With
        With .Rows(GRID_EXTRA_ROW_MAX)
            .Cells(GRID_HEADER_COL_RAND).Value = "最大"
            With .Cells(GRID_COL_ATK)
                lngDamage = mlngAtkDamage(nEnemy, NUM_RAND_RANGES - 1)
                .Style.BackColor = DetermineBackColor(
                        ColoringMode.COLOR_MODE_ATK_DAMAGE, lngDamage,
                        lngEnemyHP, lngEnemyAtk, Color.LightYellow)
                .Value = lngDamage
            End With
            With .Cells(GRID_COL_DEF)
                lngDamage = mlngDefDamage(nEnemy, NUM_RAND_RANGES - 1)
                .Style.BackColor = DetermineBackColor(
                        ColoringMode.COLOR_MODE_DEF_DAMAGE, lngDamage,
                        lngEnemyHP, lngEnemyAtk, Color.LightYellow)
                .Value = lngDamage
            End With
        End With
        With .Rows(GRID_EXTRA_ROW_MIN)
            .Cells(GRID_HEADER_COL_RAND).Value = "最小"
            With .Cells(GRID_COL_ATK)
                lngDamage = mlngAtkDamage(nEnemy, 0)
                .Style.BackColor = DetermineBackColor(
                        ColoringMode.COLOR_MODE_ATK_DAMAGE, lngDamage,
                        lngEnemyHP, lngEnemyAtk, Color.LightYellow)
                .Value = lngDamage
            End With
            With .Cells(GRID_COL_DEF)
                lngDamage = mlngDefDamage(nEnemy, 0)
                .Style.BackColor = DetermineBackColor(
                        ColoringMode.COLOR_MODE_DEF_DAMAGE, lngDamage,
                        lngEnemyHP, lngEnemyAtk, Color.LightYellow)
                .Value = lngDamage
            End With
        End With
        With .Rows(GRID_EXTRA_ROW_AVERAGE)
            .Cells(GRID_HEADER_COL_RAND).Value = "平均"
            With .Cells(GRID_COL_ATK)
                lngSumValue = mlngAtkDamage(nEnemy, TABLE_EXTRA_INDEX_SUM)
                lngDamage = Int(lngSumValue / NUM_RAND_RANGES)
                .Style.BackColor = DetermineBackColor(
                        ColoringMode.COLOR_MODE_ATK_DAMAGE, lngDamage,
                        lngEnemyHP, lngEnemyAtk, Color.LightYellow)
                .Value = Format$(lngSumValue / NUM_RAND_RANGES, "#0.0##")
            End With
            With .Cells(GRID_COL_DEF)
                lngSumValue = mlngDefDamage(nEnemy, TABLE_EXTRA_INDEX_SUM)
                lngDamage = Int(lngSumValue / NUM_RAND_RANGES)
                .Style.BackColor = DetermineBackColor(
                        ColoringMode.COLOR_MODE_DEF_DAMAGE, lngDamage,
                        lngEnemyHP, lngEnemyAtk, Color.LightYellow)
                .Value = Format$(lngSumValue / NUM_RAND_RANGES, "#0.0##")
            End With
        End With
        With .Rows(GRID_EXTRA_ROW_HP)
            .Cells(GRID_HEADER_COL_RAND).Value = "HP"
            .Cells(GRID_COL_ATK).Value = mlngTableEnemyHP(nEnemy)
            .Cells(GRID_COL_DEF).Value = ""
        End With
    End With
End Sub

''========================================================================
Private Sub SortList(
        ByRef lpSortResult() As Integer, ByRef lpData() As Integer,
        ByVal nStart As Integer, ByVal nEnd As Integer,
        ByVal eSortOrder As SortOrder)
''--------------------------------------------------------------------
''    データ順にソートする
''--------------------------------------------------------------------

    Dim i As Integer, j As Integer
    Dim blnUsed() As Boolean
    Dim lngCurValue As Integer
    Dim lngMinIndex As Integer
    Dim lngMinValue As Integer

    ReDim lpSortResult(nEnd)

    If (eSortOrder = SortOrder.SORT_ORDER_NONE) Then
        For i = nStart To nEnd
            lpSortResult(i) = i
        Next
        Exit Sub
    End If

    ReDim blnUsed(nEnd)
    For i = 0 To nEnd
        blnUsed(i) = False
    Next

    For i = nStart To nEnd
        lngMinValue = 99999999
        lngMinIndex = -1
        For j = nStart To nEnd
            If (blnUsed(j) = True) Then
                Continue For
            End If

            If (eSortOrder = SortOrder.SORT_ORDER_DESCENDING) Then
                lngCurValue = -lpData(j)
            Else
                lngCurValue = lpData(j)
            End If

            If (lngCurValue < lngMinValue) Then
                lngMinIndex = j
                lngMinValue = lngCurValue
            End If
        Next j

        lpSortResult(i) = lngMinIndex
        blnUsed(lngMinIndex) = True
    Next i

End Sub

''========================================================================
Private Sub UpdateDamageTable(
        ByVal nMode As Long, ByVal nEnemy As Long,
        ByVal eColSortOrder As SortOrder,
        ByVal eRowSortOrder As SortOrder)
''--------------------------------------------------------------------
''    ダメージのリストを表示する
''--------------------------------------------------------------------

    Dim lngRand As Integer
    Dim Y As Integer

    With grdDamage
        .RowCount = NUM_RAND_RANGES + NUM_HEADER_ROWS
        If (nMode = 2) Then
            .ColumnCount = 3
        Else
            .ColumnCount = NUM_MONSTERS + NUM_FIXED_COLUMNS
        End If
        With .Columns(GRID_HEADER_COL_RAND)
            .HeaderText = "乱数"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 48
            .Frozen = True
        End With
        With .Rows(NUM_HEADER_ROWS - 1)
            .Frozen = True
        End With

        For lngRand = 0 To NUM_RAND_RANGES - 1
            If (eRowSortOrder = SortOrder.SORT_ORDER_DESCENDING) Then
                Y = NUM_RAND_RANGES - 1 - lngRand
            Else
                Y = lngRand
            End If
            With .Rows(Y + NUM_HEADER_ROWS)
                With .Cells(GRID_HEADER_COL_RAND)
                    .Value = lngRand + RAND_RANGE_MIN
                    .Style.BackColor = Color.LightGray
                End With
            End With
        Next lngRand

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
        With .Rows(GRID_EXTRA_ROW_HP)
            With .Cells(GRID_HEADER_COL_RAND)
                .Value = "HP"
                .Style.BackColor = Color.LightGray
            End With
        End With
    End With

    If (nMode = 0) Then
        ' 敵を攻撃した時のダメージ
        ShowEnemiesDamageTableData(
                mlngAtkDamage, mlngTableEnemyD, "守備力",
                eColSortOrder, eRowSortOrder,
                ColoringMode.COLOR_MODE_ATK_DAMAGE)
        Exit Sub
    ElseIf (nMode = 1) Then
        ' 敵の攻撃を受けた時のダメージ
        ShowEnemiesDamageTableData(
                mlngDefDamage, mlngTableEnemyA, "攻撃力",
                eColSortOrder, eRowSortOrder,
                ColoringMode.COLOR_MODE_DEF_DAMAGE)
        Exit Sub
    Else
        '特定の敵との戦闘
        ShowOneEnemyDamageTableData(nEnemy, eRowSortOrder)
    End If

End Sub

''========================================================================
Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
''--------------------------------------------------------------------
''    「終了」ボタンのクリックイベントハンドラ
''--------------------------------------------------------------------

    Me.Close()
End Sub

''========================================================================
Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
''--------------------------------------------------------------------
''    「計算」ボタンのクリックイベントハンドラ
''--------------------------------------------------------------------

    RunCalcButtonHandler()
End Sub

''========================================================================
Private Sub Damage_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles Me.FormClosing
''--------------------------------------------------------------------
''    フォームのクローズイベントハンドラ
''--------------------------------------------------------------------

    With My.Settings
        .WindowLeft = Me.Left
        .WindowTop = Me.Top

        .Level = updLevel.Value
        .Power = updPower.Value
        .Weapon = updWeapon.Value
        .Shield = updShield.Value

        .Mode0Checked = optMode0.Checked
        .Mode1Checked = optMode1.Checked
        .Mode2Checked = optMode2.Checked

        .ColSort = cmbColSort.SelectedIndex

        .Save()
    End With

End Sub

''========================================================================
Private Sub Damage_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
''--------------------------------------------------------------------
''    フォームのロードイベントハンドラ
''--------------------------------------------------------------------
    Dim i As Integer

    ' 初期化中のイベントの処理を無効化しておく
    mblnFlagEvent = False

    mColSortOrder = SortOrder.SORT_ORDER_ASCENDING
    mRowSortOrder = SortOrder.SORT_ORDER_DESCENDING

    With cmbColSort
        .SelectedIndex = mColSortOrder
    End With
    With cmbRowSort
        .SelectedIndex = mRowSortOrder - 1
    End With

    ' テーブルデータをロードする
    LoadTableData()

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

    ' コントロールの初期化
    With My.Settings
        Me.Left = .WindowLeft
        Me.Top = .WindowTop

        updLevel.Value = .Level
        updPower.Value = .Power
        updWeapon.Value = .Weapon
        updShield.Value = .Shield

        optMode0.Checked = .Mode0Checked
        optMode1.Checked = .Mode1Checked
        optMode2.Checked = .Mode2Checked
    End With

    mblnFlagEvent = True
    RunCalcButtonHandler()
End Sub

''========================================================================
Private Sub Damage_Resize(sender As Object, e As EventArgs) _
        Handles Me.Resize
''--------------------------------------------------------------------
''    フォームのリサイズイベントハンドラ
''--------------------------------------------------------------------

    If mblnFlagEvent = False Then Exit Sub

    With grdDamage
        .Width = Me.Width - 32
        .Height = Me.Height - 196
    End With
End Sub

''========================================================================
Private Sub updLevel_ValueChanged(sender As Object, e As EventArgs) _
    Handles updLevel.ValueChanged
''--------------------------------------------------------------------
''    アップダウンの値が変更された時のイベントハンドラ
''--------------------------------------------------------------------

    If mblnFlagEvent = False Then Exit Sub
    RunCalcButtonHandler()
End Sub

''========================================================================
Private Sub updPower_ValueChanged(sender As Object, e As EventArgs) _
    Handles updPower.ValueChanged
''--------------------------------------------------------------------
''    アップダウンの値が変更された時のイベントハンドラ
''--------------------------------------------------------------------

    If mblnFlagEvent = False Then Exit Sub
    RunCalcButtonHandler()
End Sub

''========================================================================
Private Sub updShield_ValueChanged(sender As Object, e As EventArgs) _
    Handles updShield.ValueChanged
''--------------------------------------------------------------------
''    アップダウンの値が変更された時のイベントハンドラ
''--------------------------------------------------------------------

    If mblnFlagEvent = False Then Exit Sub
    RunCalcButtonHandler()
End Sub

''========================================================================
Private Sub updWeapon_ValueChanged(sender As Object, e As EventArgs) _
    Handles updWeapon.ValueChanged
''--------------------------------------------------------------------
''    アップダウンの値が変更された時のイベントハンドラ
''--------------------------------------------------------------------

    If mblnFlagEvent = False Then Exit Sub
    RunCalcButtonHandler()
End Sub

''========================================================================
Private Sub optMode_CheckedChanged(sender As Object, e As EventArgs) _
    Handles optMode0.CheckedChanged, _
            optMode1.CheckedChanged, _
            optMode2.CheckedChanged
''--------------------------------------------------------------------
''    ラジオボタン選択時のイベントハンドラ
''--------------------------------------------------------------------

    If mblnFlagEvent = False Then Exit Sub

    cmbEnemy.Enabled = optMode2.Checked
    RunCalcButtonHandler()
End Sub

''========================================================================
Private Sub cmbEnemy_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles cmbEnemy.SelectedIndexChanged
''--------------------------------------------------------------------
''    ドロップダウンリスト選択時のイベントハンドラ
''--------------------------------------------------------------------

    If mblnFlagEvent = False Then Exit Sub
    RunCalcButtonHandler()
End Sub

''========================================================================
Private Sub cmbSort_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles cmbColSort.SelectedIndexChanged, _
            cmbRowSort.SelectedIndexChanged
''--------------------------------------------------------------------
''    ドロップダウンリスト選択時のイベントハンドラ
''--------------------------------------------------------------------

    If mblnFlagEvent = False Then Exit Sub
    RunCalcButtonHandler()
End Sub

End Class
