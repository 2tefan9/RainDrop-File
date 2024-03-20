using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static BubblePrototype;

public class Operation : Bubble
{
    public int number1 = 0;
    public int number2 = 0;
    [SerializeField]
    private TMP_Text number1Text;
    [SerializeField]
    private TMP_Text number2Text;
    [SerializeField]
    private TMP_Text operators;
    public string nU1, nU2;
    int integerSol;
    public int Solu;
    public string binSol;
    
    // base 10 operazione decimale
    // base 3  operazione decimale d'0ro
    // base 2  operazione binaria



    private void Start()
    {
        if (Base == 10 || Base == 3)
        {
            CreateRandomNumber();
        }
        else if (Base == 2)
        {
            ConvertToBinary();
        }
    }


    public void CreateRandomNumber()
    {
        number1 = UnityEngine.Random.Range(1, secondRangeNumber);
        nU1 = Convert.ToString(number1);
        number1Text.text = nU1;
        number2 = UnityEngine.Random.Range(1, secondRangeNumber);
        nU2 = Convert.ToString(number2);
        number2Text.text = nU2;
        CreateSolution();
    }
    public void CreateSolution()
    {
        switch (bubbleType)
        {
            case eBubbleID.Addiction: Solution = number1 + number2; operators.text = "+"; break;
            case eBubbleID.Subtraction: Solution = number1 - number2; operators.text = "-"; break;
            case eBubbleID.Multiplication: Solution = number1 * number2; operators.text = "x"; break;
            case eBubbleID.Division:
                {
                    operators.text = "/";
                    checkIntegerOperations();
                    break;
                }

        }
        if (Base == 2)
        {
            ConvertToBinarySolution(Solution);           
        }
        else
        Solu = Solution;
       
        
    }

    private void checkIntegerOperations()
    {
        integerSol = number1 % number2;
        if (integerSol == 0)
        {
            nU2 = Convert.ToString(number2);
            number2Text.text = nU2;
            CreateSolutiondiv();
        }
        else if(Base==10||Base==3)
            CreateRandomNumber();
       
    }

    public void CreateSolutiondiv()
    {
        
        Solution = number1 / number2;

    }

    public void ConvertToBinary()
    {
        number1 = UnityEngine.Random.Range(1, 20);  
        number2 = UnityEngine.Random.Range(1, 20);
        string binaryRepresentation = Convert.ToString(number1, 2);
        nU1 = binaryRepresentation;
        number1Text.text = nU1;
        string binaryRepresentation2 = Convert.ToString(number2, 2);
        nU2= binaryRepresentation2;
        number2Text.text = nU2;
        CreateSolution();
    }

    //Problem Binary conversion 

    public int ConvertToBinarySolution(int Decimal)
    {
        int binaryRepresentationSOL = 0;
        int position = 1;

        while (Decimal > 0)
        {
            int remainder = Solution % 2;
            binaryRepresentationSOL = remainder * position + binaryRepresentationSOL;
            Decimal /= 2;
            position *= 10;
        }
        Solu = binaryRepresentationSOL;
        binSol = Convert.ToString(Solu);
        Solution = Solu;
        return binaryRepresentationSOL;
    }

 
}

