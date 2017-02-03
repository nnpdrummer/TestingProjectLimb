using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPageButton : PhoneButton
{
    public GameObject currentScrennPnl;
    public GameObject nextScreenPnl;

    public override void OnClickEvent()
    {
        nextScreenPnl.SetActive(true);
        currentScrennPnl.SetActive(false);
    }
}
