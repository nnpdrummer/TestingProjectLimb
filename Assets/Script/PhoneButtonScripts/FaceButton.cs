using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceButton : PhoneButton
{
    public GameObject[] uIComponentsToClose;
    public GameObject currentScreen;

    // To be changed by children
    public override void OnClickEvent() { Debug.Log("Face Button pressed"); }

    // Closes all of the associated panels associated with each main phone button.
    protected virtual void CloseAllUIComponents()
    {
        for (int uIIterator = 0; uIIterator < uIComponentsToClose.Length; uIIterator++)
        {
            uIComponentsToClose[uIIterator].SetActive(false);
        }
    }
}
