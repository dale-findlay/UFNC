using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int conveyorSpeed = 2;
    List<Type> supportedTypes = new List<Type>();

    public bool startGame = false;
    public bool enableGrab = true;
    public bool pauseEnabled = true;

    public Player currentPlayer;

    private Type lastType = null;
    private Component lastObject = null;
    private void Awake()
    {
        if (gameManager)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        //Save

        //int saveCount = SaveGameManager.saveGameManager.GetSaveCount();
        //if(saveCount == 0)
        //{
        //    //no saves so it needs to be new game not continue.
        //    playText.text = "New Game";
        //}
        //else
        //{
        //    playText.text = "Continue";
        //}

        supportedTypes.Add(typeof(WaterBottle));
        supportedTypes.Add(typeof(NoodleBowl));
    }

    void OnMethodCall(Type t, Component currentComponent, string methodName)
    {

        switch (t.Name)
        {
            case "NoodleBowl":
                {
                    (currentComponent as NoodleBowl).Invoke(methodName, 0);
                    break;
                }
            case "WaterBottle":
                {
                    (currentComponent as WaterBottle).Invoke(methodName, 0);
                    break;
                }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (enableGrab)
        {
            Vector2 mousePointWorld = Camera.main.ScreenToWorldPoint(InputHandler.InputPosition);

            Debug.DrawRay(mousePointWorld, Vector3.forward * 10, Color.red);

            RaycastHit2D hitInfo = Physics2D.Raycast(mousePointWorld, Vector2.zero, 0);

            if (lastObject != null)
            {
                lastObject.transform.position = mousePointWorld;
            }

            if (hitInfo)
            {
                GameObject hitGameObject = hitInfo.transform.gameObject;

                //Debug.Log("Hit Object: " + hitGameObject.name);

                foreach (Type t in supportedTypes)
                {
                    Component[] components = hitGameObject.GetComponents(t);

                    if (components.Length == 1)
                    {
                        Component currentComponent = components[0];

                        //Debug.Log("Supported Object Found: " + currentComponent.name);

                        if (InputHandler.GetScreenPressDown(0))
                        {
                            //we are grabbing a supported object.
                            currentComponent.transform.position = mousePointWorld;

                            OnMethodCall(t, currentComponent, "OnGrabStart");

                            lastType = t;
                            lastObject = currentComponent;
                        }
                        else if (InputHandler.GetScreenPressUp(0))
                        {
                            if (lastObject != null)
                            {
                                OnMethodCall(lastType, lastObject, "OnGrabEnd");
                                lastObject = null;
                            }

                        }
                    }
                }
            }
        }
    }
}
