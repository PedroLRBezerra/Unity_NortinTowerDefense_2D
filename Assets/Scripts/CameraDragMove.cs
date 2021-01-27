using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragMove : MonoBehaviour {
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;


    void Start () {
        ResetCamera = Camera.main.transform.position;
    }
    void LateUpdate () {
        if (Input.GetMouseButton (0)) {
            Diference = (Camera.main.ScreenToWorldPoint (Input.mousePosition)) - Camera.main.transform.position;
            if (Drag == false) {
                Drag = true;
                Origin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            }
        } else {
            Drag = false;
        }
        if (Drag == true) {
        Vector3 xyBounded = Camera.main.transform.position;
        xyBounded.x=Mathf.Clamp(Origin.x - Diference.x,LevelManager.Instance.getMinX(), LevelManager.Instance.getMaxX());
        xyBounded.y=Mathf.Clamp(Origin.y - Diference.y,LevelManager.Instance.getMinZ(), LevelManager.Instance.getMaxZ());

        Camera.main.transform.position = xyBounded;
        }
    }
}