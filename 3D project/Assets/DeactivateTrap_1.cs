using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTrap_1 : MonoBehaviour
{
    public GameObject physicalTraps;
    public GameObject triggerAreas;
    bool isDeactivated = false;

    public void test()
    {
        if (!isDeactivated) { physicalTraps.gameObject.SetActive(false);  triggerAreas.gameObject.SetActive(false); }
        isDeactivated = true;
    }


}
