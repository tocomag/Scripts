using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float radius;
    [SerializeField] private float longtitudeInterval; // 緯度
    [SerializeField] private float latitudeInterval; // 経度
    [SerializeField] private int layer;
    [SerializeField] private float reductionRatioPerLayer;

    void Start()
    {
        GenerateSphere();
    }
    public void GenerateSphere()
    {
        float local_radius = radius;
        for (int l = 0; l < layer; l++)
        {
            for (float lo = longtitudeInterval; lo < 360f - longtitudeInterval; lo+=longtitudeInterval)
            {
                for (float la = latitudeInterval; la <= 180f - latitudeInterval; la+=latitudeInterval)
                {
                    float lo_rad = lo * Mathf.Deg2Rad;
                    float la_rad = la * Mathf.Deg2Rad;
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
