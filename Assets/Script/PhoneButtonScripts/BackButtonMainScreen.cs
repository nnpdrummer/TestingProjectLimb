using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonMainScreen : FaceButton
{
    public override void OnClickEvent()
    {
        CloseAllPanels();
        GoBack();
    }

    // Add seperate statements to further implement.
    private void GoBack()
    {
        mainPhoneScreenPanel.SetActive(true);
        mapPhoneScreenPanel.SetActive(false);
    }

}
