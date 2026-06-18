using UnityEngine;

public class CellView : MonoBehaviour
{
    public int vL; // veiwLayer
    public int vX; // viewX
    public int vY; // viewY
    [SerializeField] public Collider vCol; // viewCollider
    [SerializeField] public MeshRenderer vMRen; // viewMeshRenderer
}