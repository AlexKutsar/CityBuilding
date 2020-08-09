using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ResourceForConstruction
{
    public ResourceType resourceType;
    public int costConstruction;
    public int costDelete;
}
public class ResourcesForConstruction : ScriptableObject
{
    public int amountRecourcesForConstruction = 3;
    public List<ResourceForConstruction>[] resources;
    //public resources[] levelsBuilding = new resources[amountRecourcesForConstruction]();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CreateArray()
    {
        resources = new List<ResourceForConstruction>[amountRecourcesForConstruction];
    }
}
