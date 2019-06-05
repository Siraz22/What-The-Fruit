using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Spawns : MonoBehaviour {

    Spawnner Spawnner_Script;

    private int Spawn_Num;

    private void Awake()
    {
        Spawnner_Script = GameObject.FindObjectOfType<Spawnner>();
    }

    public void Check_Which_Special_CouroutineToStart(int check_num)
    {
        if (check_num >= 0 && check_num < 25)
            StartCoroutine("Diagonal1");
        else if (check_num >= 25 && check_num < 50)
            StartCoroutine("Diagonal2");
        else if (check_num >= 50 && check_num < 70)
            StartCoroutine("Pyramid");

        /*
        else if (check_num >= 70 && check_num < 85)
            StartCoroutine("Scatter");
        else if (check_num >= 85 && check_num < 95)
            StartCoroutine("RareX");
        else if (check_num >= 95 && check_num <= 100)
            StartCoroutine("UltraRare");
            */

    }


    /***********************************************************************************************************************************************
     *****************************************************DIAGONAL 1********************************************************************************
     ***********************************************************************************************************************************************/

    IEnumerator Diagonal1()
    {
       
        int lowest_platform_no = Spawnner_Script.Lowest_spawn_number;
        Spawn_Num = Random.Range(1,2);

        Debug.Log(Spawn_Num);

        while(true)
        {
            Debug.Log("Diag1");

            yield return new WaitForSeconds(0.3f);

            if (Spawn_Num == 1 )
            {
                Debug.Log("Diag1 Fast");
                Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(0, 7)], Spawnner_Script.Spawn_Points[lowest_platform_no].position, Spawnner_Script.Spawn_Points[2].rotation);
                lowest_platform_no--;
                Spawn_Num = 2;
            }
            else if (Spawn_Num == 2)
            {
                Debug.Log("Diag1 Fruit");

                Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(8, 14)], Spawnner_Script.Spawn_Points[lowest_platform_no].position, Spawnner_Script.Spawn_Points[2].rotation);
                lowest_platform_no--;
                Spawn_Num = 1;
            }

            if (lowest_platform_no < Spawnner_Script.Topmost_spawn_number)
                break;
        }

        Debug.Log("Diag1 Break");

        Spawnner_Script.StartCoroutine("RandomSpawn");
    }

    /***********************************************************************************************************************************************
     *****************************************************DIAGONAL 2********************************************************************************
     ***********************************************************************************************************************************************/

    IEnumerator Diagonal2()
    {
        Debug.Log("Diag2");
        int top_platform_no = Spawnner_Script.Topmost_spawn_number;
        Spawn_Num = Random.Range(1, 2);

        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (Spawn_Num == 1)
            {
                Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(0, 7)], Spawnner_Script.Spawn_Points[top_platform_no].position, Spawnner_Script.Spawn_Points[2].rotation);
                top_platform_no++;
                Spawn_Num = 2;
            }
            else if (Spawn_Num == 2)
            {
                Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(8, 14)], Spawnner_Script.Spawn_Points[top_platform_no].position, Spawnner_Script.Spawn_Points[2].rotation);
                top_platform_no++;
                Spawn_Num = 1;
            }

            if (top_platform_no > Spawnner_Script.Lowest_spawn_number )
                break;
        }

        Spawnner_Script.StartCoroutine("RandomSpawn");
    }


    /***********************************************************************************************************************************************
     ******************************************************PYRAMID *********************************************************************************
     ***********************************************************************************************************************************************/

    IEnumerator Pyramid()
    {
        Debug.Log("Pyramid");
        int fluctuate_num = Spawnner_Script.Lowest_spawn_number;
        Spawn_Num = Random.Range(1, 2);

        bool change_direction= false;

        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            if(change_direction==true)
            {
                if (Spawn_Num == 1)
                {
                    Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(8, 14)], Spawnner_Script.Spawn_Points[fluctuate_num].position, Spawnner_Script.Spawn_Points[2].rotation);
                    fluctuate_num++;
                    Spawn_Num = 2;
                }
                else if (Spawn_Num == 2)
                {
                    Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(0, 7)], Spawnner_Script.Spawn_Points[fluctuate_num].position, Spawnner_Script.Spawn_Points[2].rotation);
                    fluctuate_num++;
                    Spawn_Num = 1;

                }

                if (fluctuate_num > Spawnner_Script.Lowest_spawn_number)
                    break;
            }

            if (change_direction == false)
            {
                if (Spawn_Num == 1)
                {
                    Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(0, 7)], Spawnner_Script.Spawn_Points[fluctuate_num].position, Spawnner_Script.Spawn_Points[2].rotation);
                    fluctuate_num--;
                    Spawn_Num = 2;
                }
                else if (Spawn_Num == 2)
                {
                    Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(8, 14)], Spawnner_Script.Spawn_Points[fluctuate_num].position, Spawnner_Script.Spawn_Points[2].rotation);
                    fluctuate_num--;
                    Spawn_Num = 1;
                }

                if (fluctuate_num < Spawnner_Script.Topmost_spawn_number)
                {
                    fluctuate_num = Spawnner_Script.Topmost_spawn_number + 1;
                    change_direction = true;
                }
            }
        }

        Spawnner_Script.StartCoroutine("RandomSpawn");
    }

    /***********************************************************************************************************************************************
     ******************************************************SCATTER *********************************************************************************
     ***********************************************************************************************************************************************/

        /*
    IEnumerator Scatter()
    {

        int Line = Random.Range(0, 1);

        int lowest_platform_no = Spawnner_Script.Lowest_spawn_number;
        Spawn_Num = Random.Range(0, 1);

        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (Spawn_Num == 1)
            {
                Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(0, 7)], Spawnner_Script.Spawn_Points[lowest_platform_no].position, Spawnner_Script.Spawn_Points[2].rotation);
                lowest_platform_no--;
                Spawn_Num = 2;
            }
            else if (Spawn_Num == 2)
            {
                Instantiate(Spawnner_Script.FruitsAndFasts[Random.Range(8, 14)], Spawnner_Script.Spawn_Points[lowest_platform_no].position, Spawnner_Script.Spawn_Points[2].rotation);
                lowest_platform_no--;
                Spawn_Num = 1;
            }

            if (lowest_platform_no < Spawnner_Script.Topmost_spawn_number)
                break;
        }

        Spawnner_Script.StartCoroutine("RandomSpawn");
    }
    */

}
