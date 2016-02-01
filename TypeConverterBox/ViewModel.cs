namespace TypeConverterBox
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private int intValue = 5;
        private Foo fooValue = new Foo(6);
        private Caster fooCaster;
        public event PropertyChangedEventHandler PropertyChanged;

        public int IntValue
        {
            get { return this.intValue; }
            set
            {
                if (value == this.intValue) return;
                this.intValue = value;
                this.OnPropertyChanged();
            }
        }

        [TypeConverter(typeof(FooConverter))]
        public Foo FooValue
        {
            get { return this.fooValue; }
            set
            {
                if (value.Equals(this.fooValue)) return;
                this.fooValue = value;
                this.OnPropertyChanged();
            }
        }

        public Caster FooCaster
        {
            get { return this.fooCaster; }
            set
            {
                if (Equals(value, this.fooCaster)) return;
                this.fooCaster = value;
                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}