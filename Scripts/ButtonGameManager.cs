using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonGameManager : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject moneyManager;

    private MoneyManager _moneyScript;
    private GameManager _gameScript;

    void Start(){
        gameManager=GameObject.Find("GameManager");
        moneyManager=GameObject.Find("MoneyManager");
        _moneyScript=moneyManager.GetComponent<MoneyManager>();
        _gameScript=gameManager.GetComponent<GameManager>();
    }
    public void PushLuffyButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Luffy);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Luffy;
    }

    public void PushZoroButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Zoro);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Zoro;
    }

    public void PushNamiButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Nami);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Nami;
    }

    public void PushUsopButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Usop);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Usop;
    }

    public void PushSanjiButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Sanji);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Sanji;
    }

    public void PushChopperButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Chopper);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Chopper;
    }

    public void PushRobinButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Robin);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Robin;
    }

    public void PushFrankyButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Franky);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Franky;
    }

    public void PushBrookButton(){
        _moneyScript.SetPurchaseCharacter((int)MoneyManager.PRICE.Brook);
        _gameScript._pickedCharacter=GameManager.CHARACTERS.Brook;
    }

    public void PurchaseP1Button(){
        if((MoneyManager.p1Money)>=(_moneyScript.GetPurchasePrice())){
            _moneyScript.ReduceP1Money(_moneyScript.GetPurchasePrice());
            _gameScript.RefreshP1MoneyText();
            _gameScript.SetScene(GameManager.SCENE.P1Drop);
        }
        else{
            Debug.Log("買えません");
        }
    }

    public void PurchaseP2Button(){
        if((MoneyManager.p2Money)>=(_moneyScript.GetPurchasePrice())){
            _moneyScript.ReduceP2Money(_moneyScript.GetPurchasePrice());
            _gameScript.RefreshP2MoneyText();
            _gameScript.SetScene(GameManager.SCENE.P2Drop);
        }
        else{
            Debug.Log("買えないよ");
        }
    }

    public void RotateLeftButton(){
        if(!GameManager.isFall){
            _gameScript.RotateCharacter(GameManager.ROTATE.Left);
        }
    }

    public void RotateRightButton(){
        if(!GameManager.isFall){
            _gameScript.RotateCharacter(GameManager.ROTATE.Right);
        }
    }

    public void PushDropButton(){
        _gameScript.DropCharacter();
        if(_gameScript.GetScene()==GameManager.SCENE.P1Drop){
            _gameScript.SetScene(GameManager.SCENE.P1Check);
            //Debug.Log("P1Check");
        }
        else if(_gameScript.GetScene()==GameManager.SCENE.P2Drop){
            _gameScript.SetScene(GameManager.SCENE.P2Check);
        }
    }

}
