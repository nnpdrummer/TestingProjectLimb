using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeHandler : MonoBehaviour
{
    // The current map the player is on right now.
    public MapNode currentMap;

    //List of maps (locations) NOT including the current map the player is on.
    public MapNode[] otherMaps;

    // The distances of each map from the current location (map) of the player.
    public float[] distancesToOtherMaps;

    private void Start()
    {
        currentMap.AssignAsCurrentLocation();

        if(otherMaps.Length == distancesToOtherMaps.Length) { SetRelativeDistances(); }
        else { Debug.Log("MapNodeHandler ERROR: The number of maps in otherMaps is NOT equivalent to the number of floats in distancesToOtherMaps"); }
    }

    private void SetRelativeDistances()
    {
        for (int mapIterator = 0; mapIterator < otherMaps.Length; mapIterator++)
        {
            otherMaps[mapIterator].setDistanceFromCurrentLocation(distancesToOtherMaps[mapIterator]);
        }
    }
}
