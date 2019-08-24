using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonLeft : Player
{
    // Start is called before the first frame update
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
            Switch((int)Orientation.Left,"S");
            checkHasBall(hasBall, MoveDimentions.LeftX, MoveDimentions.LeftY);
        }
        if (Input.GetAxis("Shoot_S") == 1)
        {
            if (hasBall)
            {
                kickBall("H", (int)Orientation.Left);
                hasBall = false;
            }
        }

        if (Input.GetAxis("Pass_S") == 1)
        {
            if (hasBall)
            {
                passBall();
                hasBall = false;
            }
        }

    }
}
