using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class events {
    public static UnityEvent<int> LoseLives = new UnityEvent<int>();
    public static UnityEvent<int> GainCash = new UnityEvent<int>();
    public static UnityEvent<int> LoseLivesUI = new UnityEvent<int>();
    public static UnityEvent<int> GainCashUI = new UnityEvent<int>();
    public static UnityEvent<GameObject> towerSelected = new UnityEvent<GameObject>();  
    public static TowerUpgradeEvent towerUpgrade = new TowerUpgradeEvent();
    public static UnityEvent<int> changeTarget = new UnityEvent<int>();
    public static UnityEvent<string> destroyTower = new UnityEvent<string>();
    public static UnityEvent<int> onLoad = new UnityEvent<int>();
    public static UnityEvent<int> addMM = new UnityEvent<int>();
    public static UnityEvent<int> gainExp = new UnityEvent<int>();
    public static UnityEvent<int> levelUp = new UnityEvent<int>();
    public static UnityEvent<int> gameOver = new UnityEvent<int>();
    public static gameOver gameOverEvent = new gameOver();

}
//milestone 7
public class TowerUpgradeEvent : UnityEvent<string, string, Dictionary<string,float>,bool >{ }
public class gameOver : UnityEvent<int,bool> { }

public delegate bool waveStart();


