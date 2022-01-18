using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGameOver : MonoBehaviour
{
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start(){
        gameManager =GameObject.Find("GameManager");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GG");
        StartCoroutine("MoveGameOverCoroutine");
    }

    IEnumerator MoveGameOverCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        gameManager.GetComponent<GameManager>().GameOver();
        yield return null;
    }
}
