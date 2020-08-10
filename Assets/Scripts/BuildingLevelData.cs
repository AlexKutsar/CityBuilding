using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceForConstruction
{
    [Tooltip("Тип ресурса")] public ResourceType ResourceType;
    [Tooltip("Количество ресурса для строительства")] public int CostConstruction;
    [Tooltip("Количество возвращаемого ресурса при удалении")] public int CostDelete;
}
[System.Serializable]
[CreateAssetMenu(menuName = "Building/Building Level", fileName = "New Level Building")]
public class BuildingLevelData : ScriptableObject
{
    [Header("Строительство")]
    [Tooltip("Список ресурсов для строительства")] public List<ResourceForConstruction> resourcesForConstruction = new List<ResourceForConstruction>();
    [Tooltip("Время постройки")] public float TimeConstruction;
    

}
