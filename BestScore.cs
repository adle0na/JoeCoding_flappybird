using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 베스트 스코어 표시
        GetComponent<Text>().text = "Best Score " + Score.bestscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
