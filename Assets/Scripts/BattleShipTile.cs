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

    public void ChangeState() {
        if (currentState is NeutralState) {
            ((NeutralState)currentState).ChangeStates();
        }

        if (currentState is IncomingState) {
            ((IncomingState)currentState).ChangeStates();
        }
    }


    //try and change the state using this
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision entered");
    }
    // ^ fix what's above

    public void SetStateIncoming() {
        currentState = new IncomingState(this);
    }

    public void SetSuccessState()
    {
        currentState = new SuccessState(this);
    }

    public void SetNeutralState()
    {
        currentState = new NeutralState(this);
    }

    class NeutralState : CubeState {
       
        public NeutralState(BattleShipTile tile) : base(tile) {
            tile.meshRenderer.material.color = Color.gray;
        }

        //put change state in the state classes. Instead of using a superclass-wide hashmap.
        public void ChangeStates()
        {
            tile.currentState = new MissState(tile);
        }
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

        public void ChangeStates()
        {
            tile.currentState = new SuccessState(tile);

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
