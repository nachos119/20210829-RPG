using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    // �ִϸ����� ��Ʈ�ѷ��� ���� ���迡�� ������ ��ȣ�� ����ϴ�.
    public const int ANI_IDLE = 0;
    public const int ANI_WALK = 1;
    public const int ANI_ATTACK = 2;
    public const int ANI_DAMAGE = 3;
    public const int ANI_DIE = 4;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // �ִϸ��̼� ��ȣ�� �Է� �޾Ƽ� �÷��̾��� �ִϸ��̼��� �ش�Ǵ� �ִϸ��̼����� �ٲ��ִ� �Լ�
    public void ChangeAni(int aniNumber)
    {
        switch (aniNumber)
        {
            case PlayerAni.ANI_IDLE:
                anim.SetBool("isIdle", true);
                anim.SetFloat("Blend", 0.0f);
                break;
            case PlayerAni.ANI_WALK:
                anim.SetFloat("Blend", 1.0f);
                break;
            case PlayerAni.ANI_ATTACK:
                anim.SetBool("isAttack", true);
                break;
            case PlayerAni.ANI_DAMAGE:
                anim.SetBool("isDamage", true);
                break;
            case PlayerAni.ANI_DIE:
                anim.SetBool("isDie", true);
                break;
        }
        //anim.SetInteger("aniName", aniNumber);
    }
}
