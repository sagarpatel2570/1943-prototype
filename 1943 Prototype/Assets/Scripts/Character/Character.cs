using UnityEngine;
using System.Collections;
using System;

// character consisit the list of all the abilities and update s them every update
[SelectionBase]
public class Character : MonoBehaviour,IDeath
{
    public event Action OnDeath;
    public bool isPlayer;
    public CharacterStates state;

    public Animator Animator { get; protected set; }
    public Controller2D Controller { get; protected set; }
    public CharacterMovement CharacterMovement { get; protected set; }
    public Transform model;

    CharacterAbility[] characterAbilities;

    void Awake()
    {
        Controller = GetComponent<Controller2D>();
    }

    void OnEnable()
    {
        Initialization();
    }

    void OnDisable()
    {
        // basically is is the ondisable for all abilities 
        foreach (CharacterAbility ability in characterAbilities)
        {
            ability.DeInit();
        }
    }

    void Initialization()
    {
        characterAbilities = GetComponents<CharacterAbility>();
        CharacterMovement = GetComponent<CharacterMovement>();
        Animator = GetComponentInChildren<Animator>();

        // basically is is the onenable for all abilities 
        foreach (CharacterAbility ability in characterAbilities)
        {
            ability.Init();
        }
    }

    /// <summary>
    /// Every update we update the abilities in three parts
    /// "EarlyProcessAbilities" were we handle the input
    /// "ProcessAbilities" were we do the actions
    /// "LateProcessAbilities" thind we need to do after all the abilites of action is been done
    /// </summary>
    void Update()
    {
        EarlyProcessAbilities();
        ProcessAbilities();
        LateProcessAbilities();
    }

    void EarlyProcessAbilities()
    {
        foreach (CharacterAbility ability in characterAbilities)
        {
            ability.EarlyProcessAbility();
        }
    }

    void ProcessAbilities()
    {
        foreach (CharacterAbility ability in characterAbilities)
        {
            ability.ProcessAbility();
        }
    }

    void LateProcessAbilities()
    {
        foreach (CharacterAbility ability in characterAbilities)
        {
            ability.LateProcessAbility();
        }
    }

    public void Reset()
    {
        if (characterAbilities == null)
        {
            return;
        }
        
        foreach (CharacterAbility ability in characterAbilities)
        {
            if (ability.enabled)
            {
                ability.Reset();
            }
        }
    }

    /// <summary>
    /// when the state is changed we update the animation
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState (CharacterStates state)
    {
        if(this.state == state)
        {
            return;
        }
        
        CharacterStates previousState = this.state;
        this.state = state;
    }


    public void Destroy()
    {
        OnDeath?.Invoke();
    }
}

public enum CharacterStates
{
    IDLE = 0,
    MOVE = 1,
    ATTACK = 2,
    DEATH = 3
}