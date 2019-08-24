using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanUp : Player
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
            Switch((int)Orientation.Up, "H");
            checkHasBall(hasBall, MoveDimentions.UpX, MoveDimentions.UpY);
        }

        if (Input.GetAxis("Shoot_H") == 1)
        {
            if (hasBall)
            {
                kickBall("H", (int)Orientation.Up);
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
