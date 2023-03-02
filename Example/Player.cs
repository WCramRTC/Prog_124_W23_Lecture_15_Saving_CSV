using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_W24_Lecture_15_Saving_CSV.Example
{
    internal class Player
    {
        string _name;
        string _hp;

        public Player(string name, string hp)
        {
            _name = name;
            _hp = hp;
        }

        public Player() { }

        public string Name { get => _name; set => _name = value; }
        public string Hp { get => _hp; set => _hp = value; }

        public override string ToString()
        {
            return $"Name: {_name} - HP: {_hp}";
        }
    }
}
