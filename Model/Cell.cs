public class Cell // １マスの情報を持つデータクラス
{
    public int layer;
    public int x;
    public int y;
    public bool isMine; // 地雷である
    public bool isFlagged; // 旗である
    public bool isRevealed; // 開きである
    public int aroundMineCount; //　周囲の地雷数
    public Cell(int layer, int x, int y, bool isMine, bool isFlagged, bool isRevealed, int aroundMineCount)
    {
        this.layer = layer;
        this.x = x;
        this.y = y;
        this.isMine = isMine;
        this.isFlagged = isFlagged;
        this.isRevealed = isRevealed;
        this.aroundMineCount = aroundMineCount;
    }
}