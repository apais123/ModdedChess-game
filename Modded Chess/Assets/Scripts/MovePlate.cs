﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour {

    public GameObject controller;

    GameObject reference = null;

    //Board positions
    int matrixX;
    int matrixY;

    //false is movement, true is attacking
    public bool attack = false;

    public void Start() {
        if (attack) {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp() {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack) {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            if (cp.name == "white_king") controller.GetComponent<Game>().Winner("black");
            if (cp.name == "black_king") controller.GetComponent<Game>().Winner("white");


            Destroy(cp);
        }

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Chessman>().GetXBoard(), 
            reference.GetComponent<Chessman>().GetYBoard());

        reference.GetComponent<Chessman>().SetXBoard(matrixX);
        reference.GetComponent<Chessman>().SetYBoard(matrixY);
        reference.GetComponent<Chessman>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);

        reference.GetComponent<Chessman>().DestroyMovePlates();

        if (reference.GetComponent<Chessman>().GetPromote())
        {
            if (controller.GetComponent<Game>().GetCurrentPlayer() == "white")
            {
                controller.GetComponent<Game>().Promote();
            }
        }

        controller.GetComponent<Game>().NextTurn();
    }

    public void SetCoords(int x, int y) {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj) {
        reference = obj;
    }

    public GameObject GetReference() {
        return reference;
    }
}