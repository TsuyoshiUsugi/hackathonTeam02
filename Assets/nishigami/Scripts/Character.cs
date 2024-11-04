using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamage, ITeam
{
    [SerializeField] private float moveSpeed = 1.0f;

    // 最大のHP 量を表現する変数
    [SerializeField] private int maxHP = 10;

    // 現在のHP 量を表現する変数
    [SerializeField] private int hp = 10;

    [SerializeField] private int attackPower = 1;

    [SerializeField] private Rigidbody2D myRigidbody2D = null;

    protected Team team;
    public int Hp => hp;

    // Start is called before the first frame update
    void Start()
    {
        // 自分自身からRigitbody2D を取得する。
        myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        team = Team.FRIEND;
    }

    // キャラクターを移動させるメソッド
    // 引数：moveDirection：移動方向のベクトル
    protected void Move(Vector2 moveDirection)
    {
        // myRigidbody2D.AddForce(moveDirection * moveSpeed);
        myRigidbody2D.velocity = moveDirection * moveSpeed;
    }


    

        // HP 量が0になったら実行される
    protected virtual void Dead()
    {

    }

    // HP の残量をチェックするメソッド
    private void CheckHP()
    {
        if (hp <= 0)
        {
            Dead();
        }
    }

    // hp を減らすメソッド
    // 引数：damage：受けるダメージ量
    protected void TakeDamage(int damage)
    {
        hp -= damage;
        CheckHP(); // HP の残量をチェックする
        FindAnyObjectByType<SoundManager>().PlayOneShotSound(SoundManager.ONE_SHOT_SOUND.Damage);
    }

    public virtual float applyDamage(DamageData damageData)
    {
        float damage = damageData.damageValue;
        TakeDamage((int)damage);

        return damage;
    }

    Team ITeam.getTeam()
    {
        return team;
    }
}
