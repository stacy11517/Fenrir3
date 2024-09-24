using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public Animator animator;  // Animator 元件引用

    // 用來控制技能冷卻時間
    public float dashCooldown = 1f;
    public float roarCooldown = 2f;
    public float breathCooldown = 3f;

    private bool canDash = true;
    private bool canRoar = true;
    private bool canUseBreath = true;

    // Start is called before the first frame update
    void Start()
    {
        // 獲取 Animator 元件
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // X 普攻、長按蓄力重擊 (Xbox 控制器 X 鍵對應 joystick button 2)
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            animator.SetTrigger("Attack");  // 觸發普攻動畫
        }

        // 長按 X 蓄力重擊
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            animator.SetBool("ChargeAttack", true);  // 蓄力動畫狀態
        }
        else
        {
            animator.SetBool("ChargeAttack", false); // 結束蓄力動畫
        }

        // B 震吼 (Xbox 控制器 B 鍵對應 joystick button 1)
        if (Input.GetKeyDown(KeyCode.JoystickButton1) && canRoar)
        {
            animator.SetTrigger("Roar");  // 觸發震吼動畫
            StartCoroutine(RoarCooldown());  // 開始冷卻
        }

        // A 小衝刺 (Xbox 控制器 A 鍵對應 joystick button 0)
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && canDash)
        {
            animator.SetTrigger("Dash");  // 觸發衝刺動畫
            StartCoroutine(DashCooldown());  // 開始冷卻
        }

        // Y 特殊技能（冰吐息）(Xbox 控制器 Y 鍵對應 joystick button 3)
        if (Input.GetKeyDown(KeyCode.JoystickButton3) && canUseBreath)
        {
            animator.SetTrigger("Breath");  // 觸發冰吐息動畫
            StartCoroutine(BreathCooldown());  // 開始冷卻
        }
    }

    // 冷卻時間處理
    IEnumerator DashCooldown()
    {
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    IEnumerator RoarCooldown()
    {
        canRoar = false;
        yield return new WaitForSeconds(roarCooldown);
        canRoar = true;
    }

    IEnumerator BreathCooldown()
    {
        canUseBreath = false;
        yield return new WaitForSeconds(breathCooldown);
        canUseBreath = true;
    }
}


//X 普攻、長按蓄力重擊
//B 震吼
//發出小扇形範圍震波，可以震碎、破壞可互動物品或是門

//A 小衝刺
//往前方加速衝刺一小段

//Y 特殊技能（冰吐息）
//吐出小範圍冰霜，能凍結敵人


