using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResourse : MonoBehaviour
{
    public List<Text> TextsResourses = new List<Text>();


    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(int index, int value)  // можно сделать чтобы показывалось сколько отнялось int delta
    {
        TextsResourses[index].text = value.ToString();
    }
}
