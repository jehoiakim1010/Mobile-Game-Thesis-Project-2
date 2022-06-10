using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class enemyScript : MonoBehaviour
{
    EnemyMove enemymove;
    AnimancerComponent _Animancer;

    CharacterController characterController;

    [SerializeField] AnimationClip Idle, Walk, Attack;
    public float moveSpeed;
    public float rotateSpeed;

    GameObject Player;
    bool isPlayerNear;
    LayerMask LayerMaskPlayer;

    [SerializeField] float MaxDistance;

    float CooldownTimer_Sword_Attack;

    bool isAttack;

    [SerializeField] float Cooldown_Sword_Attack;

    bool isAttackDone;

    GameObject attack;

    GameObject Canvas;

    GameObject Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        enemymove = this.gameObject.GetComponent<EnemyMove>();

        _Animancer = this.gameObject.GetComponent<AnimancerComponent>();

        LayerMaskPlayer = LayerMask.GetMask("Player");

        _Animancer.Layers[0].Play(Idle, 0.25f, FadeMode.FixedSpeed);

        attack = this.gameObject.transform.Find("Spawnpoint").gameObject;

        Canvas = this.gameObject.transform.Find("Canvas").gameObject;

        Healthbar = this.gameObject.transform.Find("Canvas").transform.Find("health").gameObject;

        characterController = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        if (Player != null)
        {
            Canvas.transform.LookAt(Player.transform.position);
        }
    }

    void Update()
    {

        if (Player != null)
        {
            if (enemymove.PlayerisNear == true)
            {
                isPlayerNear = Physics.CheckSphere(this.transform.position, MaxDistance, LayerMaskPlayer);

                //Attack Cooldown
                if (CooldownTimer_Sword_Attack <= 0.0f && isAttack == false)
                {
                    CooldownTimer_Sword_Attack = Cooldown_Sword_Attack;
                    isAttack = true;

                }
                else
                {
                    if (isAttack == false)
                    {
                        CooldownTimer_Sword_Attack -= 1 * Time.deltaTime;
                        isAttackDone = false;
                    }

                }
                if (isAttack && isPlayerNear)
                {
                    this.transform.LookAt(Player.transform.position);

                    if (isAttackDone == false)
                    {

                        var state = _Animancer.Layers[0].Play(Attack, 0.25f, FadeMode.FixedSpeed);

                        state.Speed = 1.0f;

                        state.Events.OnEnd = () =>
                        {
                            GameObject EnemyAttack = BlackSpiritPool.Pooling_Instance.GamePooled();
                            EnemyAttack.SetActive(true);
                            EnemyAttack.transform.position = attack.transform.position;

                            isAttackDone = true;
                            isAttack = false;
                        };
                    }

                    else
                    {
                        Vector3 GetPatrol = Player.transform.position - this.transform.position;

                        Quaternion RotateTo = Quaternion.LookRotation(GetPatrol);

                        Quaternion LookAt = Quaternion.RotateTowards(this.transform.rotation, RotateTo, 200 * Time.deltaTime);

                        this.transform.rotation = LookAt;

                        this.transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, moveSpeed * Time.deltaTime);

                        var state = _Animancer.Layers[0].Play(Walk, 0.25f, FadeMode.FixedSpeed);
                        state.Speed = 2.0f;
                    }
                }
                else
                {
                    if (isPlayerNear == false)
                    {
                        Vector3 GetPatrol = Player.transform.position - this.transform.position;

                        Quaternion RotateTo = Quaternion.LookRotation(GetPatrol);

                        Quaternion LookAt = Quaternion.RotateTowards(this.transform.rotation, RotateTo, 200 * Time.deltaTime);

                        this.transform.rotation = LookAt;

                        characterController.Move(transform.TransformDirection(Vector3.forward) * moveSpeed * Time.deltaTime);

                        var state = _Animancer.Layers[0].Play(Walk, 0.25f, FadeMode.FixedSpeed);
                        state.Speed = 2.0f;
                    }
                    else
                    {
                        var state = _Animancer.Layers[0].Play(Idle, 0.25f, FadeMode.FixedSpeed);
                        state.Speed = 2.0f;
                    }
                }

            }
        }

        else
        {
            Player = GameObject.FindWithTag("Player");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(this.transform.position, MaxDistance);
    }
}
