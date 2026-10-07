using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using extOSC;


public class OscProcess : MonoBehaviour
{
    //code ajouté
    public extOSC.OSCReceiver oscReceiver;
    public GameManager gameManager;
    public Ball ball;
    public PlayerPaddle playerPaddle;

    public int potInMin = 0;
    public int potInMax = 1023;
    public float potOutMin = 0.0f; //-4.32f;
    public float potOutMax = 1.0f; //4.32f;


    // Start is called before the first frame update
    void Start()
    {
        //code ajouté
        oscReceiver.Bind("/but0", TraiterMessageBut0);
        oscReceiver.Bind("/pot", TraiterMessagePot0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //code ajouté
    void TraiterMessageBut0(OSCMessage message)
    {
        // Validez qu�il y a bien le nombre attendu d�arguments (1 dans l�exemple) :
        if (message.Values.Count != 1)
        {
            Debug.Log("Le message " + message.Address + " n�a pas le bon nombre d�arguments");
            return; // Quitte la fonction sans ex�cuter la suite
        }

        // V�rifiez que l�argument est du type attendu (`int` dans l�exemple) :
        if (message.Values[0].Type != OSCValueType.Int)
        {
            Debug.Log("Le premier argument du message " + message.Address + "n�est pas un entier");
            return; // Quitte la fonction sans ex�cuter la suite
        }

        // R�cup�rer la valeur de l�argument :
        int valeur = message.Values[0].IntValue;

        // Deboguer
        // Debug.Log("Re�u : " + message.Address + " " + valeur);

        // TRAITER LA VALEUR ICI !

    //code ajouté
    if (valeur == 1)
    {
        // METTRE ICI L’APPEL À LA FONCTION POUR LANCER LA BALLE
        // COMME INDICE, C’EST QQCH COMME : gameState.Throw()

        gameManager.ThrowBall(); //code ajouté
    } else {

    }


    }

    //code ajouté
    void TraiterMessagePot0(OSCMessage message)
    {
        // Validez qu�il y a bien le nombre attendu d�arguments (1 dans l�exemple) :
        if (message.Values.Count != 1)
        {
            Debug.Log("Le message " + message.Address + " n�a pas le bon nombre d�arguments");
            return; // Quitte la fonction sans ex�cuter la suite
        }

        // V�rifiez que l�argument est du type attendu (`int` dans l�exemple) :
        if (message.Values[0].Type != OSCValueType.Int)
        {
            Debug.Log("Le premier argument du message " + message.Address + "n�est pas un entier");
            return; // Quitte la fonction sans ex�cuter la suite
        }

        // R�cup�rer la valeur de l�argument :
        int valeur = message.Values[0].IntValue;

        // Deboguer
        // Debug.Log("Re�u : " + message.Address + " " + valeur);

        // TRAITER LA VALEUR ICI !
        //code ajouté
        float ajuste = (((float)valeur - potInMin) / (potInMax - potInMin) * (potOutMax - potOutMin) + potOutMin);
        // AJOUTER À LA LIGNE SUIVANTE LE CODE POUR APPLIQUER LA VARIABLE ajuste AU DÉPLACEMENT DE LA PALETTE ICI !
        // COMME INDICE C’EST QQCH COMME : palette.setVercialPosition( ajuste);
        playerPaddle.SetPosition(ajuste);


    }

}
