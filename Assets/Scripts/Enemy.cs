using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private string type;   
    [SerializeField]
    private int cod; 
    [SerializeField]
    private float speed=1f;
    [SerializeField]
    private float life;
    private float startLife;
    [SerializeField]
    private int moneyWorth;

   
    private Transform nextDestination;
    private int wavepointIndex=0;

    void Start(){
        nextDestination = Waypoints.points[0];
        transform.position= GameObject.FindGameObjectWithTag("Start").transform.position;
        this.startLife=life;
    }

    void Update(){
        transform.position=Vector2.MoveTowards(transform.position,nextDestination.position,speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,nextDestination.position)< 0.1f){
            wavepointIndex++;
            if(wavepointIndex<Waypoints.points.Length){
                nextDestination=Waypoints.points[wavepointIndex];
            }else{
                GameOverUI.Instance.EnemyWiner(gameObject);
                LevelManager.Instance.EndGame();
                release();
            }
            
        }
    }
    
 public void release(){
        LevelManager.Instance.pool.releaseObject(gameObject);
       reset();
    }
    
private void reset(){
    transform.position=GameObject.FindGameObjectWithTag("Start").transform.position;
    wavepointIndex=0;
    nextDestination = Waypoints.points[0];
    this.life=startLife;
}

public void takeDamage(int codShot , float damage){
    this.life-=damage*((float)(DamageShot.Instance.getMultDmg(this.cod,codShot)));
    if(this.life<=0){
        WaveSpawner.enemysAlive--;
        LevelManager.Instance.earnMoney(this.moneyWorth);
        release();
    }
}

public string Type{get{
        return this.type;
    }
}

}
