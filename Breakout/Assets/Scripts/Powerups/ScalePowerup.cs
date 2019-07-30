using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePowerup : Powerup
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    //add 1 to the scale of the gameObject
    protected override void applyPowerup(GameObject gameObject) {
        gameObject.transform.localScale  += new Vector3(1, 0, 0);
    }

    //subtract 1 from the scale of the gameObject
    protected override void undoPowerup(GameObject gameObject) {
        gameObject.transform.localScale -= new Vector3(1, 0, 0);
    }

    protected override float getPowerupTime() {
        return 10f;
    }
}
