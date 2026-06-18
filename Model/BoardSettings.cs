using UnityEngine;

[CreateAssetMenu(fileName = "BoardSettings", menuName = "Game/BoardSettings")]
public class BoardSettings : ScriptableObject
{
    public float radius;
    public float longtitudeInterval; // 緯度
    public float latitudeInterval; // 経度
    public int layer;
    public float reductionRatioPerLayer; // 半径の縮小率
    public int mines; // 盤面に存在する地雷の総数
}
