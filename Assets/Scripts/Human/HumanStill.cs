using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStill : Player
{
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (active)
        {
            Switch((int)Orientation.Still, "H");
            checkHasBall(hasBall, MoveDimentions.LeftX, MoveDimentions.LeftY);
        }

        if (Input.GetAxis("Shoot_H") == 1)
        {
            if (hasBall)
            {
                kickBall("H", (int)Orientation.Still);
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
