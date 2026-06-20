using System.Collections.Generic;
using UnityEngine;

public class BoardFactory // 内部処理で扱う盤面情報を生成するFactoryクラス
{
    private BoardSettings stgs;
    public BoardFactory(BoardSettings stgs)
    {
        this.stgs = stgs;
    }
    private int[,] neighbors =
    {
        {-1,-1},{0,-1},{1,-1},
        {-1,0},        {1,0},
        {-1,1},{0,1},{1,1}
    };

    public Board CreateBoard()
    {
        int loCount = (int)(360f / stgs.longtitudeInterval);
        int laCount = (int)(180f / stgs.latitudeInterval);
        Cell[,,] cells = new Cell[stgs.layer, loCount, laCount];
        for (int l = 0; l < stgs.layer; l++)
        {
            for (int lo = 0; lo < loCount; lo++) // y=0のマスは重複しないよう存在しない
            {
                for (int la = 1; la < laCount; la++)
                {
                    // Debug.Log($"({l},{lo},{la})という添え字番号にCellが格納されました");
                    cells[l, lo, la] = new Cell(l, lo, la, stgs.cellHealth, false, false, false, 0);
                }
            }
        }

        var mines = new List<Cell>();
        while (mines.Count < stgs.mines) // 指定数の地雷を生成する
        {
            int x = Random.Range(0, loCount);
            int y = Random.Range(1, laCount);
            int layer = Random.Range(0, stgs.layer);
            Cell cell = cells[layer, x, y];
            if (cell.isMine) continue;
            cell.isMine = true;
            Debug.Log($"({layer},{x},{y})に地雷が設置されました");
            mines.Add(cell);
            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                int nx = x + neighbors[i, 0];
                int ny = y + neighbors[i, 1]; // y=0のマスは重複しないよう存在しない
                if (ny <= 0 || ny >= laCount) continue;
                int true_nx = (nx % loCount + loCount) % loCount; // x座標が球を循環するようにしてる(mod的考え方)
                Cell neighbor_cell = cells[layer, true_nx, ny];
                neighbor_cell.aroundMineCount++;
                Debug.Log($"({layer},{true_nx},{ny})が地雷に近接しているマスです");
            }
        }
        return new Board(cells);
    }
}