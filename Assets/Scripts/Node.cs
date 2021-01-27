using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Color32 fullColor = new Color32(255,118,118,255);
    private Color32 emptyColor = new Color32(96,255,90,255);
    private Color defaultColor;

    private SpriteRenderer rend;

    private GameObject tower;

    public bool IsEmpty{get;private set;}

    void Start(){
        rend = GetComponent<SpriteRenderer>();
        defaultColor=rend.color;
        IsEmpty=true;
    }


  private void OnMouseExit(){
      HouverNodeColor(defaultColor);
   }

  private void OnMouseOver()
    {
         if(!IsEmpty && !EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn == null){
             if(Input.GetMouseButtonDown(0)){
                LevelManager.Instance.SelectNode(this);
                Debug.Log("Node");
             }
        }
         if(!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null){
             if(IsEmpty && LevelManager.Instance.canbuyTower(GameManager.Instance.ClickedBtn.TowerPrefab.GetComponent<Tower>().Cost)){
                    HouverNodeColor(emptyColor);
                    if(Input.GetMouseButtonDown(0)){
                         PlaceTower();
                    }
             }else{
                 HouverNodeColor(fullColor);
             }
        }

       
    }

    public void DestroyTower(){
        this.IsEmpty=true;
        Destroy(tower);
        this.tower=null;
    }

    private void PlaceTower(){
        tower = Instantiate(GameManager.Instance.ClickedBtn.TowerPrefab,transform.position,Quaternion.identity);
        GameManager.Instance.BuyTower();
        IsEmpty=false;
        HouverNodeColor(defaultColor);
    }


    private void HouverNodeColor(Color newColor){
        rend.color = newColor;
    }

    public GameObject Tower(){
        return this.tower;
    }

    public Vector3 GetBuildPosition ()
	{
		return transform.position ;
	}
}
