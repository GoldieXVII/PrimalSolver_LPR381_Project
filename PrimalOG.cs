using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimalSolver
{
    internal class PrimalOG
    {
        public void maxOG (string [,] data)
        {
            
            string[,] constants = constFunc(data);
            double[] obj = objFunc(data);
            double[,] doubleConst = convertCosts(constants); 
            string[,] sign = getSign(constants);
            double[,] rhs = getRHS(constants);
            string[] restrictions = getRestictions(data);
        }

        public void minOG (string[,] data)
        {
            string[,] constants = constFunc(data);
            double[] obj = objFunc(data);
            double[,] doubleConst = convertCosts(constants);
            string[,] sign = getSign(constants);
            double[,] rhs = getRHS(constants);
            string[] restrictions = getRestictions(data);
        }

        private double [] objFunc(string[,] data)
        {
            double[] obj = new double[data.GetLength(1) - 1];
            for (int i = 1; i < data.GetLength(1) - 1; i++)
            {
                obj[i-1] = Convert.ToDouble(data[0, i]);
            }
            return obj;
        }

        private string [,] constFunc(string[,] data)
        {          
            if ((data.GetLength(0)-2) >= 2)
            {
                string[,] temp = new string[data.GetLength(0)-2, (data.GetLength(1))];
                for (int i = 1; i < data.GetLength(0)-1; i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        temp[i-1,j] = data[i,j];
                    }
                }
                return temp;
            }
            else
            {
                string[,] temp = new string[1, data.GetLength(1)];
                for (int i = 0; i < data.GetLength(1); i++)
                {
                    temp[0, i] = data[1,i];
                }
                return temp;
            }
        }
        
        private string[,] getSign(string [,] constraints)
        {
            if(constraints.GetLength(0) == 1)
            {
                string [,] sign = new string[1,1];
                sign[0,0] = constraints[0, (constraints.GetLength(1) - 2)];
                return sign;
            }else
            {
                string[,] sign = new string[(constraints.GetLength(0)),1];
                for (int i = 0; i < constraints.GetLength(0); i++)
                {
                    sign[i, 0] = constraints[i, constraints.GetLength(1)-2];
                }
                return sign;
            }    
        }

        private double[,] getRHS (string[,] constraints)
        {
            if (constraints.GetLength(0) == 1)
            {
                double [,] rhs = new double[1, 1];
                rhs [0, 0] = Convert.ToDouble(constraints[0, (constraints.GetLength(1) - 1)]);
                return rhs;
            }
            else
            {
                double[,] sign = new double[(constraints.GetLength(0)), 1];
                for (int i = 0; i < constraints.GetLength(0); i++)
                {
                    sign[i, 0] = Convert.ToDouble(constraints[i, constraints.GetLength(1) - 1]);
                }
                return sign;
            }
        } 

        private double[,] convertCosts(string[,] constraints)
        {
            if (constraints.GetLength(0) == 1)
            {
                double[,] temp = new double[1, constraints.GetLength(1) - 2];
                for(int i = 0;i < constraints.GetLength(1)-2;i++)
                {
                    temp[0, i] = Convert.ToDouble(constraints[0, i]);
                }
                return temp;
            }
            else
            {
                double[,] temp = new double[(constraints.GetLength(0)), constraints.GetLength(1) - 2];
                for (int i = 0; i < constraints.GetLength(0); i++)
                {
                    for (int j = 0; j < constraints.GetLength(1)-2; j++)
                    {
                        temp[i, j] = Convert.ToDouble(constraints[i, j]);
                    }
                }
                return temp;
            }
        }

        private string[] getRestictions(string[,] data)
        {
            string [] signRes = new string[data.GetLength(1) - 2];
            for(int i = 0; i< data.GetLength(1)-2; i++)
            {
                signRes[i] = data[(data.GetLength(0)-1), i];
                Console.WriteLine(signRes[i]);
            }
            return signRes;
        }

    }
}
