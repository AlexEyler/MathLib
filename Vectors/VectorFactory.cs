using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib {
    public partial class Vector {

        /* Create a new vector from a string input */
        public static Vector NewVector(string input) {
            List<double> newVector = new List<double>();
            int i = 0;
            while (!(input[i] == '{')) {
                if (!(input[i] == ' ')) {
                    throw new FormatException("Vector is an invalid format");
                }
                i++;
            }
            i++;

            if (i >= input.Length) {
                throw new FormatException("Vector is an invalid format");
            }
            while (input[i] != '}') {
                if (i >= input.Length) {
                    throw new FormatException("Vector is an invalid format");
                }
                // go to number
                while (input[i] == ' ') {
                    i++;
                }

                string num = "";
                // build number
                while (Char.IsNumber(input[i]) || input[i] == '.' || input[i] == '-' || input[i] == '+') {
                    num += input[i];
                    i++;
                }
                double value = -1;
                try {
                    value = Double.Parse(num);
                } catch (Exception) {
                    throw new FormatException("Vector is an invalid format");
                }
                newVector.Add(value);

                // go to next index in matrix
                while (input[i] != ',') {
                    if (input[i] == '}') {
                        i--; // we're adding to it later, but we want to stay here for now
                        break;
                    }
                    if (input[i] != ' ')
                        throw new FormatException("Vector is an invalid format");
                    i++;
                }
                i++;
            }
            return NewVector(newVector);
        }

        /* Create a new vector from a list of doubles */
        public static Vector NewVector(List<double> input) {
            return NewVector(input.ToArray());
        }

        /* Create a new vector from an array of doubles */
        public static Vector NewVector(double[] input) {
            if (input.Length == 0)
                throw new FormatException("Vector is an invalid format");
            Vector v = new Vector(input.Length);
            v.vector = input;
            return v;
        }
    }
}
