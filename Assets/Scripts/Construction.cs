using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Construction : MonoBehaviour
{
    [SerializeField] private Resources _resources = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyBuilding()
    {
        ResourcesData needRecource = _resources.resourcesData[_resources.FindIndexResourceInList(ResourceType.Gold)];
        if (needRecource.currentValue >= 10)
        {
            needRecource.ChangeAmountResource.Invoke(ResourceType.Gold, -10);
        }
    }
}
