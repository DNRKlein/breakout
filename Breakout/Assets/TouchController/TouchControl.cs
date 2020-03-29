using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    public bool isTouched() {
        if(Input.touchCount > 0) {
            var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchPosition = new Vector2(wp.x, wp.y);
            if(collider == Physics2D.OverlapPoint(touchPosition)) {
                return true;
            } else {
                return false;
            }
        }
        return false;
    }
}
