using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Movement : MonoBehaviour
{
    private InputManager inputmanager;

    [SerializeField] private Transform Place;

    private Vector3 iniposition;
    GameObject particle;
    private camera cameramain;


    private float deltaX, deltaY;
 
    private static bool locked;

  private void Awake()
    {
        inputmanager = InputManager.instance;
        cameramain = cameramain.main;
    }
    private void OnEnable()
    {
        inputmanager.OnStartTouch += move;
    }
    private void OnDisable()
    {
        inputmanager.OnEndTouch += move;
    }
    public void move

        private void update()
    {
        foreach (Touch touch in Input.touches)
        {
            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray))
            {
                // Create a particle if hit
                Instantiate(particle, transform.position, transform.rotation);
            }
        }
            if (Input.touchCount > 0 && !locked)
        {
            Debug.Log("Hello");
            Touch touch = Input.GetTouch(0);
            Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {

                deltaX = touchpos.x - transform.position.x;
                deltaY = touchpos.x - transform.position.y;

                Debug.Log("began");
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                {
                    transform.position = new Vector2(touchpos.x - deltaX, touchpos.y - deltaY);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f && Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f)
                {
                    transform.position = new Vector2(Place.position.x, Place.position.y);
                    locked = true;
                }
            }
              
                    else
                    {
                        transform.position = new Vector2(iniposition.x, iniposition.y);
                    }
                   
            
        }
    }
}
