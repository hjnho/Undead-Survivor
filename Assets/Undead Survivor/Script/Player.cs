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
        //Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; // 피타고라스 정의

        //대각선으로 이동할 때 훨씬 더 빠르게 이동함
        // -> 같은 속도로 이동
        //물리 프레임 1 만큼 소모된 시간 : fixedDeltaTIme

        // 1. 힘을 준다.
        //rigid.AddForce(inputVec);

        // 2. 속도 제어
        //rigid.velocity = inputVec;

        // 3. 위치 이동
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); //magnitude : 벡터의 순수한 크기 값

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
