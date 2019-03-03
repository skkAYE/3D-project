using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentStock : MonoBehaviour
{
    public int nbStocks;
    public int currentTotalAmmo;
    public float beamHeat;
    public float maxBeamHeat;
    public int currentAmmo;
    public GameObject StocksText;
    public GameObject ammoText;
    Text Stext;
    Text AText;
    private void Start()
    {
        currentTotalAmmo = GetComponent<Weapon>().ammoCapacity * nbStocks;
        Stext = StocksText.GetComponent<Text>();
        AText = ammoText.GetComponent<Text>();
        maxBeamHeat = GetComponent<Weapon>().maxBeamHeat;
        beamHeat = GetComponent<Weapon>().beamHeat;
        currentAmmo = GetComponent<Weapon>().currentAmmo;
            

    }

    private void Update()
    {
        currentAmmo = GetComponent<Weapon>().currentAmmo;
        beamHeat = GetComponent<Weapon>().beamHeat;
        if (nbStocks == -1) { Stext.enabled = false; AText.text= "Heat : " + (int)(beamHeat * 100) + "/" + (int)(maxBeamHeat * 100); }
        else
        {
            Stext.enabled = true;
            Stext.text = "Stock : " + currentTotalAmmo;
            AText.text = "Ammo : " + currentAmmo;
        }
    }
}
