namespace TypeConverterBox
{
    public class Caster
    {
        public Caster(Foo value)
        {
            this.Value = value;
        }

        public Foo Value { get; }

        public static implicit operator Caster(double value)
        {
            return new Caster(new Foo(value));
        }

        public static implicit operator double(Caster value)
        {
            return value.Value.Value;
        }

        public static implicit operator Caster(Foo value)
        {
            return new Caster(value);
        }

        public static implicit operator Foo(Caster value)
        {
            return value.Value;
        }
    }
}
