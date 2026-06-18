public class Board // 盤面情報をCellの3次配列として持つデータクラス
{
    public Cell[,,] cells;
    public Board(Cell[,,] cells)
    {
        this.cells = cells;
    }
}