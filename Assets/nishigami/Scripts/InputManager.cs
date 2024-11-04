using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    // WASD から移動する向きのベクトルを取得する
    // 目的：キーを放したらピタッと止まる挙動にしたいため
    // 戻り値：正規化された移動方向のベクトル
    public Vector2 GetMoveDirection()
    {
        Vector2 moveDirection = Vector2.zero;

        // x軸方向の移動
        bool isGetKey_A = Input.GetKey(KeyCode.A);
        bool isGetKey_D = Input.GetKey(KeyCode.D);

        if (isGetKey_D && !isGetKey_A)
        {
            moveDirection.x = 1;
        }
        else if (!isGetKey_D && isGetKey_A)
        {
            moveDirection.x = -1;
        }

        // y軸方向の移動
        bool isGetKey_W = Input.GetKey(KeyCode.W);
        bool isGetKey_S = Input.GetKey(KeyCode.S);

        if (isGetKey_W && !isGetKey_S)
        {
            moveDirection.y = 1;
        }
        else if (!isGetKey_W && isGetKey_S)
        {
            moveDirection.y = -1;
        }

        return moveDirection;
    }
}
