using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ResourceType
{
    Gold, Wood, Rock
}

[Serializable]
public struct ResourcesData
{
    public ResourceType resourceType;
    public int currentValue;
    public int maxValue;
    public UnityAction<ResourceType, int> ChangeAmountResource;
}
public class Resources : MonoBehaviour
{
    public List<ResourcesData> resourcesData = new List<ResourcesData>();

    //public UnityAction<ResourceType, int> ChangeAmountResource;
    public void СhangeCurrentResourсe(ResourceType resourceType, int value)
    {
        int indexResource = FindIndexResourceInList(resourceType);
        int sum = resourcesData[indexResource].currentValue + value;
        int maxSum = resourcesData[indexResource].maxValue;
        var resourceData = resourcesData[indexResource];
        if (sum >= maxSum) resourceData.currentValue = resourcesData[indexResource].maxValue;
        else if (sum <= 0) resourceData.currentValue = 0;
        else resourceData.currentValue += value;
        resourcesData[indexResource] = resourceData;
    }

    public int FindIndexResourceInList(ResourceType resourceType)
    {
        int index = -1;
        for (int i = 0; i < resourcesData.Count; i++)
        {
            if (resourcesData[i].resourceType == resourceType)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < resourcesData.Count; i++)
        {
            var resourceData = resourcesData[i];
            resourceData.ChangeAmountResource += СhangeCurrentResourсe;
            resourcesData[i] = resourceData;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
