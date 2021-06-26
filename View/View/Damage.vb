Public Class Damage

    ' ステータステーブル
    Private mlngTableAttack() As Long       ' 基本攻撃力
    Private mlngTableEnemyA() As Long       ' 敵の攻撃力
    Private mlngTableEnemyD() As Long       ' 敵の守備力

    ' 与えるダメージ／受けるダメージ
    Private mlngAtkDamage() As Long
    Private mlngDefDamage() As Long

    ' イベントチェーンの抑制フラグ
    Private mblnFlagEvent As Boolean


    '------------------------------------------------------------------------------
    ' 攻撃力と守備力、及び乱数から、ダメージを計算する
    '------------------------------------------------------------------------------
    Private Function CalcDamage(ByVal nAttack As Long, ByVal nDefense As Long,
                                ByVal nRand As Long) As Long

    End Function

    '------------------------------------------------------------------------------
    ' ダメージを計算する
    '------------------------------------------------------------------------------
    Private Sub CalcDamageTable(ByVal nLevel As Long, ByVal nPower As Long, _
                                ByVal nWeapon As Long, ByVal nShield As Long)

    End Sub

    '------------------------------------------------------------------------------
    ' 計算を行う
    '------------------------------------------------------------------------------
    Private Sub RunCalcButtonHandler()
        Dim i As Integer
        Dim lngMode As Integer
        Dim lngAttack As Integer

        If mblnFlagEvent = True Then Exit Sub

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
    ' データ順にソートする
    '------------------------------------------------------------------------------
    Private Sub SortList(ByRef lpSortResult() As Long, ByRef lpData() As Long, _
                         ByVal nStart As Long, ByVal nEnd As Long)

    End Sub

    '------------------------------------------------------------------------------
    ' ダメージのリストを表示する
    '------------------------------------------------------------------------------
    Private Sub UpdateDamageTable(ByVal nMode As Long, ByVal nEnemy As Long)

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
        mblnFlagEvent = True

        ' 基本攻撃力
        ReDim mlngTableAttack(37)
        strData = "  5,  7,  9, 11, 13, 16, 19, 22, 25, 29, 33, 37, 41, 46, 51, 56, 61, 65, 71," & _
                  " 74, 77, 80, 83, 86, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99,100,100"
        For i = 1 To 37
            mlngTableAttack(i) = Val(Mid$(strData, i * 4 - 3, 3))
        Next i

        ' 敵の名前
        With cmbEnemy
            With .Items
                .Clear()
                .Add("スライム")
                .Add("ゴースト")
                .Add("ドラキー")
                .Add("おおなめくじ")
                .Add("ももんじゃ")
                .Add("リリパット")
                .Add("おばけキノコ")
                .Add("スモールグール")
                .Add("わらいぶくろ")
                .Add("イエティ")
                .Add("まどうし")
                .Add("ミイラおとこ")
                .Add("きめんどうし")
                .Add("ベビーサタン")
                .Add("マネマネ")
                .Add("キメラ")
                .Add("くさったしたい")
                .Add("ミミック")
                .Add("ばくだんいわ")
                .Add("どろにんぎょう")
                .Add("さまようよろい")
                .Add("マドハンド")
                .Add("うごくせきぞう")
                .Add("シャドー")
                .Add("ミステリードール")
                .Add("ゴーレム")
                .Add("おおめだま")
                .Add("ギガンテス")
                .Add("はぐれメタル")
                .Add("シルバーデビル")
                .Add("アークデーモン")
                .Add("ドラゴン")
            End With

            .SelectedIndex = 0
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

        mblnFlagEvent = False
    End Sub

End Class
