using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildindGizmos : MonoBehaviour
{
    public Vector2Int positionOnGrid = Vector2Int.one;
    public Vector2Int Size = Vector2Int.one;
    [SerializeField] private Color _colorGizmos = Color.green;
    [SerializeField] private Renderer _mainRenderer = null;

    [SerializeField] private Color _normalColor;
    // Start is called before the first frame update

    private void Awake()
    {
        _normalColor = _mainRenderer.material.color;
    }
    public void SetTransparent(bool available)
    {
        if (available)
        {
            _mainRenderer.material.color = Color.green;
        }
        else
            _mainRenderer.material.color = Color.red;
    }
    public void SetNormal()
    {
        _mainRenderer.material.color = _normalColor;
    }

    private void OnDrawGizmos()
    {
        for(int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color = _colorGizmos;
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
            }
        }
    }
}
