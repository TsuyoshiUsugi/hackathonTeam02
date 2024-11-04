using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private DamageData damageData;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxSurvivalTime;

    private float survivingTime;

    [SerializeField]
    private float damageValue;

    [SerializeField]
    private DamageType damageType;


    void Start()
    {
        survivingTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        survivingTime += Time.deltaTime;

        if(survivingTime>maxSurvivalTime)
        {
            Extinguishment();
            return;
        }

        transform.position += transform.right * speed * Time.deltaTime;
    }

    void Extinguishment()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var iteam=other.gameObject.GetComponent<ITeam>();
        if (iteam == null) return;

        if (iteam.getTeam() != Team.FRIEND)
        {
            other.gameObject.GetComponent<IDamage>().applyDamage(new DamageData(damageValue, Team.FRIEND, damageType));
            Extinguishment();
        }
        FindAnyObjectByType<SoundManager>().PlayOneShotSound(SoundManager.ONE_SHOT_SOUND.Attack);
    }
}
