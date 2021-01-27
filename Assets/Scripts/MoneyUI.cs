using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

    public Text playerMoneyText;
   

    // Update is called once per frame
    void Update()
    {
        playerMoneyText.text="$ "+LevelManager.Instance.getPlayerMoney();
    }
}
