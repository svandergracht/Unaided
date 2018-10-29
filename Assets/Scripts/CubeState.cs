using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CubeState {
    // A reference to the containing class.
    protected BattleShipTile tile;

    public CubeState(BattleShipTile tileObj)
    {
        tile = tileObj;
    }

    // Each state may have an update
    public virtual void Update() {

    }

    // States may or may not override this.
    public virtual void OnTriggerEnter(Collider other)
    {
    }
}
