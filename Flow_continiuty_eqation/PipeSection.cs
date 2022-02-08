using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_continiuty_eqation
{
    class PipeSection : Calculate
    {
        static double volumeFlow { get; set; }
        double diameter { get; set; }
        double flowSpeed { get; set; }
        double sqare { get; set; }


        public void Calculate()
        {
            Console.WriteLine("In calculate method");
        }

        void calculateVolumeFlow()
        {
            volumeFlow = flowSpeed * sqare;
            Console.WriteLine("volumeFlow = " + volumeFlow);
        }

        void calculateSqare()
        {
            sqare = Math.PI * Math.Pow(diameter, 2) / 4;
            Console.WriteLine("Sqare = " + sqare);
        }

        void calculateDiameter()
        {
            diameter = Math.Sqrt((4 * sqare / Math.PI));
        }
    }
}
