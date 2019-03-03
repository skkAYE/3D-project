using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTrap : MonoBehaviour
{

    private bool isGettingDamaged = false;
    float damage = 33.0f;
    // Start is called before the first frame update
    IEnumerator Cooldwn(float timing)
    {
        yield return new WaitForSeconds(timing);
        isGettingDamaged = false;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (!isGettingDamaged)
        {
            isGettingDamaged = true;
            other.gameObject.SendMessageUpwards("ChangeHealth", -damage, SendMessageOptions.DontRequireReceiver);
            StartCoroutine(Cooldwn(1.0f));
        }
    }
}
