using UnityEngine;
using System.Collections;

public class MenuPrincipal : MonoBehaviour {

	public float posX; // posição do botão
	public float posY; // posição do botão

	public float alturaButao; // altura do botão
	public float larguraButao; // largura do botão

	public GUISkin skinMenuPrincipal; // layout dos botões

	public bool sair;
	public bool tutorial;
	public bool iniciar;
	public bool sobre;
	public bool controle;

	// Use this for initialization
	void Start () {
	
		alturaButao = 30;
		larguraButao = 80;

		posX = Screen.width /2  - (larguraButao / 2); // Screen.width = largura do monitor
		posY = Screen.height / 2 - (alturaButao / 2); // Screen.height = altura do monitor

		sair = false;
		tutorial = false;
		iniciar = false;
		controle = false;
		sobre = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/* Função de interface para o usuário (textos, botões, etc) */
	void OnGUI()
	{
		GUI.skin = skinMenuPrincipal;

		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), " \n\n\n\n\n\n\n\n\n Sistema desenvolvido utilizando técnicas de Realidade Virtual\n Instituto Militar de Engenharia \n Sistemas e Computação \n\n\nDesenvolvedores:\n\n Raquel E. M. de Oliveira \n Jauvane Cavalcante de Oliveira");

		/* Botão de Iniciar */
		if (GUI.Button(new Rect(posX + 600, posY - 250 , larguraButao , alturaButao), "Voltar")) // cria botão de Menu
		{
			iniciar = true;
		}

		/* Botões no Menu */
/*		if (tutorial == false && sobre == false && iniciar == false)
		{
			/* Botão de Iniciar */
/*			if (GUI.Button(new Rect(posX, posY - alturaButao - alturaButao + 25, larguraButao, alturaButao), "Voltar")) // cria botão de Menu
			{
				iniciar = true;
			}

			/* Botão de Controles */
/*			if (GUI.Button(new Rect(posX, posY - alturaButao + 30, larguraButao, alturaButao), "Tutorial")) // cria botão  de Menu
			{
				tutorial = true;
			}

			/* Botão Sobre */
/*			if (GUI.Button(new Rect(posX, posY + 35, larguraButao, alturaButao), "Sobre")) // cria botão  de Menu
			{
				sobre = true;
			}

			/* Botão Sobre */
/*			if (GUI.Button(new Rect(posX, posY + alturaButao + 40, larguraButao, alturaButao), "Controle")) // cria botão  de Menu
			{
				controle = true;
			}

			/* Botão para Sair */
/*			if (GUI.Button(new Rect(posX, posY + alturaButao + alturaButao + 45, larguraButao, alturaButao), "Sair")) // cria botão  de Menu
			{
				Application.Quit(); // fechar programa
			}
		}


		/* Mostra os controles */
/*		if (tutorial == false && sobre == false && sair == false && controle == true && iniciar == false)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "\n\n\n\n\n TECLADO e MOUSE\n\n Frente = W\n Trás = S\n Esquerda = A\n Direita = D\n Pular = Espaço\n Subir = U\n Descer = J\n Parar = P\n Atirar = B\n\n\n\n\n JOYSTICK \n\n Pular = X\n Subir = Y\n Descer = A\n Parar = LB\n Atirar = B");

			/* Botão para Voltar */
/*			if (GUI.Button(new Rect(posX, posY + alturaButao + 20, larguraButao, alturaButao), "Voltar")) // cria botão  de Menu
			{
				controle = false;
			}
		}

		/* Informações de autores e disciplina */
/*		if (tutorial == false && sobre == true && sair == false && controle == false && iniciar == false)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "\n\n\n Jogo desenvolvido utilizando técnicas de Realidade Virtual\n Instituto Militar de Engenharia \n Sistemas e Computação \n\n\nDesenvolvedores:\n\n Raquel E. M. de Oliveira \n Jauvane Cavalcante de Oliveira");

			/* Botão para Voltar */
/*			if (GUI.Button(new Rect(posX, posY + alturaButao + 20, larguraButao, alturaButao), "Voltar")) // cria botão  de Menu
			{
				sobre = false;
			}
		}*/
	}
}
