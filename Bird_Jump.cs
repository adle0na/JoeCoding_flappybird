using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird_Jump : MonoBehaviour
{
    public float jumpPower;
    // Rigidbody2D 컴포넌트 이름 rb로 선언
    Rigidbody2D rb;

    AudioSource jumpSound;
    void Start() // 시작시 실행
    {
        // rb변수에 Rigidbody2D 컴포넌트 사용 선언
        rb = GetComponent<Rigidbody2D>();
  
    }

    // Update is called once per frame
    void Update()
    {
        // 조건문 (왼쪽마우스 버튼이 클릭 되었을 경우)
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            // (rb의 위치값에 2D벡터값으로 up = default값 0, 1 에 *3하여 삽입 )
            rb.velocity = Vector2.up *jumpPower;

        }
        
    }

    // 콜리전 충돌시 실행
    private void OnCollisionEnter2D(Collision2D other){
        // 조건문 ( 점수가 베스트 스코어보다 높으면 )
        if(Score.score > Score.bestscore)
        {
            // 베스트 스코어를 지금 점수로 대체
            Score.bestscore = Score.score;
        }
        // 게임 오버
        SceneManager.LoadScene("GameOverScene");
    }
}
