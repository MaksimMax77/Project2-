using FSM;
using UnityEngine;

public class SphereStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;

    void Awake()
    {
        var moveState = new MoveState(transform);
        var rotateState = new RotateState(transform);

        moveState.Add(
        new Transition(
            rotateState, 
            () => Input.GetKeyDown(KeyCode.Space))
        );

        rotateState.Add(
            new Transition(
                moveState,
                () => Input.GetKeyDown(KeyCode.LeftControl)
            )
        );

        _stateMachine = new StateMachine(rotateState);
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.OnUpdate();
    }
}

class MoveState : State
{
    const float maxspeed = 1.0F;
    private float speed;
    private Transform transform;

    public MoveState(Transform transform)
    {
        this.transform = transform;
    }

    public override void OnEnter()
    {
        speed = 0.0F;
    }

    public override void OnUpdate()
    {
        if (speed < maxspeed) speed += 0.01F;
        else speed = maxspeed;

        transform.position += (Vector3) (Vector2.right * speed);
    }

    public override void OnExit()
    {
        speed = 0.0F;
    }
}

class RotateState : State
{
    private Transform transform;

    public RotateState(Transform transform)
    {
        this.transform = transform;
    }

    public override void OnEnter() { }
    public override void OnExit() { }

    public override void OnUpdate()
    {
        var prevRotation = transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(prevRotation.x, prevRotation.y, prevRotation.z + 5);
    }

}
