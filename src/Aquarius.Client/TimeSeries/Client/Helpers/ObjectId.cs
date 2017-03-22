using System;
using System.Globalization;

namespace Aquarius.TimeSeries.Client.Helpers
{
    /// <summary>
    /// Id of a registered object.
    /// </summary>
    public struct ObjectId : IComparable<ObjectId>
    {
        public const Int64 MinimumValidId = 1;

        private readonly Int64 _id;

        public ObjectId(Int64 id)
        {
            _id = id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object operand)
        {
            if (!(operand is ObjectId)) return false;
            var other = (ObjectId)operand;
            return _id.Equals(other._id);
        }

        public static bool operator ==(ObjectId leftOperand, ObjectId rightOperand)
        {
            return leftOperand._id == rightOperand._id;
        }

        public static bool operator !=(ObjectId leftOperand, ObjectId rightOperand)
        {
            return !(leftOperand == rightOperand);
        }

        public int CompareTo(ObjectId other)
        {
            return _id.CompareTo(other._id);
        }

        public override string ToString()
        {
            return _id.ToString(CultureInfo.InvariantCulture);
        }

        public static implicit operator Int64(ObjectId type)
        {
            return type._id;
        }

        public static implicit operator Int64?(ObjectId? type)
        {
            return type.HasValue ? type.Value._id : (Int64?)null;
        }

        public bool IsValid()
        {
            return _id >= MinimumValidId;
        }
    }
}
