using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // 追跡するオブジェクト（だいたいがPlayer になる）
    private GameObject target = null;
    public GameObject SetTarget { set { target = value; } }
    //自分がダメージを受けるタイプ
    public List<DamageType> weakType;

    // Start is called before the first frame update
    void Start()
    {
        team = Team.ENEMY;
    }

    protected override void Dead()
    {
        FindAnyObjectByType<IngameManager>().KillCount++;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = (target.transform.position - this.gameObject.transform.position).normalized;
        Move(moveDirection);
    }

    public override float applyDamage(DamageData damageData)
    {
        //弱点の攻撃だったら
        if(weakType.Count != 0 && weakType.Contains(damageData.damageType))
        {
            FindAnyObjectByType<SoundManager>().PlayOneShotSound(SoundManager.ONE_SHOT_SOUND.Attack);
            return base.applyDamage(damageData);
        }

        return 0f;
    }

}
