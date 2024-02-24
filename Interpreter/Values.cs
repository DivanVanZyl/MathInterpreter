namespace Interpreter
{
    public class Number(double value)
    {
        private double _value = value;
        public double Value => _value;

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
