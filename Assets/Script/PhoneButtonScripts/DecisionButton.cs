using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionButton : PhoneButton
{
    // To be implemented within child yes and no button classes.
    public override void OnClickEvent() { Debug.Log("Decision Button pressed"); }
}
