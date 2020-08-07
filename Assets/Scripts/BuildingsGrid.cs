using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int _sizeGrid = new Vector2Int(10, 10);

    private Buildind[,] _grid;
    private Buildind _flyingBuilding = null;
    private Camera _camera;
    // Start is called before the first frame update
    void Awake()
    {
        _grid = new Buildind[_sizeGrid.x, _sizeGrid.y];
        _camera = Camera.main;
    }

    public void StartPlacingBuilding(Buildind buildindPrefab)
    {
        if (_flyingBuilding != null)
        {
            Destroy(_flyingBuilding);
        }

        _flyingBuilding = Instantiate(buildindPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (_flyingBuilding != null)
        {
            var groundPlace = new Plane(Vector3.up, Vector3.zero);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if(groundPlace.Raycast(ray , out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                _flyingBuilding.transform.position = new Vector3(x, 0, y);

                if(Input.GetMouseButtonDown(0))
                {
                    _flyingBuilding = null;
                }
            }
        }
    }
}
