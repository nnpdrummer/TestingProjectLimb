using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Make separate yes buttons either through child classes of this class or child classes of decision button.
public class YesButton : DecisionButton
{
    private string destinationName;

    public override void OnClickEvent()
    {
        // Update with more destinations as necessary.
        switch (destinationName)
        {
            case "Baltimore": SceneManager.LoadScene("PhoneMenuSystem"); break;
            case "New York": SceneManager.LoadScene("Different Scene"); break;
            case "Chicago": SceneManager.LoadScene("Chicago"); break;
        }
    }

    public void setDestination(string newDestination) { destinationName = newDestination; }
}
