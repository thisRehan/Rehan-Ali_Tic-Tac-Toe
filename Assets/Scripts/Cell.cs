using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public int row;
    public int col;
    public enum Status { circle, cross, loose, win, none }
    Status state;
    public delegate void statusUpdate(Status state);
    public event statusUpdate cellstatusupdate;
    public delegate void updateStatus(int row, int col);
    public updateStatus cellStatusUpdate;
    public Cell()
    {
        row = 0;
        col = 0;
        state = Status.none;
    }
    public Cell(int Row, int Col)
    {
        row = Row;
        col = Col;
        state = Status.none;
    }
    public int getRow()
    {
        return row;
    }
    public int getCol()
    {
        return col;
    }
    public void setStatus(Status state)
    {
        this.state = state;
        cellstatusupdate?.Invoke(state);
    }
    public Status getStatus()
    {
        return state;
    }
    public void Interaction()
    {
        setStatus(Status.win);
    }
}
