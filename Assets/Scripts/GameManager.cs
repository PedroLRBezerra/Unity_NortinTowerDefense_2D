using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>

{
    public TowerBtn ClickedBtn { get;private set; }

    protected GameManager(){

    }

    public void PickTower(TowerBtn towerbtn){
        if(this.ClickedBtn != towerbtn){
            this.ClickedBtn = towerbtn;
            Hover.Instance.Activate(ClickedBtn.Sprite, ClickedBtn.TowerPrefab.GetComponent<Tower>().Range);
        }else{
            DropTower();
        }
        
    }

    public void BuyTower(){
         LevelManager.Instance.useMoney(ClickedBtn.TowerPrefab.GetComponent<Tower>().Cost);
        DropTower();
    }

    public void DropTower(){
        Hover.Instance.Deactivate();
        ClickedBtn = null;
    }
}
