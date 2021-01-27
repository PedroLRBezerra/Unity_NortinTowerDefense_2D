using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : Singleton<Hover>
{

    private SpriteRenderer spriteRenderer;
    private float drawedSphereSize;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse(){
        if(spriteRenderer.enabled){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x,transform.position.y,0);
        }
    }

    public void Activate(Sprite sprite, float range){
        this.spriteRenderer.sprite = sprite;
        spriteRenderer.enabled=true;
        drawedSphereSize=range;
    }

    public void Deactivate(){
        spriteRenderer.enabled=false;
        this.drawedSphereSize=0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y,0), this.drawedSphereSize);
        Debug.Log("cc");
    }

}
