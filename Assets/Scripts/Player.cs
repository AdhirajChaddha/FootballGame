using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject skeleton_left;
    [SerializeField] GameObject skeleton_right;
    [SerializeField] GameObject skeleton_up;
    [SerializeField] GameObject skeleton_down;
    [SerializeField] GameObject skeleton_still;

    protected Camera camera;

    float speed = Constants.PlayerSpeed;

    // Valiable to hold the direction  that character is facing (left/right/up/down)
    int flag;

    // Bool to know weather or not the character has the ball with him or not.
    protected bool hasBall;
    // Setter methord to allow other class to tell weather it has the ball or not on creation
    public bool HasBall
    {
        set{ hasBall = value; }
        get { return hasBall; }
    }
    // Bool to know weather or not the player is active. only 2 players active at a time
    // and only active players can move around 
    protected bool active;
    public bool Active
    {
        set { active = value; }
        get { return active; }
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        bound();
    }

    // Methord to ants to move is not the one they are
    // Currently moving at.
    // Axis suffix is S for skeleton and H for human it is used to decide who to act on
    protected void Switch(int flag, string axisSuffix)
    {
        //print(hasBall);
        // Getting position 
        Vector3 position = transform.position;

        if (Input.GetAxis("Horizontal_" + axisSuffix) != 0f)
        {
            if (Input.GetAxis("Horizontal_" + axisSuffix) > 0)
            {
                if (flag != (int)Orientation.Right)
                {
                    GameObject player = Instantiate(skeleton_right, position, Quaternion.identity);
                    #region Pass on 'active' value
                    if (axisSuffix == "S")
                    {
                        SkeletonRight skeletonRight = player.GetComponent<SkeletonRight>();
                        skeletonRight.Active = true;
                    }
                    else
                    {
                        HumanRight humanRight = player.GetComponent<HumanRight>();
                        humanRight.Active = true;
                    }
                    #endregion
                    #region pass along 'hasball' value
                    if (hasBall)
                    {
                        updateBallPosition(position, MoveDimentions.RightX, MoveDimentions.RightY);
                        if (axisSuffix == "S")
                        {
                            SkeletonRight skeletonRight = player.GetComponent<SkeletonRight>();
                            skeletonRight.HasBall = true;
                        }
                        else
                        {
                            HumanRight humanRight = player.GetComponent<HumanRight>();
                            humanRight.HasBall = true;
                        }
                    }
                    #endregion 
                    Destroy(gameObject);
                }
            }
            else
            {
                if (flag != (int)Orientation.Left)
                {
                    GameObject player = Instantiate(skeleton_left, position, Quaternion.identity);
                    #region pass along 'acive' value 
                    if (axisSuffix == "S")
                    {
                        SkeletonLeft skeletonLeft = player.GetComponent<SkeletonLeft>();
                        skeletonLeft.active = true;
                    }
                    else
                    {
                        HumanLeft humanLeft = player.GetComponent<HumanLeft>();
                        humanLeft.active = true;
                    }
                    #endregion
                    #region pass along 'hasball' value
                    if (hasBall)
                    {
                        updateBallPosition(position, MoveDimentions.LeftX, MoveDimentions.LeftY);
                        if (axisSuffix == "S")
                        {
                            SkeletonLeft skeletonLeft = player.GetComponent<SkeletonLeft>();
                            skeletonLeft.HasBall = true;
                        }
                        else
                        {
                            HumanLeft humanLeft = player.GetComponent<HumanLeft>();
                            humanLeft.HasBall = true;
                        }
                    }
                    #endregion
                    Destroy(gameObject);
                }
            }
            position.x += Input.GetAxis("Horizontal_" + axisSuffix) * speed * Time.deltaTime;
            transform.position = position;
        }

        else if (Input.GetAxis("Vertical_" + axisSuffix) != 0)
        {
            if (Input.GetAxis("Vertical_" + axisSuffix) > 0)
            {
                if(flag != (int)Orientation.Up)
                {
                    GameObject player = Instantiate(skeleton_up, position, Quaternion.identity);
                    #region pass along 'active' value
                    if (axisSuffix == "S")
                    {
                        SkeletonUp skeletonUp = player.GetComponent<SkeletonUp>();
                        skeletonUp.active = true;
                    }
                    else
                    {
                        HumanUp humanUp = player.GetComponent<HumanUp>();
                        humanUp.active = true;
                    }
                    #endregion
                    #region pass along 'hasball' value
                    if (hasBall)
                    {
                        updateBallPosition(position, MoveDimentions.UpX, MoveDimentions.UpY);
                        if (axisSuffix == "S")
                        {
                            SkeletonUp skeletonUp = player.GetComponent<SkeletonUp>();
                            skeletonUp.HasBall = true;
                        }
                        else
                        {
                            HumanUp humanUp = player.GetComponent<HumanUp>();
                            humanUp.HasBall = true;
                        }
                    }
                    #endregion
                    Destroy(gameObject);
                }
            }
            else
            {
                if (flag != (int)Orientation.Down)
                {
                    GameObject player = Instantiate(skeleton_down, position, Quaternion.identity);
                    #region pass along 'active' value
                    if (axisSuffix == "S")
                    {
                        SkeletonDown skeletonDown = player.GetComponent<SkeletonDown>();
                        skeletonDown.active = true;
                    }
                    else
                    {
                        HumanDown humanDown = player.GetComponent<HumanDown>();
                        humanDown.active = true;
                    }
                    #endregion
                    #region pass along 'hasball' value
                    if (hasBall)
                    {
                        updateBallPosition(position, MoveDimentions.UpX, MoveDimentions.UpY);
                        if (axisSuffix == "S")
                        {
                            SkeletonDown skeletonDown = player.GetComponent<SkeletonDown>();
                            skeletonDown.HasBall = true;
                        }
                        else
                        {
                            HumanDown humanDown = player.GetComponent<HumanDown>();
                            humanDown.HasBall = true;
                        }
                    }
                    #endregion
                    Destroy(gameObject);
                }   
            }
            position.y += Input.GetAxis("Vertical_" + axisSuffix) * speed * Time.deltaTime;
            transform.position = position;
        }
        // If there is no key pressed, it returns to the still state. 
        else
        { 
            if (flag != (int)Orientation.Still){
                GameObject player = Instantiate(skeleton_still, position, Quaternion.identity);
                #region pass along 'active' value
               
                if (axisSuffix == "S")
                {
                    SkeletonStill skeletonStill = player.GetComponent<SkeletonStill>();
                    skeletonStill.active = true;
                }
                else
                {
                    HumanStill humanStill = player.GetComponent<HumanStill>();
                    humanStill.active = true;
                }
                
                #endregion
                #region pass along 'hasball' value
                if (hasBall)
                {
                    updateBallPosition(position, MoveDimentions.RightX, MoveDimentions.RightY);
                    if (axisSuffix == "S")
                    {
                        SkeletonStill skeletonStill = player.GetComponent<SkeletonStill>();
                        skeletonStill.HasBall = true;
                    }
                    else
                    {
                        HumanStill humanStill = player.GetComponent<HumanStill>();
                        humanStill.HasBall = true;
                    }
                }
                #endregion
                Destroy(gameObject);
            }
        }
    }

    //Sets the has ball check to true when there is a collission
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            //print("Yep Hit the ball");
            hasBall = true;

        }
    }

    // Functions that checks if the player has the ball and if it does it keeps the
    // Ball next to the player
    protected void checkHasBall(bool hasBall, float X, float Y)
    {
        if (hasBall)
        {
            updateBallPosition(transform.position, X, Y);
        }
    }

    // Methord that displaces the ball a certain distance X and Y from given position
    private void updateBallPosition(Vector3 playerPosition, float X, float Y)
    {
        //Vector3 playerPosition = transform.position;
        GameObject ball = GameObject.FindGameObjectWithTag("ball");

        //playerPosition = camera.WorldToScreenPoint(playerPosition);

        Vector3 ballPosition;
        ballPosition.x = playerPosition.x + X;
        ballPosition.y = playerPosition.y + Y;
        ballPosition.z = playerPosition.z;

        //ballPosition = camera.ScreenToWorldPoint(ballPosition);

        ball.transform.position = ballPosition;
    }

    // Function that applies a foce to the ball and shoots in a random 30 degree
    //range in the direction that the player is facing 
    protected void kickBall(string axisPrefix, int orientation)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("ball");
        Rigidbody2D rb2d = ball.GetComponent<Rigidbody2D>();

        float X = UnityEngine.Random.Range(0.8f, 1.0f);
        float Y = UnityEngine.Random.Range(-0.13f, 0.13f);
        float power = UnityEngine.Random.Range(Constants.MinBallSpeed, Constants.MaxBallSpeed);

        if(orientation == (int)Orientation.Right)
        {
            rb2d.AddForce(new Vector2(power * X, power * Y), ForceMode2D.Impulse);
            print("X, Y, Power: " + X + " " + Y + " " + power);
        }
        else if(orientation == (int)Orientation.Left)
        {
            X = -X;
            rb2d.AddForce(new Vector2(power * X, power * Y), ForceMode2D.Impulse);
            print("X, Y, Power: " + X + " " + Y + " " + power);
        }
        else if (orientation == (int)Orientation.Up)
        {
            updateBallPosition(ball.transform.position, 0, 0.9f);
            float temp = X;
            X = Y;
            Y = temp;
            rb2d.AddForce(new Vector2(power * X, power * Y), ForceMode2D.Impulse);
            print("X, Y, Power: " + X + " " + Y + " " + power);
        }
        else if (orientation == (int)Orientation.Down)
        {
            updateBallPosition(ball.transform.position, 0, -0.4f);
            float temp = -X;
            X = Y;
            Y = temp;
            rb2d.AddForce(new Vector2(power * X, power * Y), ForceMode2D.Impulse);
            print("X, Y, Power: " + X + " " + Y + " " + power);
        }
        else if (orientation == (int)Orientation.Still)
        {
            rb2d.AddForce(new Vector2(power * X, power * Y), ForceMode2D.Impulse);
            print("X, Y, Power: " + X + " " + Y + " " + power);
        }

    }

    private void bound()
    {
        Vector3 position = transform.position;

        // Left Edge
        if (position.x - 0.3f < -9)
        {
            position.x = -9 + 0.3f;
        }
        else if (position.x + 0.3f > 9)
        {
            position.x = 9 - 0.3f;
        }

        transform.position = position;
    }

    protected void passBall()
    {
        // Get all the gameObjects with the perticular tag
        GameObject[] players = GameObject.FindGameObjectsWithTag("skeleton");
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
                print("Distance is: " + d);
            }
        }
    }
}
