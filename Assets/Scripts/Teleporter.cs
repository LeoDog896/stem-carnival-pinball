using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
   
    // this function will update the source object's position
    // to match the target object's position
    public void teleport(GameObject source, GameObject destination)
    {
        if ((source != null) && (destination != null))
        {
            source.transform.position = destination.transform.position;
        }
    }
   
    public Teleporter()
    {

    }


   
}
