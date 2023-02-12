using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public Transform parentTransform; //For the grid position

    public GameObject building;

    [SerializeField] GameObject towerMenu = null;

    ButtonScripts buttons;

    private void OnEnable()
    {
        if(towerMenu == null)
        {
            GameObject rootObject = GameObject.Find("Canvas");
            towerMenu = rootObject.transform.Find("TowerPanel").gameObject;
        }
        buttons = towerMenu.GetComponent<ButtonScripts>();
    }
    private void OnMouseUpAsButton()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        buttons.UpdateButtons(this);
        towerMenu.SetActive(true);
        //Debug.Log(building!=null);
        /*if (building == null)
        {
            building = Instantiate(Resources.Load("Prefabs/Archer Tower") as GameObject, parentTransform.transform);
            //Debug.Log("Added Tower");
        }*/
        //Debug.Log("I am over here: " + parentTransform.position.x /10 + " " + parentTransform.position.z / 10);
    }

  
}
