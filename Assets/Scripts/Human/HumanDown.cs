using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDown : Player
{
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (active){
            Switch((int)Orientation.Down, "H");
            checkHasBall(hasBall, MoveDimentions.DownX, MoveDimentions.DownY);
        }

        if (Input.GetAxis("Shoot_H") == 1)
        {
            if (hasBall)
            {
                kickBall("H", (int)Orientation.Down);
                hasBall = false;
            }
        }

        if (Input.GetAxis("Pass_H") == 1)
        {
            if (hasBall)
            {
                passBall();
                hasBall = false;
            }
        }

    }
}
