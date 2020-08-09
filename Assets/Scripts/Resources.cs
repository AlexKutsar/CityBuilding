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
public class ResourcesData
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
        int maxSum = resourcesData[indexResource].maxValue;
        int amountCurrentResource = resourcesData[indexResource].currentValue;
        int sum = amountCurrentResource + value;
        if (sum >= maxSum) amountCurrentResource = maxSum;
        else if (sum <= 0) amountCurrentResource = 0;
        else amountCurrentResource += value;
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
            resourcesData[i].ChangeAmountResource += СhangeCurrentResourсe;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
