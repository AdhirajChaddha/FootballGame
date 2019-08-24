using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Class that manages setting the active players in the game based on the ball's
// position and action. It is attatched to the main camera
public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddClosestPlayerEventListner(SetClosestPlayerActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When this listner event is called, it sets two players closet to the
    // ball to active from both the teams
    public void SetClosestPlayerActive(int State, int lastAction)
    {
        print("envoked bitches!!!!");
        string[] tags = { "skeleton", "human" };

        foreach (string tag_ in tags)
        {
            // Get all the gameObjects with the perticular tag
            GameObject[] players = GameObject.FindGameObjectsWithTag(tag_);
            if (players.Length != 0)
            {
                // Dictionary that hold distance to the gameObject as key and GameObject as value
                IDictionary<float, GameObject> dict = new Dictionary<float, GameObject>();

                // Array to store distnaces to sort 
                float[] distances = new float[players.Length];
                int i = 0;

                foreach (GameObject player in players)
                {
                    // Getting the player's position and calculating the distance to the player
                    Vector2 distanceVector = player.transform.position - transform.position;
                    float distance = Mathf.Sqrt(
                        (distanceVector.x * distanceVector.x) + (distanceVector.y * distanceVector.y));

                    // Adding it to the dictonary for later refrence and array for sorting
                    dict.Add(distance, player);
                    distances[i] = distance;
                    i++;


                }
                Array.Sort(distances);

                foreach(float d in distances)
                {
                    print("Distance for " + tag_ + " is: " + d);
                }

                GameObject activePlayer = dict[distances[0]];

                #region get approraite component and set its active state to true
                try
                {
                    if (tag_ == "skeleton")
                    {
                        activePlayer.GetComponent<SkeletonStill>().Active = true;
                    }
                    else
                    {
                        activePlayer.GetComponent<HumanStill>().Active = true;
                    }
                }
                catch
                {
                    try
                    {
                        if (tag == "skeleton")
                        {
                            activePlayer.GetComponent<SkeletonRight>().Active = true;
                        }
                        else
                        {
                            activePlayer.GetComponent<HumanRight>().Active = true;
                        }
                    }
                    catch
                    {
                        try
                        {
                            if (tag == "skeleton")
                            {
                                activePlayer.GetComponent<SkeletonLeft>().Active = true;
                            }
                            else
                            {
                                activePlayer.GetComponent<HumanLeft>().Active = true;
                            }
                        }
                        catch
                        {
                            try
                            {
                                if (tag == "skeleton")
                                {
                                    activePlayer.GetComponent<SkeletonUp>().Active = true;
                                }
                                else
                                {
                                    activePlayer.GetComponent<HumanUp>().Active = true;
                                }
                            }
                            catch
                            {
                                if (tag == "skeleton")
                                {
                                    activePlayer.GetComponent<SkeletonDown>().Active = true;
                                }
                                else
                                {
                                    activePlayer.GetComponent<HumanDown>().Active = true;
                                }
                            }
                        }
                    }
                }
                #endregion

            }

        }
    }
}
