using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Picture : IDraw
    {
        public List<Shape> Geometry;

        public int NumberOfShapes { get { return Geometry.Count; } set { } }

        public Shape[] shapes;

        public Shape this[int index]
        {
            get
            {
                return shapes[index];
            }
            set
            {
                shapes[index] = value;
            }
        }

        public Picture()
        {
            Geometry = new List<Shape>();
        }
        public Picture(int collectionLength)
        {
            Geometry = new List<Shape>(collectionLength);

            NumberOfShapes = collectionLength;
        }

        public void Add(Shape figure)
        {
            Geometry.Add(figure);
        }

       public void RemoveByName(string nameToRemove)
        {
            if (NumberOfShapes == 0)
            {
                Console.WriteLine("There are nothing to remove  - list is empty!");
            }
            else
            {
                for (int i = 0; i < NumberOfShapes; i++)
                {
                    if (Geometry[i].Name == nameToRemove)
                    {
                        Geometry.Remove(Geometry[i]);
                    }
                }
            }
        }

        public void RemoveByArea(double areaLimit)
        {
            if (NumberOfShapes == 0)
            {
                Console.WriteLine("There are nothing to remove  - list is empty!");
            }
            else
            {
                for (int i = 0; i < NumberOfShapes; i++)
                {
                    if (Geometry[i].Square() > areaLimit)
                    {
                        Geometry.Remove(Geometry[i]);
                    }
                }
            }
        }

        public void RemoveByType(Type figure)
        {
            if (NumberOfShapes == 0)
            {
                Console.WriteLine("There are nothing to remove  - list is empty!");
            }
            else
            {
                for (int i = 0; i < NumberOfShapes; i++)
                {
                    if (Geometry[i].GetType() == figure)
                    {
                        Geometry.Remove(Geometry[i]);
                    }
                }
            }
        }

        public void Draw()
        {
            if (NumberOfShapes == 0)
            {
                Console.WriteLine("~The list is empty!~");
            }
            else
            {
                int i = 1;
                foreach (Shape el in Geometry)
                {
                    Circle c;
                    Quadrate q;
                    Triangle t;
                    if (el is Circle)
                    {
                        c = (Circle)el;
                        Console.WriteLine("Figure # {0}", i++);
                        c.Draw();
                    }
                    else if (el is Quadrate)
                    {
                        q = (Quadrate)el;
                        Console.WriteLine("Figure # {0}", i++);
                        q.Draw();
                    }
                    else
                    {
                        t = (Triangle)el;
                        Console.WriteLine("Figure # {0}", i++);
                        t.Draw();
                    }
                }
            }
            
        }

    }
}
