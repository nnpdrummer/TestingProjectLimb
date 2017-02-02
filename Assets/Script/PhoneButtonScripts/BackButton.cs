using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Probably add further child classes for each phone page
public class BackButton : PhoneButton
{
    public GameObject[] uIObjectsToCloseOnScreen;
    public GameObject currentScreen;
    public GameObject previousScreen;

    public override void OnClickEvent()
    {
        Debug.Log("Back button pressed");
        GoBack();
    }

    // Add seperate statements to further implement.
    private void GoBack()
    {
        int activeObjects = 0;

        for(int objectIterator = 0; objectIterator < uIObjectsToCloseOnScreen.Length; objectIterator++)
        {
            if(uIObjectsToCloseOnScreen[objectIterator].activeSelf) { uIObjectsToCloseOnScreen[objectIterator].SetActive(false); activeObjects++; }
        }
        
        if(activeObjects == 0)
        {
            currentScreen.SetActive(false);
            previousScreen.SetActive(true);
        }
    }
}
