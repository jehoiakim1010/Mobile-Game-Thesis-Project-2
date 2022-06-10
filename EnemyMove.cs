using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;
public class EnemyMove : MonoBehaviour
{
    CharacterController characterController;
    AnimancerComponent _Animancer;

    [SerializeField] AnimationClip Idle, Walk;
    bool isPlayerNear;

    [HideInInspector] public bool PlayerisNear;
    [SerializeField] float MaxDistance;

    LayerMask layerMask;
    LayerMask playerLayer;

    Vector3 velocity;
    Vector3 gravVelocity;
    float gravity = -20;
    bool isGround;
    CharacterController enemyControl;

    float WaitTime;
    [SerializeField] float MaxWaitTime;

    [SerializeField] GameObject[] Spot;
    int RandomSpot;
    [SerializeField] float rotation;

    [SerializeField] float speed;

    [SerializeField] float MinDistance;

    [SerializeField] float Rad;
    bool isStopMovement;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
        playerLayer = LayerMask.GetMask("Player");

        _Animancer = this.gameObject.GetComponent<AnimancerComponent>();

        characterController = this.gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        isGround = Physics.CheckSphere(this.transform.position, Rad, layerMask);

        if (isGround)
        {
            velocity.y = -10f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;

            enemyControl.Move(velocity * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        isPlayerNear = Physics.CheckSphere(this.transform.position, MaxDistance, playerLayer);

        if (isPlayerNear)
        {
            PlayerisNear = true;
        }
        else
        {
            PlayerisNear = false;


            Vector3 GetPatrol = Spot[RandomSpot].transform.position - this.transform.position;

            Quaternion RotateTo = Quaternion.LookRotation(GetPatrol);

            Quaternion LookAt = Quaternion.RotateTowards(this.transform.rotation, RotateTo, rotation * Time.deltaTime);

            this.transform.rotation = LookAt;

            if (isStopMovement == false)
            {
                if (Vector3.Distance(this.transform.position, Spot[RandomSpot].transform.position) < MinDistance)
                {
                    var state = _Animancer.Layers[0].Play(Idle, 0.25f, FadeMode.FixedSpeed);
                    state.Speed = 1.0f;
                }
                else
                {
                    var state = _Animancer.Layers[0].Play(Walk, 0.25f, FadeMode.FixedSpeed);
                    state.Speed = 1.0f;
                }

                this.characterController.Move(transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime);
            }
            else
            {
                var state = _Animancer.Layers[0].Play(Idle, 0.25f, FadeMode.FixedSpeed);
                state.Speed = 1.0f;
            }

            if (Vector3.Distance(this.transform.position, Spot[RandomSpot].transform.position) < MinDistance)
            {
                if (WaitTime <= 0.0f)
                {
                    RandomSpot = Random.Range(0, Spot.Length);

                    WaitTime = MaxWaitTime;

                    isStopMovement = false;
                }
                else
                {
                    WaitTime -= 2 * Time.deltaTime;

                    isStopMovement = true;
                }
            }
            else
            {
                isStopMovement = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, MaxDistance);
        Gizmos.DrawWireSphere(this.transform.position, MinDistance);
        Gizmos.DrawWireSphere(this.transform.position, Rad);
    }

}
