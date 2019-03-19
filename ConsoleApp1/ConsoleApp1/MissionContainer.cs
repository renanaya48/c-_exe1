using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    public class FunctionsContainer
    {
        //the delegate will hold functions that get and return double
        public delegate double FuncToDo(double nameToCal);
        //member: dictionary that will hold string and function
        private Dictionary<string, FuncToDo> funcMap;

        //constructor
        public FunctionsContainer()
        {
            this.funcMap = new Dictionary<string, FuncToDo>();
        }

        //properties
        public Dictionary<string, FuncToDo> FuncMap
        {
            get { return this.funcMap; }
            set { this.funcMap = value; }
        }

        public FuncToDo this[string str]
        {
            get
            {
                if (!funcMap.ContainsKey(str))
                {
                    this.funcMap.Add(str, value => value);
                    
                }
                return this.FuncMap[str];
            }
            set
            {
                if (!funcMap.ContainsKey(str))
                {
                    this.funcMap.Add(str, value);
                }
                else
                {
                    this.funcMap[str] = value;
                }

            }
        }




        public List<string> getAllMissions()
        {
            List<string> allMissionsList = new List<string>();
            foreach (var pair in this.funcMap)
            {
                allMissionsList.Add(pair.Key);
            }
            return allMissionsList;
        }
    }
}
