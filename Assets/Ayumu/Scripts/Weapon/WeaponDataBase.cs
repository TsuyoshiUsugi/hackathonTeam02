
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]
public class WeaponDataBase : ScriptableObject
{
   public List<WeaponData> weapons = new List<WeaponData>();
}

[System.Serializable]
public class WeaponData
{
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public DamageData damage;
    [SerializeField]
    public Sprite icon;
    public string str;

    WeaponData(GameObject bullet, DamageData damage, Sprite icon)
    {
        this.bullet = bullet;
        this.damage = damage;
        this.icon = icon;
    }
}