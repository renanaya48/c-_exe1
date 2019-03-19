using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        //members
        private readonly string name;
        public string type;
        private readonly List<FunctionsContainer.FuncToDo> listOfFunc;
        private double result;
        public event EventHandler<double> OnCalculate;

        public ComposedMission(string name1)
        {
            this.name = name1;
            this.type = "Compose";
            this.listOfFunc = new List<FunctionsContainer.FuncToDo>();
        }
        public ComposedMission Add(FunctionsContainer.FuncToDo func)
        {
            this.listOfFunc.Add(func);
            return this;
        }

        public string Name { get { return this.name; } }

        public string Type { get { return this.type; } }

        public double Calculate(double value)
        {
            this.result = value;
            foreach (FunctionsContainer.FuncToDo i in this.listOfFunc)
            {
                this.result = i(this.result);
            }
            if (this.OnCalculate != null)
            {
                OnCalculate(this, this.result);
            }

            return this.result;
            /*
            if (OnCalculate != null)
            {
                OnCalculate(this, result);
            }
            return result;
            */
        }
    }
}
