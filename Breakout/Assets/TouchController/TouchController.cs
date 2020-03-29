using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField]
    private TouchControl leftControl;
    [SerializeField]
    private TouchControl rightControl;
    [SerializeField]
    private TouchControl launchBallControl;

    public int getMovementTouchRaw() {
        if(leftControl.isTouched()) {
            return -1;
        } else if (rightControl.isTouched()) {
            return 1;
        } else {
            return 0;
        }
    }

    public bool launchBallControlIsTouched() {
        if(launchBallControl.isTouched()) {
            return true;
        } else {
            return false;
        }
    }
}
