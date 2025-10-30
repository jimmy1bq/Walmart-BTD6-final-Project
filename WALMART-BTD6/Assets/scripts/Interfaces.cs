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


