using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelManager : Singleton<LevelManager> {


    private int playerMoney;

    [SerializeField]
    private int playerStartMoney;

    [SerializeField]
    private int Level;

    private bool isGameOver;

    private bool isGameRunning;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

     [SerializeField]
    private GameObject blur;

    public  ObjectPool pool { get; set; }


     void Awake () {
        pool = GetComponent<ObjectPool> ();
         this.playerMoney=playerStartMoney;
         this.isGameOver=false;
    }

    void Start () {
       GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    public int GetLevel () {
        return Level;
    }

    public void earnMoney(int earnedMoney){
        this.playerMoney+=earnedMoney;
    }
    public void useMoney(int usedMoney){
        this.playerMoney-=usedMoney;
    }

    public int getPlayerMoney(){
        return this.playerMoney;
    }

    public bool canbuyTower(int towerPrice){
        if(towerPrice<=this.playerMoney){
            return true;
        }
        return false;
    }

    public void SellTower(){
        Node node = NodeUI.Instance.Target();
        earnMoney(node.Tower().GetComponent<Tower>().Cost);
        node.DestroyTower();
        DeselectNode();
    }

    public void SelectNode (Node node)
	{
		if ( NodeUI.Instance.Target() == node)
		{
			DeselectNode();
			return;
		}
		NodeUI.Instance.SetTarget(node);
	}

	public void DeselectNode()
	{
		NodeUI.Instance.Hide();
	}

    public void ChangeBlur(){
        this.blur.SetActive(!this.blur.activeSelf);
    }

    public void EndGame(){
        Time.timeScale=0f;
        this.isGameOver=true;
        GameOverUI.Instance.GameOver();
    }

    public bool IsGameOver{get{
            return this.isGameOver;
        }
    }

    public bool IsGameRunning{get{
            return this.isGameRunning;
        }
        set{
         this.isGameRunning=value;
        }
    }

    public void GameWon(){
        Time.timeScale=0f;
        this.isGameOver=true;
        GameWonUI.Instance.gameWon();
    }

    public  float getMinX(){return minX;}
    public  float getMinZ(){return minZ;}
    public  float getMaxX(){return maxX;}
    public  float getMaxZ(){return maxZ;}

}