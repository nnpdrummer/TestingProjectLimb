using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Probably add further child classes for each phone page
public class BackButton : FaceButton
{
    public GameObject previousScreen;

    public override void OnClickEvent()
    {
        CloseAllUIComponents();
    }

    // Add seperate statements to further implement.
    protected override void CloseAllUIComponents()
    {
        int activeComponents = 0;

        for(int uII = 0; uII < uIComponentsToClose.Length; uII++)
        {
            if(uIComponentsToClose[uII].activeSelf) { uIComponentsToClose[uII].SetActive(false); activeComponents++; }
        }
        
        if(activeComponents == 0)
        {
            currentScreen.SetActive(false);
            previousScreen.SetActive(true);
        }
    }
}
