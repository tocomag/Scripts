using UnityEngine;

public class SphereGenerator : MonoBehaviour // 球状に盤面を生成するFactoryクラス
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private BoardSettings stgs;

    void Start()
    {
        GenerateSphere(); // いずれはGameManagerで実行する
    }
    public GameObject[,,] GenerateSphere()
    {
        int loCount = (int)(360f / stgs.longtitudeInterval); // 縦線の数
        int laCount = (int)(180f / stgs.latitudeInterval); // 横線の数
        float local_radius = stgs.radius;
        GameObject[,,] objs = new GameObject[stgs.layer, loCount, laCount];
        for (int l = 0; l < stgs.layer; l++)
        {
            for (int lo = 0; lo < loCount; lo++)
            {
                for (int la = 1; la < laCount; la++) // 一番上に置くと重なるので置かない
                {
                    float lo_rad = lo * stgs.longtitudeInterval * Mathf.Deg2Rad;
                    float la_rad = la * stgs.latitudeInterval * Mathf.Deg2Rad;
                    Vector3 pos = new Vector3
                    (
                        local_radius * Mathf.Cos(lo_rad) * Mathf.Sin(la_rad) + transform.position.x,
                        local_radius * Mathf.Cos(la_rad) + transform.position.y,
                        local_radius * Mathf.Sin(lo_rad) * Mathf.Sin(la_rad) + transform.position.z
                    );
                    GameObject obj = Instantiate(prefab, pos, Quaternion.identity, transform);
                    CellView view = obj.GetComponent<CellView>();
                    view.vL = l;
                    view.vX = lo;
                    view.vY = la;
                    objs[l, lo, la] = obj;
                }
            }
            local_radius *= stgs.reductionRatioPerLayer; // 内側の層は半径が縮む
        }
        return objs; // 表示の処理を持つクラスに渡す
    }
}