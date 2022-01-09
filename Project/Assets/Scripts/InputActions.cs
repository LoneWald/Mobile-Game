//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""8514fe8f-7ff6-4348-a61d-e73c543986df"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""99c5477f-0498-48c6-8894-31fd3861e8fe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""37b7e415-66a6-48f8-a3c4-551fcbe3636b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JumpForward"",
                    ""type"": ""Button"",
                    ""id"": ""c5c218ba-c2d5-4def-8952-bf440149159c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FrontBlock"",
                    ""type"": ""Button"",
                    ""id"": ""f58eb129-05dc-4510-8b8e-c36854b351e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Take Item"",
                    ""type"": ""Button"",
                    ""id"": ""b9168886-e56f-4722-a182-df643753e9a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TalkNPC"",
                    ""type"": ""Button"",
                    ""id"": ""a7e17ac1-8628-47f9-8770-c38095570b02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ad83a1c-1681-49e6-8d24-d92ba512f1b7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""190431bd-96c7-4718-b92a-ab63d6d8519a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9aa99c20-5286-4ea6-b520-852bcd14201a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0372ba80-da49-4980-92d0-0026efbc5769"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b6e75784-95bb-400f-aa24-fa896ade8e15"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2a73c76b-a6f4-425f-b3c7-54c4d5f4c558"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d20ef1f9-7d3b-4b79-8af4-8b6731e1f4de"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""689ad5c7-5b19-4091-8d6d-46fbf97a3088"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ee92ab3-6008-45d4-b7f2-46d03623a549"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0cc36ae-73c9-4743-a433-28b357b0cae9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3515e5f4-86fc-4050-837e-606bf8d792ed"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrontBlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f0f976b-a42d-422c-a634-98fd0d927609"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrontBlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b4167ed-6c97-4493-ad69-e53fc5f3860b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Take Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""120fcf1e-047e-4846-bb76-b5aad23045f0"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TalkNPC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIInput"",
            ""id"": ""cb6c214b-9302-45eb-afbc-728f168b4cb7"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""b8b5bd78-f5a7-4098-add4-1e6434eea321"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropItem"",
                    ""type"": ""Button"",
                    ""id"": ""e8306dfe-1fc5-4b11-94ab-2016e50eda2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectItem"",
                    ""type"": ""Button"",
                    ""id"": ""4322ac3d-cacf-4573-91ac-28c05b68d328"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveItem"",
                    ""type"": ""Button"",
                    ""id"": ""56a4114e-9851-45ae-93a6-75c1d89020fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetItem"",
                    ""type"": ""Button"",
                    ""id"": ""3deee805-3ae0-4b59-b35c-b1735145d9dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShowQuests"",
                    ""type"": ""Button"",
                    ""id"": ""dbb70862-58e4-4e67-88c6-7850f3c7b25a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4bf67225-da0f-41f4-83a2-aa846b425a42"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d49cd5a-85e0-4f97-b13a-9d0d9484322f"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42444502-f10e-4131-b058-e7191b8c704c"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b29d5d0-262f-4f94-a473-e38108d18eb2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b0364e7-4dea-47f3-a44d-d8d3e3a79138"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24a62ca4-b9f0-4d45-ba22-d6bf30474613"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""089f8fc4-bfd9-4ca6-a260-bb1a627a3049"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowQuests"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Move = m_PlayerActions.FindAction("Move", throwIfNotFound: true);
        m_PlayerActions_Attack = m_PlayerActions.FindAction("Attack", throwIfNotFound: true);
        m_PlayerActions_JumpForward = m_PlayerActions.FindAction("JumpForward", throwIfNotFound: true);
        m_PlayerActions_FrontBlock = m_PlayerActions.FindAction("FrontBlock", throwIfNotFound: true);
        m_PlayerActions_TakeItem = m_PlayerActions.FindAction("Take Item", throwIfNotFound: true);
        m_PlayerActions_TalkNPC = m_PlayerActions.FindAction("TalkNPC", throwIfNotFound: true);
        // UIInput
        m_UIInput = asset.FindActionMap("UIInput", throwIfNotFound: true);
        m_UIInput_Inventory = m_UIInput.FindAction("Inventory", throwIfNotFound: true);
        m_UIInput_DropItem = m_UIInput.FindAction("DropItem", throwIfNotFound: true);
        m_UIInput_SelectItem = m_UIInput.FindAction("SelectItem", throwIfNotFound: true);
        m_UIInput_MoveItem = m_UIInput.FindAction("MoveItem", throwIfNotFound: true);
        m_UIInput_SetItem = m_UIInput.FindAction("SetItem", throwIfNotFound: true);
        m_UIInput_ShowQuests = m_UIInput.FindAction("ShowQuests", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Move;
    private readonly InputAction m_PlayerActions_Attack;
    private readonly InputAction m_PlayerActions_JumpForward;
    private readonly InputAction m_PlayerActions_FrontBlock;
    private readonly InputAction m_PlayerActions_TakeItem;
    private readonly InputAction m_PlayerActions_TalkNPC;
    public struct PlayerActionsActions
    {
        private @InputActions m_Wrapper;
        public PlayerActionsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerActions_Move;
        public InputAction @Attack => m_Wrapper.m_PlayerActions_Attack;
        public InputAction @JumpForward => m_Wrapper.m_PlayerActions_JumpForward;
        public InputAction @FrontBlock => m_Wrapper.m_PlayerActions_FrontBlock;
        public InputAction @TakeItem => m_Wrapper.m_PlayerActions_TakeItem;
        public InputAction @TalkNPC => m_Wrapper.m_PlayerActions_TalkNPC;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                @JumpForward.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJumpForward;
                @JumpForward.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJumpForward;
                @JumpForward.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJumpForward;
                @FrontBlock.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnFrontBlock;
                @FrontBlock.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnFrontBlock;
                @FrontBlock.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnFrontBlock;
                @TakeItem.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTakeItem;
                @TakeItem.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTakeItem;
                @TakeItem.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTakeItem;
                @TalkNPC.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTalkNPC;
                @TalkNPC.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTalkNPC;
                @TalkNPC.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTalkNPC;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @JumpForward.started += instance.OnJumpForward;
                @JumpForward.performed += instance.OnJumpForward;
                @JumpForward.canceled += instance.OnJumpForward;
                @FrontBlock.started += instance.OnFrontBlock;
                @FrontBlock.performed += instance.OnFrontBlock;
                @FrontBlock.canceled += instance.OnFrontBlock;
                @TakeItem.started += instance.OnTakeItem;
                @TakeItem.performed += instance.OnTakeItem;
                @TakeItem.canceled += instance.OnTakeItem;
                @TalkNPC.started += instance.OnTalkNPC;
                @TalkNPC.performed += instance.OnTalkNPC;
                @TalkNPC.canceled += instance.OnTalkNPC;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // UIInput
    private readonly InputActionMap m_UIInput;
    private IUIInputActions m_UIInputActionsCallbackInterface;
    private readonly InputAction m_UIInput_Inventory;
    private readonly InputAction m_UIInput_DropItem;
    private readonly InputAction m_UIInput_SelectItem;
    private readonly InputAction m_UIInput_MoveItem;
    private readonly InputAction m_UIInput_SetItem;
    private readonly InputAction m_UIInput_ShowQuests;
    public struct UIInputActions
    {
        private @InputActions m_Wrapper;
        public UIInputActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Inventory => m_Wrapper.m_UIInput_Inventory;
        public InputAction @DropItem => m_Wrapper.m_UIInput_DropItem;
        public InputAction @SelectItem => m_Wrapper.m_UIInput_SelectItem;
        public InputAction @MoveItem => m_Wrapper.m_UIInput_MoveItem;
        public InputAction @SetItem => m_Wrapper.m_UIInput_SetItem;
        public InputAction @ShowQuests => m_Wrapper.m_UIInput_ShowQuests;
        public InputActionMap Get() { return m_Wrapper.m_UIInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIInputActions set) { return set.Get(); }
        public void SetCallbacks(IUIInputActions instance)
        {
            if (m_Wrapper.m_UIInputActionsCallbackInterface != null)
            {
                @Inventory.started -= m_Wrapper.m_UIInputActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_UIInputActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_UIInputActionsCallbackInterface.OnInventory;
                @DropItem.started -= m_Wrapper.m_UIInputActionsCallbackInterface.OnDropItem;
                @DropItem.performed -= m_Wrapper.m_UIInputActionsCallbackInterface.OnDropItem;
                @DropItem.canceled -= m_Wrapper.m_UIInputActionsCallbackInterface.OnDropItem;
                @SelectItem.started -= m_Wrapper.m_UIInputActionsCallbackInterface.OnSelectItem;
                @SelectItem.performed -= m_Wrapper.m_UIInputActionsCallbackInterface.OnSelectItem;
                @SelectItem.canceled -= m_Wrapper.m_UIInputActionsCallbackInterface.OnSelectItem;
                @MoveItem.started -= m_Wrapper.m_UIInputActionsCallbackInterface.OnMoveItem;
                @MoveItem.performed -= m_Wrapper.m_UIInputActionsCallbackInterface.OnMoveItem;
                @MoveItem.canceled -= m_Wrapper.m_UIInputActionsCallbackInterface.OnMoveItem;
                @SetItem.started -= m_Wrapper.m_UIInputActionsCallbackInterface.OnSetItem;
                @SetItem.performed -= m_Wrapper.m_UIInputActionsCallbackInterface.OnSetItem;
                @SetItem.canceled -= m_Wrapper.m_UIInputActionsCallbackInterface.OnSetItem;
                @ShowQuests.started -= m_Wrapper.m_UIInputActionsCallbackInterface.OnShowQuests;
                @ShowQuests.performed -= m_Wrapper.m_UIInputActionsCallbackInterface.OnShowQuests;
                @ShowQuests.canceled -= m_Wrapper.m_UIInputActionsCallbackInterface.OnShowQuests;
            }
            m_Wrapper.m_UIInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @DropItem.started += instance.OnDropItem;
                @DropItem.performed += instance.OnDropItem;
                @DropItem.canceled += instance.OnDropItem;
                @SelectItem.started += instance.OnSelectItem;
                @SelectItem.performed += instance.OnSelectItem;
                @SelectItem.canceled += instance.OnSelectItem;
                @MoveItem.started += instance.OnMoveItem;
                @MoveItem.performed += instance.OnMoveItem;
                @MoveItem.canceled += instance.OnMoveItem;
                @SetItem.started += instance.OnSetItem;
                @SetItem.performed += instance.OnSetItem;
                @SetItem.canceled += instance.OnSetItem;
                @ShowQuests.started += instance.OnShowQuests;
                @ShowQuests.performed += instance.OnShowQuests;
                @ShowQuests.canceled += instance.OnShowQuests;
            }
        }
    }
    public UIInputActions @UIInput => new UIInputActions(this);
    public interface IPlayerActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJumpForward(InputAction.CallbackContext context);
        void OnFrontBlock(InputAction.CallbackContext context);
        void OnTakeItem(InputAction.CallbackContext context);
        void OnTalkNPC(InputAction.CallbackContext context);
    }
    public interface IUIInputActions
    {
        void OnInventory(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
        void OnSelectItem(InputAction.CallbackContext context);
        void OnMoveItem(InputAction.CallbackContext context);
        void OnSetItem(InputAction.CallbackContext context);
        void OnShowQuests(InputAction.CallbackContext context);
    }
}
