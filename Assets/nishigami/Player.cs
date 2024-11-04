using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private InputManager inputManager = new InputManager();

    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] WeaponController weaponController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = inputManager.GetMoveDirection();
        if (moveDirection != Vector2.zero)
        {
            if (weaponController.FixedMousePos.x >= 0 && moveDirection.x >= 0 || weaponController.FixedMousePos.x < 0 && moveDirection.x < 0)
            {
                animator.SetFloat("Speed", 1);
            }
            else
            {
                animator.SetFloat("Speed", -1);
            }
        

            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (moveDirection.x >= 0)
        {
            //spriteRenderer.flipX = false;
        }
        else if (moveDirection.x < 0)
        {
            //spriteRenderer.flipX = true;
        }
        Move(moveDirection);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //aaaa
        var team=collision.gameObject.GetComponent<ITeam>();
        if (team == null) return;
        // 敵チームかどうかを判定する
        if (team.getTeam() != this.gameObject.GetComponent<ITeam>().getTeam())
        {
            Debug.Log(string.Format("[Character - OnCollisionEnter2D()] 敵 と接触した。"));

            // （妥協）1 ダメージずつ受けるようにする
            TakeDamage(1);


        }
    }
}
