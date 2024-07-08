using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotFiller : MonoBehaviour {

    public GameObject smallTurret;
    public GameObject mediumTurret;
    public GameObject largeTurret;

    public GameObject smallWeapon;
    public GameObject mediumWeapon;
    public GameObject largeWeapon;

    const string SMALL_TURRET_NAME = "SmallTurret_";
    const string MEDIUM_TURRET_NAME = "MediumTurret_";
    const string LARGE_TURRET_NAME = "LargeTurret_";
    const string SMALL_WEAPON_NAME = "SmallWeapon_";
    const string MEDIUM_WEAPON_NAME = "MediumWeapon_";
    const string LARGE_WEAPON_NAME = "LargeWeapon_";

    //public enum SlotType { smallT, mediumT, largeT, smallW, mediumW, largeW }
    HashSet<Transform> smallWeaponSlots = new HashSet<Transform>();
    HashSet<Transform> mediumWeaponSlots = new HashSet<Transform>();
    HashSet<Transform> largeWeaponSlots = new HashSet<Transform>();

    HashSet<Transform> smallTurretSlots = new HashSet<Transform>();
    HashSet<Transform> mediumTurretSlots = new HashSet<Transform>();
    HashSet<Transform> largeTurretSlots = new HashSet<Transform>();

    void OnValidate()
    {
        GetSlots();
    }

    public void GetSlots()
    {
        smallTurretSlots.Clear();
        mediumTurretSlots.Clear();
        largeTurretSlots.Clear();
        smallWeaponSlots.Clear();
        mediumWeaponSlots.Clear();
        largeWeaponSlots.Clear();

        Transform[] children = transform.GetComponentsInChildren<Transform>();
        for(int i = 0; i < children.Length; i++)
        {
            if (children[i].name.StartsWith(SMALL_TURRET_NAME))
                smallTurretSlots.Add(children[i]);
            else if (children[i].name.StartsWith(MEDIUM_TURRET_NAME))
                mediumTurretSlots.Add(children[i]);
            else if (children[i].name.StartsWith(LARGE_TURRET_NAME))
                largeTurretSlots.Add(children[i]);

            else if (children[i].name.StartsWith(SMALL_WEAPON_NAME))
                smallWeaponSlots.Add(children[i]);
            else if (children[i].name.StartsWith(MEDIUM_WEAPON_NAME))
                mediumWeaponSlots.Add(children[i]);
            else if (children[i].name.StartsWith(LARGE_WEAPON_NAME))
                largeWeaponSlots.Add(children[i]);
        }
    }

    public void ClearSlots()
    {
        ClearSlot(smallTurretSlots);
        ClearSlot(mediumTurretSlots);
        ClearSlot(largeTurretSlots);
        ClearSlot(smallWeaponSlots);
        ClearSlot(mediumWeaponSlots);
        ClearSlot(largeWeaponSlots);
    }

    void ClearSlot(HashSet<Transform> slot)
    {
        GetSlots();
        Debug.Log("Clear");
        foreach(Transform t in slot)
        {
            int j = t.childCount;
            for(; j > 0; j--)
            {
                if(t != null && t.GetChild(0) != null)
                    DestroyImmediate(t.GetChild(0).gameObject);
            }
        }
    }

    public void MountSlots()
    {
        ClearSlots();

        if(smallWeapon != null)
            MountSlot(smallWeapon, smallWeaponSlots);
        if (mediumWeapon != null)
            MountSlot(mediumWeapon, mediumWeaponSlots);
        if (largeWeapon != null)
            MountSlot(largeWeapon, largeWeaponSlots);
        if (smallTurret != null)
            MountSlot(smallTurret, smallTurretSlots);
        if (mediumTurret != null)
            MountSlot(mediumTurret, mediumTurretSlots);
        if (largeTurret != null)
            MountSlot(largeTurret, largeTurretSlots);
    }

    void MountSlot(GameObject obj, HashSet<Transform> hashSet)
    {
        foreach(Transform t in hashSet)
            GameObject.Instantiate(obj, t, false);   
    }
}
