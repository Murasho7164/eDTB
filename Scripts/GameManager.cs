using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject canvasP1;
    public GameObject canvasP2;
    public GameObject canvasCharacter;
    public GameObject canvasUI;
    public GameObject p1MoneyText;
    public GameObject p2MoneyText;

    public GameObject[] p1PriceText=new GameObject[CHARACTERS_NUM];
    public GameObject[] p2PriceText=new GameObject[CHARACTERS_NUM];

    public Camera camera;
    private GameObject moneyManager;

    private MoneyManager _moneyScript;
    private const int CHARACTERS_NUM=9;
    public enum CHARACTERS {
        Luffy,
        Zoro,
        Nami,
        Usop,
        Sanji,
        Chopper,
        Robin,
        Franky,
        Brook,
    }

    public CHARACTERS _pickedCharacter;

    public enum SCENE {
        P1Pick,
        P1Drop,
        P1Check,
        P2Pick,
        P2Drop,
        P2Check,
        Wait,
        P1Win,
        P2Win,
    }
    public SCENE _scene;

    public GameObject[] characters;
    private float _dropHeight;
    private int _droppedCharacters;
    private GameObject _geneCharacter;
    private int _turns;

    //public const float rotateFrame=15;

    private bool _ispaid;
    private bool _isExisting;

    public static bool isFall;
    public static bool dropButtonPushed;
    public static bool isGameOver=false;

    public enum ROTATE{
        Left=45,
        Right=-45,
    }
    public static List<Moving> isMoves=new List<Moving>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init(){
        _droppedCharacters=0;
        _dropHeight=50;//ちょうどよさげな高さ
        _turns=1;
        _scene=SCENE.P1Pick;
        canvasP1.SetActive(false);
        canvasP2.SetActive(false);
        canvasUI.SetActive(false);
        _ispaid=false;
        _isExisting=false;
        isFall=false;
        dropButtonPushed=false;

        isMoves.Clear();
        StartCoroutine(StateReset());

        moneyManager=GameObject.Find("MoneyManager");
        _moneyScript=moneyManager.GetComponent<MoneyManager>();

    }


    // Update is called once per frame
    void Update()
    {
        switch(_scene){
            case SCENE.P1Pick://Player1のピック
            canvasP1.SetActive(true);
            if(_ispaid==false){
                _moneyScript.IncreaseP1Money(_turns);
                _ispaid=true;
            }
            RefreshP1MoneyText();
            break;

            case SCENE.P1Drop://Player1のドロップ
            canvasP1.SetActive(false);
            canvasUI.SetActive(true);

            if(!_isExisting){
                StartCoroutine(GenerateCharacter());
                _isExisting=true;
                return;
            }

            if(!isFall){
                MoveCharacter();
            }

            break;

            case SCENE.P1Check://Player1の動きチェック
            canvasUI.SetActive(false);

            if (CheckMove(isMoves))
            {
                return;//移動中なら処理はここまで
            }
            if((!CheckMove(isMoves))&&dropButtonPushed&&!isFall){
                _droppedCharacters++;
                SetScene(SCENE.P2Pick);
            }
            break;

            case SCENE.P2Pick:
            _isExisting=false;
            canvasP2.SetActive(true);
            canvasP2.SetActive(true);
            if(_ispaid==false){
                _moneyScript.IncreaseP2Money(_turns);
                _ispaid=true;
            }
            RefreshP1MoneyText();
            break;

            case SCENE.P2Drop:
            canvasP1.SetActive(false);
            canvasUI.SetActive(true);

            if(!_isExisting){
                StartCoroutine(GenerateCharacter());
                _isExisting=true;
                return;
            }

            if(!isFall){
                MoveCharacter();
            }

            _turns++;
            break;
        }

        //Debug.Log(CheckMove(Character.isMoves));
    }

    public SCENE GetScene(){
        return _scene;
    }
    public void SetScene(SCENE scene){
        _scene=scene;
    }

    public void RefreshP1MoneyText(){
        p1MoneyText.GetComponent<Text>().text="所持金："+_moneyScript.GetP1Money().ToString()+"B";
    }

    public void CreateCharacter(){
        //Debug.Log((int)_pickedCharacter);
        _geneCharacter=Instantiate(characters[(int)_pickedCharacter]);
        _geneCharacter.transform.SetParent(canvasCharacter.transform,false);
        _geneCharacter.transform.localPosition=new Vector3(0,_dropHeight,0);

        _geneCharacter.GetComponent<Rigidbody2D>().isKinematic=true;

        _isExisting=true;
    }

    public void RotateCharacter(ROTATE rotate){
        _geneCharacter.transform.Rotate(0,0,(int)rotate);
    }

    public void DropCharacter(){
        _geneCharacter.GetComponent<Rigidbody2D>().isKinematic=false;
        isFall=true;
    }

    public void MoveCharacter(){
        if(!CheckButtonDown.isButtonPushing){
            if(Input.GetMouseButton(0)){
                Vector3 pos=_geneCharacter.transform.position;
                pos.x=camera.ScreenToWorldPoint(Input.mousePosition).x;
                _geneCharacter.transform.position=pos;
            }
        }
    }

    public bool CheckMove(List<Moving> isMoves){
        if(isMoves==null){
            return false;
        }
        foreach(Moving m in isMoves){
            if(m.isMoving){
                return true;
            }
        }
        return false;
    }

    IEnumerator StateReset(){
        while(!isGameOver){
            yield return new WaitUntil(()=>isFall);
            yield return new WaitForSeconds(2.0f);
            isFall=false;
            _isExisting=false;
        }
    }

    IEnumerator GenerateCharacter(){
        while(CameraController.isCollision){
            yield return new WaitForEndOfFrame();
            camera.transform.Translate(0,0.1f,0);
            _dropHeight+=0.1f;
            }
        if(!CameraController.isCollision){
            CreateCharacter();
        }
    }


/*     private IEnumerator WaitTime(float s)
    {
        Debug.Log("coroutin");
        yield return new WaitForSeconds(s);
        yield return null;
    } */

}
