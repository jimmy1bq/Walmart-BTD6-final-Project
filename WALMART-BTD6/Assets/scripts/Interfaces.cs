using UnityEngine;

public interface IDamageTaken { 
    void damageTaken(int damageAmount, GameObject projectileThatDamageIt);
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
    public int parentGetID();
    public int personalGetID();
    //milestrone 7: pure ID doesn't work  because if 2 gameobjects have the same id on the map the projectile will hit one and ignore the other one

   
}
public interface IGiveProptieres 
{
    public bool returnCanHitLead();
    public bool returnCanHitBlack();
    public void getParentLayerMask(LayerMask layerToHit);

}
public interface IreturnIndexNum
{
    public int wayPointIndex();
    public float returnDistanceFromWayPoint();

    public int returnBoxLayer();
    public int returnOuterProtLayer();

    public bool returnIfTank();
}
public interface IaddDamage
{ 
    public void addDamage(float damageToAdd);
    public void addRadius(float rad);
}
public interface IStun { 

    public void stunEnemy(float stunDuration);
    public void stunChildEnemy(float stunDuration);

}

public interface Iexplodeable
{
    public void selfDet();
    public void recursion(int recurseAmount);
}




