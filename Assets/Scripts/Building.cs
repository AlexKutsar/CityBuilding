using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool IsResourceBuilding = false;
    public Transform checkRoad = null;
    public List<BuildingLevelData> LevelsData = new List<BuildingLevelData>();
    [SerializeField] private int _currentLevel = 0;
    public int CurrentLevel => _currentLevel;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp()
    {
        _currentLevel++;
    }
}
