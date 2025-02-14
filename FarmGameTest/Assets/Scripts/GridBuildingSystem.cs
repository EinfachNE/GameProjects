using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour
{
    [SerializeField] Transform testTransform;
    private GridXY<FarmPlotGridObject> grid;
    void Start()
    {
        grid = new GridXY<FarmPlotGridObject>(500, 100, 1f, new Vector3(-9, -5), (GridXY<FarmPlotGridObject> g, int x, int y) => new FarmPlotGridObject(g, x, y));
    }
    public class FarmPlotGridObject
    {
        private GridXY<FarmPlotGridObject> grid;
        private int x;
        private int y;
        private Transform transform = null;

        public FarmPlotGridObject(GridXY<FarmPlotGridObject> _grid, int _x, int _y)
        {
            grid = _grid;
            x = _x;
            y = _y;
        }
        public void SetTransform(Transform _transform)
        {
            transform = _transform;
            grid.TriggerGridobjectChanged(x,y);
        }
        public void ClearTransform()
        {
            transform = null;
        }
        public bool CanBuild()
        {
            return transform == null;
        }

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            grid.GetXY(mouseWorldPos, out int x, out int y);

            FarmPlotGridObject gridObject = grid.GetGridObject(x, y);

            if (gridObject.CanBuild())
            {
                Transform buildTransform = Instantiate(testTransform, grid.GetWorldPosition(x, y), Quaternion.identity);
                gridObject.SetTransform(buildTransform);
            }
        }
    }
}


