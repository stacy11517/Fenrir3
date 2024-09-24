using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public Animator animator;  // Animator ����ޥ�

    // �Ψӱ���ޯ�N�o�ɶ�
    public float dashCooldown = 1f;
    public float roarCooldown = 2f;
    public float breathCooldown = 3f;

    private bool canDash = true;
    private bool canRoar = true;
    private bool canUseBreath = true;

    // Start is called before the first frame update
    void Start()
    {
        // ��� Animator ����
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // X ����B�����W�O���� (Xbox ��� X ����� joystick button 2)
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            animator.SetTrigger("Attack");  // Ĳ�o����ʵe
        }

        // ���� X �W�O����
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            animator.SetBool("ChargeAttack", true);  // �W�O�ʵe���A
        }
        else
        {
            animator.SetBool("ChargeAttack", false); // �����W�O�ʵe
        }

        // B �_�q (Xbox ��� B ����� joystick button 1)
        if (Input.GetKeyDown(KeyCode.JoystickButton1) && canRoar)
        {
            animator.SetTrigger("Roar");  // Ĳ�o�_�q�ʵe
            StartCoroutine(RoarCooldown());  // �}�l�N�o
        }

        // A �p�Ĩ� (Xbox ��� A ����� joystick button 0)
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && canDash)
        {
            animator.SetTrigger("Dash");  // Ĳ�o�Ĩ�ʵe
            StartCoroutine(DashCooldown());  // �}�l�N�o
        }

        // Y �S��ޯ�]�B�R���^(Xbox ��� Y ����� joystick button 3)
        if (Input.GetKeyDown(KeyCode.JoystickButton3) && canUseBreath)
        {
            animator.SetTrigger("Breath");  // Ĳ�o�B�R���ʵe
            StartCoroutine(BreathCooldown());  // �}�l�N�o
        }
    }

    // �N�o�ɶ��B�z
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


//X ����B�����W�O����
//B �_�q
//�o�X�p���νd��_�i�A�i�H�_�H�B�}�a�i���ʪ��~�άO��

//A �p�Ĩ�
//���e��[�t�Ĩ�@�p�q

//Y �S��ޯ�]�B�R���^
//�R�X�p�d��B���A��ᵲ�ĤH


