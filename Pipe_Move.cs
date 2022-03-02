using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Move : MonoBehaviour
{
    // 기둥 이동 속도 public 속성 float형 moveSpeed 변수 선언
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform의 위치값을 왼쪽으로 Time.deltaTime으로 속도에 비례하여 이동
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;
    }
}
