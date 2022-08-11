using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 direction = Vector3.zero;
    [SerializeField] [Range(0f, 10f)] private float damp = 1f;
    [SerializeField] [Range(0f, 10f)] private float velocityDamp = 3f;
    private Vector3 Xmin;
    private Vector3 Ymax;
    private bool dead;

    private void Start()
    {
        Camera camera = Camera.main;
        Xmin = camera.ScreenToWorldPoint(new Vector3 (0f, 0f, 1));
        Ymax = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 1));
        this.enabled = false;
    }

    public void Kill()
    {
        direction = Vector3.zero;
        dead = true;
    }
    
    public void Resurrect()
    {
        dead = false;
    }
    
    void FixedUpdate()
    {
        if(dead) return;
        
        if (Input.GetKey(KeyCode.W))
            direction += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            direction -= Vector3.up;
        if (Input.GetKey(KeyCode.A))
            direction -= Vector3.right;
        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;
        if (Input.GetKey(KeyCode.Mouse1))
            RotateTowardsMouse();
        
        if(direction == Vector3.zero) return;
        
        DirectionClamper(ref direction);
        var position = transform.position;
        Vector3 sumPos = position + direction;
        Vector3 toPos = new Vector3(Mathf.Clamp(sumPos.x,Xmin.x + 1.5f,Ymax.x - 1.5f),
            Mathf.Clamp(sumPos.y,Xmin.y + 1.5f,Ymax.y - 1.5f),sumPos.z);
        position = Vector3.Lerp(position, toPos, damp);
        transform.position = position;
        DirectionReducer(ref direction);
    }

    public void RotateTowardsMouse()
    {
        Vector3 pos = new Vector3(transform.position.x,transform.position.y,0);
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos;
        float angle = Vector3.Angle(transform.up,mousePoint);
        float sign = Mathf.Sign(Vector3.Cross(transform.up,mousePoint).z);
        angle *= sign;
        transform.Rotate(transform.forward,angle);
    }

    /// <summary>
    /// This could be done by rigidbody but I'd prefer mathf-based movement
    /// </summary>
    /// <param name="dir"></param>
    public void DirectionClamper(ref Vector3 dir)
    {
        float x, y, z;
        x = Mathf.Clamp(dir.x, -1,1);
        y = Mathf.Clamp(dir.y, -1,1);
        z = Mathf.Clamp(dir.z, -1,1);
        dir = new Vector3(x,y,0);
    }

    public void DirectionReducer(ref Vector3 dir)
    {
        float x, y, z;
        x = dir.x;
        y = dir.y;
        z = dir.z;

        x = Mathf.Abs(x) > 0.1f ? Mathf.Sign(x) * (Mathf.Abs(x) - Time.deltaTime * velocityDamp ) : 0;
        y = Mathf.Abs(y) > 0.1f ? Mathf.Sign(y) * (Mathf.Abs(y) - Time.deltaTime * velocityDamp ) : 0;
        z = Mathf.Abs(z) > 0.1f ? Mathf.Sign(z) * (Mathf.Abs(z) - Time.deltaTime * velocityDamp ) : 0;
        dir = new Vector3(x,y,z);
    }
}
