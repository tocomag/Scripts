public class BoardService
{
    private Board board;
    private BoardSettings stgs;
    private int loCount;
    private int laCount;
    private int[,] neighbors =
    {
        {-1,-1},{0,-1},{1,-1},
        {-1,0},        {1,0},
        {-1,1},{0,1},{1,1}
    };
    public BoardService(Board board, BoardSettings stgs)
    {
        this.board = board;
        this.stgs = stgs;
        loCount = (int)(360f / stgs.longtitudeInterval);
        laCount = (int)(180f / stgs.latitudeInterval);
    }
    /*
    指定したマスにダメージを与える処理
    上のマスが開いていないとそのマスにはダメージを与えられない
    地雷を開けたとき最大で同じ層の周囲8マスと下層の周囲9マスにダメージを与える
    地雷が開けるマスでもその上のマスが開いていないとそのマスにはダメージを与えられない
    つまり地雷は同じ層でダメージを与えられたマスの下のマスに必ずダメージを与える
    地雷は最下層で開けてしまうとポイントがマイナスされる
    層の数は大きいほど深い(内側の)層で、小さいほど浅い(外側の)層
    */
    public void Open(int layer, int x, int y)
    {
        Cell cell = board.cells[layer, x, y];
        if (layer > 0) // 最上層より下の層のマスを開いていた時
        {
            Cell upperCell = board.cells[layer - 1, x, y];
            if (!upperCell.isRevealed) return;
        }
        if (cell.isRevealed) return;
        GetDamaged(cell, stgs.playerDamage);

        if (cell.isRevealed && cell.isMine) // 地雷を踏んだ時の処理
        {
            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                int nx = x + neighbors[i, 0];
                int ny = y + neighbors[i, 1];
                if (ny <= 0 || ny >= laCount) continue;
                int true_nx = (nx % loCount + loCount) % loCount;
                Cell neighbor_cell = board.cells[layer, true_nx, ny];
                if (layer > 0) // 最上層より下の層のマスを開いていた時
                {
                    Cell upperCell = board.cells[layer - 1, true_nx, ny];
                    if (!upperCell.isRevealed) continue;
                }
                if (layer == stgs.layer - 1) continue; // 最下層で地雷が爆発したとき
                GetDamaged(neighbor_cell, stgs.mineDamage);
                Cell neighbor_cell_down = board.cells[layer + 1, true_nx, ny];
                GetDamaged(neighbor_cell_down, stgs.mineDamage);
            }
        }
    }
    public void GetDamaged(Cell cell, int damage)
    {
        if (cell.health <= 0) cell.isRevealed = true;
        cell.health -= damage;
        if (cell.health <= 0) cell.isRevealed = true;
    }
}