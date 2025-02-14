using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    private GridXY<TestGridObject> grid;

    void Start()
    {
        grid = new GridXY<TestGridObject>(16, 9, 10f, new Vector3(20, 0), (GridXY<TestGridObject> g, int x, int y) => new TestGridObject(g, x, y));
    }

   
}

public class TestGridObject
{

    private GridXY<TestGridObject> grid;
    private int x;
    private int y;
    private int value;

    public TestGridObject(GridXY<TestGridObject> _grid, int _x, int _y)
    {
        grid = _grid;
        x = _x;
        y = _y;
    }

    public void AddValue(int addValue)
    {
        value +=addValue;
        grid.TriggerGridobjectChanged(x, y);
    }
}
