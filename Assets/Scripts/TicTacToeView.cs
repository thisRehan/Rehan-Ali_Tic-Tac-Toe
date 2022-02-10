using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeView : MonoBehaviour
{
    public int noOfRows;
    public int noOfCols;
    public float horizontalSpacing;
    public float verticalSpacing;
    public int count;
    public GameObject cellPrefab;
    TicTacToeGrid ticTacToeGrid;
    //Matrix list = new Matrix(2, 2);
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize()
    {
        ticTacToeGrid = new TicTacToeGrid(noOfRows, noOfCols);
        ticTacToeGrid.cellCreated += onCellCreated;
        ticTacToeGrid.makeCellGrid();
        ticTacToeGrid.Display();
    }
    public void onCellCreated(Cell cell)
    {
        position();
        CellView UnityCell =  Instantiate(cellPrefab, position(), transform.rotation).GetComponent<CellView>();
        count++;
    }
    public Vector3 position()
    {
        if (count == noOfRows)
        {
            horizontalSpacing = 1;
            verticalSpacing += 1.5f;
            count = 0;
        }
        else
            horizontalSpacing += 1;
        Vector3 InstantiatePosition = new Vector3(horizontalSpacing, 0, verticalSpacing);
        return InstantiatePosition;
    }
}
