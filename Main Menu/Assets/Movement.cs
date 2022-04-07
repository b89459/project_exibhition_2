using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    [SerializeField] private Transform Place;

    private Vector2 iniposition;

   
    
    private float deltaX, deltaY;
 
    private static bool locked;

    private void start()
    {
        iniposition = transform.position;
    }

    private void update()
    {
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
            locked = false;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                  //  if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                    {
                        deltaX = touchpos.x - transform.position.x;
                        deltaY = touchpos.x - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                    {
                        transform.position = new Vector2(touchpos.x - deltaX, touchpos.y - deltaY);
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f && Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f)
                    {
                        transform.position = new Vector2(Place.position.x, Place.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(iniposition.x, iniposition.y);
                    }
                    break;
            }
        }
    }
}
