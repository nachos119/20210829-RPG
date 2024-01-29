using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// ����
public enum Player_State
{
    Idle, Walk, Attack, Damage, Die
}

public class PlayerMove : MonoBehaviour
{
    // ����
    public Player_State state;

    // �ִ�
    Animator animator;
    PlayerAni PlayerAni;
    float play;

    public Player_State currentState = Player_State.Idle;


    public float moveSpeed = 5f; // �յ� �������� �ӵ�
    public float rotateSpeed = 180f; // �¿� ȸ�� �ӵ�


    private PlayerController playerInput; // �÷��̾� �Է��� �˷��ִ� ������Ʈ
    private Rigidbody playerRigidbody; // �÷��̾� ĳ������ ������ٵ�
    private Animator playerAnimator; // �÷��̾� ĳ������ �ִϸ�����

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
        // idle �⺻����
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
        // ����� ������Ʈ���� ������ ��������
        playerInput = GetComponent<PlayerController>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        PlayerAni = GetComponent<PlayerAni>();
    }

    // FixedUpdate�� ���� ���� �ֱ⿡ ���� �����
    private void FixedUpdate()
    {
        // ���� ���� �ֱ⸶�� ������, ȸ��, �ִϸ��̼� ó�� ����
        // ȸ�� ����
        Rotate();
        // ������ ����
        Move();
        // �Է°������� �ִϸ������� Move �Ķ���Ͱ� ����
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

    // �Է°��� ���� ĳ���͸� �յڷ� ������
    private void Move()
    {
        // ��������� �̵��� �Ÿ� ���
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        // ������ٵ� �̿��� ���� ������Ʈ ��ġ ����
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // �Է°��� ���� ĳ���͸� �¿�� ȸ��
    private void Rotate()
    {
        // ��������� ȸ���� ��ġ ���
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        // ������ٵ� �̿��� ���� ������Ʈ ȸ�� ����
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }
}
