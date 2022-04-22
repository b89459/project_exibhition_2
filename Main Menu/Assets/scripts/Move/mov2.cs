using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;



public class mov2 : MonoBehaviour
{
    private InputManager inputmanager;

    [SerializeField] private Transform Place;

    private Vector3 iniposition;

    private Camera cameramain;

    Vector3 touchpos;
    private Touchh touchControls;



    private void Awake()
    {
        touchControls = new Touchh();
        iniposition = transform.position;
        inputmanager = InputManager.Instance;
        cameramain = Camera.main;
    }

   public static bool locked;


    private void OnEnable()
    {

        //   inputmanager.OnStartTouch += move;

        touchControls.Enable();
        EnhancedTouchSupport.Enable();
    }


    private void OnDisable()
    {
        //  inputmanager.OnEndTouch += move;
        touchControls.Disable();
        EnhancedTouchSupport.Disable();
    }
    public void move(Vector2 screenPosition, float time)
    {
        if (locked)
        {
            Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameramain.nearClipPlane);
            touchpos = cameramain.ScreenToWorldPoint(screenCoordinates);
            touchpos.z = 0;
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
            {

            }
            if (Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f && Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f)
            {
                transform.position = new Vector2(Place.position.x, Place.position.y);

            }
        }

    }


    private void Update()
    {



        foreach (UnityEngine.InputSystem.EnhancedTouch.Touch touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            Vector2 screenPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();

            Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameramain.nearClipPlane);
            touchpos = cameramain.ScreenToWorldPoint(screenCoordinates);
            touchpos.z = 0;

            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                if (locked == false)
                {
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                    {
                        transform.position = touchpos;



                    }
                }
            };
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
            {
                if (locked == false)
                {

                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                    {

                        transform.position = touchpos;

                    }
                }
            }
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended)
            {
                if (Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f && Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f)
                {
                    transform.position = new Vector2(Place.position.x, Place.position.y);
                    locked = true;
                    gameObject.GetComponent<Collider2D>().enabled = false;
                }
            }
            else
            {

                {
                    // transform.position = iniposition;
                }
            }
            if (touch.tapCount == 2)
            {
                if (locked == false)
                {
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                    {


                        Debug.Log("Done");
                        transform.eulerAngles = new Vector3(
    transform.eulerAngles.x,
    transform.eulerAngles.y,
   transform.eulerAngles.z + 45
);
                        break;
                    }
                }
            }

        }

    }
}

