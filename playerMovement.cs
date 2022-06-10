using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Animancer;
public class playerMovement : MonoBehaviour
{
    //CharacterController
    CharacterController controllerPlayer;

    //Character Speed
    public float speed;

    AnimancerComponent _Animancer;

    [SerializeField] AnimationClip Idle, Attack1, Attack2, Attack3, Walk, Crafting;

    Vector3 con;
    Vector3 Velocity;
    float PlayerVelocity;
    float gravity = -100;
    bool isGround;

    //Crafting
    [HideInInspector] public bool isCrafting;

    GameObject Canvas;
    GameObject Chairs;
    GameObject Hammer;
    LayerMask Ground;

    [SerializeField]
    float PlayerRotation;

    //Character Rotation
    public float rotateSpeed;


    GameObject Spawnpoint;

    float LastAttack;

    [SerializeField] float LightAttackDelay;

    [SerializeField] float LightAttackANimationSpeed;

    bool isSkillMode;
    bool isAttackMode;

    //public static playerMovement Instance;

    Scene Scenename;

    public int NumberAttack;

    bool CraftingRunOnce;

    public GameObject Sword, Axe, DoubleAxe;

    string Weapon;

    GameObject VideoPlayer;

    Scene scene;

    public void StopVideo()
    {
        VideoPlayer.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (scene.name == "Stage1" || scene.name == "Stage2" || scene.name == "Stage3" || scene.name == "Stage4" || scene.name == "Stage5")
        {
            VideoPlayer = GameObject.Find("/CanvasAttack/Story").gameObject;
            Time.timeScale = 0.0f;
        }

        _Animancer = this.gameObject.GetComponent<AnimancerComponent>();

        controllerPlayer = this.gameObject.GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();

        Ground = LayerMask.GetMask("Ground");

        Spawnpoint = this.gameObject.transform.Find("Spawnpoint").gameObject;

        Canvas = this.gameObject.transform.Find("Canvas").gameObject;

        Chairs = this.gameObject.transform.Find("Chair").gameObject;

        Hammer = this.gameObject.transform.Find("mixamorig:Hips").transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1")
        .transform.Find("mixamorig:Spine2").transform.Find("mixamorig:RightShoulder").transform.Find("mixamorig:RightArm")
        .transform.Find("mixamorig:RightForeArm").transform.Find("mixamorig:RightHand").transform.Find("Hammer").gameObject;

        Canvas.SetActive(false);

        Chairs.SetActive(false);

        Hammer.SetActive(false);

        Sword = this.gameObject.transform.Find("mixamorig:Hips").transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1")
        .transform.Find("mixamorig:Spine2").transform.Find("mixamorig:RightShoulder").transform.Find("mixamorig:RightArm")
        .transform.Find("mixamorig:RightForeArm").transform.Find("mixamorig:RightHand").transform.Find("First Sword").gameObject;

        Axe = this.gameObject.transform.Find("mixamorig:Hips").transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1")
        .transform.Find("mixamorig:Spine2").transform.Find("mixamorig:RightShoulder").transform.Find("mixamorig:RightArm")
        .transform.Find("mixamorig:RightForeArm").transform.Find("mixamorig:RightHand").transform.Find("Axe").gameObject;

        DoubleAxe = this.gameObject.transform.Find("mixamorig:Hips").transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1")
        .transform.Find("mixamorig:Spine2").transform.Find("mixamorig:RightShoulder").transform.Find("mixamorig:RightArm")
        .transform.Find("mixamorig:RightForeArm").transform.Find("mixamorig:RightHand").transform.Find("Double Axe").gameObject;

        Sword.SetActive(false);

        Axe.SetActive(false);

        DoubleAxe.SetActive(false);

        /*if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        GameObject.DontDestroyOnLoad(this.gameObject);*/

        //CharacterSkin = this.gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();

        if (Sword.activeSelf == false && Axe.activeSelf == false && DoubleAxe.activeSelf == false)
        {
            if (ES3.KeyExists("Player Sword"))
            {
                Weapon = ES3.Load<string>("Player Sword");

                if (Weapon == "Sword")
                {
                    Sword.SetActive(true);
                    DoubleAxe.SetActive(false);
                    Axe.SetActive(false);
                }
                else if (Weapon == "Axe")
                {
                    Sword.SetActive(false);
                    DoubleAxe.SetActive(false);
                    Axe.SetActive(true);
                }

                else if (Weapon == "Double Axe")
                {
                    Sword.SetActive(false);
                    DoubleAxe.SetActive(true);
                    Axe.SetActive(false);
                }


            }
            else
            {
                Sword.SetActive(true);
            }
        }

    }
    private void LateUpdate()
    {
        Canvas.transform.LookAt(Camera.main.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCrafting == false)
        {
            float horizontalMove = SimpleInput.GetAxis("Horizontal");
            float verticalMove = SimpleInput.GetAxis("Vertical");

            con = new Vector3(horizontalMove, 0, verticalMove).normalized;
            NumberAttack = Mathf.Clamp(NumberAttack, 0, 3);


            if (isAttackMode == false)
            {
                if (con.magnitude >= 0.001f)
                {
                    float CameraAngle = Mathf.Atan2(con.x, con.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, CameraAngle, ref PlayerVelocity, PlayerRotation * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

                    controllerPlayer.Move(transform.forward * speed * Time.deltaTime);

                    _Animancer.Layers[0].Play(Walk, 0.25f, FadeMode.FixedSpeed);
                }
                else
                {
                    _Animancer.Layers[0].Play(Idle, 0.25f, FadeMode.FixedSpeed);

                }
            }
            else
            {
                if (Time.time - LastAttack > LightAttackDelay)
                {
                    NumberAttack = 0;
                    isAttackMode = false;
                }

                if (isAttackMode == false)
                {
                    _Animancer.Layers[0].Play(Idle, 0.25f, FadeMode.FixedSpeed);
                }
            }
        }
        else
        {
            if (CraftingRunOnce == false)
            {
                StartCoroutine(PlayerisCrafting());

                CraftingRunOnce = true;
            }
        }

        Gravity();

    }


    IEnumerator PlayerisCrafting()
    {
        _Animancer.Layers[0].Play(Crafting, 0.25f, FadeMode.FixedSpeed);

        Canvas.SetActive(true);

        Chairs.SetActive(true);

        Hammer.SetActive(true);

        Sword.SetActive(false);
        DoubleAxe.SetActive(false);
        Axe.SetActive(false);

        yield return new WaitForSeconds(5.0f);

        if (ES3.KeyExists("Player Sword"))
        {
            Weapon = ES3.Load<string>("Player Sword");

            if (Weapon == "Sword")
            {
                Sword.SetActive(true);
                DoubleAxe.SetActive(false);
                Axe.SetActive(false);
            }
            else if (Weapon == "Axe")
            {
                Sword.SetActive(false);
                DoubleAxe.SetActive(false);
                Axe.SetActive(true);
            }

            else if (Weapon == "Double Axe")
            {
                Sword.SetActive(false);
                DoubleAxe.SetActive(true);
                Axe.SetActive(false);
            }
        }

        Canvas.SetActive(false);

        Chairs.SetActive(false);

        Hammer.SetActive(false);

        isCrafting = false;
        CraftingRunOnce = false;
    }
    public void PlayerAttack()
    {

        LastAttack = Time.time;
        NumberAttack++;
        isAttackMode = true;

        if (NumberAttack == 1)
        {
            //soundmanager.PlaySound("PlayerHit");

            var state = _Animancer.Layers[0].Play(Attack1, 0.25f, FadeMode.FixedSpeed);
            state.Speed = LightAttackANimationSpeed;
        }

    }

    public void PlayerAddDamage()
    {
        GameObject PlayerAttack = PlayerDamagePool.Pooling_Instance.GamePooled();
        PlayerAttack.SetActive(true);
        PlayerAttack.transform.position = this.Spawnpoint.transform.position;
    }
    public void PlayerAttack2()
    {

        if (NumberAttack >= 2)
        {
            //soundmanager.PlaySound("PlayerHit");
            var state = _Animancer.Layers[0].Play(Attack2, 0.25f, FadeMode.FixedSpeed);
            state.Speed = LightAttackANimationSpeed;
        }
        else
        {
            _Animancer.Stop(Attack1);
            NumberAttack = 0;
        }
    }

    public void PlayerAttack3()
    {

        if (NumberAttack >= 2)
        {
            //soundmanager.PlaySound("PlayerHit");
            var state = _Animancer.Layers[0].Play(Attack3, 0.25f, FadeMode.FixedSpeed);
            state.Speed = LightAttackANimationSpeed;
        }
        else
        {
            _Animancer.Stop(Attack1);
            NumberAttack = 0;
        }
    }

    public void Reset()
    {
        _Animancer.Stop(Attack3);

        if (NumberAttack == 1)
        {
            //soundmanager.PlaySound("PlayerHit");
            var state = _Animancer.Layers[0].Play(Attack1, 0.25f, FadeMode.FixedSpeed);
            state.Speed = LightAttackANimationSpeed;
            NumberAttack = 1;
        }
        else
        {
            _Animancer.Stop(Attack1);
        }

        NumberAttack = 0;
    }



    public void Gravity()
    {
        isGround = Physics.CheckSphere(this.transform.position, 0.8f, Ground);

        Velocity.y += gravity * Time.deltaTime;

        controllerPlayer.Move(Velocity * Time.deltaTime);

        if (isGround && Velocity.y < 0)
        {
            Velocity.y = -10f;
        }
    }
}
