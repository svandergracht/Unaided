using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipTile : MonoBehaviour {

    //Mesh renderer that controls the color of the cube
    public MeshRenderer meshRenderer;

    private CubeState currentState;
    //holders for the other states
    //NeutralState neutralState;
    //MissState missState;
    //IncomingState incomingState;
    //SuccessState successState;

    //private Dictionary<CubeState, CubeState> statesMapping = new Dictionary<CubeState, CubeState>();
    
    // Use this for initialization
    void Start () {
        //create states instances
        //neutralState = new NeutralState(this);
        //missState = new MissState(this);

        //setup statesMapping
        //statesMapping.Add(neutralState, missState);

        //statesMapping.Add(incomingState, successState);

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

    public void SetSuccessState()
    {
        currentState = new SuccessState(this);
    }

    public void ChangeStates() {
        //currentState = statesMapping[currentState];
        if (currentState is IncomingState) {
            //currentState = successState;
        }

    }

    class NeutralState : CubeState {
       
        public NeutralState(BattleShipTile tile) : base(tile) {
            tile.meshRenderer.material.color = Color.gray;
        }

        //put change state in the state classes. Instead of using a superclass-wide hashmap.
    }

    class MissState : CubeState
    {

        public MissState(BattleShipTile tile) : base(tile)
        {
            tile.meshRenderer.material.color = Color.yellow;
        }
    }

    class IncomingState : CubeState
    {
        public IncomingState(BattleShipTile tile) : base(tile)
        {
            Debug.Log("Incoming state being called");
            //Renderer rend = tile.GetComponent<MeshRenderer>();
            //Debug.Log("Rend = null?? " + rend == null);
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
