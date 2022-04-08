using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class rortation : MonoBehaviour
{
    private InputManager inputmanager;
    private Touchh touchControls;
    UnityEngine.InputSystem.EnhancedTouch.Touch touch;
    float touchDuration;
    private void Awake()
    {
        touchControls = new Touchh();

        inputmanager = InputManager.Instance;
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if(UnityEngine.InputSystem. > 0)
        {
            touchDuration += Time.deltaTime;
            
        }
    }
    public static bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }
}
