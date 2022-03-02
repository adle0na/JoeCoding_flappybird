using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{

    // GameObject를 public으로 지정가능한 pipe 변수 선언
    public GameObject pipe;

    public float timeDiff;
    // float형의 수정가능한 timer 변수 선언
    float timer = 0;
    void Start()
    {

    }
    void Update()
    {
        // timer 값에 deltaTime값 추가
        timer += Time.deltaTime;
        // 조건문 (timer가 1보다 클경우 = deltaTime값이 1초가 지날 경우)
        if (timer * Random.Range(0.08f, 0.8f) > timeDiff )
        {
            // pipe변수를 생성
            GameObject newpipe = ObjectPooler.Instance.GenerateGameObject(pipe);
            // 랜덤 위치 지정
            newpipe.transform.position = new Vector3(6, Random.Range(-1.7f, 5.7f), 0 );
            // 타이머 값을 0으로 초기화
            timer = 0;
            // ObjectPooler 호출 10초뒤 파괴
            ObjectPooler.Instance.DestroyGameObject(newpipe, 10.0f);
        }

    }
}
