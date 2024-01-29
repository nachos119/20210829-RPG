using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 상태
public enum Player_State
{
    Idle, Walk, Attack, Damage, Die
}

public class PlayerMove : MonoBehaviour
{
    // 상태
    public Player_State state;

    // 애니
    Animator animator;
    PlayerAni PlayerAni;
    float play;

    public Player_State currentState = Player_State.Idle;


    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도


    private PlayerController playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeState(Player_State newState, int aniNumber)
    {
        if (currentState == newState)
        {
            return;
        }

        animator.SetBool("isIdle", false);
        animator.SetBool("isWalk", false);
        animator.SetBool("isAttack", false);
        animator.SetBool("isDie", false);
        animator.SetBool("isDamage", false);

        // play = 0;
        //animator.SetFloat("Blend", play);

        state = newState;
        PlayerAni.ChangeAni(aniNumber);
        currentState = newState;
    }
    public void ctrlStart()
    {
        // idle 기본지정
        state = Player_State.Idle;
        animator = GetComponent<Animator>();
        //  myAni = GetComponent<PlayerAni>();
        // ChangeState(Player_State.Idle, PlayerAni.ANI_WALK);
        ChangeState(Player_State.Idle, PlayerAni.ANI_IDLE);
    }

    public void UpdateState()
    {
        switch (currentState)
        {
            case Player_State.Idle:
                animator.SetBool("isIdle", true);
                break;
            case Player_State.Walk:
                animator.SetBool("isWalk", true);
                break;
            case Player_State.Attack:
                animator.SetBool("isAttack", true);
                // animator.SetBool("thatLive", false);
                break;
            case Player_State.Damage:
                animator.SetBool("isDamage", true);
                // animator.SetBool("isH", false);
                // animator.SetBool("isB", false);
                break;
            case Player_State.Die:
                animator.SetBool("isDie", true);
                // animator.SetBool("isAlive", false);
                break;

        }
    }

    private void Start()
    {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerController>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        PlayerAni = GetComponent<PlayerAni>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        // 회전 실행
        Rotate();
        // 움직임 실행
        Move();
        // 입력값에따라 애니메이터의 Move 파라미터값 변경
        //playerAnimator.SetFloat("Move", playerInput.move);
        if (playerInput.attack == true)
        {
            state = Player_State.Attack;
            ChangeState(Player_State.Attack, PlayerAni.ANI_ATTACK);
        }
        else if (playerInput.move != 0)
        {
            state = Player_State.Walk;
            ChangeState(Player_State.Walk, PlayerAni.ANI_WALK);
        }
        else
        {
            state = Player_State.Idle;
            ChangeState(Player_State.Idle, PlayerAni.ANI_IDLE);
        }
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {
        // 상대적으로 이동할 거리 계산
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        // 리지드바디를 이용해 게임 오브젝트 위치 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        // 상대적으로 회전할 수치 계산
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        // 리지드바디를 이용해 게임 오브젝트 회전 변경
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }
}
