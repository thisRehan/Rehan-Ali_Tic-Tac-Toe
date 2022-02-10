using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    int noOfRows;
    int noOfColumns;
    List<List<int>> list;
    int[,] array;
    public Matrix(int[,] array2D)
    {
        ArrayToList(array2D);
    }
    public Matrix(int row, int col)
    {
        list = new List<List<int>>();
        for(int i=0; i<row; i++)
        {
            list.Add(new List<int>());
            for(int j=0; j<col; j++)
            {
                list[i].Add(0);
            }
        }
    }
    public void ArrayToList(int[,] array)
    {
        noOfRows = array.GetLength(0);
        noOfColumns = array.GetLength(1);
        list = new List<List<int>>();
        for(int row=0; row<noOfRows; row++)
        {
            list.Add(new List<int>());
            for(int col=0; col<noOfColumns; col++)
            {
                list[row].Add(array[row, col]);
            }
        }
    }
    public void Display()
    {
        string matrix = "";
        for (int row = 0; row < list.Count; row++)
        {
            for (int col = 0; col < list[1].Count; col++)
            {
                matrix = matrix + list[row][col] + "  ";
            }
            matrix = matrix + "\n";
        }
        Debug.Log(matrix);
    }
    public void Display(List<List<int>> list)
    {
        string matrix = "";
        for (int row = 0; row < list.Count; row++)
        {
            for (int col = 0; col < list[1].Count; col++)
            {
                matrix = matrix + list[row][col] + "  ";
            }
            matrix = matrix + "\n";
        }
        Debug.Log(matrix);
    }
    public void setElement(int rowIndex, int colIndex, int value)
    {
        if (rowIndex<list.Count && colIndex<list[1].Count)
        {
            list[rowIndex][colIndex] = value;
        }
        else
            Debug.LogError("No. of Row or Col does not exist");
    }
    public int getElement(int rowIndex, int colIndex)
    {
        if (rowIndex < list.Count && colIndex < list[0].Count)
        {
           int value = (list[rowIndex][colIndex]);
            return value;
        }
        else
        {
            Debug.LogError("No. of Row or Col does not exist");
            return 0;
        }
    }
    public void ScalarAddition(int number)
    {
        for(int row=0; row<list.Count; row++)
        {
            for(int col=0; col<list[1].Count; col++)
            {
                list[row][col] = list[row][col] + number;
            }
        }
    }
    public void ScalarSubstraction(int number)
    {
        for(int row=0; row<list.Count; row++)
        {
            for(int col=0; col<list[1].Count; col++)
            {
                list[row][col] = list[row][col] - number;
            }
        }
    }
    public void ScalarMultiplication(int number)
    {
        for (int row = 0; row<list.Count; row++)
        {
            for (int col = 0; col<list[1].Count; col++)
            {
                list[row][col] = list[row][col] * number;
            }
        }
    }
    public void ScalarDivision(int number)
    {
        for (int row = 0; row<list.Count; row++)
        {
            for (int col = 0; col<list[1].Count; col++)
            {
                list[row][col] = list[row][col] / number;
            }
        }
    }    public void Addition(Matrix toAdd)
    {
        if (list.Count == toAdd.noOfRows && list[1].Count == toAdd.noOfColumns)
        {
            List<List<int>> list1 = new List<List<int>>();
            for (int row = 0; row<list.Count; row++)
            {
                list1.Add(new List<int>());
                for (int col = 0; col<list[1].Count; col++)
                {
                    list1[row].Add((list[row][col] + toAdd.list[row][col]));
                }
            }
            Display(list1);
        }
        else
            Debug.LogError("Order of matrices nust be same");
    }

    public void Subtraction(Matrix toSubtract)
    {
        if (list.Count == toSubtract.noOfRows && list[1].Count == toSubtract.noOfColumns)
        {
            List<List<int>> list1 = new List<List<int>>();
            for (int row = 0; row < list.Count; row++)
            {
                list1.Add(new List<int>());
                for (int col = 0; col < list[1].Count; col++)
                {
                    list1[row].Add(list[row][col] + toSubtract.list[row][col]);
                }
            }
            Display(list1);
        }
        else
            Debug.LogError("Order of matrices nust be same");
    }
    public void ReplaceMatrixWith(int num)
    {
        for(int row=0; row<list.Count; row++)
        {
            for(int col=0; col<list[1].Count; col++)
            {
                list[row][col] = num;
            }
        }
    }
    public void swapRows(int row1, int row2)
    {
        if (row1 < list.Count && row2 < list.Count)
        {
            int temp = 0;
            for (int col = 0; col < list[1].Count; col++)
            {
                temp = list[row2][col];
                list[row2][col] = list[row1][col];
                list[row1][col] = temp;
            }
        }
        else
            Debug.LogError("Row does not exist");
    }
    public void swapCols(int col1, int col2)
    {
        if (col1 < list[1].Count && col2 < list[1].Count)
        {
            int temp = 0;
            for (int row = 0; row < list.Count; row++)
            {
                temp = list[row][col1];
                list[row][col1] = list[row][col2];
                list[row][col2] = temp;
            }
        }
        else
            Debug.LogError("Column does not exist");
    }
    public void ReplaceRowWith(int rowIndex, int number)
    {
        if (rowIndex < list.Count)
        {
            for (int col = 0; col < list[1].Count; col++)
            {
                list[rowIndex][col] = number;
            }
        }
        else
            Debug.LogError("Row does not exist");
    }
    public void ReplaceColWith(int colIndex, int number)
    {
        if (colIndex < list[1].Count)
        {
            for (int row = 0; row < list.Count; row++)
            {
                list[row][colIndex] = number;
            }
        }
        else
            Debug.LogError("Column does not exist");
    }
    public bool isRowSame(int r1Index, int r2Index)
    {
        if (r1Index < list.Count && r2Index < list.Count)
        {
            bool same = true;
            for (int col=0; col<list[1].Count; col++)
            {
                if (list[r1Index][col] != list[r2Index][col])
                    same = false;
            }
            return same;
        }
        else
        {
            Debug.LogError("Row does not exist");
            return false;
        }
            
    }
    public bool isColSame(int col1Index, int col2Index)
    {
        if(col1Index < list[1].Count && col2Index < list[1].Count)
        {
            bool same = true;
            for (int row=0; row<list.Count; row++)
            {
                if (list[row][col1Index] != list[row][col2Index])
                    same = false;
            }
            return same;
        }
        else
        {
            Debug.LogError("Column does not exist");
            return false;
        }
            
    }
    public bool IsDiagonalSame()
    {
        if(list.Count == list[1].Count)
        {
            bool Isdiagonal = true;
            int row = 0;
            int col = 0;
            for (int k=1; k<list.Count; k++)
            {
                if (list[row][col] != list[row+1][col+1])
                    Isdiagonal = false;
                row++;
                col++;
            }
            return Isdiagonal;
        }
        else
        {
            Debug.LogError("Matrix must be square");
            return false;
        }
            
    }
    public bool IsInverseDiagonalSame()
    {
        if (list.Count == list[1].Count)
        {
            bool inverseDiagonal = true;
            int row = 0;
            int col = list[1].Count - 1;
            for (int k=1; k<list.Count; k++)
            {
                if (list[row][col] != list[row+1][col-1])
                    inverseDiagonal = false;
                row++;
                col--;
            }
            return inverseDiagonal;
        }
        else
        {
            Debug.LogError("Matrix must be square");
            return false;
        }
    }
    public void setDiagonal(int number)
    {
        if(list.Count == list[1].Count)
        {
            int row = 0;
            int col = 0;
            for(int i=0; i<list.Count; i++)
            {
                list[row][col] = number;
                row++;
                col++;
            }
        }
        else
            Debug.LogError("Matrix must be square");
    }
    public void setInverseDiagonal(int number)
    {
        if(list.Count == list[1].Count)
        {
            int row = 0;
            int col = list[1].Count - 1;
            for(int i=0; i<list.Count; i++)
            {
                list[row][col] = number;
                row++;
                col--;
            }
        }
        else
            Debug.LogError("Matrix must be square");
    }
    public void Multiplication(int[,] array1, int[,] array2)
    {
        if (array1.GetLength(1) == array2.GetLength(0))
        {
            int[,] array3 = new int[array1.GetLength(0), array2.GetLength(1)];
            for (int row = 0; row < array1.GetLength(0); row++)
            {
                for (int col = 0; col < array2.GetLength(1); col++)
                {
                    for (int i = 0; i < array1.GetLength(1); i++)
                    {
                        array3[row, col] = array3[row, col] + (array1[row, i] * array2[i, col]);
                    }
                }
            }
        }
        else
            Debug.Log("Multiplication not Possible");
    }
    public void Determinant(int[,] array)// Only work for [2,2] matrices.
    {
        int answer = 0;
        if (array.GetLength(0) == array.GetLength(1))
        {
            answer = (array[0, 0] * array[1, 1]) - (array[0, 1] * array[1, 0]);
            Debug.Log(answer);
        }
        else
            Debug.Log("Determinant not Possible");
    }
    public void Transpose()
    {
        int[,] array1 = new int[list[1].Count, list.Count];
        for(int row = 0; row<list.Count; row++)
        {
            for(int col =0; col<list[1].Count; col++)
            {
                array1[col, row] = list[row][col];
            }
        }
    }
    public bool isColSame(int col)
    {
        bool same = true;
        for (int row = 0; row < list.Count - 1; row++)
        {
            if (list[row][col] != list[row + 1][col])
                same = false;
        }
        return same;
    }
    public bool isRowSame(int row)
    {
        bool same = true;
        for(int col=0; col<list[1].Count -1; col++)
        {
            if (list[row][col] != list[row][col+1])
                same = false;
        }
        return same;
    }
}

