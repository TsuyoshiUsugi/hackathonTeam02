using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponController : MonoBehaviour
{

    [SerializeField]
    private Weapon weapon;

    [SerializeField] 
    Animator animator;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    public Vector2 FixedMousePos { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.lookAtMouse();
        this.shouldFire();
    }

    private void lookAtMouse()
    {
        Vector3 screen_point = Input.mousePosition;
        Vector2 deviceCoord = new Vector2(Screen.width, Screen.height);

        Vector2 fixedmousPos = (Vector2)Input.mousePosition - deviceCoord * 0.5f;
        if (fixedmousPos.x >= 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX=true;
        }
        FixedMousePos = fixedmousPos;
        float angle = Mathf.Atan2(fixedmousPos.y, fixedmousPos.x);
        this.transform.rotation = Quaternion.EulerRotation(0, 0, angle);
    }

    private void shouldFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.fireStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            weapon.fireEnd();
        }
    }
}
