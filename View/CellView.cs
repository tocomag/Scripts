using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] public int vL; // veiwLayer
    [SerializeField] public int vX; // viewX
    [SerializeField] public int vY; // viewY
    [SerializeField] public Collider vCol; // viewCollider
    [SerializeField] public MeshRenderer vMRen; // viewMeshRenderer
}