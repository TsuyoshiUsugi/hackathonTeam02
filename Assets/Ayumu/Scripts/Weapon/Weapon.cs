using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public   class Weapon : MonoBehaviour
{

    [SerializeField]
    GameObject bullet;
    protected float lastFireTime = 0f;
    protected  bool shouldFire = false;

    [SerializeField]
    protected float fireRate = 10f;
    [SerializeField]
    protected bool isFullauto = true;
    
    [SerializeField] 
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.fireProc();
    }

    public void changeWeapon(WeaponData weaponData)
    {
        this.bullet = weaponData.bullet;

    }

    public  void fireStart()
    {
        if (this.shouldFire)
        {
            return;
        }
        
        this.shouldFire = true;
    }
    public  void fireEnd()
    {
        this.shouldFire = false;
    }

    protected void fireProc() {
        if (shouldFire == false || this.lastFireTime + 1f / this.fireRate > Time.time)
            return;
        animator.SetTrigger("Attack");
        this.lastFireTime = Time.time;
        if (this.bullet != null)
        {
            GameObject tmp = Instantiate(this.bullet, this.transform);
            tmp.gameObject.transform.parent = null;
        }
        Debug.Log("FIRE!!");
    }



}
