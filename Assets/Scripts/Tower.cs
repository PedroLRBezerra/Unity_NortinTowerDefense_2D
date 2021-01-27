using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

[Header("Attributes")]
[SerializeField]
private float range = 5f;
[SerializeField]
private float fireRate = 1f;
private float fireCountdown = 0f;
[SerializeField]
private float cost;
[SerializeField]
private string shotType;
[SerializeField]

[Header("Unity Setup Fields")]
private Transform target;
public string enemyTag = "Enemy";
public GameObject firepoint;

void Start(){
    InvokeRepeating("UpdateTarget",0f,0.5f);
}

void Update(){
    if(target==null)
        return;    

    LockOnTarget();

    if(fireCountdown<=0f){
        Shoot();
        fireCountdown = 1f/fireRate;
    }

    fireCountdown -= Time.deltaTime;

}

void UpdateTarget(){
    GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    float shortestDistance = Mathf.Infinity;
    GameObject nearestEnemy = null;

    foreach (GameObject enemy in enemies)
    {
        float distanceToEnemy = Vector2.Distance(transform.position,enemy.transform.position);
        if(distanceToEnemy<shortestDistance && enemy.activeSelf){
            shortestDistance=distanceToEnemy;
            nearestEnemy=enemy;
        }
    }

    if(nearestEnemy != null && shortestDistance <= range){
        target = nearestEnemy.transform;
    }else
    {
        target=null;
    }
}

void LockOnTarget ()
{
    Vector3 dir = target.position - transform.position;
    float angle = (Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg)-270;
    transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
}

private void Shoot(){
    Shot shot = LevelManager.Instance.pool.GetObject(shotType).GetComponent<Shot>();
    if(shot!=null){
        shot.Seek(target);
        shot.transform.position=firepoint.transform.position;
    }
    
}

 void OnDrawGizmosSelected(){
     Gizmos.color=Color.red;
     Gizmos.DrawWireSphere(transform.position,range);
 }

  public float Range { get{
            return range;
        }
    }

    public int Cost{get{
            return (int)cost;
        }
    }

}
