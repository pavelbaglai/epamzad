using System;
using System.Globalization;

namespace homework_7.Task1
{
    public class Customer
    {
        private string _name;
        private decimal _revenue;
        private string _contactphone;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentOutOfRangeException(nameof(Name));
                _name = value;
            }
        }

        public decimal Revenue
        {
            get
            {
                return _revenue;
            }
            set
            {
                if (value < 0 || value > Decimal.MaxValue) throw new ArgumentOutOfRangeException(nameof(Revenue)); //nameof show parameters value in details
                _revenue = value;
            }
        }

        public string ContactPhone
        {
            get
            {
                return _contactphone;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentOutOfRangeException(nameof(ContactPhone));
                _contactphone = value;
            }
        }

        public Customer(string name, decimal rev, string cphone)
        {
            Name = name;
            Revenue = rev;
            ContactPhone = cphone;
        }

        public override String ToString()
        {
            return ToString("Full");
        }

        public string ToString(string fmt)
        {
            if (String.IsNullOrEmpty(fmt))
                fmt = "Full";

            NumberFormatInfo nfi = CultureInfo.CreateSpecificCulture("en-US").NumberFormat;

            switch (fmt)
            {
                case "Full":
                    return String.Format("Customer record: {0}, {1}, {2} ", Name, Revenue.ToString("N2", nfi),ContactPhone);
                case "Phone":
                    return String.Format("Customer record: {0}", ContactPhone);
                case "NameRev":
                    return String.Format("Customer record: {0}, {1}", Name, Revenue.ToString("N2", nfi));
                case "Name":
                    return String.Format("Customer record: {0}", Revenue);
                default:
                    String msg = String.Format("'{0}' is an invalid format string",
                        fmt);
                    throw new ArgumentException(msg);
            }
        }
    }
}