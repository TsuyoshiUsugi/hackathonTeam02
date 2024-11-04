using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダメージを受けるオブジェクトに実装する
/// </summary>
public interface IDamage
{
    public float applyDamage(DamageData damageData);
}
