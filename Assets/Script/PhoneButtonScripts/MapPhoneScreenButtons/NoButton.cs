using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoButton : DecisionButton
{
    public GameObject informationPanel;

    public override void OnClickEvent() { informationPanel.SetActive(false); }
}
