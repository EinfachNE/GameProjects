using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class GridXY<TGridObject>
{
    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }
    private int width, height;
    private float cellSize;
    private Transform standartTransform;
    private Vector3 originPosition;
    private TGridObject[,] gridArray;

    public GridXY(int _width, int _height, float _cellSize, Vector3 _originPosition, Transform _standartTransform, Func<GridXY<TGridObject>, int, int, Transform, TGridObject> createGridObject)
    {

        width = _width;
        height = _height;
        cellSize = _cellSize;
        originPosition = _originPosition;
        standartTransform = _standartTransform;

        gridArray = new TGridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                gridArray[x, y] = createGridObject(this, x, y, standartTransform);
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }
    public void GetXY(Vector3 worldposition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldposition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldposition - originPosition).y / cellSize);
    }
    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
            gridArray[x, y] = value;
        if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }

    public void TriggerGridobjectChanged(int x, int y)
    {
        if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }

    public void SetGridObject(Vector3 worldposition, TGridObject value)
    {
        int x, y;
        GetXY(worldposition, out x, out y);
        SetGridObject(x, y, value);
    }
    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }

        else
        {
            return default(TGridObject);
        }
    }
    public TGridObject GetGridObject(Vector3 worldposition)
    {
        int x, y;
        GetXY(worldposition, out x, out y);
        return GetGridObject(x, y);
    }
}


