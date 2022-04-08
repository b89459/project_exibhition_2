using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;



public class Movement : MonoBehaviour
{
    private InputManager inputmanager;

    [SerializeField] private Transform Place;

    private Vector3 iniposition;
    GameObject particle;
    private Camera cameramain;
    private float deltaX, deltaY;
    Vector3 touchpos;
    private Touchh touchControls;

    private void Awake()
    {
        touchControls = new Touchh();

        inputmanager = InputManager.Instance;
        cameramain = Camera.main;
    }

    private static bool locked;


    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        //   inputmanager.OnStartTouch += move;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
        touchControls.Enable();
    }


    private void OnDisable()
    {
        //  inputmanager.OnEndTouch += move;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
        touchControls.Disable();
    }
    public void move(Vector2 screenPosition, float time)
    {
        if (!locked)
        {
            Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameramain.nearClipPlane);
            touchpos = cameramain.ScreenToWorldPoint(screenCoordinates);
            touchpos.z = 0;
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
            {
                transform.position = touchpos;

            }
            if (Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f && Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f)
            {
                transform.position = new Vector2(Place.position.x, Place.position.y);
                locked = true;
            }
        }

    }
    public void FingerDown(Finger finger)
    {

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
                if (!locked && GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                {
                    transform.position = touchpos;
                    deltaX = touchpos.x - transform.position.x;
                    deltaY = touchpos.x - transform.position.y;
                }

            };
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
            {

                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos))
                {

                    transform.position = touchpos;
                    Debug.Log(transform.position);
                }
            }
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended)
            {
                if (Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f && Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f)
                {
                    transform.position = new Vector2(Place.position.x, Place.position.y);
                    locked = true;
                }
            }
            else
            {

            }

        }

    }
}

