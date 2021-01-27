using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Text TowerCost;

    public Sprite Sprite{
        get{
            return sprite;
        }
    }

    void Start(){
        this.TowerCost.text="$"+towerPrefab.GetComponent<Tower>().Cost;
    }

    public GameObject TowerPrefab { get{
            return towerPrefab;
        }
    }
   
}
