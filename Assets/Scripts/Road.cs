using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private BuildindGizmos _buildindGizmos = null;
    // Start is called before the first frame update
    void Awake()
    {
        _buildindGizmos = GetComponent<BuildindGizmos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
