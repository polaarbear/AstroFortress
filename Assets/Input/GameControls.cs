// GENERATED AUTOMATICALLY FROM 'Assets/Input/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""InGameControls"",
            ""id"": ""55f1a8a7-1b61-4e0d-b886-584de782f0e6"",
            ""actions"": [
                {
                    ""name"": ""ToggleThruster"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4bb5978b-3198-4b0f-8ddf-d0b68787d65b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""RotateShip"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6fdcffd9-9020-4059-a3d7-aabe1d13dcc0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5f5246fa-0197-4277-8fcd-8af33b761502"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleThruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9272c41-61a6-43c0-b201-74d12cee4d89"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleThruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KBM"",
                    ""id"": ""4530f250-6290-4b06-9c56-b157e4a72f8e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShip"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f1f1d634-ecf0-4683-9d63-10f4f47ceb5c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""27604980-f2a5-4c40-beaa-fa55e11f9d24"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""73098df1-e1fa-41b5-8554-ff455d6e832a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShip"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""245882be-8a10-4139-a169-607a6c7dd7b1"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a6ce4fa9-9cd9-48b2-b643-bbc51fb302d4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InGameControls
        m_InGameControls = asset.FindActionMap("InGameControls", throwIfNotFound: true);
        m_InGameControls_ToggleThruster = m_InGameControls.FindAction("ToggleThruster", throwIfNotFound: true);
        m_InGameControls_RotateShip = m_InGameControls.FindAction("RotateShip", throwIfNotFound: true);
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

    // InGameControls
    private readonly InputActionMap m_InGameControls;
    private IInGameControlsActions m_InGameControlsActionsCallbackInterface;
    private readonly InputAction m_InGameControls_ToggleThruster;
    private readonly InputAction m_InGameControls_RotateShip;
    public struct InGameControlsActions
    {
        private @GameControls m_Wrapper;
        public InGameControlsActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleThruster => m_Wrapper.m_InGameControls_ToggleThruster;
        public InputAction @RotateShip => m_Wrapper.m_InGameControls_RotateShip;
        public InputActionMap Get() { return m_Wrapper.m_InGameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IInGameControlsActions instance)
        {
            if (m_Wrapper.m_InGameControlsActionsCallbackInterface != null)
            {
                @ToggleThruster.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnToggleThruster;
                @ToggleThruster.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnToggleThruster;
                @ToggleThruster.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnToggleThruster;
                @RotateShip.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateShip;
                @RotateShip.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateShip;
                @RotateShip.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateShip;
            }
            m_Wrapper.m_InGameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleThruster.started += instance.OnToggleThruster;
                @ToggleThruster.performed += instance.OnToggleThruster;
                @ToggleThruster.canceled += instance.OnToggleThruster;
                @RotateShip.started += instance.OnRotateShip;
                @RotateShip.performed += instance.OnRotateShip;
                @RotateShip.canceled += instance.OnRotateShip;
            }
        }
    }
    public InGameControlsActions @InGameControls => new InGameControlsActions(this);
    public interface IInGameControlsActions
    {
        void OnToggleThruster(InputAction.CallbackContext context);
        void OnRotateShip(InputAction.CallbackContext context);
    }
}
