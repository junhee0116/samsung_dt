using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool isGameEnd = false;

    public void EndGame() {
        if(!isGameEnd) {
            isGameEnd = true;
        }
    }
}