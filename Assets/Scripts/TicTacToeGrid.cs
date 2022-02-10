using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    public int noOfRows;
    public int noOfCols;
    public List<List<Cell>> cellGrid;
    public delegate void onCellCreated(Cell cell);
    public event onCellCreated cellCreated;
    // Start is called before the first frame update
    public TicTacToeGrid(int row, int col) : base(row,col)
    {
        noOfRows = row;
        noOfCols = col;
        cellGrid = new List<List<Cell>>();
    }
    public void makeCellGrid()
    {
        for (int i = 0; i < noOfRows; i++)
        {
            cellGrid.Add(new List<Cell>());
            for (int j = 0; j < noOfCols; j++)
            {
                cellGrid[i].Add(new Cell(i,j));
                cellCreated?.Invoke(cellGrid[i][j]);
                setElement(i, j, (int)Cell.Status.none);
            }
        }
    }
    public void show()
    {
        for(int i=0; i<2; i++)
        {
            for(int j=0; j<2; j++)
            {
                Debug.Log(cellGrid[i][j]);
            }
        }
    }
    public bool checkWin()
    {
        if (checkRowWin())
            return true;
        if (checkColWin())
            return true;
        if (checkDiagonalWin())
            return true;
        if (checkInverseDiagonal())
            return true;
        return false;
    }
    public bool checkRowWin()
    {
        for(int i=0; i<noOfRows; i++)
        {
            if (isRowSame(i))
                return true;
        }
        return false;
    }
    public bool checkColWin()
    {
        for (int i = 0; i < noOfCols; i++)
        {
            if (isColSame(i))
                return true;
        }
        return false;
    }
    public bool checkDiagonalWin()
    {
        if (IsDiagonalSame())
            return true;
        else
            return false;
    }
    public bool checkInverseDiagonal()
    {
        if (IsInverseDiagonalSame())
            return true;
        else
            return false;
    }
}
