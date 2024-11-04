using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTester : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0f, 1f) > 0.9)
        {
            weapon.fireStart();
        }
        if (Random.Range(0f, 1f) > 0.9)
        {
            weapon.fireEnd();
        }
    }
}
