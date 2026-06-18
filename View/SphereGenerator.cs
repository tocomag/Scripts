using UnityEngine;

public class SphereGenerator : MonoBehaviour // 球状に盤面を生成するFactoryクラス
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float radius;
    [SerializeField] private float longtitudeInterval; // 緯度
    [SerializeField] private float latitudeInterval; // 経度
    [SerializeField] private int layer;
    [SerializeField] private float reductionRatioPerLayer; // 半径の縮小率

    void Start()
    {
        GenerateSphere();
    }
    public void GenerateSphere()
    {
        int loCount = (int)(360f / longtitudeInterval); // 縦線の数
        int laCount = (int)(180f / latitudeInterval); // 横線の数
        float local_radius = radius;
        for (int l = 0; l < layer; l++)
        {
            for (int lo = 0; lo < loCount; lo++)
            {
                for (int la = 0; la < laCount; la++)
                {
                    if (la == 0) continue;
                    float lo_rad = lo * longtitudeInterval * Mathf.Deg2Rad;
                    float la_rad = la * latitudeInterval * Mathf.Deg2Rad;
                    Vector3 pos = new Vector3
                    (
                        local_radius * Mathf.Cos(lo_rad) * Mathf.Sin(la_rad) + transform.position.x,
                        local_radius * Mathf.Cos(la_rad) + transform.position.y,
                        local_radius * Mathf.Sin(lo_rad) * Mathf.Sin(la_rad) + transform.position.z
                    );
                    Instantiate(prefab, pos, Quaternion.identity, transform);
                }
            }
            local_radius *= reductionRatioPerLayer; // 内側の層は半径が縮む
        }   
    }
}