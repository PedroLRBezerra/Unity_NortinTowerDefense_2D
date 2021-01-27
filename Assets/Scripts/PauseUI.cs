using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape)  || Input.GetKeyDown(KeyCode.P)){
            Toggle();
        }
    }

    public void Toggle(){
        if(!LevelManager.Instance.IsGameOver){
            pauseUI.SetActive(!pauseUI.activeSelf);
        }
        

        if(pauseUI.activeSelf){
            pause();
        }else{
           unPause();
        }
    }

    public void Retry(){
         Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu(){
        Debug.Log("Menu");
    }

    private void pause(){
         Time.timeScale=0f;
         GameManager.Instance.DropTower();
         GameObject [] towerBtns = GameObject.FindGameObjectsWithTag("TowerBtn");
         foreach (GameObject  btn in towerBtns)
         {
             btn.GetComponent<Button>().interactable = false;
         }
         LevelManager.Instance.ChangeBlur();
    }

     private void unPause(){
         Time.timeScale=1f;
         GameObject [] towerBtns = GameObject.FindGameObjectsWithTag("TowerBtn");
         foreach (GameObject  btn in towerBtns)
         {
             btn.GetComponent<Button>().interactable = true;
         }
         LevelManager.Instance.ChangeBlur();
    }
}
