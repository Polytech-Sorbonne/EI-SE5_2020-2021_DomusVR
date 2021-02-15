using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayHider : MonoBehaviour
{
    public void HideRay()
    {
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<XRInteractorLineVisual>().enabled = false;
    }

    public void DisplayRay()
    {
        GetComponent<LineRenderer>().enabled = true;
        GetComponent<XRInteractorLineVisual>().enabled = true;
    }
}
