using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonUI : Singleton<GameWonUI>
{
     [SerializeField]
   private GameObject gameWonUI;

   public void gameWon(){
         GameManager.Instance.DropTower();
       GameObject [] towerPanel = GameObject.FindGameObjectsWithTag("TowerPanel");
         foreach (GameObject  btn in towerPanel)
         {
             btn.SetActive(false);
         }
         LevelManager.Instance.ChangeBlur();
         this.gameWonUI.SetActive(true);
   }

   public void NextLevel(){
       Debug.Log("Next Level is "+(LevelManager.Instance.GetLevel()+1));
   }
}
