using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_continiuty_eqation
{
    class PipeSection : Calculate
    {
        public static double volumeFlow { get; set; }
        public double diameter { get; set; }
        public double flowSpeed { get; set; }
        public double sqare { get; set; }


        public void Calculate()
        {
            Console.WriteLine("In calculate method");
        }

        public double calculateVolumeFlow()
        {
            return volumeFlow = flowSpeed * sqare;
            
        }

        public double calculateSqare()
        {
            return sqare = Math.PI * Math.Pow(diameter, 2) / 4;
            
        }

        public double calculateDiameter()
        {
            return diameter = Math.Sqrt((4 * sqare / Math.PI));
        }

        public double calculatwFlowSpeed()
        {
            return flowSpeed = volumeFlow / sqare;
        }
    }
}
