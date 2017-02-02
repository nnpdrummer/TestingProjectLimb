using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : SwitchPageButton
{
    public GameObject mainPhoneScreenPanel;
    public GameObject mapPhoneScreenPanel;
   
    public override void OnClickEvent()
    {
        base.OnClickEvent();
        mapPhoneScreenPanel.SetActive(true);
        mainPhoneScreenPanel.SetActive(false);
    }
}
