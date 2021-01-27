using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    private int wave=-1;

    public static  int enemysAlive = 0;

    private int [][] enemysInWaves;
    private string [] enemysType = {"enemy_virus","enemy_spyware","enemy_worm","enemy_adware","enemy_horse","enemy_ransomware"};
    private float [] enemySpawnTime;

    public Text CurrentWaveNumber;

    public Text CurrentTimeUnitlNetxWave;

    private float countdown = 10f;

    private float timeBetweenWaves=6f; 

    private bool hasShowedSecondWaveDialogue;
    private bool hasShowedGameWonDialogue;
    public GameObject SecondWaveDialogue;
    public GameObject GameWonDialogue;

    void Awake(){
           enemysInWaves=Waves.GetWaves(LevelManager.Instance.GetLevel());
           enemySpawnTime=Waves.getWavesRespawnTime(LevelManager.Instance.GetLevel());
           this.wave=-1;
           enemysAlive = 0;
           this.countdown=10f;
           this.timeBetweenWaves=6f;
           this.hasShowedSecondWaveDialogue=false;
           this.hasShowedGameWonDialogue=false;
     }

    void Start()
    {
       
    }

    void Update ()
	{
       // Debug.Log("WS -"+enemysAlive+" - "+wave+" - "+(enemysInWaves.Length-1)+" - "+countdown);
		if (enemysAlive > 0 || !LevelManager.Instance.IsGameRunning)
		{
			return;
		}

		if (wave == enemysInWaves.Length-1)
		{
            if(GameWonDialogue==null){
                 LevelManager.Instance.GameWon();
			       this.enabled = false; 
                     return;
            }
            if(!hasShowedGameWonDialogue){
                GameWonDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
                this.hasShowedGameWonDialogue=true;
            }else{
                if(LevelManager.Instance.IsGameRunning){
                    DialogueManager.Instance.DialogueBox.SetActive(false);
                    LevelManager.Instance.GameWon();
			       this.enabled = false; 
                     return;
                }
            }	
		}

		if (countdown <= 0f)
		{
			StartWave();
			countdown = timeBetweenWaves;
			return;
		}

        if(wave == 0 && !hasShowedSecondWaveDialogue && this.SecondWaveDialogue!=null){
            hasShowedSecondWaveDialogue=true;
            SecondWaveDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		CurrentTimeUnitlNetxWave.text = "Inimigos Vindo Em "+ string.Format("{0:00}", countdown);
	}

    public void StartWave(){
       StartCoroutine(SpawWave());
   }

    private IEnumerator SpawWave(){
        wave++;

        CurrentWaveNumber.text = (wave+1).ToString();
        CurrentTimeUnitlNetxWave.text = "";

        enemysAlive = enemysInWaves[wave][0];

        for (int i = 1; i <= enemysInWaves[wave][0]; i++)
        {
            //Debug.Log(i);
            yield return new WaitForSeconds(enemySpawnTime[wave]);
            LevelManager.Instance.pool.GetObject(enemysType[enemysInWaves[wave][i]]);
        }
        
    }
}
