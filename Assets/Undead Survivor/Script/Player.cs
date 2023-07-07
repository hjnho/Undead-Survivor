using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    SpriteRenderer spriter;
    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //   void Update()
    //   {
    //          inputVec.x = Input.GetAxis("Horizontal");
    //         inputVec.x = Input.GetAxisRaw("Horizontal");
    //         inputVec.y = Input.GetAxisRaw("Vertical");
    //   }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void FixedUpdate()
    {

        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; // ��Ÿ��� ����

        //�밢������ �̵��� �� �ξ� �� ������ �̵���
        // -> ���� �ӵ��� �̵�
        //���� ������ 1 ��ŭ �Ҹ�� �ð� : fixedDeltaTIme

        // 1. ���� �ش�.
        //rigid.AddForce(inputVec);

        // 2. �ӵ� ����
        //rigid.velocity = inputVec;

        // 3. ��ġ �̵�
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); //magnitude : ������ ������ ũ�� ��

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
