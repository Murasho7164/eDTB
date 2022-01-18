using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    

    private Rigidbody2D _rigid;
    private GameObject _gameManager;
    private GameManager _gameScript;
    Moving moving=new Moving();
    // Start is called before the first frame update
    void Start()
    {
        _gameManager=GameObject.Find("GameManager");
        _gameScript=_gameManager.GetComponent<GameManager>();
        _rigid=GetComponent<Rigidbody2D>();
        GameManager.isMoves.Add(moving);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(_gameScript.GetScene());
        if(_gameScript.GetScene()==GameManager.SCENE.P1Check||_gameScript.GetScene()==GameManager.SCENE.P2Check){
            MovingCheck();
        }
        //Debug.Log(moving.isMoving);
    }
    public void MovingCheck(){
        if (_rigid.velocity.magnitude>0.01f){
            //Debug.Log("true");
            moving.isMoving=true;
        }
        else{
            //Debug.Log("false");
            moving.isMoving=false;
        }
    }

}

public class Moving{
    public bool isMoving;
}

