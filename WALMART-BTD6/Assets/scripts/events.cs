using UnityEngine;
using UnityEngine.Events;
public static class events {
    public static UnityEvent<int> LoseLives = new UnityEvent<int>();
    public static UnityEvent<int> GainCash = new UnityEvent<int>();
    public static UnityEvent<GameObject> towerSelected = new UnityEvent<GameObject>();

    public static UnityEvent<GameObject> startAttacking = new UnityEvent<GameObject>();




}
