﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public abstract class MovableEntities : Entities
    {
        public Point destination;

        public void Move(Point destination)
        {
            this.destination.X = destination.X;
            this.destination.Y = destination.Y;
        }

    }
}
