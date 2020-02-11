using System;

namespace Dojodachi.Models
{
    public class Dojod
    {
        private int _happiness;
        private int _fullness;
        private int _energy;
        private int _meals;
        public int Happiness 
        {
            get{return _happiness;}
        }
        public int Fullness
        {
            get{return _fullness;}
        }
        public int Energy
        {
            get{return _energy;}
        }
        public int Meals
        {
            get{return _meals;}
        }
        public Dojod()
        {
            _happiness = 20;
            _fullness = 20;
            _energy = 50;
            _meals = 3;
        }

        public string Feed()
        {
            if(_meals == 0)
            {
                return "Oops! Cannot feed Dojodachi; you ran out of meals!";
            }
            Random rand = new Random();
            if(rand.Next(5) == 2)
            {
                _meals -= 1;
                return $"Om nom...ewww!!! This meal is bad! Meals -1";
            }
            int num = rand.Next(5,11);
            _fullness += num;
            _meals -= 1;
            return $"Om nom nom! It was delicious! Fullness +{num}, Meals -1";
        }

        public string Play()
        {
            Random rand = new Random();
            if(rand.Next(5) == 2)
            {
                _energy -= 5;
                return $"I don't like this game! Energy -5";
            }
            int num = rand.Next(5,11);
            _happiness += num;
            _energy -= 5;
            return $"Ggwp! Happiness +{num}, Energy -5";
        }

        public string Work()
        {
            Random rand = new Random();
            int num = rand.Next(1,4);
            _energy -= 5;
            _meals += num;
            return $"Going to work... ehh... just gotta earn those meals... Meals +{num}, Energy -5";
        }

        public string Sleep()
        {
            _energy += 15;
            _fullness -= 5;
            _happiness -= 5;
            return $"Zzzz.... Energy +15, Fullness -5, Happiness -5";
        }
    }
}