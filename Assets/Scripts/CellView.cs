using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] GameObject[] status;
    Cell cell = new Cell();
    // Start is called before the first frame update
    void Start()
    {
        cell.cellstatusupdate += setStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setStatus(Cell.Status state)
    {
        for(int i=0; i<status.Length; i++)
        {
            if (i == (int)state)
            {
                status[i].SetActive(true);
            }
            else
                status[i].SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        cell.Interaction();
    }
    private void OnDestroy()
    {
        cell.cellstatusupdate -= setStatus;
    }
}
