using System.Collections.Generic;
using UnityEngine;

public class BoardFactory // 内部処理で扱う盤面情報を生成するFactoryクラス
{
    private BoardSettings stgs;
    public BoardFactory(BoardSettings stgs)
    {
        this.stgs = stgs;
    }

    public Board CreateBoard()
    {
        int loCount = (int)(360f / stgs.longtitudeInterval);
        int laCount = (int)(180f / stgs.latitudeInterval);
        Cell[,,] cells = new Cell[stgs.layer, loCount, laCount];
        for (int l = 0; l < stgs.layer; l++)
        {
            for (int lo = 1; lo < loCount; lo++) // 一番上は重なるので考えないものとする
            {
                for (int la = 0; la < laCount; la++)
                {
                    Debug.Log($"({l},{lo},{la})という添え字番号にCellが格納されました");
                    cells[l, lo, la] = new Cell(l, lo, la, false, false, false, 0);
                }
            }
        }

        var mines = new List<Cell>();
        while (mines.Count < stgs.mines) // 指定数の地雷を生成する
        {
            int x = Random.Range(0, loCount);
            int y = Random.Range(0, laCount);
            int layer = Random.Range(0, stgs.layer);
            Cell cell = cells[layer, x, y];
            if (cell.isMine) continue;
            cell.isMine = true;
            mines.Add(cell);
        }
        return new Board(cells);
    }
}