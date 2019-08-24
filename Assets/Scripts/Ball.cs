using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    int withSomeone;
    int lastAction;

    ClosestPlayersActiveEvent closestPlayersActiveEvent = new ClosestPlayersActiveEvent();

    public int WithSomeone
    {
        get{ return withSomeone; }
        set{ withSomeone = value; }
    }

    public int LastAction
    {
        get { return lastAction; }
        set { lastAction = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddClosestPlayerEventInvoker(this);

        withSomeone = (int)BallData.Idle;
        lastAction = (int)BallData.Still;

        closestPlayersActiveEvent.Invoke(withSomeone, lastAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (withSomeone == (int)BallData.Idle && lastAction == (int)BallData.Still)
        {
            //print("Called");
            //closestPlayersActiveEvent.Invoke(withSomeone, lastAction);
        }
    }

    Vector3[] SpriteLocalToWorld(Sprite sp)
    {
        Vector3 pos = transform.position;
        Vector3[] array = new Vector3[2];
        //top left
        array[0] = pos + sp.bounds.min;
        // Bottom right
        array[1] = pos + sp.bounds.max;
        return array;
    }

    public void AddClosestPlayerAciveEventListner(UnityAction<int, int> listner)
    {
        closestPlayersActiveEvent.AddListener(listner);
    }
}
