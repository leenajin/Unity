using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //사용자의 인풋을 시스템에 적용하는 부분

    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChanged;

    #region Singleton
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Camera cam;
    Animator animator;

    PlayerMotor motor;
    CharacterCombat combat;

    public LayerMask movementMask;
    public LayerMask interactionMask;

    public Interactable focus;

    CharacterStat stat;
    

    private void Start()
    {
        cam = Camera.main;
        animator = GetComponentInChildren<Animator>();

        motor = GetComponent<PlayerMotor>();
        combat = GetComponent<CharacterCombat>();
    }

    private void Update()
    {
        //ui위에 클릭은 받아오지 않도록
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //float agentVelocity = agent.velocity.sqrMagnitude;
        if (Player.instance.stat.currentHP > 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit, movementMask))
                {
                    motor.MoveToTarget(hit.point);
                    SetFocus(null); // 포커스가 사라지는부분
                }
            }
        
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, interactionMask))
                {
                    SetFocus(hit.collider.GetComponent<Interactable>());

                    //combat.Attack();
                }

            }
        }
    }

    public void SetFocus(Interactable newFocus)
    {
        onFocusChanged?.Invoke(newFocus);
        
        if (focus != newFocus && focus != null)
        {
            //기존 선택되었던 인터랙터블 객체에도 해제됨을 알려주어야한다.
            focus.OnDefocused();
        }

        focus = newFocus;

        if(focus != null)
        {
            //새로 선택된 인터랙터블 객체에 알려주기
            focus.OnFocused();
        }    
    }

}
