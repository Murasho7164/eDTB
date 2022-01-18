using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int p1Money;
    public static int p2Money;
/*     public const int PRICE_LUFFY=1000;
    public const int PRICE_ZORO=800;
    public const int PRICE_NAMI=600;
    public const int PRICE_USOP=700;
    public const int PRICE_SANJI=800;
    public const int PRICE_CHOPPER=300;
    public const int PRICE_ROBIN=500;
    public const int PRICE_FRANKY=700;
    public const int PRICE_BROOK=600; */
    public enum PRICE{
        Luffy=1000,
        Zoro=800,
        Nami=600,
        Usop=700,
        Sanji=800,
        Chopper=300,
        Robin=500,
        Franky=700,
        Brook=600,
    }

    //public int purchaseCharacter;
    public int purchasePrice;
    void Start()
    {
        MoneyInit();
    }
    public void MoneyInit(){
        p1Money =0;
        p2Money =0;
        purchasePrice=0;
    }
    public void SetP1Money(int n){
        p1Money =n;
    }
    public void SetP2Money(int n){
        p2Money =n;
    }

    public int GetP1Money(){
        return p1Money;
    }

    public int GetP2Money(){
        return p2Money;
    }
    public void ReduceP1Money(int n){
        p1Money -=n;
    }
    public void ReduceP2Money(int n){
        p2Money -=n;
    }

    public void IncreaseP1Money(int n){
        if(n<5){
            p1Money +=n*1000;
        }
        else{
            p1Money+=5000;
        }
    }
    public void IncreaseP2Money(int n){
        if(n<5){
            p2Money+=n*1000;
        }
        else {
            p2Money+=5000;
        }
    }

    public void SetPurchaseCharacter(int n){
        purchasePrice = n;
    }

    public int GetPurchasePrice(){
        return purchasePrice;
    }
}
