using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingsGrid : MonoBehaviour
{
    
    public Vector2Int GridSize = new Vector2Int(10, 10);

    [SerializeField] private Construction _construction;

    private BuildindGizmos[,] _grid;
    private BuildindGizmos _flyingBuilding = null;
    private Camera _camera;
    // Start is called before the first frame update
    void Awake()
    {
        _grid = new BuildindGizmos[GridSize.x, GridSize.y];
        _camera = Camera.main;
        if (_construction == null) _construction = GetComponent<Construction>();
    }

    public void StartPlacingBuilding(BuildindGizmos buildindPrefab)
    {
        if (_flyingBuilding != null)
        {
            Destroy(_flyingBuilding.gameObject);
        }

        _flyingBuilding = Instantiate(buildindPrefab);
    }
    public void StopPlacingBuilding()
    {
        if (_flyingBuilding != null)
        {
            Destroy(_flyingBuilding.gameObject);
        }
        _flyingBuilding = null;
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

                bool available = true;
                if (x < 0 || x > GridSize.x - _flyingBuilding.Size.x) available = false;
                if (y < 0 || y > GridSize.y - _flyingBuilding.Size.y) available = false;

                if (available && IsPlaceTaken(x, y)) available = false;

                _flyingBuilding.transform.position = new Vector3(x, 0, y);
                _flyingBuilding.SetTransparent(available);
                if (available && Input.GetMouseButtonDown(0))
                {
                    if (EventSystem.current.IsPointerOverGameObject()) return;
                    else
                    {
                        Building building = null;
                        var isBuilding = _flyingBuilding.gameObject.TryGetComponent<Building>(out building);
                        if (_construction.BuyBuilding(building))
                        {
                            PlaceFlyingBuilding(x, y);
                        }
                    }
                }
            }

        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < _flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < _flyingBuilding.Size.y; y++)
            {
                if (_grid[placeX + x, placeY + y] != null) return true;
            }
        }
        return false;
    }
    public void PlaceFlyingBuilding(int placeX, int placeY)
    {
        var buildindPrefab = _flyingBuilding;
        for (int x = 0; x < _flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < _flyingBuilding.Size.y; y++)
            {
                _grid[placeX + x, placeY + y] = _flyingBuilding;
            }
        }
        _flyingBuilding.SetNormal();
        _flyingBuilding.positionOnGrid = new Vector2Int(placeX, placeY);
        _flyingBuilding = null;
        _flyingBuilding = Instantiate(buildindPrefab);
    }

    public void RemoveObjectFromGrid(Vector2Int position, Vector2Int sizeObject)
    {
        for (int x = 0; x < sizeObject.x; x++)
        {
            for (int y = 0; y < sizeObject.y; y++)
            {
                _grid[position.x + x, position.y + y] = null;
            }
        }
    }
}
