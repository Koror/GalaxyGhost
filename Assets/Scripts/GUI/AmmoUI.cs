using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public Text TextAmmo;

    public void UpdateAmmo(int ammo)
    {
        TextAmmo.text = "Ammo: " + ammo;
    }
}
