using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour {
    float theta_scale = 0.01f;        //Set lower to add more points
    int size; //Total number of points in circle
    LineRenderer lineRenderer;
 
    void Awake() {
        float sizeValue = (2.0f * Mathf.PI) / theta_scale;
        size = (int)sizeValue;
        size++;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = size;
        hide();
    }

    void moveToNewPosition(Vector3 position){
        lineRenderer.transform.position = 
            Vector3.Lerp(lineRenderer.transform.position, 
                new Vector3(position.x, lineRenderer.transform.position.y, position.z), 0.1f);
    }

    void updateCirclePoints(Vector3 position, float radius){
        float theta = 0f;
        for (int i = 0; i < size; i++)
        {
            theta += (2.0f * Mathf.PI * theta_scale);
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            position = new Vector3(x, 0, z);
            lineRenderer.SetPosition(i, position);
        }
    }

    public void hide(){
        lineRenderer.gameObject.SetActive(false);
    }
 
    public void DrawAt(Vector3 position, float radius) {
        lineRenderer.gameObject.SetActive(true);
        moveToNewPosition(position);
        updateCirclePoints(position, radius);
    }
}
