using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public partial class Form1 : MonoBehaviour
{
    Map_01 GameMap;
    bool meleeAlive = true;
    bool rangedAlive = true;
    GameEngine TheGame;
    int GameCount = 0;
    bool timer = true;
    public GameObject BlueS;
    public GameObject YellowS;
    public GameObject parent;
    public GameObject BlueA;
    public GameObject YellowA;
    public GameObject BlueW;
    public GameObject YellowW;
    public GameObject BlueRec;
    public GameObject YellowRec;
    public GameObject BlueFac;
    public GameObject YellowFac;
    public Camera GameCamera;
    bool pause = true;

    int timeCount = 0;

    public void Begin()
    {

        foreach (GameObject G in GameObject.FindGameObjectsWithTag("Unit"))
        {
            Destroy(G);
        }

        foreach(GameObject G in GameObject.FindGameObjectsWithTag("Building"))
        {
            Destroy(G);
        }

        GameMap = new Map_01();
        GameMap.NewBattlefield();
        TheGame = new GameEngine();

        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                Map_01 UnitPos = new Map_01();

                foreach (MeleeUnit u in GameMap.MeleeList)
                {

                    if (u != null)
                    {
                        if (x == u.X && y == u.Y)
                        {
                            Vector3 pos;
                            switch (u.team)
                            {

                                case "Blue":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(BlueS, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowS, pos, Quaternion.Euler(90, 180, 0));

                                    break;
                            }
                        }
                    }

                }

                foreach (RangedUnit u in GameMap.RangedList)
                {

                    if (u != null)
                    {
                        if (x == u.X && y == u.Y)
                        {
                            Vector3 pos;
                            switch (u.team)
                            {
                                case "Blue":
                                    pos = new Vector3(x, y, -2);

                                    Instantiate(BlueA, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowA, pos, Quaternion.Euler(90, 180, 0));
                                    break;

                            }
                        }
                    }

                }

                for (int i = 0; i < 4; i++)
                {

                    if (i == 0 || i == 1)
                    {
                        RecourceBuilding u = (RecourceBuilding)GameMap.buildingList[i];

                        if (x == u.X && y == u.Y)
                        {

                            Vector3 pos;
                            switch (u.Team)
                            {
                                case "Blue":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(BlueRec, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowRec, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                            }
                        }
                    }
                    else
                    {
                        Factory u = (Factory)GameMap.buildingList[i];

                        if (x == u.X && y == u.Y)
                        {

                            Vector3 pos;
                            switch (u.Team)
                            {
                                case "Blue":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(BlueFac, pos, Quaternion.Euler(90, 180, 0));
                                    Debug.Log("factory");
                                    break;
                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowFac, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                            }
                        }
                    }


                }

                foreach (Wizard u in GameMap.WizardList)
                {

                    if (u != null)
                    {
                        if (x == u.X && y == u.Y)
                        {
                            Vector3 pos;

                            switch (u.team)
                            {
                                case "Blue":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(BlueW, pos, Quaternion.Euler(90, 180, 0));
                                    break;

                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowW, pos, Quaternion.Euler(90, 180, 0));
                                    break;
                            }
                        }
                    }
                }
            }
        } //Update

    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fStream = new FileStream("GameMap.dat", FileMode.Open, FileAccess.Read, FileShare.None);

        try
        {
            GameMap = (Map_01)bf.Deserialize(fStream);

        }
        catch
        {
            Debug.Log("couldnt load game");
        }
    }

    public void SaveGame()
    {

        BinaryFormatter b = new BinaryFormatter();
        FileStream fStream = new FileStream("GameMap.dat", FileMode.Create, FileAccess.Write, FileShare.None);

        try
        {
            using (fStream)
            {
                b.Serialize(fStream, GameMap);
                Debug.Log("Game Saved");
            }
        }
        catch
        {
            Debug.Log("Couldnt Save Game");
        }
    }

    public void PauseGame()
    {
        if (pause)
        {
            pause = false;
        }
        else
        {
            pause = true;
        }
    }

    private void updatebuttons()
    {
        foreach (GameObject G in GameObject.FindGameObjectsWithTag("Unit"))
        {
            Destroy(G);
        }

        Vector3 posP = new Vector3(9, -2, 0);
        Instantiate(parent, posP, Quaternion.identity);

        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                Map_01 UnitPos = new Map_01();

                foreach (MeleeUnit u in GameMap.MeleeList)
                {

                    if (u != null)
                    {
                        if (x == u.X && y == u.Y)
                        {
                            Vector3 pos;
                            switch (u.team)
                            {

                                case "Blue":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(BlueS, pos, Quaternion.Euler(90 , 180, 0));

                                    break;

                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowS, pos, Quaternion.Euler(90, 180, 0));

                                    break;
                            }
                        }
                    }

                }

                foreach (RangedUnit u in GameMap.RangedList)
                {

                    if (u != null)
                    {
                        if (x == u.X && y == u.Y)
                        {
                            Vector3 pos;
                            switch (u.team)
                            {
                                case "Blue":
                                    pos = new Vector3(x, y, -2);

                                    Instantiate(BlueA, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowA, pos, Quaternion.Euler(90, 180, 0));
                                    break;

                            }
                        }
                    }

                }

                for (int i = 0; i < 4; i++)
                {

                    if (i == 0 || i == 1)
                    {
                        RecourceBuilding u = (RecourceBuilding)GameMap.buildingList[i];

                        if (x == u.X && y == u.Y)
                        {

                            Vector3 pos;
                            switch (u.Team)
                            {
                                case "Blue":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(BlueRec, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowRec, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                            }
                        }
                    }
                    else
                    {
                        Factory u = (Factory)GameMap.buildingList[i];

                        if (x == u.X && y == u.Y)
                        {

                            Vector3 pos;
                            switch (u.Team)
                            {
                                case "Blue":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(BlueFac, pos, Quaternion.Euler(90, 180, 0));

                                    break;
                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowFac, pos, Quaternion.Euler(90, 180, 0));

                                    break;

                            }
                        }
                    }


                }

                foreach (Wizard u in GameMap.WizardList)
                {

                    if (u != null)
                    {
                        if (x == u.X && y == u.Y)
                        {
                            Vector3 pos;

                            switch (u.team)
                            {
                                case "Blue":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(BlueW, pos, Quaternion.Euler(90, 180, 0));
                                    break;

                                case "Yellow":
                                    pos = new Vector3(x, y, -2);
                                    Instantiate(YellowW, pos, Quaternion.Euler(90, 180, 0));
                                    break;
                            }
                        }
                    }
                }
            }
        } //Update
    }// displays positions of units and buildings

    public void CombatEngine(Unit u)
    {

        if (u.attackRange == 2)
        {

            MeleeUnit u2 = (MeleeUnit)u;
            if ((u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList)) != null)
            {
                int distance = u2.FindUnit(u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList));
                // info.Text = info.Text + "\n" + distance.ToString();
                if (distance <= u2.attackRange)
                {
                    u2.Combat(u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList));

                } //combat
                else
                {
                    if (u2.Health > 2)
                    {
                        if (u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList).attackRange < 3)
                        {
                            MeleeUnit Position = (MeleeUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (Position.X > u2.X)
                            {

                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X < u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }
                            if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }
                        else
                        {
                            RangedUnit Position = (RangedUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (Position.X > u2.X)
                            {

                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X < u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }
                            if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }


                    }// movement
                    else
                    {
                        if (u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList).attackRange < 3)
                        {
                            MeleeUnit Position = (MeleeUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);

                            if (Position.X < u2.X)
                            {

                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X > u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }
                            if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }
                        else
                        {
                            RangedUnit Position = (RangedUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);

                            if (Position.X < u2.X)
                            {

                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X > u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }
                            if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }

                    }// running away / needs work

                }

                if (u.Death())
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (GameMap.MeleeList[i] != null)
                        {
                            if (GameMap.MeleeList[i] == u)
                            {
                                for (int k = i; k < 14; k++)
                                {
                                    GameMap.MeleeList[k] = GameMap.MeleeList[k + 1];
                                }

                                GameMap.MeleeList[14] = null;
                            }
                        }
                    }

                } // handels death in the game
            }// melee

        }

        else if (u.attackRange == 4)
        {
            RangedUnit u2 = (RangedUnit)u;
            int counti = 0;
            for (int i = 0; i < 5; i++)
            {
                if (GameMap.MeleeList[i] != null && u.ReturnPosition(GameMap.MeleeList, GameMap.RangedList) != null)
                {
                    if (u.ReturnPosition(GameMap.MeleeList, GameMap.RangedList).team != u.team)
                    {
                        counti++;
                    }

                }
            }
            if (counti > 0) // see number of units in array
            {


                int distance = u2.FindUnit(u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList));

                if (distance <= u2.attackRange)
                {
                    u2.Combat(u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList));

                } //combat
                else
                {
                    if (u2.Health > 2)
                    {
                        if (u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList).attackRange > 3)
                        {
                            RangedUnit Position = (RangedUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (Position.X > u2.X)
                            {
                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X < u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }
                            if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }
                        else
                        {
                            MeleeUnit Position = (MeleeUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (Position.X > u2.X)
                            {
                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X < u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }
                            if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }


                    }// movement
                    else
                    {
                        if (u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList).attackRange > 3)
                        {
                            RangedUnit Position = (RangedUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (Position.X < u2.X)
                            {

                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X > u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }


                            if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }
                        else
                        {
                            MeleeUnit Position = (MeleeUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (u2.X + u2.Speed >= 0 && u2.X + u2.Speed <= 19)
                            {


                                if (Position.X < u2.X)
                                {

                                    u.MoveUnit(1, 0);
                                }
                                else if (Position.X > u2.X)
                                {

                                    u.MoveUnit(-1, 0);
                                }
                            }

                            if (u2.Y + u2.Speed >= 0 && u2.Y + u2.Speed <= 19)
                            {


                                if (Position.Y < u2.Y)
                                {
                                    u.MoveUnit(0, 1);
                                }
                                else if (Position.Y > u2.Y)
                                {
                                    u.MoveUnit(0, -1);
                                }
                            }

                        }





                    }// running away / needs work
                }

            }

            if (u.Death())
            {

                for (int i = 0; i < 15; i++)
                {
                    if (GameMap.RangedList[i] != null)
                    {
                        if (GameMap.RangedList[i] == u)
                        {
                            for (int k = i; k < 14; k++)
                            {
                                GameMap.RangedList[k] = GameMap.RangedList[k + 1];
                            }

                            GameMap.RangedList[14] = null;
                        }
                    }
                }


            } // handels death in the game
        }

        else
        {
            Wizard u2 = (Wizard)u;
            int counti = 0;
            for (int i = 0; i < 5; i++)
            {
                if (GameMap.MeleeList[i] != null && u.ReturnPosition(GameMap.MeleeList, GameMap.RangedList) != null)
                {
                    if (u.ReturnPosition(GameMap.MeleeList, GameMap.RangedList).team != u.team)
                    {
                        counti++;
                    }

                }
            }
            if (counti > 0) // see number of units in array
            {


                int distance = u2.FindUnit(u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList));

                if (distance <= u2.attackRange)
                {
                    u2.Combat(u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList));

                } //combat
                else
                {
                    if (u2.Health > 2)
                    {
                        if (u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList).attackRange > 3)
                        {
                            RangedUnit Position = (RangedUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (Position.X > u2.X)
                            {
                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X < u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }
                            if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }
                        else
                        {
                            MeleeUnit Position = (MeleeUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (Position.X > u2.X)
                            {
                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X < u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }
                            if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }


                    }// movement
                    else
                    {
                        if (u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList).attackRange > 3)
                        {
                            RangedUnit Position = (RangedUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (Position.X < u2.X)
                            {

                                u.MoveUnit(1, 0);
                            }
                            else if (Position.X > u2.X)
                            {

                                u.MoveUnit(-1, 0);
                            }


                            if (Position.Y < u2.Y)
                            {
                                u.MoveUnit(0, 1);
                            }
                            else if (Position.Y > u2.Y)
                            {
                                u.MoveUnit(0, -1);
                            }
                        }
                        else
                        {
                            MeleeUnit Position = (MeleeUnit)u2.ReturnPosition(GameMap.MeleeList, GameMap.RangedList);
                            if (u2.X + u2.Speed >= 0 && u2.X + u2.Speed <= 19)
                            {


                                if (Position.X < u2.X)
                                {

                                    u.MoveUnit(1, 0);
                                }
                                else if (Position.X > u2.X)
                                {

                                    u.MoveUnit(-1, 0);
                                }
                            }

                            if (u2.Y + u2.Speed >= 0 && u2.Y + u2.Speed <= 19)
                            {


                                if (Position.Y < u2.Y)
                                {
                                    u.MoveUnit(0, 1);
                                }
                                else if (Position.Y > u2.Y)
                                {
                                    u.MoveUnit(0, -1);
                                }
                            }

                        }





                    }// running away / needs work
                }

            }

            if (u.Death())
            {

                for (int i = 0; i < 15; i++)
                {
                    if (GameMap.RangedList[i] != null)
                    {
                        if (GameMap.RangedList[i] == u)
                        {
                            for (int k = i; k < 14; k++)
                            {
                                GameMap.RangedList[k] = GameMap.RangedList[k + 1];
                            }

                            GameMap.RangedList[14] = null;
                        }
                    }
                }


            } // handels death in the game
        }




    }// the working of the game

    private void Update()
    {
        if (timeCount != 60)
        {
            timeCount++;
        }
        else
        {


            if (pause)
            {
                int count = 0;

                for (int i = 0; i < 2; i++)
                {
                    if (GameMap.WizardList[i] != null)
                    {
                        Wizard w = GameMap.WizardList[i];
                        CombatEngine(w);
                    }
                }

                foreach (MeleeUnit u in GameMap.MeleeList)
                {
                    if (u != null)
                    {
                        if (u.Alive)
                        {
                            count++;
                        }
                    }


                }

                if (count == 0)
                {
                    meleeAlive = false;
                }

                if (meleeAlive)
                {
                    foreach (MeleeUnit u in GameMap.MeleeList)
                    {
                        if (u != null)
                        {
                            if (u.Alive)
                            {
                                if (count > 0)
                                {
                                    CombatEngine(u);
                                }
                            }
                        }


                    }
                }

                count = 0;

                foreach (RangedUnit u in GameMap.RangedList)
                {
                    if (u != null)
                    {
                        if (u.Alive)
                        {
                            count++;
                        }
                    }


                }

                if (count == 0)
                {
                    rangedAlive = false;
                }

                if (rangedAlive)
                {
                    foreach (RangedUnit u in GameMap.RangedList)
                    {
                        if (u != null)
                        {
                            if (u.Alive)
                            {
                                if (count > 0)
                                {
                                    CombatEngine(u);
                                }
                            }
                        }


                    }
                }
                else
                {
                    //  MessageBox.Show("Ranged units dead");
                }

                int unitcount = 0;
                for (int i = 0; i < 15; i++)
                {
                    if (GameMap.MeleeList[i] != null)
                    {
                        unitcount++;
                    }

                }

                RecourceBuilding b1 = (RecourceBuilding)GameMap.buildingList[0];

                if (b1.Remaining > 0)
                {

                    b1.generate(b1.AmountTick);
                    GameMap.availableBlue = GameMap.availableBlue + b1.AmountTick;
                }


                b1 = (RecourceBuilding)GameMap.buildingList[1];

                if (b1.Remaining > 0)
                {

                    b1.generate(b1.AmountTick);
                    GameMap.availableYellow = GameMap.availableYellow + b1.AmountTick;
                }



                if (unitcount < 14)
                {

                    RecourceBuilding b = (RecourceBuilding)GameMap.buildingList[0];
                    if (b.Remaining > 0)
                    {

                        GameMap.availableBlue = GameMap.availableBlue - 5;
                        Factory factory = (Factory)GameMap.buildingList[2];
                        GameMap.MeleeList[unitcount] = (MeleeUnit)factory.SpawnUnit();

                    }


                    b = (RecourceBuilding)GameMap.buildingList[1];
                    if (b.Remaining > 0)
                    {
                        GameMap.availableYellow = GameMap.availableYellow - 5;
                        Factory factory = (Factory)GameMap.buildingList[3];
                        GameMap.MeleeList[unitcount + 1] = (MeleeUnit)factory.SpawnUnit();
                    }
                }

                timeCount = 0;
                GameCount++;
                updatebuttons();
            }
        }

    }

    public void MoveUp()
    {
        Vector3 Pos = GameCamera.transform.position;
        Pos.y++;
        GameCamera.transform.SetPositionAndRotation(Pos, Quaternion.identity);
    }

    public void MoveDown()
    {
        Vector3 Pos = GameCamera.transform.position;
        Pos.y--;
        GameCamera.transform.SetPositionAndRotation(Pos, Quaternion.identity);
    }

    public void MoveLeft()
    {
        Vector3 Pos = GameCamera.transform.position;
        Pos.x--;
        GameCamera.transform.SetPositionAndRotation(Pos, Quaternion.identity);
    }

    public void MoveRight()
    {
        Vector3 Pos = GameCamera.transform.position;
        Pos.x++;
        GameCamera.transform.SetPositionAndRotation(Pos, Quaternion.identity);
    }

    public void ZoomIn()
    {
        GameCamera.orthographicSize = GameCamera.orthographicSize -1;
    }

    public void ZoomOut()
    {
        GameCamera.orthographicSize = GameCamera.orthographicSize + 1;
    }

    public string FindUnit(int x, int y)
    {
        string info = "Item not found";

        foreach (MeleeUnit u in GameMap.MeleeList)
        {
            if (u != null)
            {
                if (u.X == x && u.Y == y)
                {
                    info = u.ToString();
                }
            }
            
        }
        foreach (RangedUnit u in GameMap.RangedList)
        {
            if (u != null)
            {
                if (u.X == x && u.Y == y)
                {
                    info = u.ToString();
                }
            }
        }

        foreach (Wizard u in GameMap.WizardList)
        {
            if (u != null)
            {
                if (u.X == x && u.Y == y)
                {
                    info = u.ToString();
                }
            }
        }

       for (int k = 0; k< 4; k++)
        {
            if (k == 0 ||k == 1)
            {
                RecourceBuilding u = (RecourceBuilding)GameMap.buildingList[k];
                if (u != null)
                {
                    if (u.X == x && u.Y == y)
                    {
                        info = u.ToString();
                    }
                }
            }
            else
            {
               Factory u = (Factory)GameMap.buildingList[k];
                if (u != null)
                {
                    if (u.X == x && u.Y == y)
                    {
                        info = u.ToString();
                    }
                }
            }

        }


        return info;
    }
}


