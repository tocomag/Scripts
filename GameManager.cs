using UnityEngine;
public class GameManager : MonoBehaviour
{
    private BoardSettings stgs;
    private Board board;
    void Awake()
    {
        var bFactory = new BoardFactory(stgs);
        board = bFactory.CreateBoard();
    }
}