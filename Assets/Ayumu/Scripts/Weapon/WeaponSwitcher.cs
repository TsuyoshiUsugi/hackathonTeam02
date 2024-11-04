using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField]
    protected WeaponDataBase weaponData;
    [SerializeField]
    protected Weapon weapon;
    [SerializeField]
    protected UnityEngine.UI.Text text; 
    [SerializeField]
    protected UnityEngine.UI.Image icon;



    protected bool lockUpdateIndex = false;


    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateIndex(0);
    }

    protected void UpdateIndex(int wh) {
        currentIndex = (currentIndex + (int)wh + this.weaponData.weapons.Count) % this.weaponData.weapons.Count;
        WeaponData weapondata = weaponData.weapons[currentIndex];
        this.weapon.changeWeapon(weapondata);
        this.text.text = weapondata.str;
        this.icon.sprite = weapondata.icon;
        FindAnyObjectByType<SoundManager>().PlayOneShotSound(SoundManager.ONE_SHOT_SOUND.ChangeSlot);
    }

    // Update is called once per frame
    void Update()
    {
        float wh = Input.mouseScrollDelta.y;
        if (wh != 0 && this.lockUpdateIndex == false)
        {
            this.UpdateIndex((int)wh);
        }
    }
}
