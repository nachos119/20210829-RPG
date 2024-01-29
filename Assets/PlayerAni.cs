using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    // 애니메이터 컨트롤러의 전이 관계에서 설정한 번호에 맞춤니다.
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

    // 애니메이션 번호를 입력 받아서 플레이어의 애니메이션을 해당되는 애니메이션으로 바꿔주는 함수
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
