using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentStock : MonoBehaviour
{
    public int nbStocks;
    public int currentTotalAmmo;

    private void Start()
    {
        currentTotalAmmo = GetComponent<Weapon>().ammoCapacity * (nbStocks+1);
    }
}
