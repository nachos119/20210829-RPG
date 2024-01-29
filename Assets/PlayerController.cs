using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ������ ��ũ��
    private PlayerMove playerMove;

    // ĳ���� ��ġ
    private Vector3 targetPos;

    // ���� ����
    public string moveAxisName = "Vertical"; // �յ� �������� ���� �Է��� �̸�
    public string rotateAxisName = "Horizontal"; // �¿� ȸ���� ���� �Է��� �̸�
    public string attackButtonName = "Attack"; // �߻縦 ���� �Է� ��ư �̸�

    // �� �Ҵ��� ���ο����� ����
    public float move { get; private set; } // ������ ������ �Է°�
    public float rotate { get; private set; } // ������ ȸ�� �Է°�
    public bool attack { get; private set; } // ������ �߻� �Է°�

    void Awake()
    {
        playerMove = GetComponent<PlayerMove>();

        targetPos = transform.position;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //// ���ӿ��� ���¿����� ����� �Է��� �������� �ʴ´�
        //if (GameManager.instance != null && GameManager.instance.isGameover)
        //{
        //    move = 0;
        //    rotate = 0;
        //    fire = false;
        //    reload = false;
        //    return;
        //}

        // move�� ���� �Է� ����
        move = Input.GetAxis(moveAxisName);
        // rotate�� ���� �Է� ����
        rotate = Input.GetAxis(rotateAxisName);
        // fire�� ���� �Է� ����
        attack = Input.GetButton(attackButtonName);
    }
}
