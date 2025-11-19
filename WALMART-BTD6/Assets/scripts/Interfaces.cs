using UnityEngine;

public interface IDamageTaken { 
    void damageTaken(int damageAmount);
}

public interface IIndex {
    public void wayPointReciever(int index);
   }
public interface IHovering { 
    public void hoveringState(bool hovering);
}

public interface IUNORSelected
{
    public void towerSelected();
    public void towerUnSelected();
}
public interface IPopToPopCount 
{
    public void damageDealt(int popCount);

}
public interface IProjctileOwner
{
   public void setProjectileOwner(GameObject owner);
}

public interface IGiveEnemy {

    public void setEnemy(GameObject enemy) 
    { }

}

public interface IStatChange { 

    public void statChangePierce(float pierce);
    public void statChangeProjSpeed(float speed);

}
public interface ICollidingWithTowers {
    public bool collidingwithOtherObject();

}
public interface IGetSetID
{
    public void setID(int ID);
    public int GetID();

}


