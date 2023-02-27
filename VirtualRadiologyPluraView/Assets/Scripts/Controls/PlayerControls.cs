//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Controls/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""28faa14e-671b-4fe0-9fef-d34de5a70323"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9a364fa7-43e5-470d-bf22-f21b3c94f881"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""c6de422a-95e6-4a4a-baf5-3daeb8164f6c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""a5be2513-7866-4da8-ba8c-dcccc81482fc"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector3(x=0.2,y=0.2,z=0.2)"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7b39cd94-af16-463c-9c4e-cbee549e1205"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1b01297a-69b7-46f2-a682-2167e114aa65"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ceb57f83-6da2-4d13-9a68-6f8ed788e699"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""18e486e2-a7c1-44de-900d-d7c0201ac906"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""21ed9e0a-368b-4a18-a326-62541564abcf"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""13de7757-e707-4613-be24-5787c66a61b1"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""98010a62-8cbf-4abc-a37f-1aa5efb20fad"",
                    ""path"": ""<SpaceNavigatorHID>/translation"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0)"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""4a489d25-c027-4b8d-9227-8dea6f7ce401"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8b3b99f6-85a2-47cf-b35d-038ea5d61595"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fdb43595-822b-440c-9a21-aaa5bede76bb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e336d7da-b8e7-4693-acee-200fa9203357"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f662f432-d867-4cea-964a-7aa4bf651764"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""75fce324-2888-4284-bd9f-ba4ef9dfcc43"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""9f1ffe55-037e-4f83-bab7-25f7f41d09d8"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7ba5ccfa-3cb3-4fc2-8c5d-98abc10788d9"",
                    ""path"": ""<SpaceNavigatorHID>/rotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ApplicationControls"",
            ""id"": ""8e7ded8a-c78d-4654-b625-c855d3e168d6"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""f8eb0629-2805-48dc-a877-54913c53bac8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ResetObject"",
                    ""type"": ""Button"",
                    ""id"": ""cf01cc06-8337-431d-b2de-66972bd45392"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NewPlane"",
                    ""type"": ""Button"",
                    ""id"": ""22c88bdf-9635-4100-b51c-03a2c956d0a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DeletePlane"",
                    ""type"": ""Button"",
                    ""id"": ""898c2a94-ee7d-4674-98cc-4944df88fe30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectObject"",
                    ""type"": ""Button"",
                    ""id"": ""54187347-c5e4-4d20-b98c-b856b04b56a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextObject"",
                    ""type"": ""Button"",
                    ""id"": ""fb3bae2b-843b-49b5-9c0b-95e93d82ce72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PreviousObject"",
                    ""type"": ""Button"",
                    ""id"": ""bf42364e-9ba8-4690-9857-68b39650bda8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1335afe9-3e0b-44c2-a3b3-69fd82f214ab"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2ae5c93-2e75-49cf-a0bc-22c3f53c6d8b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf86cf0f-7165-46b5-91d6-b5b4ad14651a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed8feb05-4a44-4746-b3af-78a60784c67c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffbac5d7-9600-4cd8-8f24-475fdf3fbdd7"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NewPlane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a472fabd-8866-4aaf-87ab-2947b5d75020"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NewPlane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""173d5c6a-7826-4d46-bc83-b20f20831fef"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NewPlane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a52785f-d444-49e3-a88c-d295ed81c16a"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeletePlane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""320a1f06-6fdf-4f45-960b-b57df90d4fdb"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeletePlane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8540e2b2-e722-45f6-9e95-450e81c8ebd1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeletePlane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c89739b5-5d7d-4a5d-9925-fd88e2e93513"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0399831-f2a4-4e8b-b29d-172616f4f810"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c45cf1d7-9309-47c7-b67b-97a0a3cd5f03"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3724a766-2bbc-4218-b5b2-3de7a39543bd"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be470346-b362-497a-a8b0-decf327d6f13"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e630a84-9f98-4268-93c5-8615ecf155ed"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed0ae82d-bd70-4db2-844c-df43ceb177e1"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d37140cd-a745-4a51-8abc-9f0eb2422624"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4feabce3-79f2-46eb-82e7-4bb4344f68a4"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3d5cb74-0f37-4580-be6b-b8d2f474f5dc"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1036b47f-4123-474f-bd33-aff165d26ac8"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=5)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e51e50bd-8d24-4466-979d-8e59fad80b08"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=5)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3dbc16f-9892-415c-b10a-ecba25f9468a"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=6)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4db66e56-60c4-453e-9983-800a75c0ed05"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=6)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b648300-65a0-427e-b906-fc6da1d1f80c"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=7)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0b5fd94-36c6-4119-9477-3e7c4f243c31"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=7)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f595425-89d5-4be4-8e59-370d93310099"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=8)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08b724d5-7395-40ec-b1f3-39d9447cb978"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=8)"",
                    ""groups"": """",
                    ""action"": ""SelectObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""512af3cd-3d6f-4c9c-ade9-b04a3899b07f"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5e4a1fd-b969-477e-910c-a4af1ffe2b08"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37bfaf3e-49cf-44f4-ac42-1121e2ce33a4"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddef7bb1-d96d-4684-9ebf-23619aceedc0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Rotation = m_PlayerMovement.FindAction("Rotation", throwIfNotFound: true);
        // ApplicationControls
        m_ApplicationControls = asset.FindActionMap("ApplicationControls", throwIfNotFound: true);
        m_ApplicationControls_Quit = m_ApplicationControls.FindAction("Quit", throwIfNotFound: true);
        m_ApplicationControls_ResetObject = m_ApplicationControls.FindAction("ResetObject", throwIfNotFound: true);
        m_ApplicationControls_NewPlane = m_ApplicationControls.FindAction("NewPlane", throwIfNotFound: true);
        m_ApplicationControls_DeletePlane = m_ApplicationControls.FindAction("DeletePlane", throwIfNotFound: true);
        m_ApplicationControls_SelectObject = m_ApplicationControls.FindAction("SelectObject", throwIfNotFound: true);
        m_ApplicationControls_NextObject = m_ApplicationControls.FindAction("NextObject", throwIfNotFound: true);
        m_ApplicationControls_PreviousObject = m_ApplicationControls.FindAction("PreviousObject", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Rotation;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Rotation => m_Wrapper.m_PlayerMovement_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Rotation.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // ApplicationControls
    private readonly InputActionMap m_ApplicationControls;
    private IApplicationControlsActions m_ApplicationControlsActionsCallbackInterface;
    private readonly InputAction m_ApplicationControls_Quit;
    private readonly InputAction m_ApplicationControls_ResetObject;
    private readonly InputAction m_ApplicationControls_NewPlane;
    private readonly InputAction m_ApplicationControls_DeletePlane;
    private readonly InputAction m_ApplicationControls_SelectObject;
    private readonly InputAction m_ApplicationControls_NextObject;
    private readonly InputAction m_ApplicationControls_PreviousObject;
    public struct ApplicationControlsActions
    {
        private @PlayerControls m_Wrapper;
        public ApplicationControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_ApplicationControls_Quit;
        public InputAction @ResetObject => m_Wrapper.m_ApplicationControls_ResetObject;
        public InputAction @NewPlane => m_Wrapper.m_ApplicationControls_NewPlane;
        public InputAction @DeletePlane => m_Wrapper.m_ApplicationControls_DeletePlane;
        public InputAction @SelectObject => m_Wrapper.m_ApplicationControls_SelectObject;
        public InputAction @NextObject => m_Wrapper.m_ApplicationControls_NextObject;
        public InputAction @PreviousObject => m_Wrapper.m_ApplicationControls_PreviousObject;
        public InputActionMap Get() { return m_Wrapper.m_ApplicationControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ApplicationControlsActions set) { return set.Get(); }
        public void SetCallbacks(IApplicationControlsActions instance)
        {
            if (m_Wrapper.m_ApplicationControlsActionsCallbackInterface != null)
            {
                @Quit.started -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnQuit;
                @ResetObject.started -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnResetObject;
                @ResetObject.performed -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnResetObject;
                @ResetObject.canceled -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnResetObject;
                @NewPlane.started -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnNewPlane;
                @NewPlane.performed -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnNewPlane;
                @NewPlane.canceled -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnNewPlane;
                @DeletePlane.started -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnDeletePlane;
                @DeletePlane.performed -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnDeletePlane;
                @DeletePlane.canceled -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnDeletePlane;
                @SelectObject.started -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnSelectObject;
                @SelectObject.performed -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnSelectObject;
                @SelectObject.canceled -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnSelectObject;
                @NextObject.started -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnNextObject;
                @NextObject.performed -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnNextObject;
                @NextObject.canceled -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnNextObject;
                @PreviousObject.started -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnPreviousObject;
                @PreviousObject.performed -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnPreviousObject;
                @PreviousObject.canceled -= m_Wrapper.m_ApplicationControlsActionsCallbackInterface.OnPreviousObject;
            }
            m_Wrapper.m_ApplicationControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @ResetObject.started += instance.OnResetObject;
                @ResetObject.performed += instance.OnResetObject;
                @ResetObject.canceled += instance.OnResetObject;
                @NewPlane.started += instance.OnNewPlane;
                @NewPlane.performed += instance.OnNewPlane;
                @NewPlane.canceled += instance.OnNewPlane;
                @DeletePlane.started += instance.OnDeletePlane;
                @DeletePlane.performed += instance.OnDeletePlane;
                @DeletePlane.canceled += instance.OnDeletePlane;
                @SelectObject.started += instance.OnSelectObject;
                @SelectObject.performed += instance.OnSelectObject;
                @SelectObject.canceled += instance.OnSelectObject;
                @NextObject.started += instance.OnNextObject;
                @NextObject.performed += instance.OnNextObject;
                @NextObject.canceled += instance.OnNextObject;
                @PreviousObject.started += instance.OnPreviousObject;
                @PreviousObject.performed += instance.OnPreviousObject;
                @PreviousObject.canceled += instance.OnPreviousObject;
            }
        }
    }
    public ApplicationControlsActions @ApplicationControls => new ApplicationControlsActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
    public interface IApplicationControlsActions
    {
        void OnQuit(InputAction.CallbackContext context);
        void OnResetObject(InputAction.CallbackContext context);
        void OnNewPlane(InputAction.CallbackContext context);
        void OnDeletePlane(InputAction.CallbackContext context);
        void OnSelectObject(InputAction.CallbackContext context);
        void OnNextObject(InputAction.CallbackContext context);
        void OnPreviousObject(InputAction.CallbackContext context);
    }
}
