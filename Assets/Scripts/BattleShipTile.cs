using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipTile : MonoBehaviour {

    //Mesh renderer that controls the color of the cube
    public MeshRenderer meshRenderer;

    private CubeState currentState;

    // Use this for initialization
    void Start () {

	}

    private void Awake()
    {
        currentState = new NeutralState(this);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetStateIncoming() {
        currentState = new IncomingState(this);
    }

    class NeutralState : CubeState {
       
        public NeutralState(BattleShipTile tile) : base(tile) {
            tile.meshRenderer.material.color = Color.gray;

        }
    }

    class IncomingState : CubeState
    {
        public IncomingState(BattleShipTile tile) : base(tile)
        {
            tile.meshRenderer.material.color = Color.red;

        }
    }

    class SuccessState : CubeState
    {

        public SuccessState(BattleShipTile tile) : base(tile)
        {
            tile.meshRenderer.material.color = Color.green;

        }
    }
}
