using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        //members
        private readonly string name;
        private readonly string type;
        public event EventHandler<double> OnCalculate;
        private readonly FunctionsContainer.FuncToDo function;

        public SingleMission (FunctionsContainer.FuncToDo func, string name1)
        {
            this.function = func;
            this.name = name1;
            this.type = "Single";

        }

        public string Name { get { return this.name; } }
        public string Type { get { return this.type; } }


        public double Calculate(double value)
        {
            double answer = function(value);
            if (this.OnCalculate != null)
            {
                OnCalculate(this, answer);
            }

            return answer;
        }
    }
}
