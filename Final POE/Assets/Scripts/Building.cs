﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    [Serializable]
    abstract public class Building
    {
        protected int x;
        protected int y;
        protected string team;
        protected int health;
        protected char symbol;

        abstract public void Constructor(int bX, int bY, string bTeam);
        abstract public void Destroy();
        abstract public string ToString();


    }

