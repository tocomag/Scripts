using UnityEngine;
public class GameManager : MonoBehaviour
{
    public BoardSettings stgs;
    public Board board;
    void Awake()
    {
        var bFactory = new BoardFactory(stgs);
        board = bFactory.CreateBoard();
    }
}