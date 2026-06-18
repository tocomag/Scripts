using UnityEngine;

public class CellView : MonoBehaviour
{
    public int vL {get; set;} // veiwLayer
    public int vX {get; set;} // viewX
    public int vY {get; set;} // viewY
    [SerializeField] public Collider vCol; // viewCollider
    [SerializeField] public MeshRenderer vMRen; // viewMeshRenderer
}