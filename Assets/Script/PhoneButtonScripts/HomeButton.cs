using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : FaceButton
{
    public override void OnClickEvent()
    {
        CloseAllPanels();
        GoHome();
    }

    private void GoHome()
    {
        //Add panels as needed.
        mainPhoneScreenPanel.SetActive(true);
        mapPhoneScreenPanel.SetActive(false);
    }
}
