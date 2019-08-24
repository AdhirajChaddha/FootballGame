using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static Ball invoker;
    static UnityAction<int, int> listner;

    public static void AddClosestPlayerEventInvoker(Ball ball)
    {
        invoker = ball;

        if (listner != null)
        {
            invoker.AddClosestPlayerAciveEventListner(listner);
        }
    }

    public static void AddClosestPlayerEventListner(UnityAction<int, int> listner_)
    {
        listner = listner_;

        if (invoker != null)
        {
            invoker.AddClosestPlayerAciveEventListner(listner);
        }
    }
}
