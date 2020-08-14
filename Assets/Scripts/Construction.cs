using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Construction : MonoBehaviour
{
    //public Building BuildingForConstruction = null;

    [SerializeField] private Resources _resources = null;

    private int _amountNeedResource = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool BuyBuilding(Building building)
    {
        if (CheckAllNeedResourse(building))
        {
            TakeAwayResources(building);
            return true;
        }
        else return false;
    }
    public bool BuyRoad(Road road)
    {
        if (CheckAllNeedResourseRoad(road))
        {
            TakeAwayResourcesRoad(road);
            return true;
        }
        else return false;
    }
    // написать перегрузку методов
    private bool CheckAllNeedResourseRoad(Road road)
    {
        _amountNeedResource = road.ResourcesForConstruction.Count;
        for (int i = 0; i < _amountNeedResource; i++)
        {
            ResourceForConstruction resource = road.ResourcesForConstruction[i];
            if (!CheckAmountResource(resource.ResourceType, resource.CostConstruction)) return false;
        }
        return true;
    }

    private bool CheckAllNeedResourse(Building building)
    {
        _amountNeedResource = building.LevelsData[building.CurrentLevel].resourcesForConstruction.Count;
        for (int i = 0; i < _amountNeedResource; i++)
        {
            ResourceForConstruction resource = building.LevelsData[building.CurrentLevel].resourcesForConstruction[i];
            if (!CheckAmountResource(resource.ResourceType, resource.CostConstruction)) return false;
        }
        return true;
    }
    private bool CheckAmountResource(ResourceType resourceType, int value)
    {
        int amountHaveRecource = _resources.resourcesData[_resources.FindIndexResourceInList(resourceType)].currentValue;
        return (amountHaveRecource >= value);
    }

    private void TakeAwayResources(Building building)
    {
        for (int i = 0; i < _amountNeedResource; i++)
        {
            ResourceForConstruction resource = building.LevelsData[building.CurrentLevel].resourcesForConstruction[i];
            ResourcesData needRecource = _resources.resourcesData[_resources.FindIndexResourceInList(resource.ResourceType)];
            needRecource.ChangeAmountResource.Invoke(resource.ResourceType, -resource.CostConstruction);
        }
    }
    private void TakeAwayResourcesRoad(Road road)
    {
        for (int i = 0; i < _amountNeedResource; i++)
        {
            ResourceForConstruction resource = road.ResourcesForConstruction[i];
            ResourcesData needRecource = _resources.resourcesData[_resources.FindIndexResourceInList(resource.ResourceType)];
            needRecource.ChangeAmountResource.Invoke(resource.ResourceType, -resource.CostConstruction);
            
        }
    }
}
