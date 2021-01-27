using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private int cod;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float damage;

    private Transform target;



    public void Seek(Transform _target){
        target=_target;
    }

    // Update is called once per frame
    void Update()
    {
        if(!target.gameObject.activeSelf){
            release();
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        float angle = (Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg)-270;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(dir.magnitude<=distanceThisFrame){
            hitTarget();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame,Space.World);
    }

    void hitTarget(){
        release();
        target.GetComponent<Enemy>().takeDamage(cod,damage);
    }

     private void release(){
        LevelManager.Instance.pool.releaseObject(gameObject);
    }
}
