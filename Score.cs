using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // 클래스에서 관리 가능한 static으로 int형변수 score관리
    public static int score = 0;
    public static int bestscore = 0;
    // Start is called before the first frame update
    void Start()
    {
       score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = score.ToString();
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (Score.score > Score.bestscore){
            Score.bestscore = Score.score;
        }
        SceneManager.LoadScene("GameOverScene");
    }
}
