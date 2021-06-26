Public Class Damage

    ' ステータステーブル
    Private mlngTableAttack() As Long       ' 基本攻撃力
    Private mlngTableEnemyA() As Long       ' 敵の攻撃力
    Private mlngTableEnemyD() As Long       ' 敵の守備力

    ' 与えるダメージ／受けるダメージ
    Private mlngAtkDamage() As Long
    Private mlngDefDamage() As Long

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

End Class
