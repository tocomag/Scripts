using UnityEngine;

[CreateAssetMenu(fileName = "BoardSettings", menuName = "Game/BoardSettings")]
public class BoardSettings : ScriptableObject
{
    public float radius;
    public float longtitudeInterval;
    public float latitudeInterval;
    public int layer;
    public float reductionRatioPerLayer;
}
