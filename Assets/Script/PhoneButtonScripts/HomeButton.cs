using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : FaceButton
{
    public GameObject mainPhoneScreenPanel;

    public override void OnClickEvent()
    {
        CloseAllUIComponents();
        GoHome();
    }

    private void GoHome()
    {
        currentScreen.SetActive(false);
        mainPhoneScreenPanel.SetActive(true);
    }
}
