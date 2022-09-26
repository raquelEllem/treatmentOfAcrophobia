using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesRift : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // retorna verdadeiro se o botão “A” estiver pressionado no momento.
        OVRInput.Get(OVRInput.Button.One);

        // retorna verdadeiro se o botão “A” foi pressionado neste quadro.
        OVRInput.GetDown(OVRInput.Button.One);

        // retorna true se o botão "X" foi liberado neste frame.
        OVRInput.GetUp(OVRInput.RawButton.X);

        // retorna um Vector2 do estado atual do thumbstick (controle esquerdo). 
        // (intervalo X / Y de -1,0f a 1,0f)
        OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // retorna verdadeiro se o thumbstick do controle esquerdo estiver atualmente pressionado 
        OVRInput.Get(OVRInput.Button.PrimaryThumbstick);

        // retorna true se o thumbstick do controle esquerdo foi movido.  
        // (Acima / Abaixo / Esquerda / Direita - Interprete o thumbstick como um D-pad).
        OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp);
        OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown);
        OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft);
        OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight);

        // retorna um float do estado atual do gatilho (dedo indicador) do controle direito.  
        // (intervalo de 0.0f a 1.0f)
        OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        // retorna true se o botão "B" for tocado pelo usuário no momento.
        OVRInput.Get(OVRInput.Touch.Two);

        // retorna verdadeiro se o controle direito está conectado
        OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote);


    }
}
