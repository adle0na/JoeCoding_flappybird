using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // public으로 관리, static으로 다른 sript에서도 관리가능한 ObjectPooler클래스의 Intance를 선언
    public static ObjectPooler Instance;
    // 입력값을 Dictionary안에 받아올 게임List를 선언
    public Dictionary<int,List<GameObject>> gameObjects = new Dictionary<int, List<GameObject>>();
    
    // 시작하면 실행 (Start보다 먼저 실행)
    void Awake()
    {
        // Instance를 ObjectPooler로 지정
        Instance = this;
    }
    #region GenerateGameObject

    // 수정가능한 GenerateGameObject를 선언 (게임옵젝트 prefab,부모의 Transform값을 = null 값으로 )선언
    public GameObject GenerateGameObject(GameObject prefab,Transform parent = null)
    {
        // int형 index변수 초기값 0로 설정
        int index = 0;
        // int형 hashkey prefab인 GetHashCode를 삽입
        int hashKey = prefab.GetHashCode();
        // 게임object임 idlePrefab = null값으로 지정
        GameObject idlePrefab = null;

        // 조건문 (게임 오브젝트인 ContainsKey가 hashkey값이 아닐경우)
        if (!gameObjects.ContainsKey(hashKey))
            // 받아온 hashKey값의 오브젝트를 List에 추가
            gameObjects.Add(hashKey, new List<GameObject>());

        // 반복문 (알아서 지정되는 형식var로 i값 0부터 hashKey의 Count값보다 작을때까지만 증가)
        for (var i = 0; i < gameObjects[hashKey].Count; i++)
        {
            // hashKey의 배열값[i]
            // 조건문(obj의 상태가 activeSelf경우) continue;
            GameObject obj = gameObjects[hashKey][i];
            if (obj.activeSelf) continue;
            
            // index 값을 i로 지정
            index = i;
            // idlePrefab을 obj로 지정
            idlePrefab = obj;
            // 탈출
            break;
        }

        // 조건문 ( idelPrefab이 null 값일 경우 )
        if (idlePrefab == null)
        {
            // hashKey로 받은 오브젝트를 prefab의 부모 생성
            gameObjects[hashKey].Add(Instantiate(prefab,parent));
            // index hashKey Count값에서 -1 (0에서 시작되니까 넣은거임)
            index = gameObjects[hashKey].Count - 1;
        }
        else
        {
            idlePrefab.transform.parent = parent;
            idlePrefab.SetActive(true);
        }
        return gameObjects[hashKey][index];
    }
    
    #endregion
    #region DestroyGameObject
    public void DestroyGameObject(GameObject prefab)
    {
        //StopAllCoroutines();
        prefab.transform.parent = transform;
        prefab.SetActive(false);
    }

    public void DestroyGameObject(GameObject prefab,float time)
    {
        StartCoroutine(DestroyTime(prefab,time));
    }

    IEnumerator DestroyTime(GameObject prefab, float time)
    {
        yield return new WaitForSeconds(time);
        DestroyGameObject(prefab);
        yield return null;
    }
    #endregion
}
